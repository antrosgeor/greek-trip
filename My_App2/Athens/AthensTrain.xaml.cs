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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace My_App2
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class AthensTrain : My_App2.Common.LayoutAwarePage
    {
        static List<string> ores = new List<string>();
        static List<string> tilef = new List<string>();

        public AthensTrain()
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

        
    
        private async void athens_thain_xalkida_Click(object sender, RoutedEventArgs e)
        {
           
            oresTextBlock.Text = string.Empty;
            tilefonaTextBlock.Text = string.Empty;

            await File(@"/Athens/Train/XalkidaOres.txt", ores);
            foreach (string x in ores)
            {
                oresTextBlock.Text += x + Environment.NewLine;
            }

            await File(@"/Athens/Train/XalkidaTilef.txt", tilef);
            foreach (string x in tilef)
            {
                tilefonaTextBlock.Text += x + Environment.NewLine;
            }
        }



        private async void AthensTrainLarisa_Click_1(object sender, RoutedEventArgs e)
        {
            oresTextBlock.Text = string.Empty;
            tilefonaTextBlock.Text = string.Empty;
      
            await File(@"/Athens/Train/LarisaOres.txt", ores);
            foreach (string x in ores)
            {
                oresTextBlock.Text += x + Environment.NewLine;
            }

            await File(@"/Athens/Train/LarisaTilef.txt", tilef);
            foreach (string x in tilef)
            {
                tilefonaTextBlock.Text += x + Environment.NewLine;
            }
        }

        private async void AthensTrainThesaloniki_Click(object sender, RoutedEventArgs e)
        {


            oresTextBlock.Text = string.Empty;
            tilefonaTextBlock.Text = string.Empty;
       

            await File(@"/Athens/Train/ThesOres.txt", ores);
            foreach (string x in ores)
            {
                oresTextBlock.Text += x + Environment.NewLine;
            }

            await File(@"/Athens/Train/ThesTilef.txt", tilef);
            foreach (string x in tilef)
            {
                tilefonaTextBlock.Text += x + Environment.NewLine;
            }
        }


        private async void AthensTrainPlaty_Click(object sender, RoutedEventArgs e)
        {



            oresTextBlock.Text = string.Empty;
            tilefonaTextBlock.Text = string.Empty;
       
            await File(@"/Athens/Train/PlatyOres.txt", ores);
            foreach (string x in ores)
            {
                oresTextBlock.Text += x + Environment.NewLine;
            }

            await File(@"/Athens/Train/PlatyTilef.txt", tilef);
            foreach (string x in tilef)
            {
                tilefonaTextBlock.Text += x + Environment.NewLine;
            }
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

        private async void AthensTrainBolos_Click_1(object sender, RoutedEventArgs e)
        {

            oresTextBlock.Text = string.Empty;
            tilefonaTextBlock.Text = string.Empty;

            await File(@"/Athens/Train/BolosOres.txt", ores);
            foreach (string x in ores)
            {
                oresTextBlock.Text += x + Environment.NewLine;
            }

            await File(@"/Athens/Train/BolosTilef.txt", tilef);
            foreach (string x in tilef)
            {
                tilefonaTextBlock.Text += x + Environment.NewLine;
            }
           // image.Source = new BitmapImage(new Uri("ms-appx:/Athens/Train/info_port(2).jpg", UriKind.Absolute));
        }

    }
}
