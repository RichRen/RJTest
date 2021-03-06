﻿using Newtonsoft.Json;

namespace System.Web.Mvc
{
    public class JsonNetResult : JsonResult
    {
        public JsonSerializerSettings Settings { get; set; }

        public JsonNetResult()
        {
            Settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                DateFormatString = "yyyy-MM-dd"
            };
        }
        public JsonNetResult(string DateFormat)
            : this()
        {
            Settings.DateFormatString = DateFormat;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            //if (this.JsonRequestBehavior == JsonRequestBehavior.DenyGet && string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            //    throw new InvalidOperationException("JSON GET is not allowed");
            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = string.IsNullOrEmpty(this.ContentType) ? "application/json" : this.ContentType;
            if (this.ContentEncoding != null)
                response.ContentEncoding = this.ContentEncoding;
            if (this.Data == null)
                return;
            var result = JsonConvert.SerializeObject(this.Data, this.Settings);
            response.Write(result);
        }
    }
}