using Infrastructure;
using Microsoft.Practices.Unity;
using Module2.Views;
using Prism.Modularity;
using Prism.Regions;

namespace Module2
{
    public class Module2Init : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _container;
        private readonly string _moduleName = "Module2";

        public Module2Init(RegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {           
            _container.RegisterType(typeof(object), typeof(ChartView), _moduleName);
            if (_moduleName.Equals(ModuleConfigure.Instance.InitialModuleName))
            {
                _regionManager.RequestNavigate(RegionNames.MasterRegion, _moduleName);
            }
            _regionManager.RegisterViewWithRegion(RegionNames.StartupRegion, () => _container.Resolve<LaunchView>());
        }
    }
}
