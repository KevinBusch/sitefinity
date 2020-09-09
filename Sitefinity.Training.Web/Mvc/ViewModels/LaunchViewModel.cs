using Newtonsoft.Json;

namespace SitefinityWebApp.Mvc.ViewModels
{
    public class LaunchViewModel
    {
        [JsonProperty(PropertyName = "details")]
        public string Details { get; set; }

        [JsonProperty(PropertyName = "mission_name")]
        public string MissionName { get; set; }
    }
}