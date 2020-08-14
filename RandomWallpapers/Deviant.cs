using HtmlAgilityPack;
using ScrapySharp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RandomWallpapers
{
    class Deviant
    {
        string URl = @"https://www.deviantart.com/topic/wallpaper?page=1";
        Random rand = new Random();
        HtmlWeb web = new HtmlWeb();
        public Deviant()
        {


        }
        public Uri Serach()
        {
            HtmlNode node = web.Load(URl + $"?{rand.Next(0, 40)}").DocumentNode;
            HtmlNode[] nodes = node.CssSelect("a.[data-hook='deviation_link']").ToArray();
            string artpage = nodes[rand.Next(0, 18)].GetAttributeValue("href");
            node = web.Load(artpage).DocumentNode;
            return new Uri((node.CssSelect("[data-hook='art_stage']").ToArray().First().CssSelect("img").ToArray().First().GetAttributeValue("src")));
        }
    }
}
