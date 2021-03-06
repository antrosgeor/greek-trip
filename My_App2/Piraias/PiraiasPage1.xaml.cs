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

namespace My_App2.Piraias
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class PiraiasPage1 : My_App2.Common.LayoutAwarePage
    {
        public static bool restaurant = false; public static bool coffee = false;
        public PiraiasPage1()
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
            PiraiasMap.ZoomLevel = 10;
            PiraiasMap.Center = new Location(37.8, 23.7);
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(firstPage));
        }

        private void PiraiasTrain_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PiraiasTrainPage1));
        }

        private void Athensint2_Click(object sender, RoutedEventArgs e)
        {
            restaurant = true; coffee = false;
            this.Frame.Navigate(typeof(piraiasrestoran));
        }

        private void Athensint3_Click(object sender, RoutedEventArgs e)
        {
            restaurant = false; coffee = true;
            this.Frame.Navigate(typeof(piraiasrestoran));
        }

        private void PiraiasBus_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PiraiasBus));
        }

        private void PiraiasTaxi_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Piraiastaxi));
        }

        private void Piraiasship_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PiraiasPort));
        }

        private void athensint1_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Piraiasinterest));
        }
    }
}
