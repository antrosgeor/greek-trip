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

namespace My_App2.Athens
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class Athensrestoran : My_App2.Common.LayoutAwarePage
    {
        static List<string> kimeno = new List<string>();
        static List<string> titlos = new List<string>();
        private Geolocator geolocator;
        private Location location;
        private DataTransferManager handler = DataTransferManager.GetForCurrentView();
        public Athensrestoran()
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
            athenstaxi.SetView(location, 15);

            Pushpin pin = new Pushpin
            {
                Text = "ME"
            };
            athenstaxi.Children.Add(pin);
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
            athenstaxi.ZoomLevel = 10;
            athenstaxi.Center = new Location(38, 24);
            
            //for restaurants
            if (AthensPage1.restaurant == true && AthensPage1.coffee == false)
            {
                //ekatharisis ton text
                kimenoTextBlock.Text = string.Empty;
                titlosTextBlock.Text = string.Empty;

                //efanisi tou text kimeno 
                await File(@"/Athens/restaurants.txt", kimeno);
                foreach (string x in kimeno)
                {
                    kimenoTextBlock.Text += x + Environment.NewLine;
                }
                
                //efanisi tou text kimeno
                await File(@"/Athens/title1.txt", titlos);
                foreach (string x in titlos)
                {
                    titlosTextBlock.Text += x + Environment.NewLine;
                }
                //efanisis ton simion
                 Pushpin pin1 = new Pushpin
                    {
                        Text = "1"//1. ΘΕΣΣΑΛΙΑ
                    };
                    athenstaxi.Children.Add(pin1);
                    MapLayer.SetPosition(pin1, new Location(38.088920, 23.798313));

                Pushpin pin2 = new Pushpin
                    {
                        Text = "2"//2.'ΣΟΥΦΑΛΑ
                    };
                    athenstaxi.Children.Add(pin2);
                    MapLayer.SetPosition(pin2, new Location(37.993672, 23.764690));

                Pushpin pin3 = new Pushpin
                    {
                        Text = "3"//3. 50-50
                    };
                    athenstaxi.Children.Add(pin3);
                    MapLayer.SetPosition(pin3, new Location(37.860602, 23.750918));

                 Pushpin pin4 = new Pushpin
                    {
                        Text = "4"//4. ΓΚΟΥΓΚΟΥ ΜΕΖΕ
                    };
                    athenstaxi.Children.Add(pin4);
                    MapLayer.SetPosition(pin4, new Location(37.911735, 23.710471));

                Pushpin pin5 = new Pushpin
                    {
                        Text = "5"//5. fatsio
                    };
                    athenstaxi.Children.Add(pin5);
                    MapLayer.SetPosition(pin5, new Location(37.973138, 23.747387));
            
                    Pushpin pin6 = new Pushpin
                    {
                        Text = "6"//6.FISH ΑΛΙΔΑ
                    };
                    athenstaxi.Children.Add(pin6);
                    MapLayer.SetPosition(pin6, new Location(37.973500, 23.750799));
            
                 Pushpin pin7 = new Pushpin
                    {
                       Text = "7"//7. FU-RIN-KA-ZAN.
                    };
                    athenstaxi.Children.Add(pin7);
                    MapLayer.SetPosition(pin7, new Location(37.974843, 23.732954));

                  Pushpin pin8 = new Pushpin
                    {
                        Text = "8"//8.ΠΛΑΚΙΩΤΙΣΣΑ
                    };
                    athenstaxi.Children.Add(pin8);
                    MapLayer.SetPosition(pin8, new Location(37.969570, 23.730701));
            }

            if (AthensPage1.restaurant == false && AthensPage1.coffee == true)
            {
                //ekatharisis ton text
                kimenoTextBlock.Text = string.Empty;
                titlosTextBlock.Text = string.Empty;

                //efanisi tou text kimeno 
                await File(@"/Athens/coffee.txt", kimeno);
                foreach (string x in kimeno)
                {
                    kimenoTextBlock.Text += x + Environment.NewLine;
                }

                //efanisi tou text kimeno
                await File(@"/Athens/title2.txt", titlos);
                foreach (string x in titlos)
                {
                    titlosTextBlock.Text += x + Environment.NewLine;
                }
                //efanisis ton simion
                Pushpin pin1 = new Pushpin
                {
                    Text = "1"//1."CAFE PEROS" (Τσακάλωφ 2 Αθήνα)
                };
                athenstaxi.Children.Add(pin1);
                MapLayer.SetPosition(pin1, new Location(37.977550, 23.741081));

                Pushpin pin2 = new Pushpin
                {
                    Text = "2"//2."FLOCAFE" (Λεωφόρος Αλεξάνδρας 221 Αθήνα)
                };
                athenstaxi.Children.Add(pin2);
                MapLayer.SetPosition(pin2, new Location(37.986879, 23.760235));

                Pushpin pin3 = new Pushpin
                {
                    Text = "3"//"EL VINO" (Σκουφά 47-49 Αθήνα)
                };
                athenstaxi.Children.Add(pin3);
                MapLayer.SetPosition(pin3, new Location(37.980082, 23.738237));

                Pushpin pin4 = new Pushpin
                {
                    Text = "4"//4. "OSTRIA" (Οικονόμου 4-6 Εξάρχεια)
                };
                athenstaxi.Children.Add(pin4);
                MapLayer.SetPosition(pin4, new Location(37.986942, 23.735611));

                Pushpin pin5 = new Pushpin
                {
                    Text = "5"//5."JACKSON HALL" (Μηλιώνη 4 Αθήνα)
                };
                athenstaxi.Children.Add(pin5);
                MapLayer.SetPosition(pin5, new Location(37.977298, 23.739840));

                Pushpin pin6 = new Pushpin
                {
                    Text = "6"//6."POQUITO CAFE" (Υμηττού 93 Παγκράτι)
                };
                athenstaxi.Children.Add(pin6);
                MapLayer.SetPosition(pin6, new Location(37.967962, 23.750937));

                Pushpin pin7 = new Pushpin
                {
                    Text = "7"//7. "OASIS ΖΑΠΠΕΙΟΥ" (Λεωφόρος Βασιλίσσης Αμαλίας)
                };
                athenstaxi.Children.Add(pin7);
                MapLayer.SetPosition(pin7, new Location(37.972594, 23.734548));

                Pushpin pin8 = new Pushpin
                {
                    Text = "8"//8."SOHO" (Βουτάδων 54Β Αθήνα)
                };
                athenstaxi.Children.Add(pin8);
                MapLayer.SetPosition(pin8, new Location(37.978685, 23.713010));
            }
         
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AthensPage1));
            kimenoTextBlock.Text = string.Empty;
            titlosTextBlock.Text = string.Empty;
            AthensPage1.restaurant = false;
            AthensPage1.coffee = false;
        }
    }
}
