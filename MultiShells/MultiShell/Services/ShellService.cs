using Infrastructure;
using Infrastructure.MultiShell;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Regions;

namespace MultiShell.Services
{
    public class ShellService : IShellService
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;

        public ShellService(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _container = container;
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
        }

        public void ShowShell(string module)
        {
            Shell shell = _container.Resolve<Shell>();
            IRegionManager scopedRegion = _regionManager.CreateRegionManager();
            RegionManager.SetRegionManager(shell, scopedRegion);
            RegionManagerAware.SetRegionManagerAware(shell, scopedRegion);
            if (!string.IsNullOrEmpty(module))
            {
                scopedRegion.RequestNavigate(RegionNames.MasterRegion, module);
            }
            Properties.Settings.Default.ModuleLastOpened = module;
            Properties.Settings.Default.Save();
            shell.Show();
        }
    }
}
