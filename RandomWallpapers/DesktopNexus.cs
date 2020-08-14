using HtmlAgilityPack;
using ScrapySharp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomWallpapers
{
    class DesktopNexus
    {
        /*

       abstract: ["3D and CG", "Collages", "Fantasy", "Fireworks", "Graffiti", "Mind Teasers", "Photography", "Textures", "Other"],
       aircraft: ["Airfields", "Antique", "Blimps", "Commercial", "Concepts", "Gliders", "Helicopters", "Hot Air Balloons", "Military", "Missiles", "Private Planes", "Other"],
       animals: ["Bears", "Birds", "Butterflies", "Cats", "Cows", "Deer", "Dinosaurs", "Dogs", "Dolphins", "Ducks", "Elephants", "Fish", "Frogs", "Giraffes", "Horses", "Kangaroos", "Primates", "Reptiles", "Rodents", "Sharks", "Sheep", "Squirrels", "Whales", "Zebras", "Other"],
       anime: ["Ah My Goddess", "Akira", "Appleseed", "Azumanga", "Beck", "Berserk", "Bleach", "Boogiepop", "Bubblegum Crisis", "Burst Angel", "Card Captor Sakura", "Chobits", "Chrono Crusade", "Cowboy Bebop", "Dead or Alive", "Digimon", "DNA", "Dragonball", "Escaflowne", "Evangelion", "Excel Saga", "Fate Stay Night", "Final Fantasy", "FLCL", "Fruits Basket", "Full Metal Alchemist", "Full Metal Panic", "Galaxy Angel", "Gantz", "Get Backers", "Ghost in the Shell", "Gundam Seed", "Gundam Wing", "Gunslinger Girl", "Hack Sign", "Haibane Renmei", "Hamtaro", "Hello Kitty", "Hellsing", "Howls Moving Castle", "Hyper Police", "Initial D", "Inuyasha", "Kanon", "Kiddy Grade", "Kimi ga Nozomu Eien", "King of Bandit", "Lain", "Last Exile", "Loki Ragnarok", "Love Hina", "Macross", "Mars", "My Neighbor Totoro", "Naruto", "Ninja Scroll", "Noir", "Onegai Teacher", "Onegai Twins", "Outlaw Star", "Paranoia Agent", "Pokemon", "Rahxephon", "Ranma", "Read or Die", "Robotech", "Rurouni Kenshin", "Sailor Moon", "Scrapped Princess", "Slayers", "Spirited Away", "Tekken", "Trigun", "Tsubasa", "Tsukihime", "Vampire Hunter D", "Vandread", "War of Genesis III", "Witch Hunter Robin", "Wonderful Days", "Yu Gi Oh", "Zoids", "Other"],
       architecture: ["Amusement Parks", "Ancient", "Bridges", "Farms", "Houses", "Lighthouses", "Medieval", "Modern", "Monuments", "Religious", "Skyscrapers", "Other"],
       boats: ["Commercial", "Competition", "Cruise Ships", "Fan Boats", "Ferryboats", "Human Powered", "Inflatables", "Military", "New Age", "Personal Boats", "Powerboats", "Sailboats", "Ship Wrecks", "Submarines", "Other"],
       cars: ["Acura", "Alfa Romeo", "Ascari", "Aston Martin", "Audi", "Bentley", "Bugatti", "Buick", "BMW", "Cadillac", "Chevrolet", "Chrysler", "Citroen", "Digital Art", "Dodge", "Ferrari", "Fiat", "Ford", "Girls and Cars", "GMC", "Honda", "Hummer", "Hyundai", "Infiniti", "Jaguar", "Jeep", "Kia", "Koenigsegg", "KTM", "Lamborghini", "Land Rover", "Lexus", "Lincoln", "Lotus", "Maserati", "Mazda", "McLaren", "Mercedes", "Mini Cooper", "Mitsubishi", "Nissan", "Oldsmobile", "Peugeot", "Plymouth", "Pontiac", "Porsche", "Renault", "Rolls Royce", "Saab", "Saturn", "Scion", "Smart", "Spyker", "Subaru", "Suzuki", "TVR", "Toyota", "Volkswagen", "Volvo", "Other"],
       entertainment: ["Bollywood", "Fashion", "Funny", "Movies", "Music", "Theater", "TV Series", "Other"],
       motorcycles: ["Aprilia", "BMW", "Buell", "Ducati", "Harley Davidson", "Honda", "Indian", "Kawasaki", "KTM", "Moto Guzzi", "MV Augusta", "Suzuki", "Triumph", "Victory", "Yamaha", "Other"],
       nature: ["Beaches", "Bugs", "Canyons", "Coral Reefs", "Deserts", "Fields", "Flowers", "Forces of Nature", "Forests", "Grass", "Greenroofs", "Lakes", "Mountains", "Oceans", "Rainbows", "Rivers", "Sky", "Sunsets", "Waterfalls", "Winter", "Other"],
       people: ["Actors", "Actresses", "Business", "Models Female", "Models Male", "Political", "Other"],
       space: ["Galaxies", "Moons", "People", "Planets", "Rockets", "Stars", "Satellites", "Shuttles", "Space Stations", "Other"],
       sports: ["Auto Racing", "Baseball", "Basketball", "Biking", "Boxing", "Cheerleading", "Dance", "Equestrian", "Fishing", "Football", "Golf", "Hockey", "Hunting", "Ice Skating", "Lacrosse", "Martial Arts", "Polo", "Skateboarding", "Skiing", "Skydiving", "Snowboarding", "Soccer", "Swimming", "Roller Blading", "Rugby", "Tennis", "Track", "Water Sports", "Weight Lifting", "Wrestling", "Other"],
       technology: ["AMD", "Apple", "ATI", "Cell Phones", "Firefox", "Gnome", "Intel", "KDE", "Keyboards", "Laptops", "Linux", "NVidia", "PDAs", "Servers", "Unix", "Windows", "Other"],
       videogames: ["Age of Conan", "Bioshock", "Castlevania", "Classic Arcade Games", "Command and Conquer", "Commandos", "Counter Strike", "Crazy Taxi", "Crysis", "Deus Ex", "Doom", "Everquest", "Final Fantasy", "Gears of War", "God of War", "Gran Turismo", "Grand Theft Auto", "Guild Wars", "Halo", "Half Life", "Handheld Devices", "Hitman", "Kingdom Hearts", "Mario", "Max Payne", "MDK", "Megaman", "Metal Gear Solid", "Metroid", "Mortal Kombat", "Nintendo Console", "Parasite Eve", "Playstation Console", "Quake", "Ragnarok Online", "Resident Evil", "Sonic", "Soul Calibur", "Starcraft", "Star Wars", "Street Fighter", "Team Fortress", "Tekken", "The Sims", "Theif", "Tomb Raider", "Unreal Tournament", "Warcraft Series", "World of Warcraft", "XBox", "Zelda", "Other"]
       */



        public DesktopNexus()
        {
        }
        public Uri GetWallpaper(string categorry)
        {
            string w = "1920";
            string h = "1080";
            string get_request = "/get_wallpaper_download_url.php ? id ={id} & w = {w} & h = {h}";
            string final_request = "";
            Uri final_link;
            Random rand = new Random();
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = new HtmlDocument();
            if (categorry != ""|| categorry !="all")
            {
                doc = web.Load("https://" + "desktopnexus.com/all" + $"/{rand.Next(0, 100)}");
            }
            else
            {
                doc = web.Load("https://" + categorry + "desktopnexus.com/all" + $"/{rand.Next(0, 100)}");
            }
            
            HtmlNode node = doc.DocumentNode;
            HtmlNode[] resoult = node.CssSelect(".rboxInner").ToArray();
            resoult = resoult.CssSelect("td").ToArray();
            string link = resoult[rand.Next(0, resoult.Length)].CssSelect("a").ToArray().First().GetAttributeValue("href");
            string[] chars = link.Split('/');
            string categ = link.Split('.').First().Remove(0, 2);
            string id = chars[chars.Length - 2];

            if (categorry == ""||categorry =="all"  ) 
            {
                 
                final_request = "https://" + categ + "." + "desktopnexus.com/" + $"/get_wallpaper_download_url.php?id={id}&w={w}&h={h}";
            }
            else
            {
                final_request = "https://" + categorry + "desktopnexus.com/" + $"/get_wallpaper_download_url.php?id={id}&w={w}&h={h}";
            }
            
            HtmlDocument response = web.Load(final_request);
            string templink = response.DocumentNode.InnerText.Split('?')[0];
            final_link = new Uri("https://" + templink.Remove(0, 2));
            return final_link;
        }

    }
}
