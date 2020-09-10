using System.Configuration;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Localization;

namespace SitefinityWebApp.Configuration
{
    public class IntegrationConfig : ConfigSection
    {
        [ConfigurationProperty("apiKey", IsRequired = true)]
        public string ApiKey
        {
            get
            {
                return (string)this["apiKey"];
            }
            set
            {
                this["apiKey"] = value;
            }
        }

        [ConfigurationProperty("isActive", DefaultValue = true)]
        [ObjectInfo(Description = "Use this to indicate if an API key is active or not", Title = "is Active")]
        public bool IsActive
        {
            get
            {
                return (bool)this["isActive"];
            }
            set
            {
                this["isActive"] = value;
            }
        }
    }
}