using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace My_App2.Patra
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class Patrainterest : My_App2.Common.LayoutAwarePage
    {
        static List<string> ores = new List<string>();
        static List<string> tilef = new List<string>();
        public Patrainterest()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {

        }
        static async Task File(string filePath, List<string> list)
        {
            ores.Clear();
            tilef.Clear();

            string path = "ms-appx://" + filePath;
            try
            {
                StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri(path));
                var lines = await FileIO.ReadLinesAsync(file);
                foreach (var itm in lines)
                {
                    list.Add(itm);
                }

            }
            catch (FileNotFoundException)
            {
            }

        }

        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            citysTextBlock.Text = string.Empty;
           

            await File(@"/Patra/interest/patras-rio-antirio-bridge1.txt", tilef);
            foreach (string x in tilef)
            {
                citysTextBlock.Text += x + Environment.NewLine;
            }
            image.Source = new BitmapImage(new Uri("ms-appx:/Patra/interest/patras-rio-antirio-bridge1.jpg", UriKind.Absolute));
        }

        private async void button1_Copy_Click(object sender, RoutedEventArgs e)
        {
            citysTextBlock.Text = string.Empty;
        

            await File(@"/Patra/interest/patras-castle2.txt", tilef);
            foreach (string x in tilef)
            {
                citysTextBlock.Text += x + Environment.NewLine;
            }
            image.Source = new BitmapImage(new Uri("ms-appx:/Patra/interest/patras-castle2.jpg", UriKind.Absolute));
        }

        private async void button1_Copy1_Click(object sender, RoutedEventArgs e)
        {
            citysTextBlock.Text = string.Empty;
          

            await File(@"/Patra/interest/patras-achaia-clauss3.txt", tilef);
            foreach (string x in tilef)
            {
                citysTextBlock.Text += x + Environment.NewLine;
            }
            image.Source = new BitmapImage(new Uri("ms-appx:/Patra/interest/patras-achaia-clauss3.jpg", UriKind.Absolute));
        }

  

        private async void button5_Click(object sender, RoutedEventArgs e)
        {
            citysTextBlock.Text = string.Empty;
        

            await File(@"/Patra/interest/patras-georgiou-square5.txt", tilef);
            foreach (string x in tilef)
            {
                citysTextBlock.Text += x + Environment.NewLine;
            }
            image.Source = new BitmapImage(new Uri("ms-appx:/Patra/interest/patras-georgiou-square5.jpg", UriKind.Absolute));
        }

        private async void button1_Copy4_Click(object sender, RoutedEventArgs e)
        {
            citysTextBlock.Text = string.Empty;
    

            await File(@"/Patra/interest/patras-agios-andreas6.txt", tilef);
            foreach (string x in tilef)
            {
                citysTextBlock.Text += x + Environment.NewLine;
            }
            image.Source = new BitmapImage(new Uri("ms-appx:/Patra/interest/patras-agios-andreas6.jpg", UriKind.Absolute));
        }

        private async void button7_Click(object sender, RoutedEventArgs e)
        {
            citysTextBlock.Text = string.Empty;
    

            await File(@"/Patra/interest/patras-archaeological-museum7.txt", tilef);
            foreach (string x in tilef)
            {
                citysTextBlock.Text += x + Environment.NewLine;
            }
            image.Source = new BitmapImage(new Uri("ms-appx:/Patra/interest/patras-archaeological-museum7.jpg", UriKind.Absolute));
        }

        private async void button8_Click(object sender, RoutedEventArgs e)
        {
            citysTextBlock.Text = string.Empty;
         

            await File(@"/Patra/interest/patras-mouseio-epistimwn-texnologias8.txt", tilef);
            foreach (string x in tilef)
            {
                citysTextBlock.Text += x + Environment.NewLine;
            }
            image.Source = new BitmapImage(new Uri("ms-appx:/Patra/interest/patras-mouseio-epistimwn-texnologias8.jpg", UriKind.Absolute));
        }

        private async void button20_Click(object sender, RoutedEventArgs e)
        {
            citysTextBlock.Text = string.Empty;

            await File(@"/Patra/interest/patra20.txt", tilef);
            foreach (string x in tilef)
            {
                citysTextBlock.Text += x + Environment.NewLine;
            }
            image.Source = new BitmapImage(new Uri("ms-appx:/Patra/interest/patras-roman-odeum4.jpg", UriKind.Absolute));

        }


     
    }
}
