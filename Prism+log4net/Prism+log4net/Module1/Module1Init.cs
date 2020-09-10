using Common;
using Module1.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Module1
{
    public class Module1Init : IModule
    {
        private readonly IRegionManager _regionManager;

        public Module1Init(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.TopLeftRegion, typeof(GreenView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //throw new NotImplementedException();
        }
    }
}
