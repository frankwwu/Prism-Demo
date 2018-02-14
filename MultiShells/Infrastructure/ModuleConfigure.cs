using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Infrastructure
{
    public class ModuleConfigure
    {
        private static ModuleConfigure _instance;

        public static ModuleConfigure Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ModuleConfigure();
                    _instance.DeserializeConfig();
                }
                return _instance;
            }
        }

        public string InitialModuleName { get; private set; }

        public Infrastructure.Modules.ModuleDataTable Module { get; private set; }

        public void DeserializeConfig()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Modules));
                FileStream fs = new FileStream("AppsModuleConfig.xml", FileMode.Open, FileAccess.Read);
                Modules modules = serializer.Deserialize(fs) as Modules;
                Module = modules.Module;
                fs.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public void UpdateInitialModuleName(string name)
        {
            Infrastructure.Modules.ModuleRow module = string.IsNullOrEmpty(name) ? Module.FirstOrDefault() : Module.FirstOrDefault(m => name.Equals(m.ModuleName) && m.IsEnabeled.ToLower().Equals("true"));
            if (module != null)
            {
                InitialModuleName = module.ModuleName;
            }
            else
            {
                InitialModuleName = name;
            }
        }

        public void UpdateInitialModuleNameByFlag(string argument)
        {
            if (!string.IsNullOrEmpty(argument))
            {
                Infrastructure.Modules.ModuleRow module = Module.FirstOrDefault(m => m.Argument.Equals(argument) && m.IsEnabeled.ToLower().Equals("true"));
                if (module != null)
                {
                    ModuleConfigure.Instance.InitialModuleName = module.ModuleName;
                }
            }
        }
    }
}
