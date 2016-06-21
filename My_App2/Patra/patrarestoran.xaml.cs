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

namespace My_App2.Patra
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class patrarestoran : My_App2.Common.LayoutAwarePage
    {
        static List<string> kimeno = new List<string>();
        static List<string> titlos = new List<string>();
        private Geolocator geolocator;
        private Location location;
        private DataTransferManager handler = DataTransferManager.GetForCurrentView();
        public patrarestoran()
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
            patrataxi.SetView(location, 15);

            Pushpin pin = new Pushpin
            {
                Text = "ME"
            };
            patrataxi.Children.Add(pin);
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
            patrataxi.ZoomLevel = 10;
            patrataxi.Center = new Location(38.245204, 21.729612);

            if (PatraPage1.restaurant == true && PatraPage1.coffee == false)
            {
                //ekatharisis ton text
                kimenoTextBlock.Text = string.Empty;
                titlosTextBlock.Text = string.Empty;

                //efanisi tou text kimeno 
                await File(@"/Patra/restaurants.txt", kimeno);
                foreach (string x in kimeno)
                {
                    kimenoTextBlock.Text += x + Environment.NewLine;
                }

                //efanisi tou text kimeno
                await File(@"/Patra/title1.txt", titlos);
                foreach (string x in titlos)
                {
                    titlosTextBlock.Text += x + Environment.NewLine;
                }

                //efanisis ton simion

                Pushpin pin1 = new Pushpin
                {
                    Text = "1"//1. "ΝΑΥΠΗΓΕΙΟ"  
                };
                patrataxi.Children.Add(pin1);
                MapLayer.SetPosition(pin1, new Location(38.188679, 21.735951));

                Pushpin pin2 = new Pushpin
                {
                    Text = "2"//2..  "ΓΛΑΥΚΟΣ" 
                };
                patrataxi.Children.Add(pin2);
                MapLayer.SetPosition(pin2, new Location(38.207346, 21.775801));

                Pushpin pin3 = new Pushpin
                {
                    Text = "3"//3. Η ΚΟΥΖΙΝΑ ΤΗΣ ΚΟΡΝΗΛΙΑΣ" 
                };
                patrataxi.Children.Add(pin3);
                MapLayer.SetPosition(pin3, new Location(38.192414, 21.708472));

                Pushpin pin4 = new Pushpin
                {
                    Text = "4"//4. . "ΤΟ ΠΑΡΑΔΟΣΙΑΚΟ ΣΤΕΚΙ
                };
                patrataxi.Children.Add(pin4);
                MapLayer.SetPosition(pin4, new Location(38.266617, 21.767304));

                Pushpin pin5 = new Pushpin
                {
                    Text = "5"//5. "ΠΛΟΥΜΠΗ ΕΛΕΥΘΕΡΙΑ
                };
                patrataxi.Children.Add(pin5);
                MapLayer.SetPosition(pin5, new Location(38.220024, 21.741367));


                Pushpin pin6 = new Pushpin
                {
                    Text = "6"//6.ΑΧΙΛΛΕΙΟΝ 
                };
                patrataxi.Children.Add(pin6);
                MapLayer.SetPosition(pin6, new Location(38.244608, 21.734263));

                Pushpin pin7 = new Pushpin
                {
                    Text = "7"//7. "ΣΙΝΙΑΛΟ
                };
                patrataxi.Children.Add(pin7);
                MapLayer.SetPosition(pin7, new Location(38.211715, 21.781209));



                Pushpin pin8 = new Pushpin
                {
                    Text = "8"//8."ΜΟΥΡΙΕΣ" 
                };
                patrataxi.Children.Add(pin8);
                MapLayer.SetPosition(pin8, new Location(38.238161, 21.744976));
            }

            if (PatraPage1.restaurant == false && PatraPage1.coffee == true)
            {
                //ekatharisis ton text
                kimenoTextBlock.Text = string.Empty;
                titlosTextBlock.Text = string.Empty;

                //efanisi tou text kimeno 
                await File(@"/Patra/Coffee.txt", kimeno);
                foreach (string x in kimeno)
                {
                    kimenoTextBlock.Text += x + Environment.NewLine;
                }

                //efanisi tou text kimeno
                await File(@"/Patra/title2.txt", titlos);
                foreach (string x in titlos)
                {
                    titlosTextBlock.Text += x + Environment.NewLine;
                }

                //efanisis ton simion

                Pushpin pin1 = new Pushpin
                {
                    Text = "1"//1. "PAS MAL" (Ηρώων Πολυτεχνείου & Κύπρου 2)
                };
                patrataxi.Children.Add(pin1);
                MapLayer.SetPosition(pin1, new Location(38.260464, 21.738869));

                Pushpin pin2 = new Pushpin
                {
                    Text = "2"//2. GALA ESPRESSO BAR" (Φιλοποίμενος 13)
                };
                patrataxi.Children.Add(pin2);
                MapLayer.SetPosition(pin2, new Location(38.245779, 21.731942));

                Pushpin pin3 = new Pushpin
                {
                    Text = "3"//3. "MOLIENTO" (Πλατεία Βασιλέως Γεωργίου Α1)
                };
                patrataxi.Children.Add(pin3);
                MapLayer.SetPosition(pin3, new Location(38.246876, 21.734617));

                Pushpin pin4 = new Pushpin
                {
                    Text = "4"//4. "SYMBOL CAFE" (Παντανάσσης 35-37)
                };
                patrataxi.Children.Add(pin4);
                MapLayer.SetPosition(pin4, new Location(38.245365, 21.733791));

                Pushpin pin5 = new Pushpin
                {
                    Text = "5"//5. "ALTROSPORTS CAFE" (Καραϊσκάκη 198 )
                };
                patrataxi.Children.Add(pin5);
                MapLayer.SetPosition(pin5, new Location(38.211703, 21.781193));


                Pushpin pin6 = new Pushpin
                {
                    Text = "6"//6. "ESPRESSO" (Φεραίου Ρήγα 42)
                };
                patrataxi.Children.Add(pin6);
                MapLayer.SetPosition(pin6, new Location(38.249589, 21.737130));

                Pushpin pin7 = new Pushpin
                {
                    Text = "7"//7. "CHRISTIE ' S"(Λεωφόρος Κορίνθου 333)
                };
                patrataxi.Children.Add(pin7);
                MapLayer.SetPosition(pin7, new Location(38.243451, 21.732386));

            }
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PatraPage1));
            kimenoTextBlock.Text = string.Empty;
            titlosTextBlock.Text = string.Empty;
            PatraPage1.restaurant = false;
            PatraPage1.coffee = false;
        }
    }
}