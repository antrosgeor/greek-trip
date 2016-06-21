using Bing.Maps;
using My_App2.Athens;
using System;
using System.Collections.Generic;
using Windows.ApplicationModel.DataTransfer;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace My_App2
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class firstPage : My_App2.Common.LayoutAwarePage
    {
        static List<string> kimeno = new List<string>();
        static List<string> titlos = new List<string>();
        private Geolocator geolocator;
        private Location location;
        private DataTransferManager handler = DataTransferManager.GetForCurrentView();
        public bool larisanav = false; private bool athinanav = false; private bool thesalonikinav = false; private bool volosnav = false; private bool piraiasnav = false; private bool patranav = false;

        public firstPage()
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
          
        }

        public async void position()
        {
            var coordinates = await geolocator.GetGeopositionAsync();
            geolocator.MovementThreshold = 100;
            geolocator.PositionChanged += geolocator_PositionChanged;

            location = new Location(coordinates.Coordinate.Latitude, coordinates.Coordinate.Longitude);
            myMap.SetView(location, 15);

            Pushpin pin = new Pushpin
            {
                Text = "My Position"
            };
            myMap.Children.Add(pin);
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
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            myMap.ZoomLevel = 6;
            myMap.Center = new Location(38, 22);

        }

        private void Country_Click(object sender, RoutedEventArgs e)
        {
            myMap.ZoomLevel = 6;
            myMap.Center = new Location(38, 22);
        }

        private void athens_Click(object sender, RoutedEventArgs e)
        {
            athinanav = true; larisanav = false; thesalonikinav = false; volosnav = false; piraiasnav = false; patranav = false;
            myMap.ZoomLevel = 8;
            myMap.Center = new Location(38, 24);
        }

        private void thesalonika_Click(object sender, RoutedEventArgs e)
        {
            myMap.ZoomLevel = 8;
            myMap.Center = new Location(40.5, 23);
            thesalonikinav = true; larisanav = false; athinanav = false; volosnav = false; piraiasnav = false; patranav = false;
        }

        private void larisa_Click(object sender, RoutedEventArgs e)
        {
            myMap.ZoomLevel = 9;
            myMap.Center = new Location(39.5, 22.5);
            larisanav = true; athinanav = false; thesalonikinav = false; volosnav = false; piraiasnav = false; patranav = false;
        }

        private void patra_Click(object sender, RoutedEventArgs e)
        {
            myMap.ZoomLevel = 8;
            myMap.Center = new Location(38.247361, 21.733046);
            patranav = true; larisanav = false; athinanav = false; thesalonikinav = false; volosnav = false; piraiasnav = false;
        }

        private void bolos_Click(object sender, RoutedEventArgs e)
        {
            myMap.ZoomLevel = 9;
            myMap.Center = new Location(39.364172, 22.932955);
            volosnav = true; larisanav = false; athinanav = false; thesalonikinav = false; piraiasnav = false; patranav = false;
        }

        private void piraias_Click(object sender, RoutedEventArgs e)
        {
            myMap.ZoomLevel = 11;
            myMap.Center = new Location(37.943012, 23.646395);
            piraiasnav = true; volosnav = false; larisanav = false; athinanav = false; thesalonikinav = false; patranav = false;
        }

        private void next1_Click(object sender, RoutedEventArgs e)
        {
            if (athinanav == true) this.Frame.Navigate(typeof(Athens.AthensPage1));
            if (thesalonikinav == true) this.Frame.Navigate(typeof(ThesalonikiPage1));
            if (larisanav == true) this.Frame.Navigate(typeof(Larisa.LarisaPage1));
            if (patranav == true) this.Frame.Navigate(typeof(Patra.PatraPage1));
            if (volosnav == true) this.Frame.Navigate(typeof(Bolos.BolosPage1));
            if (piraiasnav == true) this.Frame.Navigate(typeof(Piraias.PiraiasPage1));

        }

        private void my_position_Click(object sender, RoutedEventArgs e)
        {
            position();
        }

        private void cities_position_Click(object sender, RoutedEventArgs e)
        {
            Pushpin pin1 = new Pushpin
            {
                Text = "ATHENS"//3. . "Athens" 
            };
            myMap.Children.Add(pin1);
            MapLayer.SetPosition(pin1, new Location(37.976122, 23.736060));

            Pushpin pin2 = new Pushpin
            {
                Text = "THESSALONIKI"//3. . "Athens" 
            };
            myMap.Children.Add(pin2);
            MapLayer.SetPosition(pin2, new Location(40.639659, 22.936909));

            Pushpin pin3 = new Pushpin
            {
                Text = "VOLOS"//3. . "VOLOS" 
            };
            myMap.Children.Add(pin3);
            MapLayer.SetPosition(pin3, new Location(39.374258, 22.957331));

            Pushpin pin4 = new Pushpin
            {
                Text = "LARISA"//3. . "LARISA" 
            };
            myMap.Children.Add(pin4);
            MapLayer.SetPosition(pin4, new Location(39.639358, 22.420557));

            Pushpin pin5 = new Pushpin
            {
                Text = "PATRA"//3. . "PATRA" 
            };
            myMap.Children.Add(pin5);
            MapLayer.SetPosition(pin5, new Location(38.245204, 21.732359));

            Pushpin pin6 = new Pushpin
            {
                Text = "PIRAEUS"//3. . "Piraeus" 
            };
            myMap.Children.Add(pin6);
            MapLayer.SetPosition(pin6, new Location(37.943148, 23.647253));
        }
    }
}