using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismSkin.Themes.Views;

namespace PrismSkin.Themes
{
    public class ThemesModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewA));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}