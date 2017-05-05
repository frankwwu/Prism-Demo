using Common;
using Microsoft.Practices.Unity;
using Module2.Views;
using Prism.Modularity;
using Prism.Regions;

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
            _regionManager.RegisterViewWithRegion(RegionNames.BottomLeftRegion, () => this._container.Resolve<RedView>());
        }

        #endregion
    }
}
