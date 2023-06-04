using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrawlerForm {
    class Crawler {
        public event Action<Crawler> CrawlerStopped;
        public event Action<Crawler, string, string> PageDownloaded;
        //待下载队列
        Queue<string> pending = new Queue<string>();
        //已下载网页
        public Dictionary<string, bool> Downloaded { get; } = new Dictionary<string, bool>();

        //URL检测表达式，用于在HTML文本中查找URL
        public static readonly string UrlDetectRegex = @"(href|HREF)\s*=\s*[""'](?<url>[^""'#>]+)[""']";
        //URL解析表达式
        public static readonly string urlParseRegex = @"^(?<site>(?<protocal>https?)://(?<host>[\w\d.-]+)(:\d+)?($|/))(\w+/)*(?<file>[^#?]*)";
        //主机过滤规则
        public string HostFilter { get; set; }
        //文件过滤规则
        public string FileFilter { get; set; }
        //最大下载数量
        public int MaxPage { get; set; }
        //起始网址
        public string StartURL { get; set; }
        //网页编码
        public Encoding HtmlEncoding { get; set; }

        public Crawler() {
            MaxPage = 100;
            HtmlEncoding = Encoding.UTF8;
        }

        public void Start() {
            Downloaded.Clear();
            pending.Clear();
            pending.Enqueue(StartURL);

            while (Downloaded.Count < MaxPage && pending.Count > 0) {
                string url = pending.Dequeue();
                try {
                    string html = DownLoad(url); // 下载
                    Downloaded[url] = true;
                    PageDownloaded(this, url, "success");
                    Parse(html, url);//解析,并加入新的链接
                } catch (Exception ex) {
                    Downloaded[url] = false;
                    PageDownloaded(this, url, "  Error:" + ex.Message);
                }
            }
            CrawlerStopped(this);
        }

        private string DownLoad(string url) {
            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            string html = webClient.DownloadString(url);
            string fileName = Downloaded.Count.ToString();
            File.WriteAllText(fileName, html, Encoding.UTF8);
            return html;
        }

        private void Parse(string html, string pageUrl) {
            var matches = new Regex(UrlDetectRegex).Matches(html);
            foreach (Match match in matches) {
                string linkUrl = match.Groups["url"].Value;
                if (linkUrl == null || linkUrl == "" || linkUrl.StartsWith("javascript:")) continue;
                linkUrl = FixUrl(linkUrl, pageUrl);//转绝对路径
                                                   //解析出host和file两个部分，进行过滤
                Match linkUrlMatch = Regex.Match(linkUrl, urlParseRegex);
                string host = linkUrlMatch.Groups["host"].Value;
                string file = linkUrlMatch.Groups["file"].Value;
                if (Regex.IsMatch(host, HostFilter) && Regex.IsMatch(file, FileFilter)
                  && !Downloaded.ContainsKey(linkUrl) && !pending.Contains(linkUrl)) {
                    pending.Enqueue(linkUrl);
                }
            }
        }

        //将非完整路径转为完整路径
        static private string FixUrl(string url, string pageUrl) {
            if (url.Contains("://")) { //完整路径
                return url;
            }
            if (url.StartsWith("//")) {
                Match urlMatch = Regex.Match(pageUrl, urlParseRegex);
                string protocal = urlMatch.Groups["protocal"].Value;
                return protocal + ":" + url;
            }
            if (url.StartsWith("/")) {
                Match urlMatch = Regex.Match(pageUrl, urlParseRegex);
                String site = urlMatch.Groups["site"].Value;
                return site.EndsWith("/") ? site + url.Substring(1) : site + url;
            }

            if (url.StartsWith("../")) {
                url = url.Substring(3);
                int idx = pageUrl.LastIndexOf('/');
                return FixUrl(url, pageUrl.Substring(0, idx));
            }

            if (url.StartsWith("./")) {
                return FixUrl(url.Substring(2), pageUrl);
            }
            //非上述开头的相对路径
            int end = pageUrl.LastIndexOf("/");
            return pageUrl.Substring(0, end) + "/" + url;
        }

    }
}
