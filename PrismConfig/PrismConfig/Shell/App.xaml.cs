using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using Shell.Views;
using System.Windows;

namespace Shell
{
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<ShellView>();
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //register class object here
            //containerRegistry.RegisterInstance<ShellView>(_tempShellView);
        }
        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog() { ModulePath = "." };
        }
    }
}
