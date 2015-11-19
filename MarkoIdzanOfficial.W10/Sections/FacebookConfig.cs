using System;
using System.Collections.Generic;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.Facebook;
using AppStudio.Uwp.Actions;
using AppStudio.Uwp.Commands;
using AppStudio.Uwp.Navigation;
using MarkoIdzanOfficial.Config;
using MarkoIdzanOfficial.ViewModels;

namespace MarkoIdzanOfficial.Sections
{
    public class FacebookConfig : SectionConfigBase<FacebookDataConfig, FacebookSchema>
    {
        public override DataProviderBase<FacebookDataConfig, FacebookSchema> DataProvider
        {
            get
            {
                return new FacebookDataProvider(new FacebookOAuthTokens
                {
                    AppId = "1680806408798789",
                    AppSecret = "7dea6c1cb3245c1247703ac3fb368959"
                });
            }
        }

        public override FacebookDataConfig Config
        {
            get
            {
                return new FacebookDataConfig
                {
                    UserId = "286583304877103"
                };
            }
        }

        public override NavigationInfo ListNavigationInfo
        {
            get 
            {
                return NavigationInfo.FromPage("FacebookListPage");
            }
        }

        public override ListPageConfig<FacebookSchema> ListPage
        {
            get 
            {
                return new ListPageConfig<FacebookSchema>
                {
                    Title = "Facebook",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.Title.ToSafeString();
                        viewModel.SubTitle = item.Summary.ToSafeString();
                        viewModel.Description = null;
                        viewModel.Image = item.ImageUrl.ToSafeString();
                    },
                    NavigationInfo = (item) =>
                    {
                        return NavigationInfo.FromPage("FacebookDetailPage", true);
                    }
                };
            }
        }

        public override DetailPageConfig<FacebookSchema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, FacebookSchema>>();
                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = item.Author.ToSafeString();
                    viewModel.Title = "";
                    viewModel.Description = item.Content.ToSafeString();
                    viewModel.Image = item.ImageUrl.ToSafeString();
                    viewModel.Content = null;
                });

                var actions = new List<ActionConfig<FacebookSchema>>
                {
                    ActionConfig<FacebookSchema>.Link("Go To Source", (item) => item.FeedUrl.ToSafeString()),
                };

                return new DetailPageConfig<FacebookSchema>
                {
                    Title = "Facebook",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }

        public override string PageTitle
        {
            get { return "Facebook"; }
        }
    }
}
