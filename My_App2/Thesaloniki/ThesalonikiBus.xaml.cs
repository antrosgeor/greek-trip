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

namespace My_App2.Thesaloniki
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class ThesalonikiBus : My_App2.Common.LayoutAwarePage
    {
        static List<string> ores = new List<string>();
        static List<string> tilef = new List<string>();
        public ThesalonikiBus()
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

        private async void ThesalonikiBusAlexandroupoli_Click(object sender, RoutedEventArgs e)
        {
            oresTextBlock.Text = string.Empty;
            tilefonaTextBlock.Text = string.Empty;

            await File(@"/Thesaloniki/bus/Ale3anOres.txt", ores);
            foreach (string x in ores)
            {
                oresTextBlock.Text += x + Environment.NewLine;
            }

            await File(@"/Thesaloniki/bus/Ale3anTilef.txt", tilef);
            foreach (string x in tilef)
            {
                tilefonaTextBlock.Text += x + Environment.NewLine;
            }
        }

        private async void ThesalonikiBusAthens_Click(object sender, RoutedEventArgs e)
        {
            oresTextBlock.Text = string.Empty;
            tilefonaTextBlock.Text = string.Empty;

            await File(@"/Thesaloniki/bus/AthensAerosOres.txt", ores);
            foreach (string x in ores)
            {
                oresTextBlock.Text += x + Environment.NewLine;
            }

            await File(@"/Thesaloniki/bus/AthensAerosTilef.txt", tilef);
            foreach (string x in tilef)
            {
                tilefonaTextBlock.Text += x + Environment.NewLine;
            }
        }

        private async void ThesalonikiBusAthens2_Click(object sender, RoutedEventArgs e)
        {
            oresTextBlock.Text = string.Empty;
            tilefonaTextBlock.Text = string.Empty;

            await File(@"/Thesaloniki/bus/AthensKifisosOres.txt", ores);
            foreach (string x in ores)
            {
                oresTextBlock.Text += x + Environment.NewLine;
            }

            await File(@"/Thesaloniki/bus/AthensKifisosTilef.txt", tilef);
            foreach (string x in tilef)
            {
                tilefonaTextBlock.Text += x + Environment.NewLine;
            }
        }

        private async void ThesalonikiBusBolos_Click(object sender, RoutedEventArgs e)
        {
            oresTextBlock.Text = string.Empty;
            tilefonaTextBlock.Text = string.Empty;

            await File(@"/Thesaloniki/bus/BolosOres.txt", ores);
            foreach (string x in ores)
            {
                oresTextBlock.Text += x + Environment.NewLine;
            }

            await File(@"/Thesaloniki/bus/BolosTilef.txt", tilef);
            foreach (string x in tilef)
            {
                tilefonaTextBlock.Text += x + Environment.NewLine;
            }
        }

        private async void ThesalonikiBusPatra_Click(object sender, RoutedEventArgs e)
        {
            oresTextBlock.Text = string.Empty;
            tilefonaTextBlock.Text = string.Empty;

            await File(@"/Thesaloniki/bus/PatraOres.txt", ores);
            foreach (string x in ores)
            {
                oresTextBlock.Text += x + Environment.NewLine;
            }

            await File(@"/Thesaloniki/bus/PatraTilef.txt", tilef);
            foreach (string x in tilef)
            {
                tilefonaTextBlock.Text += x + Environment.NewLine;
            }
        }

        private async void ThesalonikiBusdrama_Click(object sender, RoutedEventArgs e)
        {
            oresTextBlock.Text = string.Empty;
            tilefonaTextBlock.Text = string.Empty;

            await File(@"/Thesaloniki/bus/DramaOres.txt", ores);
            foreach (string x in ores)
            {
                oresTextBlock.Text += x + Environment.NewLine;
            }

            await File(@"/Thesaloniki/bus/DramaTilef.txt", tilef);
            foreach (string x in tilef)
            {
                tilefonaTextBlock.Text += x + Environment.NewLine;
            }
        }

        private async void ThesalonikiBusgianena_Click(object sender, RoutedEventArgs e)
        {
            oresTextBlock.Text = string.Empty;
            tilefonaTextBlock.Text = string.Empty;

            await File(@"/Thesaloniki/bus/GianenaOres.txt", ores);
            foreach (string x in ores)
            {
                oresTextBlock.Text += x + Environment.NewLine;
            }

            await File(@"/Thesaloniki/bus/GianenaTilef.txt", tilef);
            foreach (string x in tilef)
            {
                tilefonaTextBlock.Text += x + Environment.NewLine;
            }
        }

        private async void ThesalonikiBuskavala_Click(object sender, RoutedEventArgs e)
        {
            oresTextBlock.Text = string.Empty;
            tilefonaTextBlock.Text = string.Empty;

            await File(@"/Thesaloniki/bus/KavalaOres.txt", ores);
            foreach (string x in ores)
            {
                oresTextBlock.Text += x + Environment.NewLine;
            }

            await File(@"/Thesaloniki/bus/KavalaTilef.txt", tilef);
            foreach (string x in tilef)
            {
                tilefonaTextBlock.Text += x + Environment.NewLine;
            }
        }

        private async void ThesalonikiBuskomotini_Click(object sender, RoutedEventArgs e)
        {
            oresTextBlock.Text = string.Empty;
            tilefonaTextBlock.Text = string.Empty;

            await File(@"/Thesaloniki/bus/KomotiniOres.txt", ores);
            foreach (string x in ores)
            {
                oresTextBlock.Text += x + Environment.NewLine;
            }

            await File(@"/Thesaloniki/bus/KomotiniTilef.txt", tilef);
            foreach (string x in tilef)
            {
                tilefonaTextBlock.Text += x + Environment.NewLine;
            }
        }

        private async void ThesalonikiBuskozani_Click(object sender, RoutedEventArgs e)
        {
            oresTextBlock.Text = string.Empty;
            tilefonaTextBlock.Text = string.Empty;

            await File(@"/Thesaloniki/bus/KozaniOres.txt", ores);
            foreach (string x in ores)
            {
                oresTextBlock.Text += x + Environment.NewLine;
            }

            await File(@"/Thesaloniki/bus/KozaniTilef.txt", tilef);
            foreach (string x in tilef)
            {
                tilefonaTextBlock.Text += x + Environment.NewLine;
            }
        }

        private async void ThesalonikiBuslamia_Click(object sender, RoutedEventArgs e)
        {
            oresTextBlock.Text = string.Empty;
            tilefonaTextBlock.Text = string.Empty;

            await File(@"/Thesaloniki/bus/LamiaOres.txt", ores);
            foreach (string x in ores)
            {
                oresTextBlock.Text += x + Environment.NewLine;
            }

            await File(@"/Thesaloniki/bus/LamiaTilef.txt", tilef);
            foreach (string x in tilef)
            {
                tilefonaTextBlock.Text += x + Environment.NewLine;
            }
        }

        private async void ThesalonikiBuslarisa_Click(object sender, RoutedEventArgs e)
        {
            oresTextBlock.Text = string.Empty;
            tilefonaTextBlock.Text = string.Empty;

            await File(@"/Thesaloniki/bus/LarisaOres.txt", ores);
            foreach (string x in ores)
            {
                oresTextBlock.Text += x + Environment.NewLine;
            }

            await File(@"/Thesaloniki/bus/LarisaTilef.txt", tilef);
            foreach (string x in tilef)
            {
                tilefonaTextBlock.Text += x + Environment.NewLine;
            }
        }

        private async void ThesalonikiBuspireas_Click(object sender, RoutedEventArgs e)
        {
            oresTextBlock.Text = string.Empty;
            tilefonaTextBlock.Text = string.Empty;

            await File(@"/Thesaloniki/bus/pireasOres.txt", ores);
            foreach (string x in ores)
            {
                oresTextBlock.Text += x + Environment.NewLine;
            }

            await File(@"/Thesaloniki/bus/pireasTilef.txt", tilef);
            foreach (string x in tilef)
            {
                tilefonaTextBlock.Text += x + Environment.NewLine;
            }
        }

        private async void ThesalonikiBusxanthi_Click(object sender, RoutedEventArgs e)
        {
            oresTextBlock.Text = string.Empty;
            tilefonaTextBlock.Text = string.Empty;

            await File(@"/Thesaloniki/bus/XanthiOres.txt", ores);
            foreach (string x in ores)
            {
                oresTextBlock.Text += x + Environment.NewLine;
            }

            await File(@"/Thesaloniki/bus/XanthiTilef.txt", tilef);
            foreach (string x in tilef)
            {
                tilefonaTextBlock.Text += x + Environment.NewLine;
            }
        }




    }
}
