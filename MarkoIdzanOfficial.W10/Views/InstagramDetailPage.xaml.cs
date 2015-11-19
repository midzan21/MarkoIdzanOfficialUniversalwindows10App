//---------------------------------------------------------------------------
//
// <copyright file="InstagramDetailPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>11/17/2015 1:57:13 PM</createdOn>
//
//---------------------------------------------------------------------------

using System;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using AppStudio.DataProviders.Instagram;
using MarkoIdzanOfficial.Sections;
using MarkoIdzanOfficial.Services;
using MarkoIdzanOfficial.ViewModels;

namespace MarkoIdzanOfficial.Views
{
    public sealed partial class InstagramDetailPage : Page
    {
        private DataTransferManager _dataTransferManager;

        public InstagramDetailPage()
        {
            this.ViewModel = new DetailViewModel<InstagramDataConfig, InstagramSchema>(new InstagramConfig());
            this.ViewModel.SupportSlideShow = true;
            this.ViewModel.SupportFullScreen = true;

            this.InitializeComponent();
        }

        public DetailViewModel<InstagramDataConfig, InstagramSchema> ViewModel { get; set; }        

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            await this.ViewModel.LoadDataAsync(e.Parameter as ItemViewModel);

            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;
            FullScreenService.CurrentPageSupportFullScreen = true;

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _dataTransferManager.DataRequested -= OnDataRequested;
            FullScreenService.CurrentPageSupportFullScreen = false;

            base.OnNavigatedFrom(e);
        }

        private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            ViewModel.ShareContent(args.Request);
        }

        private void AppBarButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            AppBarButton button = sender as AppBarButton;
            int newFontSize = Int32.Parse(button.Tag.ToString());
            mainPanel.BodyFontSize = newFontSize;
            mainPanel.UpdateFontSize();
        }
    }
}
