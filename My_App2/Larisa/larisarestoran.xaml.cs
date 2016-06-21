using Bing.Maps;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Devices.Geolocation;
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
    public sealed partial class larisarestoran : My_App2.Common.LayoutAwarePage
    {
        static List<string> kimeno = new List<string>();
        static List<string> titlos = new List<string>();
        private Geolocator geolocator;
        private Location location;
        private DataTransferManager handler = DataTransferManager.GetForCurrentView();
        public larisarestoran()
        {
            this.InitializeComponent();
            geolocator = new Geolocator
            {
                DesiredAccuracy = PositionAccuracy.High
            };
            handler.DataRequested += handler_DataRequested;
        }

         void handler_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            var request = args.Request;
            request.Data.Properties.Title = "me!!";
            request.Data.Properties.Description = "To esteila me thn tade efarmogh mou";
            request.Data.SetText(location.Latitude.ToString() + "&" + location.Longitude.ToString());
        }
        protected async override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            var coordinates = await geolocator.GetGeopositionAsync();
            geolocator.MovementThreshold = 100;
            geolocator.PositionChanged += geolocator_PositionChanged;

            location = new Location(coordinates.Coordinate.Latitude, coordinates.Coordinate.Longitude);
            larisataxi.SetView(location, 15);

            Pushpin pin = new Pushpin
            {
                Text = "ME"
            };
            larisataxi.Children.Add(pin);
            MapLayer.SetPosition(pin, location);


        }

        void geolocator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {

        }


        protected override void SaveState(Dictionary<String, Object> pageState)
        {
            handler.DataRequested -= handler_DataRequested;
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

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            // for tou see the athens
            larisataxi.ZoomLevel = 11;
            larisataxi.Center = new Location(39.639358, 22.420900);

             //for restaurants
            if (LarisaPage1.restaurant == true && LarisaPage1.coffee == false)
            {
                //ekatharisis ton text
                kimenoTextBlock.Text = string.Empty;
                titlosTextBlock.Text = string.Empty;

                //efanisi tou text kimeno 
                await File(@"/Larisa/restaurants.txt", kimeno);
                foreach (string x in kimeno)
                {
                    kimenoTextBlock.Text += x + Environment.NewLine;
                }

                //efanisi tou text kimeno
                await File(@"/Larisa/title1.txt", titlos);
                foreach (string x in titlos)
                {
                    titlosTextBlock.Text += x + Environment.NewLine;
                }

                //efanisis ton simion
                Pushpin pin1 = new Pushpin
                {
                    Text = "1"//1. Ο ΜΠΑΚΑΛΟΓΑΤΟΣ
                };
                larisataxi.Children.Add(pin1);
                MapLayer.SetPosition(pin1, new Location(39.640480, 22.416841));

                Pushpin pin2 = new Pushpin
                {
                    Text = "2"//2."ΤΑ ΚΙΤΡΙΝΑ ΓΑΝΤΙΑ" 
                };
                larisataxi.Children.Add(pin2);
                MapLayer.SetPosition(pin2, new Location(39.640429, 22.416801));

                Pushpin pin3 = new Pushpin
                {
                    Text = "3"//3. . "ΤΟ ΜΑΓΕΙΡΕΙΟ ΤΗΣ ΓΙΑΓΙΑΣ"
                };
                larisataxi.Children.Add(pin3);
                MapLayer.SetPosition(pin3, new Location(39.639572, 22.414661));

                Pushpin pin4 = new Pushpin
                {
                    Text = "4"//4.ΠΙΡΟΥΝΙΕΣ 
                };
                larisataxi.Children.Add(pin4);
                MapLayer.SetPosition(pin4, new Location(39.611112, 22.430421));

                Pushpin pin5 = new Pushpin
                {
                    Text = "5"//5. .  "ΤΟ ΣΥΝΤΡΙΒΑΝΙ" 
                };
                larisataxi.Children.Add(pin5);
                MapLayer.SetPosition(pin5, new Location(39.636543, 22.418044));


                Pushpin pin6 = new Pushpin
                {
                    Text = "6"//6."BARLEY" 
                };
                larisataxi.Children.Add(pin6);
                MapLayer.SetPosition(pin6, new Location(39.641639, 22.416739));

                Pushpin pin7 = new Pushpin
                {
                    Text = "7"//7. ΤΟ ΜΠΙΖΕΛΙ
                };
                larisataxi.Children.Add(pin7);
                MapLayer.SetPosition(pin7, new Location(39.634257, 22.425891));



                Pushpin pin8 = new Pushpin
                {
                    Text = "8"//8.ΜΕΘ΄ΗΜΩΝ
                };
                larisataxi.Children.Add(pin8);
                MapLayer.SetPosition(pin8, new Location(39.625455, 22.412773));
            }

            if (LarisaPage1.restaurant == false && LarisaPage1.coffee == true)
            {
                //ekatharisis ton text
                kimenoTextBlock.Text = string.Empty;
                titlosTextBlock.Text = string.Empty;

                //efanisi tou text kimeno 
                await File(@"/Larisa/coffee.txt", kimeno);
                foreach (string x in kimeno)
                {
                    kimenoTextBlock.Text += x + Environment.NewLine;
                }

                //efanisi tou text kimeno
                await File(@"/Larisa/title2.txt", titlos);
                foreach (string x in titlos)
                {
                    titlosTextBlock.Text += x + Environment.NewLine;
                }
           
                //efanisis ton simion
                Pushpin pin1 = new Pushpin
                {
                    Text = "1"//1. "Las Ramblas" ( Απόλλωνος 8)
                };
                larisataxi.Children.Add(pin1);
                MapLayer.SetPosition(pin1, new Location(39.639116, 22.414820));

                Pushpin pin2 = new Pushpin
                {
                    Text = "2"//2."MIKEL CAFE" (Κύπρου Πανός) 
                };
                larisataxi.Children.Add(pin2);
                MapLayer.SetPosition(pin2, new Location(39.638931, 22.416674));

                Pushpin pin3 = new Pushpin
                {
                    Text = "3"//3. "PANE D' ORO" (Ρούσβελτ Φραγκλίνου & Κύπρου)
                };
                larisataxi.Children.Add(pin3);
                MapLayer.SetPosition(pin3, new Location(39.636807, 22.417355));

                Pushpin pin4 = new Pushpin
                {
                    Text = "4"//4. "LINK " (Αγιάς 91 Λάρισα)
                };
                larisataxi.Children.Add(pin4);
                MapLayer.SetPosition(pin4, new Location(39.642103, 22.433494));

                Pushpin pin5 = new Pushpin
                {
                    Text = "5"//5."LE MOT" (Πατρόκλου 15 Λάρισα) 
                };
                larisataxi.Children.Add(pin5);
                MapLayer.SetPosition(pin5, new Location(39.636282, 22.416956));


                Pushpin pin6 = new Pushpin
                {
                    Text = "6"//6."COFFEE GALLERY" (Ιωαννίνων 72 Λάρισα)
                };
                larisataxi.Children.Add(pin6);
                MapLayer.SetPosition(pin6, new Location(39.632754, 22.400541));

                Pushpin pin7 = new Pushpin
                {
                    Text = "7"//7. "GRECO" (Πατρόκλου 4 Λάρισα)
                };
                larisataxi.Children.Add(pin7);
                MapLayer.SetPosition(pin7, new Location(39.636007, 22.415672));

            }

        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LarisaPage1));
            kimenoTextBlock.Text = string.Empty;
            titlosTextBlock.Text = string.Empty;
            LarisaPage1.restaurant = false;
            LarisaPage1.coffee = false;
        }
    }
}
