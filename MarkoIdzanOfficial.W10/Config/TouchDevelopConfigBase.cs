using AppStudio.DataProviders.TouchDevelop;

namespace MarkoIdzanOfficial.Config
{
    public abstract class TouchDevelopConfigBase : ConfigBase<TouchDevelopDataConfig, TouchDevelopSchema>
    {
        public abstract string Title { get; }
    }
}
