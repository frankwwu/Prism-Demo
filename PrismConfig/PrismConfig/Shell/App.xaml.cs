using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using Shell.Views;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace Shell
{
    // Commands to generate a C# class from an XML file:
    // xsd AppsModuleConfig.xml
    // xsd AppsModuleConfig.xsd /classes
    //
    // XML file properties: None; Copy alway
    public partial class App : PrismApplication
    {
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Modules));
            FileStream fs = new FileStream("AppsModuleConfig.xml", FileMode.Open, FileAccess.Read);
            Modules modules = serializer.Deserialize(fs) as Modules;
            foreach (ModulesModule module in modules.Items)
            {
                moduleCatalog.AddModule(new ModuleInfo()
                {
                    ModuleName = module.moduleName,
                    ModuleType = module.moduleType,
                    InitializationMode = InitializationMode.WhenAvailable
                });
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //register class object here
            //containerRegistry.RegisterInstance<Shell>(_tempShellView);
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<ShellView>();
        }
    }
}
