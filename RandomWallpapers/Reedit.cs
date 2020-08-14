using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using ScrapySharp.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RandomWallpapers
{
    class Reedit
    {
        public Uri ReeditWallpaper(string subreedit, bool random, string sort, string range)
        {
            string home_link = "https://www.reddit.com/r/wallpapers/top/?t=all";

            //...Requestig Joson package...//
            //JObject jo = SendAndColect("",subreedit);

            return GetImageReedit(random, subreedit, range);


        }
        private JObject SendAndColect(string subreedit, string request_link)
        {
            var request = WebRequest.Create(request_link) as HttpWebRequest;
            request.UserAgent = "Mozilla/5.0";
            var Out = request.GetResponse();
            JObject jo = new JObject();

            using (StreamReader reader = new StreamReader(Out.GetResponseStream(), Encoding.ASCII))
            {
                jo = JObject.Parse(reader.ReadToEnd());
            }
            return jo;

        }
        private Uri GetImageReedit(bool random, string subreedit, string range)
        {
            string request_link = $"https://gateway.reddit.com/desktopapi/v1/subreddits/{subreedit}?rtj=only&redditWebClient=web2x&app=web2x-client-production&allow_over18=&include=identity&after=t3www&dist=10&layout=card&&sort=top&t={range}&geo_filter=PL";
            JObject jo = SendAndColect(subreedit, request_link);
            Random rand = new Random();
            string id = "";
            string link = "";
            if (random)
            {
                int page = rand.Next(0, 10);
                for (int i = 0; i < page; i++)
                {
                    id = jo["posts"].Last().Values("id").First().ToString();
                    request_link = $"https://gateway.reddit.com/desktopapi/v1/subreddits/{subreedit}?rtj=only&redditWebClient=web2x&app=web2x-client-production&allow_over18=&include=identity&after={id}&dist=10&layout=card&&sort=top&t={range}&geo_filter=PL";
                    jo = SendAndColect(subreedit, request_link);

                }
                link = jo["posts"].ToArray()[rand.Next(0, jo["posts"].ToArray().Length - 1)].Children().Values("preview").First()["url"].ToString();

            }
            else
            {
                link = jo["posts"].ToArray()[rand.Next(0, jo["posts"].ToArray().Length - 1)].Children().Values("preview").First()["url"].ToString();
            }


            return new Uri(System.Net.WebUtility.HtmlDecode(link));
        }


    }
}
