using Infrastructure;
using Microsoft.Practices.Unity;
using Module1.Views;
using Prism.Modularity;
using Prism.Regions;

namespace Module1
{
    public class Module1Init : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _container;
        private readonly string _moduleName = "Module1";

        public Module1Init(RegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {           
            _container.RegisterType(typeof(object), typeof(ReportView), _moduleName);
            if (_moduleName.Equals(ModuleConfigure.Instance.InitialModuleName))
            {
                _regionManager.RequestNavigate(RegionNames.MasterRegion, _moduleName);
            }
            _regionManager.RegisterViewWithRegion(RegionNames.StartupRegion, () => _container.Resolve<LaunchView>());
        }
    }
}
