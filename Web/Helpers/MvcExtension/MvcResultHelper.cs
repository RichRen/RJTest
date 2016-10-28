using Newtonsoft.Json;
using System.Text;
using System.Web.Mvc;
using System.Collections.Generic;

public class MvcResultHelper
{
    /// <summary>
    /// 返回json提示信息
    /// </summary>
    /// <param name="message">消息内容</param>
    /// <param name="msgType">提示类别</param>
    /// <returns></returns>
    public static JsonResult resultMsg(object message, rMsgEnum msgType = rMsgEnum.success)
    {
        JsonNetResult returnJson = new JsonNetResult();
        if (message.ToString().Trim() == "")
            message = msgType.ToString();

        switch (msgType)
        {
            case rMsgEnum.success:
                returnJson.Data = new { success = message };
                break;
            case rMsgEnum.error:
                returnJson.Data = new { error = message };
                break;
            case rMsgEnum.info:
                returnJson.Data = new { info = message };
                break;
            default:
                break;
        }

        return returnJson;
    }

    public static JsonNetResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
    {
        return new JsonNetResult
        {
            Data = data,
            ContentType = contentType,
            ContentEncoding = contentEncoding,
            JsonRequestBehavior = behavior
        };
    }
    public static JsonNetResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior, JsonSerializerSettings setting)
    {
        return new JsonNetResult
        {
            Data = data,
            ContentType = contentType,
            ContentEncoding = contentEncoding,
            JsonRequestBehavior = behavior,
            Settings = setting
        };
    }
}