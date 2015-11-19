//---------------------------------------------------------------------------
//
// <copyright file="TwitterListPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>11/17/2015 1:57:13 PM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using AppStudio.DataProviders.Twitter;
using MarkoIdzanOfficial.Sections;
using MarkoIdzanOfficial.ViewModels;

namespace MarkoIdzanOfficial.Views
{
    public sealed partial class TwitterListPage : Page
    {
        public TwitterListPage()
        {
            this.ViewModel = new ListViewModel<TwitterDataConfig, TwitterSchema>(new TwitterConfig());
            this.InitializeComponent();
        }

        public ListViewModel<TwitterDataConfig, TwitterSchema> ViewModel { get; set; }


        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await this.ViewModel.LoadDataAsync();

            base.OnNavigatedTo(e);
        }

    }
}
