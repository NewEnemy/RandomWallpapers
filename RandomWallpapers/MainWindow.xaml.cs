using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Image = System.Windows.Controls.Image;

namespace RandomWallpapers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Dictionary<string,string> Websites = new Dictionary<string, string>();
        public BitmapImage bi3 = new BitmapImage();
        public MainWindow()
        {
            InitializeComponent();
            Image icon = new Image();
            icon.Width = 20;
            icon.Height = 20;
            bi3.BeginInit();
            bi3.UriSource =new Uri(@"C:\Users\New Enemy\Desktop\Model Textures\Icon\iconsmall.png");
            bi3.EndInit();
            icon.Source = bi3;
            
            Extras.Visibility = Visibility.Hidden;
            Websites.Add("wallpapers.com", "www.wallpapers.com");
            Websites.Add("r/wallpapers", "www.reddit.com/r/wallpapers/");
            Websites.Add("DesktopNexus", "www.DesktopNexus.com");
            Websites.Add("Deviant Art", "https://www.deviantart.com/topic/wallpaper");
            Websites.Add("PlaceHolder3", "www.PlaceHolder3");
            Websites.Add("PlaceHolder4", "www.PlaceHolder4");
            foreach (KeyValuePair<string,string> entry in Websites)
            {
                WebList.Items.Add(entry.Key);
            }
            
        }
        private void WebList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           if( WebList.SelectedItem.ToString() == "DesktopNexus"){
                Extras.Visibility = Visibility.Visible;
                Extras.ItemsSource = new string[] { "all","abstract.", "aircraft.", "animals.", "anime.", "architecture.", "boats.", "cars.", "entertainment.", "motorcycles.", "nature.", "people.", "space.", "sports.", "technology.", "videogames." };

            }
            else
            {
                Extras.Visibility = Visibility.Hidden;
            }
        }

        private void Collect_Click(object sender, RoutedEventArgs e)
        {
            string extrass = "";
            if (Extras.Items.Count > 0&& Extras.SelectedItem  != null) { extrass = Extras.SelectedItem.ToString(); }
            imagePreviev.Source = new BitmapImage(new Uri(@"f:\loading.jpg"));
            Thread thread = new Thread(new ThreadStart(delegate () {

                Thread.Sleep(200);
                try
                {
                    this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Send, new Action(delegate () {

                    Console.WriteLine(Websites[WebList.SelectedItem.ToString()]);
                        GetWallpaper getW = new GetWallpaper();
                     
                    Collect.IsEnabled = true;
                        bi3 = getW.CollectWallpaper(Websites[WebList.SelectedItem.ToString()],extrass);
                        imagePreviev.Source = bi3;
                    }));
                }
                catch { }
            }));

            
            if (WebList.SelectedItem != null)
            {
                Collect.IsEnabled = false;
                Collect.Content = "Next";
                thread.Name = "GetImage";
                thread.Start();
                
                }
                
                
                

         
        }

        private void SetWallpaper_Click(object sender, RoutedEventArgs e)
        {
            if (Collect.Visibility == Visibility.Visible)
            {
                GetWallpaper getW = new GetWallpaper();
                getW.ChangeWallpaper(bi3);
            }

        }

        
    }
}
