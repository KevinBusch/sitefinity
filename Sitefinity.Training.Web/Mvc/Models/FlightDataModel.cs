/* ------------------------------------------------------------------------------
<auto-generated>
    This file was generated by Sitefinity CLI v1.1.0.10
</auto-generated>
------------------------------------------------------------------------------ */

using Newtonsoft.Json;
using SitefinityWebApp.Mvc.ViewModels;
using System.Threading.Tasks;
using System.Net.Http;

namespace SitefinityWebApp.Mvc.Models
{
	public class FlightDataModel
	{
		public string Message { get; set; }

		public LaunchViewModel GetViewModel()
        {
			var getNextLaunchTask = Task.Run(() => this.GetLaunchAsync());
			getNextLaunchTask.Wait();
			return getNextLaunchTask.Result;
        }

		private async Task<LaunchViewModel> GetLaunchAsync()
        {
			using (var client = new HttpClient())
            {
				var jsonString = await client.GetStringAsync("https://api.spacexdata.com/v3/launches/latest");
				return JsonConvert.DeserializeObject<LaunchViewModel>(jsonString);
            }
        }
	}
}