using System;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace Sitefinity.Training.Web.UI.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "SystemInfO", Title = "System Info", SectionName = "System")]
    public class SystemInfoController : Controller
    {
        public string Message { get; set; }

        public ActionResult Index()
        {
            ViewBag.OS = Environment.OSVersion;
            ViewBag.Message = this.Message;
            return View("Index");
        }

        [Route("~/json/system-info")]
        public JsonResult ShortInfo()
        {
            var dynamicObject = new
            {
                OS = Environment.OSVersion.ToString(),
                Message = this.Message,
            };

            return Json(dynamicObject, JsonRequestBehavior.AllowGet);
        }

        protected override void HandleUnknownAction(string actionName)
        {
            base.ActionInvoker.InvokeAction(this.ControllerContext, "Index");
        }
    }
}
