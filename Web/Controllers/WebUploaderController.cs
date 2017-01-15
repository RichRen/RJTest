using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class WebUploaderController : Controller
    {
        // GET: WebUploader
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WebUploaderSave(HttpPostedFileBase file)
        {
            if (file == null)
                return Content("请选择文件！");
            string savePath = Server.MapPath("~/Template/");
            file.SaveAs(savePath + file.FileName);

            return Content("上传成功！");
        }
    }
}