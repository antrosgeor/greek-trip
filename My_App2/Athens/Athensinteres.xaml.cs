using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace My_App2.Athens
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class BasicPage1 : My_App2.Common.LayoutAwarePage
    {
        private static List<string> ores = new List<string>();
        private static List<string> tilef = new List<string>();

        public BasicPage1()
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

        private static async Task File(string filePath, List<string> list)
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

        private async void AthensBusMesologi_Click(object sender, RoutedEventArgs e)
        {
            citysTextBlock.Text = string.Empty;
            nameTextBlock.Text = string.Empty;

            await File(@"/Athens/Train/BolosOres.txt", ores);
            foreach (string x in ores)
            {
                nameTextBlock.Text += x + Environment.NewLine;
            }

            await File(@"/Athens/Train/BolosTilef.txt", tilef);
            foreach (string x in tilef)
            {
                citysTextBlock.Text += x + Environment.NewLine;
            }
            image.Source = new BitmapImage(new Uri("ms-appx:/Athens/Train/info_port(2).jpg", UriKind.Absolute));
        }
    }
}

// image.Source = new BitmapImage(new Uri("ms-appx:/Athens/Train/info_port(2).jpg", UriKind.Absolute));