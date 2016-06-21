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

namespace My_App2.Thesaloniki
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class thesrestoran : My_App2.Common.LayoutAwarePage
    {
        static List<string> kimeno = new List<string>();
        static List<string> titlos = new List<string>();
        private Geolocator geolocator;
        private Location location;
        private DataTransferManager handler = DataTransferManager.GetForCurrentView();
        public thesrestoran()
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
            thestaxi.SetView(location, 15);

            Pushpin pin = new Pushpin
            {
                Text = "ME"
            };
            thestaxi.Children.Add(pin);
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
            thestaxi.ZoomLevel = 10;
            thestaxi.Center = new Location(40.639138, 22.936737);
              //for restaurants

            if (ThesalonikiPage1.restaurant == true && ThesalonikiPage1.coffee == false)
            {
                //ekatharisis ton text
                kimenoTextBlock.Text = string.Empty;
                titlosTextBlock.Text = string.Empty;

                //efanisi tou text kimeno 
                await File(@"/Thesaloniki/restaurants.txt", kimeno);
                foreach (string x in kimeno)
                {
                    kimenoTextBlock.Text += x + Environment.NewLine;
                }

                //efanisi tou text kimeno
                await File(@"/Thesaloniki/title1.txt", titlos);
                foreach (string x in titlos)
                {
                    titlosTextBlock.Text += x + Environment.NewLine;
                }
                //efanisis ton simion

                Pushpin pin1 = new Pushpin
                {
                    Text = "1"//1. "ΤΑ ΠΟΥΛΙΑ" (Βιζύης & Βύζαντος 3 Σαράντα Εκκλησίες Θεσσαλονίκη)
                };
                thestaxi.Children.Add(pin1);
                MapLayer.SetPosition(pin1, new Location(40.642040, 22.948630));

                Pushpin pin2 = new Pushpin
                {
                    Text = "2"//2."ΚΑΜΕΝΗ ΓΩΝΙΑ"  (Λεωφόρος Βασιλίσσης Όλγας 72 Θεσσαλονίκη) 
                };
                thestaxi.Children.Add(pin2);
                MapLayer.SetPosition(pin2, new Location(40.609287, 22.953136));

                Pushpin pin3 = new Pushpin
                {
                    Text = "3"//3. . "ΤΟ ΣΤΕΚΙ ΤΟΥ ΜΠΑΚΑΛΗ" (Ν. Πλαστήρα 66 - Χαριλάου Θεσσαλονίκη)
                };
                thestaxi.Children.Add(pin3);
                MapLayer.SetPosition(pin3, new Location(40.602031, 22.979446));

                Pushpin pin4 = new Pushpin
                {
                    Text = "4"// 4. LA PLAGE MIGNONNE" (Εθνικής Αμύνης 4 Θεσσαλονίκη)
                };
                thestaxi.Children.Add(pin4);
                MapLayer.SetPosition(pin4, new Location(40.626754, 22.949501));

                Pushpin pin5 = new Pushpin
                {
                    Text = "5"//5. .  "PASTA PAZZA" (Αγγελάκη 35 Κέντρο, Θεσσαλονίκη) 
                };
                thestaxi.Children.Add(pin5);
                MapLayer.SetPosition(pin5, new Location(40.629941, 22.953199));


                Pushpin pin6 = new Pushpin
                {
                    Text = "6"//6. .  "LAZY LIZARD"  (Καλλιδοπούλου 5 Θεσσαλονίκη)
                };
                thestaxi.Children.Add(pin6);
                MapLayer.SetPosition(pin6, new Location(40.612237, 22.953563));

                Pushpin pin7 = new Pushpin
                {
                    Text = "7"//7. "MODIGLIANI"  (Κυδωνιάτου 12 Καπάνι)
                };
                thestaxi.Children.Add(pin7);
                MapLayer.SetPosition(pin7, new Location(40.635896, 22.942031));

                Pushpin pin8 = new Pushpin
                {
                    Text = "8"//8. "Ο ΧΑΜΟΔΡΑΚΑΣ" (Μανώλη Γαγύλη 13 Καλαμαριά)
                };
                thestaxi.Children.Add(pin8);
                MapLayer.SetPosition(pin8, new Location(40.572389, 22.952129));
            }

            if (ThesalonikiPage1.restaurant == false && ThesalonikiPage1.coffee == true)
            {

                //ekatharisis ton text
                kimenoTextBlock.Text = string.Empty;
                titlosTextBlock.Text = string.Empty;

                //efanisi tou text kimeno 
                await File(@"/Thesaloniki/coffee.txt", kimeno);
                foreach (string x in kimeno)
                {
                    kimenoTextBlock.Text += x + Environment.NewLine;
                }

                //efanisi tou text kimeno
                await File(@"/Thesaloniki/title2.txt", titlos);
                foreach (string x in titlos)
                {
                    titlosTextBlock.Text += x + Environment.NewLine;
                }

                //efanisis ton simion

                Pushpin pin1 = new Pushpin
                {
                    Text = "1"//1. "LAZY LIZARD" (Καλλιδοπούλου 5 )
                };
                thestaxi.Children.Add(pin1);
                MapLayer.SetPosition(pin1, new Location(40.612239, 22.953564));

                Pushpin pin2 = new Pushpin
                {
                    Text = "2"//2. "SUGARDRAFT CAFE" (Κατσιμίδη 2 )
                };
                thestaxi.Children.Add(pin2);
                MapLayer.SetPosition(pin2, new Location(40.615881, 22.960217));

                Pushpin pin3 = new Pushpin
                {
                    Text = "3"//3. "OMBRELLO" (Παλαιών Πατρών Γερμανού 24)
                };
                thestaxi.Children.Add(pin3);
                MapLayer.SetPosition(pin3, new Location(40.631391, 22.947901));

                Pushpin pin4 = new Pushpin
                {
                    Text = "4"// 4. "PLAYHOUSE" (Πρόξενου Λάμπρου Κορομηλά 3)
                };
                thestaxi.Children.Add(pin4);
                MapLayer.SetPosition(pin4, new Location(40.631816, 22.942097));

                Pushpin pin5 = new Pushpin
                {
                    Text = "5"//5. "ΚΑΦΕ ΠΡΩΤΗ" (Αετορράχης 39)
                };
                thestaxi.Children.Add(pin5);
                MapLayer.SetPosition(pin5, new Location(40.619200, 22.958902));


                Pushpin pin6 = new Pushpin
                {
                    Text = "6"//6."ΛΑΖΑΡΙΔΗΣ & ΚΑΚΑΡΗ" (Βασιλέως Ηρακλείου 4)
                };
                thestaxi.Children.Add(pin6);
                MapLayer.SetPosition(pin6, new Location(40.636675, 22.938552));

                Pushpin pin7 = new Pushpin
                {
                    Text = "7"//7. "TROTTOIR" (Λεωφόρος Νίκης 51)
                };
                thestaxi.Children.Add(pin7);
                MapLayer.SetPosition(pin7, new Location(40.629298, 22.944839));

                Pushpin pin8 = new Pushpin
                {
                    Text = "8"//8. "ELEPHANTAS" (Φιλίππου 2 )
                };
                thestaxi.Children.Add(pin8);
                MapLayer.SetPosition(pin8, new Location(40.639105, 22.941707));
            }


        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ThesalonikiPage1));
            kimenoTextBlock.Text = string.Empty;
            titlosTextBlock.Text = string.Empty;
            ThesalonikiPage1.restaurant = false;
            ThesalonikiPage1.coffee = false;
        }
    }
}
