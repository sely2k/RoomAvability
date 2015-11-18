﻿namespace RoomAvability
{
    using System;
    using System.Collections.Generic;

    using Windows.UI.Xaml.Controls;
    using Windows.ApplicationModel.Activation;

    using Microsoft.ApplicationInsights;

    using Caliburn.Micro;

    using RoomAvability.Views;
    using RoomAvability.ViewModels;
    using RoomAvability.Tools.Dialogs;
    using RoomAvability.Tools.Navigation;

    public sealed partial class App
    {
        /// <summary>
        /// Allows tracking page views, exceptions and other telemetry through the Microsoft Application Insights service.
        /// </summary>
        public static TelemetryClient TelemetryClient;
        private WinRTContainer _container;

        public App()
        {
            TelemetryClient = new TelemetryClient();

            InitializeComponent();
        }

        protected override void Configure()
        {
            _container = new WinRTContainer();

            _container.RegisterWinRTServices();

            _container.PerRequest<MainPageViewModel>();

            _container.RegisterSingleton(typeof(IPageNavigationService), "IPageNavigationService", typeof(PageNavigationService));
            _container.RegisterSingleton(typeof(IUserNotificationService), "IUserNotificationService", typeof(UserNotificationService));
        }

        protected override void PrepareViewFirst(Frame rootFrame)
        {
            _container.RegisterNavigationService(rootFrame);
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            DisplayRootView<MainPageView>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}