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

namespace My_App2.Larisa
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class LarisaBus : My_App2.Common.LayoutAwarePage
    {
        static List<string> ores = new List<string>();
        static List<string> tilef = new List<string>();

        public LarisaBus()
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

        private async void LarisaBusAthens_Click(object sender, RoutedEventArgs e)
        {
            oresTextBlock.Text = string.Empty;
            tilefonaTextBlock.Text = string.Empty;
            await File(@"/Larisa/bus/AthensOres.txt", ores);
            foreach (string x in ores)
            {
                oresTextBlock.Text += x + Environment.NewLine;
            }

            await File(@"/Larisa/bus/AthensTilef.txt", tilef);
            foreach (string x in tilef)
            {
                tilefonaTextBlock.Text += x + Environment.NewLine;
            }
        }

        private async void LarisaBusThesaloniki_Click(object sender, RoutedEventArgs e)
        {
            oresTextBlock.Text = string.Empty;
            tilefonaTextBlock.Text = string.Empty;
            await File(@"/Larisa/bus/ThesOres.txt", ores);
            foreach (string x in ores)
            {
                oresTextBlock.Text += x + Environment.NewLine;
            }

            await File(@"/Larisa/bus/ThesTilef.txt", tilef);
            foreach (string x in tilef)
            {
                tilefonaTextBlock.Text += x + Environment.NewLine;
            }
        }

        private async void LarisaBusBolos_Click(object sender, RoutedEventArgs e)
        {
            oresTextBlock.Text = string.Empty;
            tilefonaTextBlock.Text = string.Empty;
            await File(@"/Larisa/bus/BolosOres.txt", ores);
            foreach (string x in ores)
            {
                oresTextBlock.Text += x + Environment.NewLine;
            }

            await File(@"/Larisa/bus/BolosTilef.txt", tilef);
            foreach (string x in tilef)
            {
                tilefonaTextBlock.Text += x + Environment.NewLine;
            }
        }

        private async void LarisaBusioannina_Click(object sender, RoutedEventArgs e)
        {
            oresTextBlock.Text = string.Empty;
            tilefonaTextBlock.Text = string.Empty;
            await File(@"/Larisa/bus/ioanninaOres.txt", ores);
            foreach (string x in ores)
            {
                oresTextBlock.Text += x + Environment.NewLine;
            }

            await File(@"/Larisa/bus/ioanninaTilef.txt", tilef);
            foreach (string x in tilef)
            {
                tilefonaTextBlock.Text += x + Environment.NewLine;
            }
        }

        private async void LarisaBuskomotini_Click(object sender, RoutedEventArgs e)
        {
            oresTextBlock.Text = string.Empty;
            tilefonaTextBlock.Text = string.Empty;
            await File(@"/Larisa/bus/komotiniOres.txt", ores);
            foreach (string x in ores)
            {
                oresTextBlock.Text += x + Environment.NewLine;
            }

            await File(@"/Larisa/bus/komotiniTilef.txt", tilef);
            foreach (string x in tilef)
            {
                tilefonaTextBlock.Text += x + Environment.NewLine;
            }
        }

        private async void LarisaBusalex_Click(object sender, RoutedEventArgs e)
        {
            oresTextBlock.Text = string.Empty;
            tilefonaTextBlock.Text = string.Empty;
            await File(@"/Larisa/bus/alexOres.txt", ores);
            foreach (string x in ores)
            {
                oresTextBlock.Text += x + Environment.NewLine;
            }

            await File(@"/Larisa/bus/alexTilef.txt", tilef);
            foreach (string x in tilef)
            {
                tilefonaTextBlock.Text += x + Environment.NewLine;
            }
        }

        private async void LarisaBusserres_Click(object sender, RoutedEventArgs e)
        {
            oresTextBlock.Text = string.Empty;
            tilefonaTextBlock.Text = string.Empty;
            await File(@"/Larisa/bus/serresOres.txt", ores);
            foreach (string x in ores)
            {
                oresTextBlock.Text += x + Environment.NewLine;
            }

            await File(@"/Larisa/bus/serresTilef.txt", tilef);
            foreach (string x in tilef)
            {
                tilefonaTextBlock.Text += x + Environment.NewLine;
            }
        }

    }
}
