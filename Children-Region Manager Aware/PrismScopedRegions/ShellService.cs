using Prism.Regions;
using PrismScopedRegions.Infrastructure;
using PrismScopedRegions.Infrastructure.Prism;
using Unity;

namespace PrismScopedRegions
{
    public class ShellService :IShellService
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;

        public ShellService(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void ShowShell(string uri)
        {
            var shell = _container.Resolve<Shell>();

            var scopedRegion = _regionManager.CreateRegionManager();
            RegionManager.SetRegionManager(shell, scopedRegion);

            RegionManagerAware.SetRegionManagerAware(shell, scopedRegion);

            scopedRegion.RequestNavigate(KnownRegionNames.ContentRegion, uri);

            shell.Show();
        }
    }
}
