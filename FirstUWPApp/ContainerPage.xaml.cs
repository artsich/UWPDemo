﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace FirstUWPApp
{
    // Use mvvm model, 
    // setup all value 
    // ( api service for get film, info)
    // how dinamic contains style 
    public sealed partial class ContainerPage : Page
    {
        public ContainerPage()
        {
            this.InitializeComponent();
            ChildFrame.Navigate(typeof(HomePage));
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Home.IsSelected)
            {
                ChildFrame.Navigate(typeof(HomePage));
            }
            else if (Setting.IsSelected)
            {
                ChildFrame.Navigate(typeof(SettingPage));
            }
            else if (Support.IsSelected)
            {
                ChildFrame.Navigate(typeof(SupportPage));
            }
            mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;
        }
    }
}
