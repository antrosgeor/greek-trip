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

namespace My_App2.Athens
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class Athenstaxi : My_App2.Common.LayoutAwarePage
    {
        private Geolocator geolocator;
        private Location location;
        private DataTransferManager handler = DataTransferManager.GetForCurrentView();
        public Athenstaxi()
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

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            athenstaxi.ZoomLevel = 10;
            athenstaxi.Center = new Location(38, 24);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Pushpin pin1 = new Pushpin
            {
                Text = "1"//1. Πιάτσες Ταξί-Αττική-Ηλιούπολη / Ελευθερίου Βενιζέλου
            };
            athenstaxi.Children.Add(pin1);
            MapLayer.SetPosition(pin1, new Location(37.932667, 23.756484));

              Pushpin pin2 = new Pushpin
            {
                Text = "2"//2. Πιάτσες Ταξί-Αττική-Μαρούσι
            };
            athenstaxi.Children.Add(pin2);
            MapLayer.SetPosition(pin2, new Location(38.054747, 23.807110));
            
                Pushpin pin3 = new Pushpin
            {
                Text = "3"//3. Πιάτσες Ταξί-Αττική-Μαρούσι (Σταθμός ΗΣΑΠ)
            };
            athenstaxi.Children.Add(pin3);
            MapLayer.SetPosition(pin3, new Location(38.056231, 23.805246));
               
            Pushpin pin4 = new Pushpin
            {
                Text = "4"//4.Πιάτσες Ταξί-Αττική-Παπάγος - Στάση ΜΕΤΡΟ Εθνικής Άμυνας Κύπρου και Παράδρομος Μεσογείων
            };
            athenstaxi.Children.Add(pin4);
            MapLayer.SetPosition(pin4, new Location(37.999166, 23.784942));
            
                Pushpin pin5 = new Pushpin
            {
                Text = "5"//5. Πιάτσες Ταξί-Αττική-Πετρούπολη   Σικάγου και Αίγλης
            };
            athenstaxi.Children.Add(pin5);
            MapLayer.SetPosition(pin5, new Location(38.026436, 23.681164));
            
          
        }


    }
}
