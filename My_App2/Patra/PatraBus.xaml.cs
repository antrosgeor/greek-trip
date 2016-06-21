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

namespace My_App2.Patra
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class PatraBus : My_App2.Common.LayoutAwarePage
    {
        static List<string> ores = new List<string>();
        static List<string> tilef = new List<string>();

        public PatraBus()
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

        private async void PatraBusPiraias_Click(object sender, RoutedEventArgs e)
        {
            oresTextBlock.Text = string.Empty;
            tilefonaTextBlock.Text = string.Empty;
            await File(@"/Patra/bus/AthensOres.txt", ores);
            foreach (string x in ores)
            {
                oresTextBlock.Text += x + Environment.NewLine;
            }

            await File(@"/Patra/bus/AthensTilef.txt", tilef);
            foreach (string x in tilef)
            {
                tilefonaTextBlock.Text += x + Environment.NewLine;
            }
        }

        private async void PatraBusxalkida_Click(object sender, RoutedEventArgs e)
        {
            oresTextBlock.Text = string.Empty;
            tilefonaTextBlock.Text = string.Empty;
            await File(@"/Patra/bus/BolosOres.txt", ores);
            foreach (string x in ores)
            {
                oresTextBlock.Text += x + Environment.NewLine;
            }

            await File(@"/Patra/bus/BolosTilef.txt", tilef);
            foreach (string x in tilef)
            {
                tilefonaTextBlock.Text += x + Environment.NewLine;
            }
        }

        private async void PatraBusLarisa_Click(object sender, RoutedEventArgs e)
        {
            oresTextBlock.Text = string.Empty;
            tilefonaTextBlock.Text = string.Empty;
            await File(@"/Patra/bus/DelfiOres.txt", ores);
            foreach (string x in ores)
            {
                oresTextBlock.Text += x + Environment.NewLine;
            }

            await File(@"/Patra/bus/DelfiTilef.txt", tilef);
            foreach (string x in tilef)
            {
                tilefonaTextBlock.Text += x + Environment.NewLine;
            }
        }

        private async void PatraBusIoannina_Click(object sender, RoutedEventArgs e)
        {
            oresTextBlock.Text = string.Empty;
            tilefonaTextBlock.Text = string.Empty;
            await File(@"/Patra/bus/IoanninaOres.txt", ores);
            foreach (string x in ores)
            {
                oresTextBlock.Text += x + Environment.NewLine;
            }

            await File(@"/Patra/bus/IoanninaTilef.txt", tilef);
            foreach (string x in tilef)
            {
                tilefonaTextBlock.Text += x + Environment.NewLine;
            }
        }

        private async void PatraBusKarditsa_Click(object sender, RoutedEventArgs e)
        {
                    oresTextBlock.Text = string.Empty;
            tilefonaTextBlock.Text = string.Empty;
            await File(@"/Patra/bus/KarditsaOres.txt", ores);
            foreach (string x in ores)
            {
                oresTextBlock.Text += x + Environment.NewLine;
            }

            await File(@"/Patra/bus/KarditsaTilef.txt", tilef);
            foreach (string x in tilef)
            {
                tilefonaTextBlock.Text += x + Environment.NewLine;
            }
           
        }

        private async void PatraBuslamia_Click(object sender, RoutedEventArgs e)
        {
            oresTextBlock.Text = string.Empty;
            tilefonaTextBlock.Text = string.Empty;
            await File(@"/Patra/bus/LamiaOres.txt", ores);
            foreach (string x in ores)
            {
                oresTextBlock.Text += x + Environment.NewLine;
            }

            await File(@"/Patra/bus/LamiaTilef.txt", tilef);
            foreach (string x in tilef)
            {
                tilefonaTextBlock.Text += x + Environment.NewLine;
            }
        }

        private async void PatraBusthes_Click(object sender, RoutedEventArgs e)
        {
            oresTextBlock.Text = string.Empty;
            tilefonaTextBlock.Text = string.Empty;
            await File(@"/Patra/bus/ThesOres.txt", ores);
            foreach (string x in ores)
            {
                oresTextBlock.Text += x + Environment.NewLine;
            }

            await File(@"/Patra/bus/ThesTilef.txt", tilef);
            foreach (string x in tilef)
            {
                tilefonaTextBlock.Text += x + Environment.NewLine;
            }
        }

        private async void PatraBustrikala_Click(object sender, RoutedEventArgs e)
        {
            oresTextBlock.Text = string.Empty;
            tilefonaTextBlock.Text = string.Empty;
            await File(@"/Patra/bus/TrikalaOres.txt", ores);
            foreach (string x in ores)
            {
                oresTextBlock.Text += x + Environment.NewLine;
            }

            await File(@"/Patra/bus/TrikalaTilef.txt", tilef);
            foreach (string x in tilef)
            {
                tilefonaTextBlock.Text += x + Environment.NewLine;
            }
        }
    }
}
