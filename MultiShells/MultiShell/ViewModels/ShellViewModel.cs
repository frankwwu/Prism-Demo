using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using MultiShell.Models;
using Infrastructure;
using Infrastructure.Events;
using Infrastructure.MultiShell;
using MahApps.Metro;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Events;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;

namespace MultiShell
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
                else if (_moduleInstanceID.Equals(module.ModuleInstanceID))
                {
                    Caption = module.ShellCaption;
                }
            });

            this.AccentColors = ThemeManager.Accents.Select(a => new AccentColorMenuData()
            {
                Name = a.Name,
                ColorBrush = a.Resources["AccentColorBrush"] as Brush
            }).ToList();

            this.AppThemes = ThemeManager.AppThemes.Select(a => new AppThemeMenuData()
            {
                Name = a.Name,
                BorderColorBrush = a.Resources["BlackColorBrush"] as Brush,
                ColorBrush = a.Resources["WhiteColorBrush"] as Brush
            }).ToList();

            AppTheme theme = ThemeManager.AppThemes.FirstOrDefault(t => t.Name.Equals(Properties.Settings.Default.ThemeName));
            Accent accent = ThemeManager.Accents.FirstOrDefault(a => a.Name.Equals(Properties.Settings.Default.AccentName));
            if ((theme != null) && (accent != null))
            {
                ThemeManager.ChangeAppStyle(Application.Current, accent, theme);
            }

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
            set { _saption = value; RaisePropertyChanged(); }
        }

        public IRegionManager RegionManager { get; set; }

        public List<AccentColorMenuData> AccentColors { get; set; }

        public List<AppThemeMenuData> AppThemes { get; set; }

        public WindowState WindowState
        {
            get { return (WindowState)Enum.Parse(typeof(WindowState), Properties.Settings.Default.WindowState); }
            set { Properties.Settings.Default.WindowState = value.ToString(); Properties.Settings.Default.Save(); }
        }

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
            RegionManager.RequestNavigate(RegionNames.MasterRegion, viewName);
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
