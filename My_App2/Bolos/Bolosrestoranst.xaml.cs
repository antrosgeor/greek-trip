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

namespace My_App2.Bolos
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class Bolosrestoranst : My_App2.Common.LayoutAwarePage
    {
        static List<string> kimeno = new List<string>();
        static List<string> titlos = new List<string>();
        private Geolocator geolocator;
        private Location location;
        private DataTransferManager handler = DataTransferManager.GetForCurrentView();
        public Bolosrestoranst()
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

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected async override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            var coordinates = await geolocator.GetGeopositionAsync();
            geolocator.MovementThreshold = 100;
            geolocator.PositionChanged += geolocator_PositionChanged;

            location = new Location(coordinates.Coordinate.Latitude, coordinates.Coordinate.Longitude);
            bolostaxi.SetView(location, 15);

            Pushpin pin = new Pushpin
            {
                Text = "ME"
            };
            bolostaxi.Children.Add(pin);
            MapLayer.SetPosition(pin, location);


        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
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
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            // for tou see the athens
            bolostaxi.ZoomLevel = 9;
            bolostaxi.Center = new Location(39.364172, 22.932955);
            //for restaurants
            if (BolosPage1.restaurant == true && BolosPage1.coffee == false)
            {
                //ekatharisis ton text
                kimenoTextBlock.Text = string.Empty;
                titlosTextBlock.Text = string.Empty;

                //efanisi tou text kimeno 
                await File(@"/Bolos/restaurants.txt", kimeno);
                foreach (string x in kimeno)
                {
                    kimenoTextBlock.Text += x + Environment.NewLine;
                }

                //efanisi tou text kimeno
                await File(@"/Bolos/title1.txt", titlos);
                foreach (string x in titlos)
                {
                    titlosTextBlock.Text += x + Environment.NewLine;
                }
                //efanisis ton simion
                Pushpin pin1 = new Pushpin
                {
                    Text = "1"//1. "SVOLOS" 
                };
                bolostaxi.Children.Add(pin1);
                MapLayer.SetPosition(pin1, new Location(39.361086, 22.950051));

                Pushpin pin2 = new Pushpin
                {
                    Text = "2"//2.ΒΕΓΓΕΡΑ" 
                };
                bolostaxi.Children.Add(pin2);
                MapLayer.SetPosition(pin2, new Location(39.363190, 22.935958));

                Pushpin pin3 = new Pushpin
                {
                    Text = "3"//3. . "Ο ΧΑΛΙΑΜΠΑΛΙΑΣ" 
                };
                bolostaxi.Children.Add(pin3);
                MapLayer.SetPosition(pin3, new Location(39.359543, 22.951145));

                Pushpin pin4 = new Pushpin
                {
                    Text = "4"//4."ΑΓΓΕΛΩΝ ΓΕΥΣΕΙΣ
                };
                bolostaxi.Children.Add(pin4);
                MapLayer.SetPosition(pin4, new Location(39.363898, 22.935799));

                Pushpin pin5 = new Pushpin
                {
                    Text = "5"//5. ΜΑΡΙΝΑ
                };
                bolostaxi.Children.Add(pin5);
                MapLayer.SetPosition(pin5, new Location(39.372499, 22.935471));

                Pushpin pin6 = new Pushpin
                {
                    Text = "6"//6.ΑΧΙΛΛΕΙΟΝ
                };
                bolostaxi.Children.Add(pin6);
                MapLayer.SetPosition(pin6, new Location(39.369756, 22.945344));

                Pushpin pin7 = new Pushpin
                {
                    Text = "7"//7. ΑΛΜΗ RESTAURANT
                };
                bolostaxi.Children.Add(pin7);
                MapLayer.SetPosition(pin7, new Location(39.327766, 22.925799));

                Pushpin pin8 = new Pushpin
                {
                    Text = "8"//8.ΠΑΡΑΛΙΟ
                };
                bolostaxi.Children.Add(pin8);
                MapLayer.SetPosition(pin8, new Location(39.365537, 22.952647));
            }

            if (BolosPage1.restaurant == false && BolosPage1.coffee == true)
            {
                //ekatharisis ton text
                kimenoTextBlock.Text = string.Empty;
                titlosTextBlock.Text = string.Empty;

                //efanisi tou text kimeno 
                await File(@"/Bolos/coffee.txt", kimeno);
                foreach (string x in kimeno)
                {
                    kimenoTextBlock.Text += x + Environment.NewLine;
                }

                //efanisi tou text kimeno
                await File(@"/Bolos/title2.txt", titlos);
                foreach (string x in titlos)
                {
                    titlosTextBlock.Text += x + Environment.NewLine;
                }
                //efanisis ton simion
                Pushpin pin1 = new Pushpin
                {
                    Text = "1"//1. "SVOLOS" 
                };
                bolostaxi.Children.Add(pin1);
                MapLayer.SetPosition(pin1, new Location(39.361086, 22.950051));

                Pushpin pin2 = new Pushpin
                {
                    Text = "2"//2.ΒΕΓΓΕΡΑ" 
                };
                bolostaxi.Children.Add(pin2);
                MapLayer.SetPosition(pin2, new Location(39.363190, 22.935958));

                Pushpin pin3 = new Pushpin
                {
                    Text = "3"//3. . "Ο ΧΑΛΙΑΜΠΑΛΙΑΣ" 
                };
                bolostaxi.Children.Add(pin3);
                MapLayer.SetPosition(pin3, new Location(39.359543, 22.951145));

                Pushpin pin4 = new Pushpin
                {
                    Text = "4"//4."ΑΓΓΕΛΩΝ ΓΕΥΣΕΙΣ
                };
                bolostaxi.Children.Add(pin4);
                MapLayer.SetPosition(pin4, new Location(39.363898, 22.935799));

                Pushpin pin5 = new Pushpin
                {
                    Text = "5"//5. ΜΑΡΙΝΑ
                };
                bolostaxi.Children.Add(pin5);
                MapLayer.SetPosition(pin5, new Location(39.372499, 22.935471));

                Pushpin pin6 = new Pushpin
                {
                    Text = "6"//6.ΑΧΙΛΛΕΙΟΝ
                };
                bolostaxi.Children.Add(pin6);
                MapLayer.SetPosition(pin6, new Location(39.369756, 22.945344));

                Pushpin pin7 = new Pushpin
                {
                    Text = "7"//7. ΑΛΜΗ RESTAURANT
                };
                bolostaxi.Children.Add(pin7);
                MapLayer.SetPosition(pin7, new Location(39.327766, 22.925799));

                Pushpin pin8 = new Pushpin
                {
                    Text = "8"//8.ΠΑΡΑΛΙΟ
                };
                bolostaxi.Children.Add(pin8);
                MapLayer.SetPosition(pin8, new Location(39.365537, 22.952647));

            }
        
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BolosPage1));
            kimenoTextBlock.Text = string.Empty;
            titlosTextBlock.Text = string.Empty;
            BolosPage1.restaurant = false;
            BolosPage1.coffee = false;
        }
    }
}
