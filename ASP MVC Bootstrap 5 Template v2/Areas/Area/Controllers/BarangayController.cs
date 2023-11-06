using ASP_MVC_Bootstrap_5_Template_v2.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExcelDataReader.Core;


namespace ASP_MVC_Bootstrap_5_Template_v2.Areas.Area.Controllers
{
    public class BarangayController : Controller
    {
        // GET: Area/Barangay
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return AsyncResult<string>.Async(DateTime.Now.ToLongTimeString());
        }


        /// <summary>
        /// Insert single item
        /// </summary>
        /// <returns></returns>
        public ActionResult Insert()
        {
            return AsyncResult<string>.Async(DateTime.Now.ToLongTimeString());
        }

        public ActionResult Update()
        {
            return AsyncResult<string>.Async(DateTime.Now.ToLongTimeString());
        }

        public ActionResult Delete()
        {
            return AsyncResult<string>.Async(DateTime.Now.ToLongTimeString());
        }

        /// <summary>
        /// Insert multiple
        /// </summary>
        /// <returns></returns>
        public ActionResult MultiInsert()
        {
            return AsyncResult<string>.Async(DateTime.Now.ToLongTimeString());
        }

        public ActionResult MultiUpdate()
        {
            return AsyncResult<string>.Async(DateTime.Now.ToLongTimeString());
        }

        public ActionResult MultiDelete()
        {
            return AsyncResult<string>.Async(DateTime.Now.ToLongTimeString());
        }


        public ActionResult DropTable()
        {
            return AsyncResult<string>.Async(DateTime.Now.ToLongTimeString());
        }

        public ActionResult RecreateTable()
        {
            return AsyncResult<string>.Async(DateTime.Now.ToLongTimeString());
        }

        public ActionResult PopulateTable()
        {
            return AsyncResult<string>.Async(DateTime.Now.ToLongTimeString());
        }

        public ActionResult ReadExcel()
        {
            return AsyncResult<string>.Async(DateTime.Now.ToLongTimeString());
        }
    }
}