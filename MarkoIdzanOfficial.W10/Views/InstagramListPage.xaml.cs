//---------------------------------------------------------------------------
//
// <copyright file="InstagramListPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>11/17/2015 1:57:13 PM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using AppStudio.DataProviders.Instagram;
using MarkoIdzanOfficial.Sections;
using MarkoIdzanOfficial.ViewModels;

namespace MarkoIdzanOfficial.Views
{
    public sealed partial class InstagramListPage : Page
    {
        public InstagramListPage()
        {
            this.ViewModel = new ListViewModel<InstagramDataConfig, InstagramSchema>(new InstagramConfig());
            this.InitializeComponent();
        }

        public ListViewModel<InstagramDataConfig, InstagramSchema> ViewModel { get; set; }


        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await this.ViewModel.LoadDataAsync();

            base.OnNavigatedTo(e);
        }

    }
}
