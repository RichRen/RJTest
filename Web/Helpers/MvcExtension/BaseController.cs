namespace System.Web.Mvc
{
    public class BaseController : Controller
    {


        #region 返回json信息

        public JsonResult resultMsg(string message, rMsgEnum msgType = rMsgEnum.success)
        {
            return MvcResultHelper.resultMsg(message, msgType);
        }

        public JsonResult resultMsg(object message, rMsgEnum msgType = rMsgEnum.success)
        {
            return MvcResultHelper.resultMsg(message, msgType);
        }
        #endregion
    }


    public enum rMsgEnum
    {
        success,
        error,
        info
    }
}