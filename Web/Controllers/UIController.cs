using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;

namespace Web.Controllers
{
    public class UIController : Controller
    {
        // GET: UI
        public ActionResult Index()
        {
            int i, j = 0;
            i = 1 / j;
            return View();
        }

        public ActionResult Log4netTest()
        {
            ILog logger = LogManager.GetLogger(typeof(UIController));

            logger.Info("消息");
            logger.Warn("警告");
            logger.Error("异常");
            logger.Fatal("错误");
            return Content("log4net调试成功！");
        }
    }
}