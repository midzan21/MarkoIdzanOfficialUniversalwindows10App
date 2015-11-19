using AppStudio.Uwp;
using Windows.ApplicationModel;

namespace MarkoIdzanOfficial.ViewModels
{
    public class AboutThisAppViewModel : PageViewModel
    {
        public string Publisher
        {
            get
            {
                return "AppStudio";
            }
        }

        public string AppVersion
        {
            get
            {
                return string.Format("{0}.{1}.{2}.{3}", Package.Current.Id.Version.Major, Package.Current.Id.Version.Minor, Package.Current.Id.Version.Build, Package.Current.Id.Version.Revision);
            }
        }

        public string AboutText
        {
            get
            {
                return "Use this to create an app from scratch.";
            }
        }
		
        public string AppName
        {
            get
            {
                return "Marko Idžan Official";
            }
        }
    }
}

