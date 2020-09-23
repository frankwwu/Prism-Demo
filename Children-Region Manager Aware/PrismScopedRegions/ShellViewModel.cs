using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismScopedRegions.Infrastructure;
using PrismScopedRegions.Infrastructure.Prism;

namespace PrismScopedRegions
{
    public class ShellViewModel : BindableBase, IRegionManagerAware
    {
        private readonly IShellService _service;

        public DelegateCommand<string> OpenShellCommand { get; private set; }
        public DelegateCommand<string> NavigateCommand { get; private set; }

        public ShellViewModel(IShellService service)
        {
            _service = service;

            OpenShellCommand = new DelegateCommand<string>(OpenShell);
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        void OpenShell(string viewName)
        {
            _service.ShowShell(viewName);
        }

        void Navigate(string viewName)
        {
            RegionManager.RequestNavigate(KnownRegionNames.ContentRegion, viewName);
        }

        public IRegionManager RegionManager { get; set; }
    }
}
