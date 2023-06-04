using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Collections;
using System.Threading;

namespace assignment7
{
    public class Crawler
    {
        public event Action<Crawler,string, string> LoadResult;
        public string Hostfilter { set; get; }
        public string Filefilter { set; get; }
        public int Num { set; get; }
        public List<string> Current { get; set; }
        private Hashtable urls = new Hashtable();
        private int count = 0;
        private readonly string urlRegex = @"^(?<site>https?://(?<host>[\w.-]+)(:\d+)?($|/))(\w+/)*(?<file>[^#?]*)";
       
        public Crawler()
        {
            
        }
        public void Start(string starturl,int num,string Hostfilter,string Filefilter)
        {
            urls.Clear();
            urls.Add(starturl, false);
            this.Num = num;
            this.Hostfilter = Hostfilter;
            this.Filefilter = Filefilter;
            while(count<10)
            {
                Crawl();
            }
            
        }

        private void Crawl()
        {
            Console.WriteLine("开始爬行了...");
            while(true)
            {
                string current = null;
                foreach(string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;//已经爬行
                    current = url;
                }
                if (current == null || count > Num) break;
                System.Console.WriteLine(current);
                Console.WriteLine("爬行" + current + "页面！");
                
                string html = Download(current);
                //哈希表值设为1，表示已爬行
                urls[current] = true;
                LoadResult(this,"success", current);
                //已爬行网页数目加一
                count++;

                Parse(html,current);//加入子超链接
            }
            Console.WriteLine("爬行结束");
        }

        //给定网址，读出html
        public string Download(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);//从url中读取字符串到html中
                string filename = @"D:\Giselle\大二下\软构\assignment7\"+count.ToString()+".txt";//第几个文件
                File.WriteAllText(filename, html, Encoding.UTF8);
                return html;//返回从网页中读取的字符串
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                LoadResult(this,"defeat", ex.Message);
                return "";
            }
        }

        //解析内容，用正则表达式得到其中的超级链接href，
        //将超级链接放入哈希表
        public void Parse(string html, string upperurl)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'](?<url>[^""'#>]+)[""']";
            //读取html中的超链接
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                //转相对路径为完整地址
                string url = match.Groups["url"].Value;
                if (url == null || url == "") continue;
                url = Transform(url, upperurl);
                //爬取指定网站
                Match urlmatch = Regex.Match(url, urlRegex);
                string host = urlmatch.Groups["host"].Value;
                string file = urlmatch.Groups["file"].Value;
                
                if((file.EndsWith(Filefilter))&&Regex.IsMatch(host,Hostfilter))
                {
                    if(urls[url]==null)
                    {
                        urls[url] = false;
                    }
                }
            }

        }

        //将相对地址转换为完整地址
        public string Transform(string url,string upperurl)
        {
            
            if (url.Contains("://"))
            {
                return url;
            }
            //根路径
            if(url.StartsWith("/"))
            {
                //找上一级url中的根路径
                Match match = Regex.Match(upperurl, urlRegex);
                string site = match.Groups["site"].Value;
                return site.EndsWith("/") ? site + url.Substring(1) : site + url;
            }
            //上一层目录
            if(url.StartsWith("../"))
            {
                url = url.Substring(3);
                //上一层目录结束位置
                int index = upperurl.LastIndexOf('/');
                return Transform(url, upperurl.Substring(0, index));
            }
            //当前目录
            if(url.StartsWith("./"))
            {
                return Transform(url.Substring(2), upperurl);
            }
            if(url.StartsWith("//"))
            {
                return "http" + url;
            }
            int endindex = upperurl.LastIndexOf("/");
            return upperurl.Substring(0, endindex) + "/" + url;
        }
    }
}
