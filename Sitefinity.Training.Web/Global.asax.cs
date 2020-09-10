using Ninject.Web.Common;
using System;
using Telerik.Microsoft.Practices.Unity;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.DynamicModules.Events;
using Telerik.Sitefinity.Frontend;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Routing;
using Telerik.Sitefinity.Frontend.News.Mvc.Models;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Services;
using Bootstrapper = Telerik.Sitefinity.Abstractions.Bootstrapper;
using Telerik.Microsoft.Practices.EnterpriseLibrary.Logging.Filters;
using Telerik.Sitefinity.Configuration;
using SitefinityWebApp.Configuration;

namespace SitefinityWebApp
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Bootstrapper.Bootstrapped += Bootstrapped_Bootstrapped;
            Bootstrapper.Initialized += Bootstrapped_Initialized;
            SystemManager.ApplicationStart += new EventHandler<EventArgs>(ApplicationStartHandler);
        }

        private void Bootstrapped_Initialized(object sender, ExecutedEventArgs e)
        {
            if (e.CommandName == "Bootstrapped")
            {
                //FrontendModule.Current.DependencyResolver.Rebind<INewsModel>().To<CategoryFilterNewModel>();
                Config.RegisterSection<IntegrationConfig>();
            }
        }

        private void Bootstrapped_Bootstrapped(object sender, EventArgs e)
        {
            //FeatureActionInvokerCustom.Register();
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
