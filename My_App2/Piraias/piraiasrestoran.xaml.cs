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

namespace My_App2.Piraias
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class piraiasrestoran : My_App2.Common.LayoutAwarePage
    {
        static List<string> kimeno = new List<string>();
        static List<string> titlos = new List<string>();
        private Geolocator geolocator;
        private Location location;
        private DataTransferManager handler = DataTransferManager.GetForCurrentView();
        public piraiasrestoran()
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
            piraiastaxi.SetView(location, 15);

            Pushpin pin = new Pushpin
            {
                Text = "ME"
            };
            piraiastaxi.Children.Add(pin);
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
            piraiastaxi.ZoomLevel = 11;
            piraiastaxi.Center = new Location(37.943012, 23.646395);

            if (PiraiasPage1.restaurant == true && PiraiasPage1.coffee == false)
            {
                //ekatharisis ton text
                kimenoTextBlock.Text = string.Empty;
                titlosTextBlock.Text = string.Empty;

                //efanisi tou text kimeno 
                await File(@"/Piraias/restaurants.txt", kimeno);
                foreach (string x in kimeno)
                {
                    kimenoTextBlock.Text += x + Environment.NewLine;
                }

                //efanisi tou text kimeno
                await File(@"/Piraias/title1.txt", titlos);
                foreach (string x in titlos)
                {
                    titlosTextBlock.Text += x + Environment.NewLine;
                }

                //efanisis ton simion
                Pushpin pin1 = new Pushpin
                {
                    Text = "1"//1. .  "ΚΑΠΕΤΑΝ ΒΑΣΙΛΗΣ "  (Καισαρείας 103 Νίκαια)
                };
                piraiastaxi.Children.Add(pin1);
                MapLayer.SetPosition(pin1, new Location(37.966354, 23.641940));

                Pushpin pin2 = new Pushpin
                {
                    Text = "2"//2."VOSPOROS"
                };
                piraiastaxi.Children.Add(pin2);
                MapLayer.SetPosition(pin2, new Location(37.925321, 23.743049));

                Pushpin pin3 = new Pushpin
                {
                    Text = "3"//3."ΕΛΛΑΔΙΚΟΝ" 
                };
                piraiastaxi.Children.Add(pin3);
                MapLayer.SetPosition(pin3, new Location(37.939864, 23.649926));

                Pushpin pin4 = new Pushpin
                {
                    Text = "4"//4. 4 ΑΔΕΛΦΙΑ"  
                };
                piraiastaxi.Children.Add(pin4);
                MapLayer.SetPosition(pin4, new Location(37.938829, 23.661130));

                Pushpin pin5 = new Pushpin
                {
                    Text = "5"//5. .  "ΑΜΜΟΣ
                };
                piraiastaxi.Children.Add(pin5);
                MapLayer.SetPosition(pin5, new Location(37.937716, 23.658511));


                Pushpin pin6 = new Pushpin
                {
                    Text = "6"//6.. "ΚΟΥΠΑΣ ΔΗΜ.
                };
                piraiastaxi.Children.Add(pin6);
                MapLayer.SetPosition(pin6, new Location(37.954755, 23.670090));

                Pushpin pin7 = new Pushpin
                {
                    Text = "7"//7. ΖΕΦΥΡΟΣ SEA FOOD
                };
                piraiastaxi.Children.Add(pin7);
                MapLayer.SetPosition(pin7, new Location(37.937598, 23.658551));



                Pushpin pin8 = new Pushpin
                {
                    Text = "8"//8.EL FORNO 
                };
                piraiastaxi.Children.Add(pin8);
                MapLayer.SetPosition(pin8, new Location(37.933779, 23.633793));
            }

            if (PiraiasPage1.restaurant == false && PiraiasPage1.coffee == true)
            {
                //ekatharisis ton text
                kimenoTextBlock.Text = string.Empty;
                titlosTextBlock.Text = string.Empty;

                //efanisi tou text kimeno 
                await File(@"/Piraias/Coffee.txt", kimeno);
                foreach (string x in kimeno)
                {
                    kimenoTextBlock.Text += x + Environment.NewLine;
                }

                //efanisi tou text kimeno
                await File(@"/Piraias/title2.txt", titlos);
                foreach (string x in titlos)
                {
                    titlosTextBlock.Text += x + Environment.NewLine;
                }

                //efanisis ton simion
                Pushpin pin1 = new Pushpin
                {
                    Text = "1"//1. "EPONYMO CAFE" (Πάροδος Χίου 3)
                };
                piraiastaxi.Children.Add(pin1);
                MapLayer.SetPosition(pin1, new Location(37.953950, 23.656466));

                Pushpin pin2 = new Pushpin
                {
                    Text = "2"//2."PASSAGGIO" (Αγγ. Μεταξά 17 Πασαλιμάνι)
                };
                piraiastaxi.Children.Add(pin2);
                MapLayer.SetPosition(pin2, new Location(37.938808, 23.650316));

                Pushpin pin3 = new Pushpin
                {
                    Text = "3"//3."ΜΠΕΛΙΝΟ" (Υπαπαντής 103 Πειραιάς)
                };
                piraiastaxi.Children.Add(pin3);
                MapLayer.SetPosition(pin3, new Location(37.958515, 23.629736));

                Pushpin pin4 = new Pushpin
                {
                    Text = "4"//4. "WHITE FOX" (Γιαννοπούλου 22 Πειραιάς)
                };
                piraiastaxi.Children.Add(pin4);
                MapLayer.SetPosition(pin4, new Location(37.945863, 23.669968));

                Pushpin pin5 = new Pushpin
                {
                    Text = "5"//5. "CAVALLIERO" (Αγίου Ελευθερίου 113 Πειραιάς)
                };
                piraiastaxi.Children.Add(pin5);
                MapLayer.SetPosition(pin5, new Location(37.955673, 23.661155));


                Pushpin pin6 = new Pushpin
                {
                    Text = "6"//6."BEER HOUSE STEFANIES" (Ακτή Μιαούλη 41)
                };
                piraiastaxi.Children.Add(pin6);
                MapLayer.SetPosition(pin6, new Location(37.940648, 23.641621));

                Pushpin pin7 = new Pushpin
                {
                    Text = "7"//7. "TIME" ( Παλαιολόγου Κωνσταντίνου 9)
                };
                piraiastaxi.Children.Add(pin7);
                MapLayer.SetPosition(pin7, new Location(37.940746, 23.645398));
            }

        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PiraiasPage1));
            kimenoTextBlock.Text = string.Empty;
            titlosTextBlock.Text = string.Empty;
            PiraiasPage1.restaurant = false;
            PiraiasPage1.coffee = false;
        }
    }
}