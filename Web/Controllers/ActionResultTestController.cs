using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ActionResultTestController : Controller
    {
        // GET: ActionResultTest
        public ActionResult Index()
        {
            return View();
        }

        public ContentResult ContentResult()
        {
            return Content("Hello ContentResult!");
        }

        public JsonResult JsonResult()
        {
            var obj = new { id="123",name="rj"};

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public JavaScriptResult JavaScriptResult()
        {
            return JavaScript("alert('123');");
        }

        public FilePathResult FilePathResult()
        {
            string filename = Server.MapPath("/Image/622762d09a82581ea1ec9c77.jpg");
            return File(filename, "image/jpeg");
        }
    }
}