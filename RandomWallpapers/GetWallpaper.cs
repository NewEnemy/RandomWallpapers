using HtmlAgilityPack;
using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;
using System.Drawing;
using System.Windows.Media.Imaging;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace RandomWallpapers
{
    
    class GetWallpaper
    {
        public const int SPI_SETDESKWALLPAPER = 20;
        public const int SPIF_UPDATEINIFILE = 1;
        public const int SPIF_SENDCHANGE = 2;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        public string mainWeb;

        public GetWallpaper()
        {
           
        }
        public BitmapImage CollectWallpaper(string website,string extras =null)
        {
            mainWeb = null;
            string addres = "";
            BitmapImage imageStream = null; 
           Uri finaladdres = null;
            Random rand = new Random();
            Console.WriteLine(website);
            HtmlDocument page;
            if( website == "www.reddit.com/r/wallpapers/")
            {

                Reedit R = new Reedit();
                string subreedit = "wallpaper";
                string sort = "top";
                string range = "week";
                bool random = true;
                finaladdres = R.ReeditWallpaper(subreedit, random, sort, range);

            }
            if (website == "www.DesktopNexus.com")
            {
                string[] Cat = { "abstract", "aircraft", "animals", "anime", "architecture", "boats", "cars", "entertainment", "motorcycles", "nature", "people", "space", "sports", "technology", "videogames" };
                DesktopNexus nex = new DesktopNexus();
                imageStream = DownloadImage(nex.GetWallpaper(extras));
            }
            if (website == "www.wallpapers.com") {
                int websitePage = rand.Next(1, 200);
                addres = $"http://wallpaperswide.com/top_wallpapers.html/page/{websitePage}l";
                mainWeb = "http://wallpaperswide.com/";
                page = OpenWebsite(addres);
                finaladdres = WallpapersCom(page);
            }
            if(website == "https://www.deviantart.com/topic/wallpaper")
            {
                Deviant deviant = new Deviant();
                finaladdres = deviant.Serach();
            }
            if (finaladdres != new Uri("http://google.com")&&finaladdres !=null)
            {
                imageStream = DownloadImage(finaladdres);
            }


            return imageStream;
           
            
        }
        public void ChangeWallpaper(BitmapImage wallpaper)
        {
            BitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(wallpaper));
            using (var fileStream = new System.IO.FileStream(@"f:/wallpaper.jpg", System.IO.FileMode.Create))
            {
                encoder.Save(fileStream);
            }
            SystemParametersInfo(
            SPI_SETDESKWALLPAPER, 0, "f:\\wallpaper.jpg",
            SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
        }
        private BitmapImage DownloadImage(Uri addres)
        {
            HtmlWeb web = new HtmlWeb();
            string pattern = @"(.*)\?";
            Regex regex = new Regex(pattern);
            Match new_addres =regex.Match(addres.ToString());
            using (WebClient wb = new WebClient())
            {
                try
                {
                    using (MemoryStream stream = new MemoryStream(wb.DownloadData(addres)))
                {
                    
                        BitmapImage image = new BitmapImage();
                        image.BeginInit();
                        image.CacheOption = BitmapCacheOption.OnLoad; // here
                        image.StreamSource = stream;
                        image.EndInit();
                        return image;
                  
                }
                }
                catch
                {
                    Console.WriteLine("Something  went wrong");
                    return new BitmapImage();
                }



            }
        }
        private HtmlDocument OpenWebsite(string addres)
        {
            Uri target = new Uri(addres);
            HtmlWeb browser = new HtmlWeb();
            HtmlDocument page = browser.Load(addres);
            return page;
        }

        private Uri WallpapersCom(HtmlDocument page)
        {
            Random rand = new Random();
            HtmlNode[] content = page.DocumentNode.CssSelect(".wall").ToArray();
            string imageAddres =mainWeb + content[rand.Next(1, content.Length)].CssSelect("a").ToArray()[0].GetAttributeValue("href");
            HtmlDocument websiteDownloadPage = OpenWebsite(imageAddres);
            ///---Etap 2---///
            HtmlNode[] resolutions = websiteDownloadPage.DocumentNode.CssSelect(".wallpaper-resolutions").CssSelect("a").ToArray();
            foreach(HtmlNode node in resolutions)
            {
                if (node.InnerText == "1920x1080")
                {
                    Uri wallpaperAddres = new Uri(mainWeb + node.GetAttributeValue("href"));
                    return wallpaperAddres;
                }
            }
            return new Uri("http://google.com");

        }
    }
}
