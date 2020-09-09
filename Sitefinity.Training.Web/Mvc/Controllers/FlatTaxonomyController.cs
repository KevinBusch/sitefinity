using SitefinityWebApp.Mvc.Models;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "FlatTaxonomy", Title = "Flat Taxonomies", SectionName = "Classifications")]
    public class FlatTaxonomyController : Controller
    {
        // GET: FlatTaxonomy
        public ActionResult Index()
        {
            var model = new FlatTaxonomyModel();
            model.Populate();
            return View("Index", model);
        }
    }
}