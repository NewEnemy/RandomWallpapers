using System;
using System.Linq;
using HtmlAgilityPack;
using ScrapySharp.Network;
using ScrapySharp.Extensions;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;
namespace WebScrapp
{
    class Program
    {
        public const int SPI_SETDESKWALLPAPER = 20;
        public const int SPIF_UPDATEINIFILE = 1;
        public const int SPIF_SENDCHANGE = 2;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        static string main =  "http://wallpaperswide.com/";
        static ScrapingBrowser browser = new ScrapingBrowser();
        
        static void Main(string[] args)
        {
            Random rand = new Random();
            int websitePage = rand.Next(1, 100);
            string url_page = $"http://wallpaperswide.com/top_wallpapers.html/page/{websitePage}";
            Uri Url = new Uri(url_page);
            browser.KeepAlive = true;
            WebPage page = browser.NavigateToPage(Url);
            HtmlNode[] content = page.Html.CssSelect(".wall").ToArray();
            string randomImage = GetRandomImage(content);
            DownloadImage(randomImage);
            setWallpaper();
        }
        private static string GetRandomImage(HtmlNode[] content)
        {
            Random random = new Random();
            
            int images_on_page = content.Length;
            return main + content[random.Next(0,images_on_page)].CssSelect("a").ToArray()[0].GetAttributeValue("href");
        
        }
        static void DownloadImage(string Addres)
        {
            Uri addres = new Uri(Addres);
            WebPage page = browser.NavigateToPage(addres);
            HtmlNode content = page.Html;
            HtmlNode[] resolutions = content.CssSelect(".wallpaper-resolutions").CssSelect("a").ToArray();
            foreach(HtmlNode node in resolutions)
            {
                if (node.InnerText == "1920x1080")
                {
                   
                   Uri source_image =new Uri(main + node.GetAttributeValue("href"));
                   WebResource webResource = browser.DownloadWebResource(source_image);
                   MemoryStream stream = webResource.Content;
                   Image img = Image.FromStream(stream);
                    img.Save("f:\\wallpaper.jpg");


                }
            }
            

        }
        static void setWallpaper(){
            SystemParametersInfo(
            SPI_SETDESKWALLPAPER, 0, "f:\\wallpaper.jpg",
            SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);


        }
          

    }
}
