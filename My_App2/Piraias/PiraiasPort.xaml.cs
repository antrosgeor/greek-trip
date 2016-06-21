using Bing.Maps;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace My_App2.Piraias
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class PiraiasPort : My_App2.Common.LayoutAwarePage
    {
        public PiraiasPort()
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
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            MapPortPiraias.ZoomLevel = 12;
            MapPortPiraias.Center = new Location(37.947796, 23.641724);
        }

        private void E1_Click(object sender, RoutedEventArgs e)
        {
            MapPortPiraias.ZoomLevel = 12;
            MapPortPiraias.Center = new Location(37.751669, 23.424541);
        }

        private void E2_Click(object sender, RoutedEventArgs e)
        {
            MapPortPiraias.ZoomLevel = 12;
            MapPortPiraias.Center = new Location(36.548389, 26.352631);
        }

        private void E3_Click(object sender, RoutedEventArgs e)
        {
            MapPortPiraias.ZoomLevel = 12;
            MapPortPiraias.Center = new Location(37.100208, 25.79509);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MapPortPiraias.ZoomLevel = 12;
            MapPortPiraias.Center = new Location(36.422058, 25.4347);
        }

        private void E5_Click(object sender, RoutedEventArgs e)
        {
            MapPortPiraias.ZoomLevel = 12;
            MapPortPiraias.Center = new Location(36.95153, 26.98543);
        }

        private void E6_Click(object sender, RoutedEventArgs e)
        {
            MapPortPiraias.ZoomLevel = 12;
            MapPortPiraias.Center = new Location(36.131855, 29.57897);
        }

        private void E7_Click(object sender, RoutedEventArgs e)
        {
            MapPortPiraias.ZoomLevel = 12;
            MapPortPiraias.Center = new Location(36.890442, 27.28931);
        }

        private void E8_Click(object sender, RoutedEventArgs e)
        {
            MapPortPiraias.ZoomLevel = 12;
            MapPortPiraias.Center = new Location(34.936073, 26.13978);
        }

        private void E9_Click(object sender, RoutedEventArgs e)
        {
            MapPortPiraias.ZoomLevel = 12;
            MapPortPiraias.Center = new Location(37.439869, 24.424669);
        }

        private void E10_Click(object sender, RoutedEventArgs e)
        {
            MapPortPiraias.ZoomLevel = 12;
            MapPortPiraias.Center = new Location(36.792339, 24.57794);
        }

        private void E11_Click(object sender, RoutedEventArgs e)
        {
            MapPortPiraias.ZoomLevel = 12;
            MapPortPiraias.Center = new Location(37.795212, 26.68067);
        }

        private void E12_Click(object sender, RoutedEventArgs e)
        {
            MapPortPiraias.ZoomLevel = 12;
            MapPortPiraias.Center = new Location(37.447209, 25.339336);
        }

        private void E13_Click(object sender, RoutedEventArgs e)
        {
            MapPortPiraias.ZoomLevel = 12;
            MapPortPiraias.Center = new Location(36.744572, 24.423639);
        }

        private void E14_Click(object sender, RoutedEventArgs e)
        {
            MapPortPiraias.ZoomLevel = 12;
            MapPortPiraias.Center = new Location(39.10585, 26.55599);
        }

        private void E15_Click(object sender, RoutedEventArgs e)
        {
            MapPortPiraias.ZoomLevel = 12;
            MapPortPiraias.Center = new Location(37.059799, 25.471172);
        }

        private void E16_Click(object sender, RoutedEventArgs e)
        {
            MapPortPiraias.ZoomLevel = 12;
            MapPortPiraias.Center = new Location(35.511959, 24.012239);
        }

        private void E17_Click(object sender, RoutedEventArgs e)
        {
            MapPortPiraias.ZoomLevel = 12;
            MapPortPiraias.Center = new Location(36.721951, 25.280649);
        }

        private void E18_Click(object sender, RoutedEventArgs e)
        {
            MapPortPiraias.ZoomLevel = 12;
            MapPortPiraias.Center = new Location(36.625801, 24.91921);
        }

        private void E19_Click(object sender, RoutedEventArgs e)
        {
            MapPortPiraias.ZoomLevel = 12;
            MapPortPiraias.Center = new Location(37.119961, 25.24114);
        }

        private void E20_Click(object sender, RoutedEventArgs e)
        {
            MapPortPiraias.ZoomLevel = 12;
            MapPortPiraias.Center = new Location(37.330746, 26.557734);
        }

        private void E21_Click(object sender, RoutedEventArgs e)
        {
            MapPortPiraias.ZoomLevel = 12;
            MapPortPiraias.Center = new Location(35.341228, 25.144211);
        }

        private void E22_Click(object sender, RoutedEventArgs e)
        {
            MapPortPiraias.ZoomLevel = 12;
            MapPortPiraias.Center = new Location(36.448139, 28.2257);
        }

        private void E23_Click(object sender, RoutedEventArgs e)
        {
            MapPortPiraias.ZoomLevel = 12;
            MapPortPiraias.Center = new Location(36.422104, 27.37175);
        }

        private void E24_Click(object sender, RoutedEventArgs e)
        {
            MapPortPiraias.ZoomLevel = 12;
            MapPortPiraias.Center = new Location(37.540939, 25.162861);
        }

        private void E25_Click(object sender, RoutedEventArgs e)
        {
            MapPortPiraias.ZoomLevel = 12;
            MapPortPiraias.Center = new Location(38.367989, 26.1385);
        }

        private void E26_Click(object sender, RoutedEventArgs e)
        {
            MapPortPiraias.ZoomLevel = 12;
            MapPortPiraias.Center = new Location(37.258808, 23.130285);
        }

        private void E27_Click(object sender, RoutedEventArgs e)
        {
            MapPortPiraias.ZoomLevel = 12;
            MapPortPiraias.Center = new Location(37.154709, 24.505369);
        }

        private void E28_Click(object sender, RoutedEventArgs e)
        {
            MapPortPiraias.ZoomLevel = 12;
            MapPortPiraias.Center = new Location(36.976418, 24.702204);
        }

        private void E29_Click(object sender, RoutedEventArgs e)
        {
            MapPortPiraias.ZoomLevel = 12;
            MapPortPiraias.Center = new Location();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(piraiasport2));
        }

        private void theport_Click(object sender, RoutedEventArgs e)
        {
            MapPortPiraias.ZoomLevel = 15;
            MapPortPiraias.Center = new Location(37.947796, 23.641724);
        }
    }
}
