using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using MultiShell.Services;
using Infrastructure;
using Infrastructure.MultiShell;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Unity;

namespace MultiShell
{
    public class Bootstrapper : UnityBootstrapper
    {
        public Bootstrapper()
        {
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
            {
                string viewName = viewType.FullName;
                string viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
                string viewModelName = String.Format(CultureInfo.InvariantCulture, "{0}ViewModel, {1}", viewName, viewAssemblyName);
                return Type.GetType(viewModelName);
            });

            // Check if ModuleLastOpened is enabled?
            Infrastructure.Modules.ModuleRow module = ModuleConfigure.Instance.Module.FirstOrDefault(m => m.ModuleName.Equals(Properties.Settings.Default.ModuleLastOpened));
            if (module != null)
            {
                ModuleConfigure.Instance.UpdateInitialModuleName(Properties.Settings.Default.ModuleLastOpened);
            }
            else
            {
                // ModuleLastOpened is not enabled. Open the first enabled module.
                Infrastructure.Modules.ModuleRow alt = ModuleConfigure.Instance.Module.FirstOrDefault(m => m.IsEnabeled.ToLower().Equals("true"));
                if (alt != null)
                {
                    ModuleConfigure.Instance.UpdateInitialModuleName(alt.ModuleName);
                }
            }
        }

        public Bootstrapper(string flag)
        {
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
            {
                string viewName = viewType.FullName;
                string viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
                string viewModelName = String.Format(CultureInfo.InvariantCulture, "{0}ViewModel, {1}", viewName, viewAssemblyName);
                return Type.GetType(viewModelName);
            });
            ModuleConfigure.Instance.UpdateInitialModuleNameByFlag(flag);
        }

        protected override Prism.Modularity.IModuleCatalog CreateModuleCatalog()
        {
            // Discover modules
            DirectoryModuleCatalog dmc = new DirectoryModuleCatalog() { ModulePath = "." };
            return dmc;
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            ViewModelLocationProvider.SetDefaultViewModelFactory((type) =>
            {
                return Container.Resolve(type);
            });

            Container.RegisterType<IShellService, ShellService>(new ContainerControlledLifetimeManager());
            ServiceLocator.SetLocatorProvider(() => Container as IServiceLocator);
        }

        protected override System.Windows.DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override IRegionBehaviorFactory ConfigureDefaultRegionBehaviors()
        {
            IRegionBehaviorFactory behaviors = base.ConfigureDefaultRegionBehaviors();
            behaviors.AddIfMissing(RegionManagerAwareBehavior.BehaviorKey, typeof(RegionManagerAwareBehavior));
            return behaviors;
        }

        protected override void InitializeShell()
        {
            IRegionManager regionManager = RegionManager.GetRegionManager((Shell));
            RegionManagerAware.SetRegionManagerAware(Shell, regionManager);
            App.Current.MainWindow.Show();
        }
    }
}
