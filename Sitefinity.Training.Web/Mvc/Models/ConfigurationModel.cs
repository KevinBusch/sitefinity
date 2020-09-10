using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Data.Configuration;
using Telerik.Sitefinity.Localization.Configuration;

namespace SitefinityWebApp.MVC.Models
{
    public class ConfigurationModel
    {
        public ConfigManager GetManager()
        {
            return ConfigManager.GetManager();
        }
        
        public IEnumerable<ConnStringSettings> GetConnectionStringSettings()
        {
            return this.GetManager()
                .GetSection<DataConfig>()
                .ConnectionStrings
                .Elements;
        }

        public string AddReportingConnectionString()
        {
            var dataConfig = this.GetManager()
                .GetSection<DataConfig>();
            var connectionStringsSection = dataConfig.ConnectionStrings;
            var result = $"{REPORTING_CONN_STRING_NAME} aleady exists!";

            try
            {
                if (!connectionStringsSection.ContainsKey(REPORTING_CONN_STRING_NAME))
                {
                    var connectinStringsSetting = new ConnStringSettings(connectionStringsSection)
                    {
                        Name = REPORTING_CONN_STRING_NAME,
                        ConnectionString = "Data Source=127.0.0.1\\masterReporting;Integrated Security=True;User Instance=false;Initial Catalog=ReportingDb"
                    };

                    connectionStringsSection.Add(connectinStringsSetting);

                    this.GetManager().SaveSection(dataConfig);
                    result = $"{REPORTING_CONN_STRING_NAME} connection string was successfully created!";
                };
            }
            catch (Exception exception)
            {
                result = exception.ToString();
            }

            return result;
        }

        public IEnumerable<string> GetInstalledLanguages()
        {
            return Config.Get<ResourcesConfig>()
                .Cultures
                .Elements
                .Select(c => c.DisplayName);
        }

        private const string REPORTING_CONN_STRING_NAME = "AppReporting";
    }
}