using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace assignment7
{
    class Program
    {
        static void Main(string[] args)
        {
            Crawler myCrawler = new Crawler();
           

            string startUrl = "https://www.runoob.com/regexp/regexp-syntax.html";
            myCrawler.Start(startUrl,10, @"www.runoob.com",".html");
        }
    }
}
