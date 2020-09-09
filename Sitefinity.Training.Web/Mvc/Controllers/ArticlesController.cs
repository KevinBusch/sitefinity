using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Modules.News;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.News.Model;

namespace SitefinityWebApp.MVC.Controllers
{
    [ControllerToolboxItem(Name = "ArticlesController", Title = "Articles", SectionName = "Custom")]
    public class ArticlesController : Controller
    {
        // GET: Articles
        public ActionResult Index()
        {
            return View("ArticlesList", this.GetNewsItems());
        }

        private IQueryable<NewsItem> GetNewsItems()
        {
            var newsManager = NewsManager.GetManager();

            return newsManager.GetNewsItems()
                .Where(n => n.Status == ContentLifecycleStatus.Live && n.Visible == true)
                .OrderByDescending(n => n.PublicationDate)
                .Take(3);
        }
    }
}