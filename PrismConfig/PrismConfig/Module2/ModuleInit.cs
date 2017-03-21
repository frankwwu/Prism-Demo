using System;
using Prism.Modularity;
using Prism.Regions;
using Common;
using Module2.Views;
using Microsoft.Practices.Unity;

namespace Module2
{
    public class ModuleInit : IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;

        public ModuleInit(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        #region IModule Members

        public void Initialize()
        {
            this._regionManager.RegisterViewWithRegion(RegionNames.StartupMenuRegion, () => _container.Resolve<StartupMenuView>());
            this._regionManager.RegisterViewWithRegion(RegionNames.RightRegion, () => this._container.Resolve<MasterView>());
        }

        #endregion
    }
}
