using Fiddler;
using System;
using System.IO;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace dncAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            FiddlerApplication.oSAZProvider = new DNZSAZProvider();
            string SazDir = @"C:\Users\Roby\Desktop\SAZ";
            foreach (string file in Directory.GetFiles(SazDir,"*.saz",SearchOption.AllDirectories))
            {
                string sazPath = file;
                int tef = 0;
                Console.Write($"处理文件路径:{sazPath}");
                Session[] ssls = Utilities.ReadSessionArchive(sazPath, false);
                foreach (Session se in ssls)
                {
                    tef++;
                    var htmlDoc = new HtmlDocument();
                    //https://m.shangxueba.com/ask/1236321.html
                    if (se.uriContains("m.shangxueba.com/ask"))
                    {
                        string html = se.GetResponseBodyAsString();
                        htmlDoc.LoadHtml(html);
                    }
                    //https://www.shangxueba.com/ask/1236321.html
                    if (se.uriContains("www.shangxueba.com/ask"))
                    {

                    }
                    //https://m.shangxueba.com/ask/ask_getzuijia.aspx?=11014716
                    if (se.uriContains("shangxueba.com/ask/ask_getzuijia"))
                    {

                    }
                }
            }
            Console.WriteLine("Done!");
        }
    }
}
