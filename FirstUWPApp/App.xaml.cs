﻿using System;
using FilmFindService.Interfaces;
using FilmsDataAccessLayer;
using FilmsDataAccessLayer.Models;
using FirstUWPApp.Views.ViewModels;
using Ninject;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace FirstUWPApp
{
    sealed partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        private void Test()
        {
            IKernel kernel = new StandardKernel(new AppConfig.NinjectModules.FilmServiceModule());
            var a = kernel.Get<IRepository<FilmInfo>>();
            var b = kernel.Get<IFilmsService>();
            var c = kernel.Get<HomeViewModel>();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {

            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame == null)
            {
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }
                else
                {
                    Init();
                }

                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    rootFrame.Navigate(typeof(ContainerPage), e.Arguments);
                }

                Window.Current.Activate();
            }
        }

        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            deferral.Complete();
        }

        private void Init()
        {
            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<FilmFindService.Models.FilmInfoDTO, FilmsDataAccessLayer.Models.FilmInfo>());
        }
    }
}