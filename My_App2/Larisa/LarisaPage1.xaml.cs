﻿using Bing.Maps;
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

namespace My_App2.Larisa
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class LarisaPage1 : My_App2.Common.LayoutAwarePage
    {
        public static bool restaurant = false; public static bool coffee = false;
        public LarisaPage1()
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
            LarisaMap.ZoomLevel = 9;
            LarisaMap.Center = new Location(39.5, 22.5);
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(firstPage));
        }

        private void LarisaTrain_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LarisaTrain));
        }

        private void Athensint2_Click(object sender, RoutedEventArgs e)
        {
            restaurant = true; coffee = false;
            this.Frame.Navigate(typeof(larisarestoran));
        }

        private void Athensint3_Click(object sender, RoutedEventArgs e)
        {
            restaurant = false; coffee = true;
            this.Frame.Navigate(typeof(larisarestoran));
        }

        private void LarisaBus_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LarisaBus));
        }

        private void LarisaTaxi_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LarisataxiPage1));
        }

        private void athensint1_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Larisainterest));
        }
    }
}
