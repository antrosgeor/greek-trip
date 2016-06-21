using My_App2.Athens;
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
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace My_App2
{ 
   
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
 
    public sealed partial class MainPage : My_App2.Common.LayoutAwarePage
    {
        static List<string> staseis = new List<string>();
        static List<string> ores = new List<string>();
        static List<string> tilefona = new List<string>();

        public MainPage()
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

        private async void Athnes_Pireus_Click(object sender, RoutedEventArgs e)
        {
            await File("/Piraeus.txt", staseis);

            foreach (string x in staseis)
            {     
                staseisTextBlock.Text += x + Environment.NewLine;
            }

            await File("/PiraeusOres.txt", ores);
            foreach(string x in ores)
            {
                oresTextBlock.Text += x + Environment.NewLine;
            }

            await File("/PiraeusTilef.txt", tilefona);
            foreach(string x in tilefona)
            {
             tilefonaTextBlock.Text += x + Environment.NewLine;
            }
        }

        static async Task File(string filePath, List<string> list)
        {
            staseis.Clear();
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
       
    }
}
