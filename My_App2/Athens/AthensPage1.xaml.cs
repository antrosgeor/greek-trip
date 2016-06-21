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
    public sealed partial class AthensPage1 : My_App2.Common.LayoutAwarePage
    {
  
  
        private Location location;
 
        public static bool restaurant = false; public static bool coffee = false;
        public AthensPage1()
        {
            this.InitializeComponent();
;
        }


        
        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>



        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
     
        }
        protected async override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            AthensMap.ZoomLevel = 8;
            AthensMap.Center = new Location(38, 24);
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(firstPage));
        }

        private void AthensTrain_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AthensTrain));
        }

        private void AthensBus_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AthensBusPage1));
        }

        private void AthensTaxi_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Athenstaxi));
        }

        private void Athensrestorans_Click(object sender, RoutedEventArgs e)
        {
            restaurant = true;  coffee = false;
            this.Frame.Navigate(typeof(Athensrestoran));
        }

        private void Athenscofi_Click(object sender, RoutedEventArgs e)
        {
            restaurant = false; coffee = true;
            this.Frame.Navigate(typeof(Athensrestoran));
        }

        private void athensint1_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Athensinterest));
        }


    }
}
