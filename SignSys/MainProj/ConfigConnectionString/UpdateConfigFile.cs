using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProj.ConfigConnectionString
{
    [Obsolete]
    public class UpdateConfigFile
    {
        public string GetConnStrExe()
        {
            Configuration config = GetConfigExe();
            var connectionString =
                config.ConnectionStrings.ConnectionStrings["Entities2"].ConnectionString.ToString();
            return connectionString;
        }

        public string GetConnStrDll()
        {
            Configuration config = GetConfigDll();
            var connectionString =
                config.ConnectionStrings.ConnectionStrings["Entities2"].ConnectionString.ToString();
            return connectionString;
        }

        private static Configuration GetConfigDll()
        {
            var stringPath = System.Windows.Forms.Application.ExecutablePath;
            var newStr = stringPath.Remove(stringPath.Length - 12) + "SeverToDB.dll";
            Configuration config = ConfigurationManager.OpenExeConfiguration(newStr);
            return config;
        }

        private static Configuration GetConfigExe()
        {
            var stringPath = System.Windows.Forms.Application.ExecutablePath;
            Configuration config = ConfigurationManager.OpenExeConfiguration(stringPath);
            return config;
        }

        public void UpdateStr(string connStr, string providerName)
        {
            var config = GetConfigExe();
            bool exist = false;
            if (config.ConnectionStrings.ConnectionStrings["Entities2"] != null)
            {
                exist = true;
            }
            if (exist)
            {
                config.ConnectionStrings.ConnectionStrings.Remove("Entities2");
            }
            ConnectionStringSettings mySettings =
                new ConnectionStringSettings("Entities2", connStr, providerName);
            config.ConnectionStrings.ConnectionStrings.Add(mySettings);
            // 保存对配置文件所作的更改  
            config.Save(ConfigurationSaveMode.Modified);
            // 强制重新载入配置文件的ConnectionStrings配置节  
            ConfigurationManager.RefreshSection("connectionStrings");

            var config1 = GetConfigDll();
            bool exist1 = false;
            if (config1.ConnectionStrings.ConnectionStrings["Entities2"] != null)
            {
                exist1 = true;
            }
            if (exist1)
            {
                config1.ConnectionStrings.ConnectionStrings.Remove("Entities2");
            }
            ConnectionStringSettings mySettings1 =
                new ConnectionStringSettings("Entities2", connStr, providerName);
            config1.ConnectionStrings.ConnectionStrings.Add(mySettings);
            // 保存对配置文件所作的更改  
            config1.Save(ConfigurationSaveMode.Modified);
            // 强制重新载入配置文件的ConnectionStrings配置节  
            ConfigurationManager.RefreshSection("connectionStrings");
        }
    }
}
