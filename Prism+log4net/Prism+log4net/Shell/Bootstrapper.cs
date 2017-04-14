using System;
using System.Windows;
using Common;
using log4net.Config;
using Prism.Logging;
using Prism.Modularity;
using Prism.Unity;
using Shell.Views;

namespace Shell
{
    public partial class Bootstrapper : UnityBootstrapper
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();                   
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            // Create the module catalog from a XAML file.
            return Prism.Modularity.ModuleCatalog.CreateFromXaml(new Uri("/Shell;component/ModuleCatalog.xaml", UriKind.Relative));
        }

        protected override DependencyObject CreateShell()
        {
            // Use the container to create an instance of the shell.
            ShellView view = Container.TryResolve<ShellView>();

            // Display the shell's root visual.
            view.Show();
            return view;
        }

        protected override ILoggerFacade CreateLogger()
        {
            var logger = new Log4NetLogger();
            XmlConfigurator.Configure();           
            return logger;
        }
    }
}

