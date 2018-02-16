using System;
using System.Linq;
using AI.Infrastructure;
using AI.Infrastructure.Events;
using AI.Infrastructure.MultiShell;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Events;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;

namespace AI.AppSuite
{
    public class ShellViewModel : BindableBase, IRegionManagerAware
    {      
        private readonly IShellService _shellService;
        private readonly IEventAggregator _eventAggregator;
        private readonly IModuleCatalog _catalog;
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _container;

        public ShellViewModel(IEventAggregator eventAggregator, IShellService shellService, IModuleCatalog catalog, IRegionManager regionManager, IUnityContainer container)
        {           
            _eventAggregator = eventAggregator;
            _shellService = shellService;
            _catalog = catalog;
            _regionManager = regionManager;
            _container = container;

            _eventAggregator.GetEvent<InitialShellEvent>().Subscribe(module =>
            {
                if (string.IsNullOrEmpty(_moduleInstanceID))
                {
                    _moduleInstanceID = module.ModuleInstanceID;
                    Caption = module.ShellCaption;
                }
            });

            _eventAggregator.GetEvent<AccountOpenedEvent>().Subscribe(module =>
            {
                if (module.ModuleInstanceID.Equals(_moduleInstanceID))
                {
                    Caption = module.ShellCaption;
                }
            });

            _eventAggregator.GetEvent<AccountClosedEvent>().Subscribe(module =>
            {
                if (module.ModuleInstanceID.Equals(_moduleInstanceID))
                {
                    Caption = module.ShellCaption;
                }
            });

            OpenShellCommand = new DelegateCommand<string>(OpenShell, CanOpenShell);
            NavigateCommand = new DelegateCommand<string>(Navigate);        
            ShellClosingCommand = new DelegateCommand<System.ComponentModel.CancelEventArgs>(ShellClosing);
        }

        private string _moduleInstanceID;

        public string ModuleInstanceID { get { return _moduleInstanceID; } }

        private string _saption;

        public string Caption
        {
            get { return _saption; }
            set { _saption = value; OnPropertyChanged(); }
        }
        
        public IRegionManager RegionManager { get; set; }

        #region OpenShellCommand

        public DelegateCommand<string> OpenShellCommand { get; private set; }

        private void OpenShell(string viewName)
        {
            _shellService.ShowShell(viewName);
        }

        private bool CanOpenShell(string viewName)
        {
            // When the module is absent, it won't be found in the catalog. Therefore, the menu/button is disabled.
            return _catalog.Modules.Any(m => m.ModuleType.Contains(viewName));
        }

        #endregion OpenShellCommand

        #region NavigateCommand

        public DelegateCommand<string> NavigateCommand { get; private set; }

        private void Navigate(string viewName)
        {
            RegionManager.RequestNavigate(RegionNames.ContentRegion, viewName);
        }

        #endregion NavigateCommand

        #region ShellClosingCommand

        public DelegateCommand<System.ComponentModel.CancelEventArgs> ShellClosingCommand { get; private set; }

        private void ShellClosing(System.ComponentModel.CancelEventArgs param)
        {
            ShellClosingEventArgs args = new ShellClosingEventArgs();
            args.ModuleInstanceID = _moduleInstanceID;
            args.EventArgs = param;
            _eventAggregator.GetEvent<ShellClosingEvent>().Publish(args);
        }

        #endregion ShellLoadedCommand
    }
}
