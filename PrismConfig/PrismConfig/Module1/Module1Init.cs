using Common;
using Module1.Views;
using Prism.Ioc;
using Prism.Logging;
using Prism.Modularity;
using Prism.Regions;
using Unity;

namespace Module1
{
    public class Module1Init : IModule
    {
        //private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;
        //private readonly ILoggerFacade _logger;

        public Module1Init(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.LeftRegion, typeof(MasterView));
            _regionManager.RegisterViewWithRegion(RegionNames.StartupMenuRegion, typeof(StartupMenuView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //throw new NotImplementedException();
        }
    }
}
