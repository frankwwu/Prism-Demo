using Common;
using log4net;
using Module2.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Module2
{
    public class Module2Init : IModule
    {       
        private readonly IRegionManager _regionManager;
     
        public Module2Init(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.BottomLeftRegion, typeof(RedView));            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //register class object here
            containerRegistry.RegisterInstance<ILog>(LogManager.GetLogger("Module2"));
        }
    }
}
