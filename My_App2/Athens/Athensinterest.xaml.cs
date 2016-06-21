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

namespace My_App2.Athens
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class Athensinterest : My_App2.Common.LayoutAwarePage
    {
        static List<string> kimeno = new List<string>();
        static List<string> titlos = new List<string>();
        public Athensinterest()
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
            kimeno.Clear();
            titlos.Clear();

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
           

            await File(@"/Athens/interest/athens-acropolis-museum1.txt", kimeno);
            foreach (string x in kimeno)
            {
                citysTextBlock.Text += x + Environment.NewLine;
            }
            image.Source = new BitmapImage(new Uri("ms-appx:/Athens/interest/athens-acropolis-museum1.jpg", UriKind.Absolute));
        }

        private async void button2_Click(object sender, RoutedEventArgs e)
        {
            citysTextBlock.Text = string.Empty;

            await File(@"/Athens/interest/athens-acropolis2.txt", kimeno);
            foreach (string x in kimeno)
            {
                citysTextBlock.Text += x + Environment.NewLine;
            }
            image.Source = new BitmapImage(new Uri("ms-appx:/Athens/interest/athens-acropolis2.jpg", UriKind.Absolute));
        }

        private async void button3_Click(object sender, RoutedEventArgs e)
        {
            citysTextBlock.Text = string.Empty;


            await File(@"/Athens/interest/athens-old-town3.txt", kimeno);
            foreach (string x in kimeno)
            {
                citysTextBlock.Text += x + Environment.NewLine;
            }
            image.Source = new BitmapImage(new Uri("ms-appx:/Athens/interest/athens-old-town3.jpg", UriKind.Absolute));
        }

        private async void button4_Click(object sender, RoutedEventArgs e)
        {
            citysTextBlock.Text = string.Empty;

            await File(@"/Athens/interest/athens-roman-agora4.txt", kimeno);
            foreach (string x in kimeno)
            {
                citysTextBlock.Text += x + Environment.NewLine;
            }
            image.Source = new BitmapImage(new Uri("ms-appx:/Athens/interest/athens-roman-agora4.jpg", UriKind.Absolute));
        }

        private async void button5_Click(object sender, RoutedEventArgs e)
        {
            citysTextBlock.Text = string.Empty;


            await File(@"/Athens/interest/athens-kallimarmaro5.txt", kimeno);
            foreach (string x in kimeno)
            {
                citysTextBlock.Text += x + Environment.NewLine;
            }
            image.Source = new BitmapImage(new Uri("ms-appx:/Athens/interest/athens-kallimarmaro5.jpg", UriKind.Absolute));
        }

        private async void button6_Click(object sender, RoutedEventArgs e)
        {
            citysTextBlock.Text = string.Empty;


            await File(@"/Athens/interest/athens-syntagma6.txt", kimeno);
            foreach (string x in kimeno)
            {
                citysTextBlock.Text += x + Environment.NewLine;
            }
            image.Source = new BitmapImage(new Uri("ms-appx:/Athens/interest/athens-syntagma6.jpg", UriKind.Absolute));
        }

        private async void button7_Click(object sender, RoutedEventArgs e)
        {
            citysTextBlock.Text = string.Empty;


            await File(@"/Athens/interest/athens-archaeological7.txt", kimeno);
            foreach (string x in kimeno)
            {
                citysTextBlock.Text += x + Environment.NewLine;
            }
            image.Source = new BitmapImage(new Uri("ms-appx:/Athens/interest/athens-archaeological7.jpg", UriKind.Absolute));
        }

        private async void button8_Click(object sender, RoutedEventArgs e)
        {

            citysTextBlock.Text = string.Empty;


            await File(@"/Athens/interest/athens-archaeological8.txt", kimeno);
            foreach (string x in kimeno)
            {
                citysTextBlock.Text += x + Environment.NewLine;
            }
            image.Source = new BitmapImage(new Uri("ms-appx:/Athens/interest/athens-archaeological8.jpg", UriKind.Absolute));
        }

        private async void button9_Click(object sender, RoutedEventArgs e)
        {
            citysTextBlock.Text = string.Empty;


            await File(@"/Athens/interest/athens-war-museum9.txt", kimeno);
            foreach (string x in kimeno)
            {
                citysTextBlock.Text += x + Environment.NewLine;
            }
            image.Source = new BitmapImage(new Uri("ms-appx:/Athens/interest/athens-war-museum9.jpg", UriKind.Absolute));
        }

        private async void button10_Click(object sender, RoutedEventArgs e)
        {
            citysTextBlock.Text = string.Empty;


            await File(@"/Athens/interest/athens-marathon10.txt", kimeno);
            foreach (string x in kimeno)
            {
                citysTextBlock.Text += x + Environment.NewLine;
            }
            image.Source = new BitmapImage(new Uri("ms-appx:/Athens/interest/athens-marathon10.jpg", UriKind.Absolute));
        }

        private async void button11_Click(object sender, RoutedEventArgs e)
        {
            citysTextBlock.Text = string.Empty;

            await File(@"/Athens/interest/athens-vravronas11.txt", kimeno);
            foreach (string x in kimeno)
            {
                citysTextBlock.Text += x + Environment.NewLine;
            }
            image.Source = new BitmapImage(new Uri("ms-appx:/Athens/interest/athens-vravronas11.jpg", UriKind.Absolute));
        }
    }
}
