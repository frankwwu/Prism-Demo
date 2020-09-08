using Common;
using Module2.Views;
using Prism.Ioc;
using Prism.Logging;
using Prism.Modularity;
using Prism.Regions;
using Unity;

namespace Module2
{
    public class Module2Init : IModule
    {
        //private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;
        //private readonly ILoggerFacade _logger;

        public Module2Init(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.RightRegion, typeof(MasterView));
            _regionManager.RegisterViewWithRegion(RegionNames.StartupMenuRegion, typeof(StartupMenuView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //throw new NotImplementedException();
        }
    }
}
