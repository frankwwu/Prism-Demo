using System;
using Prism.Modularity;
using Prism.Regions;
using Common;
using Module1.Views;
using Microsoft.Practices.Unity;
using Prism.Logging;

namespace Module1
{
    public class ModuleInit : IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;
        private readonly ILoggerFacade _logger;

        public ModuleInit(IUnityContainer container, IRegionManager regionManager, ILoggerFacade logger)
        {
            _container = container;
            _regionManager = regionManager;
            _logger = logger;
        }

        #region IModule Members

        public void Initialize()
        {
            _logger.Log("ModuleInit.Initialize()", Category.Debug, Priority.Medium);

            // Use View Discovery to automatically display the MasterView when the TopLeft region is displayed.
            _regionManager.RegisterViewWithRegion(RegionNames.LeftRegion, () => _container.Resolve<MasterView>());
            _regionManager.RegisterViewWithRegion(RegionNames.StartupMenuRegion, () => _container.Resolve<StartupMenuView>());
        }

        #endregion
    }
}
