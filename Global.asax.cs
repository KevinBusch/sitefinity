using SitefinityWebApp.MVC.ViewModels;
using System;
using Telerik.Sitefinity.DynamicModules.Events;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Services;

namespace SitefinityWebApp
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            SystemManager.ApplicationStart += new EventHandler<EventArgs>(ApplicationStartHandler);
        }

        private void ApplicationStartHandler(object sender, EventArgs e)
        {
            EventHub.Subscribe<IDynamicContentCreatingEvent>(evt => DynamicContentCreatingEventHandler(evt));
        }

        private void DynamicContentCreatingEventHandler(IDynamicContentCreatingEvent evt)
        {
            var userId = evt.UserId;
            var dynamicItem = evt.Item;
            //var officeModel = new OfficeModel();

            //if (dynamicItem.GetType().Equals(officeModel.OfficeType))
            //{
            //    dynamicItem.SetString("Info", "");
            //}
        }

        protected void Application_End(object sender, EventArgs e)
        {
            EventHub.Unsubscribe<IDynamicContentCreatingEvent>(DynamicContentCreatingEventHandler);
        }
    }
}
