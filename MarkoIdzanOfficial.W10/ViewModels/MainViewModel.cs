using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppStudio.Uwp;
using AppStudio.Uwp.Actions;
using AppStudio.Uwp.Commands;
using AppStudio.Uwp.Navigation;
using AppStudio.DataProviders;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using AppStudio.DataProviders.YouTube;
using AppStudio.DataProviders.Facebook;
using AppStudio.DataProviders.Twitter;
using AppStudio.DataProviders.Instagram;
using AppStudio.DataProviders.LocalStorage;
using MarkoIdzanOfficial.Sections;


namespace MarkoIdzanOfficial.ViewModels
{
    public class MainViewModel : PageViewModel
    {
        public MainViewModel(int visibleItems) : base()
        {
            PageTitle = "Marko Idžan Official";
            YouTube = new ListViewModel<YouTubeDataConfig, YouTubeSchema>(new YouTubeConfig(), visibleItems);
            Facebook = new ListViewModel<FacebookDataConfig, FacebookSchema>(new FacebookConfig(), visibleItems);
            Twitter = new ListViewModel<TwitterDataConfig, TwitterSchema>(new TwitterConfig(), visibleItems);
            Instagram = new ListViewModel<InstagramDataConfig, InstagramSchema>(new InstagramConfig(), visibleItems);
            Actions = new List<ActionInfo>();

            if (GetViewModels().Any(vm => !vm.HasLocalData))
            {
                Actions.Add(new ActionInfo
                {
                    Command = new RelayCommand(Refresh),
                    Style = ActionKnownStyles.Refresh,
                    Name = "RefreshButton",
                    ActionType = ActionType.Primary
                });
            }
        }

        public string PageTitle { get; set; }
        public ListViewModel<YouTubeDataConfig, YouTubeSchema> YouTube { get; private set; }
        public ListViewModel<FacebookDataConfig, FacebookSchema> Facebook { get; private set; }
        public ListViewModel<TwitterDataConfig, TwitterSchema> Twitter { get; private set; }
        public ListViewModel<InstagramDataConfig, InstagramSchema> Instagram { get; private set; }

        public RelayCommand<INavigable> SectionHeaderClickCommand
        {
            get
            {
                return new RelayCommand<INavigable>(item =>
                    {
                        NavigationService.NavigateTo(item);
                    });
            }
        }

        public DateTime? LastUpdated
        {
            get
            {
                return GetViewModels().Select(vm => vm.LastUpdated)
                            .OrderByDescending(d => d).FirstOrDefault();
            }
        }

        public List<ActionInfo> Actions { get; private set; }

        public bool HasActions
        {
            get
            {
                return Actions != null && Actions.Count > 0;
            }
        }

        public async Task LoadDataAsync()
        {
            var loadDataTasks = GetViewModels().Select(vm => vm.LoadDataAsync());

            await Task.WhenAll(loadDataTasks);

            OnPropertyChanged("LastUpdated");
        }

		public override void UpdateCommonProperties(SplitViewDisplayMode splitViewDisplayMode)
        {
            base.UpdateCommonProperties(splitViewDisplayMode);
            if (splitViewDisplayMode == SplitViewDisplayMode.Overlay)
            {
                AppBarRow = 3;
                AppBarColumn = 0;
                AppBarColumnSpan = 2;
            }
        }

        private async void Refresh()
        {
            var refreshDataTasks = GetViewModels()
                                        .Where(vm => !vm.HasLocalData)
                                        .Select(vm => vm.LoadDataAsync(true));

            await Task.WhenAll(refreshDataTasks);

            OnPropertyChanged("LastUpdated");
        }

        private IEnumerable<DataViewModelBase> GetViewModels()
        {
            yield return YouTube;
            yield return Facebook;
            yield return Twitter;
            yield return Instagram;
        }
    }
}
