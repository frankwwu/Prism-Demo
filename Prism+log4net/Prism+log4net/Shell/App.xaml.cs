using log4net.Config;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using Shell.Views;
using System.Windows;

namespace Shell
{
    public partial class App : PrismApplication
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // Configures the log4net system based on app.config.
            XmlConfigurator.Configure();
            base.OnStartup(e);
        }

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
