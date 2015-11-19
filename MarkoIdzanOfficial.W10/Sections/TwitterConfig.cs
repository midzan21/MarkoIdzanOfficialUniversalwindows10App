using System;
using System.Collections.Generic;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.Twitter;
using AppStudio.Uwp.Actions;
using AppStudio.Uwp.Commands;
using AppStudio.Uwp.Navigation;
using MarkoIdzanOfficial.Config;
using MarkoIdzanOfficial.ViewModels;

namespace MarkoIdzanOfficial.Sections
{
    public class TwitterConfig : SectionConfigBase<TwitterDataConfig, TwitterSchema>
    {
        public override DataProviderBase<TwitterDataConfig, TwitterSchema> DataProvider
        {
            get
            {
                return new TwitterDataProvider(new TwitterOAuthTokens
                {
                    ConsumerKey = "UlMNPHio1XycImUxZjdbfkryd",
                    ConsumerSecret = "osmmRftdpp33lzotk8IF0Ldn0M5JBNjj9AM9wfcAKoZBkMheif",
                    AccessToken = "198448776-rItvEK3HWfPojVgvYKaA5rmAvbX1Os1LHa1IKy4D",
                    AccessTokenSecret = "utvb57Ipe7FhsHBMCpnWAVuUP8hIWbxqJP5N4VnCe1sCW"
                });
            }
        }

        public override TwitterDataConfig Config
        {
            get
            {
                return new TwitterDataConfig
                {
                    QueryType = TwitterQueryType.User,
                    Query = @"midzan21"
                };
            }
        }

        public override NavigationInfo ListNavigationInfo
        {
            get 
            {
                return NavigationInfo.FromPage("TwitterListPage");
            }
        }

        public override ListPageConfig<TwitterSchema> ListPage
        {
            get 
            {
                return new ListPageConfig<TwitterSchema>
                {
                    Title = "Twitter",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.UserName.ToSafeString();
                        viewModel.SubTitle = item.Text.ToSafeString();
                        viewModel.Description = null;
                        viewModel.Image = item.UserProfileImageUrl.ToSafeString();
                    },
                    NavigationInfo = (item) =>
                    {
                        return new NavigationInfo
                        {
                            NavigationType = NavigationType.DeepLink,
                            TargetUri = new Uri(item.Url)
                        };
                    }
                };
            }
        }

        public override DetailPageConfig<TwitterSchema> DetailPage
        {
            get { return null; }
        }

        public override string PageTitle
        {
            get { return "Twitter"; }
        }
    }
}
