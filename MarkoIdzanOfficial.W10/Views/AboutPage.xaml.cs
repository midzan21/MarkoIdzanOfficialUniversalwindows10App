//---------------------------------------------------------------------------
//
// <copyright file="AboutPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>11/17/2015 1:57:13 PM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using MarkoIdzanOfficial.ViewModels;

namespace MarkoIdzanOfficial.Views
{
    public sealed partial class AboutPage : Page
    {
        public AboutPage()
        {
            AboutThisAppModel = new AboutThisAppViewModel();

            this.InitializeComponent();
        }

        public AboutThisAppViewModel AboutThisAppModel { get; private set; }
    }
}
