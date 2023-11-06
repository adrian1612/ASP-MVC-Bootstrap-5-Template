using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_MVC_Bootstrap_5_Template_v2.Classes
{
    public class AsyncResult<T>
    {
        public static ActionResult Async(
            T asyncObj,
            int MaxJsonLength = int.MaxValue,
            JsonRequestBehavior reqBehavior = JsonRequestBehavior.AllowGet, 
            System.Text.Encoding encoding = null, 
            string contentType = (string) null)
            => new JsonResult()
            {
                MaxJsonLength = MaxJsonLength,
                Data = asyncObj,
                JsonRequestBehavior = reqBehavior,
                ContentEncoding = encoding,
                ContentType = contentType
            };
    }
}