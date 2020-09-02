//using SitefinityWebApp.MVC.Models;
//using System.Web.Mvc;
//using Telerik.Sitefinity.Mvc;

//namespace SitefinityWebApp.MVC.Controllers
//{
//    [ControllerToolboxItem(Name = "OurOffices", Title = "Our Offices", SectionName = "Custom")]
//    public class OurOfficesController : Controller
//    {
//        private readonly OfficeModel officeModel;

//        public OurOfficesController()
//        {
//            this.officeModel = new OfficeModel();
//            this.officeModel.ProviderName = "OpenAccessProvider";
//        }

//        public ActionResult Index()
//        {
//            var viewModel = this.officeModel.GetOfficesViewModels();
//            return View("Index", viewModel);
//        }
//    }
//}