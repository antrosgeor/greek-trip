using Bing.Maps;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.ApplicationModel.DataTransfer;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class patrataxi : My_App2.Common.LayoutAwarePage
    {
        private Geolocator geolocator;
        private Location location;
        private DataTransferManager handler = DataTransferManager.GetForCurrentView(); 
        public patrataxi()
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
            request.Data.Properties.Title = "Eimai edw!!";
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
            patrataxi1.SetView(location, 15);

            Pushpin pin = new Pushpin
            {
                Text = "ME"
            };
            patrataxi1.Children.Add(pin);
            MapLayer.SetPosition(pin, location);



        }

        void geolocator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {

        }


        protected override void SaveState(Dictionary<String, Object> pageState)
        {
            handler.DataRequested -= handler_DataRequested;
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            patrataxi1.ZoomLevel = 10;
            patrataxi1.Center = new Location(38.245204, 21.729612);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Pushpin pin1 = new Pushpin
            {
                Text = "1"//1. Πιάτσες Ταξί-PATRA
            };
            patrataxi1.Children.Add(pin1);
            MapLayer.SetPosition(pin1, new Location(38.213077, 21.724956));

            Pushpin pin2 = new Pushpin
            {
                Text = "2"//2. Πιάτσες Ταξί-PATRA2
            };
            patrataxi1.Children.Add(pin2);
            MapLayer.SetPosition(pin2, new Location(38.249434, 21.738093));

            Pushpin pin3 = new Pushpin
            {
                Text = "3"//3. Πιάτσες Ταξί-PATRA4
            };
            patrataxi1.Children.Add(pin3);
            MapLayer.SetPosition(pin3, new Location(38.257624, 21.747084));

            Pushpin pin4 = new Pushpin
            {
                Text = "4"//4.Πιάτσες Ταξί-PATRA3
            };
            patrataxi1.Children.Add(pin4);
            MapLayer.SetPosition(pin4, new Location(38.238107, 21.745144));

            Pushpin pin5 = new Pushpin
            {
                Text = "5"//5. Πιάτσες Ταξί- PATRA15
            };
            patrataxi1.Children.Add(pin5);
            MapLayer.SetPosition(pin5, new Location(38.238014, 21.730193));
               
            Pushpin pin6 = new Pushpin
            {
                Text = "6"//6. Πιάτσες Ταξί- PATRA6
            };
            patrataxi1.Children.Add(pin6);
            MapLayer.SetPosition(pin6, new Location(38.271613, 21.745299));
               
            Pushpin pin7 = new Pushpin
            {
                Text = "7"//7. Πιάτσες Ταξί- PATRA7
            };
            patrataxi1.Children.Add(pin7);
            MapLayer.SetPosition(pin7, new Location(38.271107, 21.744827));
            
        }
    }
}


