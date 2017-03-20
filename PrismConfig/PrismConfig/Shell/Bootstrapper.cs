using System;
using System.IO;
using System.Windows;
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
            //  The catalog built app.config file.
            return new ConfigurationModuleCatalog();
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
            StreamWriter writer = File.CreateText("Log.txt");
            return new TextLogger(writer);
        }
    }
}

