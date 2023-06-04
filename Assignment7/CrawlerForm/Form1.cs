using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using assignment7;

namespace CrawlerForm
{
   

    

    public partial class Form1 : Form
    {

        public string Starturl { set; get; }
        public string Num { set; get; }
        public string HostFilter { set; get; }
        public string FileFilter { set; get; }
        public Crawler crawler = new Crawler();
        //public List<string> CurrentUrl { set; get; }
        public List<Result> results=new List<Result>();
        
        public Form1()
        {
            InitializeComponent();
            tburl.DataBindings.Add("Text", this, "Starturl");
            tbnum.DataBindings.Add("Text", this, "Num");
            tbhost.DataBindings.Add("Text", this, "HostFilter");
            tbfile.DataBindings.Add("Text", this, "FileFilter");
           
            dgvresult.DataSource = urlbindingsource;
            urlbindingsource.DataSource = results;
            crawler.LoadResult += LoadCurrenturl;
            
        }
        public void LoadCurrenturl(Crawler crawler,string s,string current)
        {
            //CurrentUrl.Add(current);
            results.Add(new Result(Starturl,s, current));
            urlbindingsource.ResetBindings(true);
            
           
        }
        
        public void Init()
        {
            
           
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
           
            
                crawler.Start(Starturl, Convert.ToInt32(Num), HostFilter, FileFilter);
            
            
            
        }
    }
    public class Result
    {
        public string StartUrl { set; get; }
        public string Res { set; get; }
        public string ResultUrl { set; get; }

        public Result(string s, string s1,string r)
        {
            StartUrl = s;
            Res = s1;
            ResultUrl = r;
        }
    }
}
