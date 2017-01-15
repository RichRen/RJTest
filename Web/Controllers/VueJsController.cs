using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class VueJsController : Controller
    {
        // GET: VueJs
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList()
        {
            List<string> list = new List<string>() { "123","456","789"};
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}

