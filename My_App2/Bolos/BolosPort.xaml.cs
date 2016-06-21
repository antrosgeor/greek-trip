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

namespace My_App2.Bolos
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class BolosPort : My_App2.Common.LayoutAwarePage
    {
        public BolosPort()
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
            MapPortBolos.ZoomLevel = 14;
            MapPortBolos.Center = new Location(39.357879, 22.942924);
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BolosPage1));
        }

        private void E1_Click(object sender, RoutedEventArgs e)
        {
            MapPortBolos.ZoomLevel = 14;
            MapPortBolos.Center = new Location(39.162009, 23.492828);
        }

        private void E2_Click(object sender, RoutedEventArgs e)
        {
            MapPortBolos.ZoomLevel = 14;
            MapPortBolos.Center = new Location(39.143352, 23.867316);
        }

        private void E3_Click(object sender, RoutedEventArgs e)
        {
            MapPortBolos.ZoomLevel = 14;
            MapPortBolos.Center = new Location(39.121233, 23.730323);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MapPortBolos.ZoomLevel = 15;
            MapPortBolos.Center = new Location(39.357775, 22.942905);
        }

    }
}
