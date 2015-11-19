using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AppStudio.Uwp.Navigation;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;

namespace MarkoIdzanOfficial.Navigation
{
    public class AppNavigation
    {
        private NavigationNode _active;

        static AppNavigation()
        {

        }

        public NavigationNode Active
        {
            get
            {
                return _active;
            }
            set
            {
                if (_active != null)
                {
                    _active.IsSelected = false;
                }
                _active = value;
                if (_active != null)
                {
                    _active.IsSelected = true;
                }
            }
        }


        public ObservableCollection<NavigationNode> Nodes { get; private set; }

        public void LoadNavigation()
        {
            Nodes = new ObservableCollection<NavigationNode>();
		    var resourceLoader = new ResourceLoader();
            Nodes.Add(new ItemNavigationNode
            {
                Title = @"Marko Idžan Official",
                Label = "Home",
                FontIcon = "\ue10f",
                IsSelected = true,
                NavigationInfo = NavigationInfo.FromPage("HomePage")
            });

            Nodes.Add(new ItemNavigationNode
            {
                Label = "YouTube",
                FontIcon = "\ue173",
                NavigationInfo = NavigationInfo.FromPage("YouTubeListPage")
            });
            Nodes.Add(new ItemNavigationNode
            {
                Label = "Facebook",
                FontIcon = "\ue19f",
                NavigationInfo = NavigationInfo.FromPage("FacebookListPage")
            });
            Nodes.Add(new ItemNavigationNode
            {
                Label = "Twitter",
                FontIcon = "\ue134",
                NavigationInfo = NavigationInfo.FromPage("TwitterListPage")
            });
            Nodes.Add(new ItemNavigationNode
            {
                Label = "Instagram",
                FontIcon = "\ue12d",
                NavigationInfo = NavigationInfo.FromPage("InstagramListPage")
            });
            Nodes.Add(new ItemNavigationNode
            {
                Label = resourceLoader.GetString("NavigationPanePrivacy"),
                FontIcon = "\ue1f7",
                NavigationInfo = new NavigationInfo()
                {
                    NavigationType = NavigationType.DeepLink,
                    TargetUri = new Uri("http://appstudio.windows.com/home/appprivacyterms", UriKind.Absolute)
                }
            });
        }

        public NavigationNode FindPage(Type pageType)
        {
            return GetAllItemNodes(Nodes).FirstOrDefault(n => n.NavigationInfo.NavigationType == NavigationType.Page && n.NavigationInfo.TargetPage == pageType.Name);
        }

        private IEnumerable<ItemNavigationNode> GetAllItemNodes(IEnumerable<NavigationNode> nodes)
        {
            foreach (var node in nodes)
            {
                if (node is ItemNavigationNode)
                {
                    yield return node as ItemNavigationNode;
                }
                else if(node is GroupNavigationNode)
                {
                    var gNode = node as GroupNavigationNode;

                    foreach (var innerNode in GetAllItemNodes(gNode.Nodes))
                    {
                        yield return innerNode;
                    }
                }
            }
        }
    }
}
