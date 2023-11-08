using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_MVC_Bootstrap_5_Template_v2.Classes
{
    public class AsyncBase
    {
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

        public ActionResult Excel_TableAppend()
        {
            return AsyncResult<string>.Async(DateTime.Now.ToLongTimeString());
        }

        public ActionResult Excel_TableReplace()
        {
            return AsyncResult<string>.Async(DateTime.Now.ToLongTimeString());
        }

        //public ActionResult PrintV2_Last(DateTime StartDate, DateTime EndDate, Status Status, Format Format = Format.PDF, bool? isLastRecord = false, string sessionUser = "")
        //{

        //    if (isLastRecord == false)
        //    {
        //        return RedirectToAction("Print", new { StartDate = StartDate, EndDate = EndDate, Status = Status, Format = Format, sessionUser = sessionUser });
        //    }
        //    ReportViewer rv = new ReportViewer(); //EXCELOPENXML FOR EXCEL & application/vnd.ms-excel FOR contentType
        //    if (sessionUser == "")
        //    {
        //        rv.LocalReport.ReportPath = Server.MapPath("~/Reports/ITSD_v2.rdlc");
        //    }
        //    else
        //    {
        //        rv.LocalReport.ReportPath = Server.MapPath("~/Reports/ITSD_v3.rdlc");
        //    }
        //    var item = new JobOrderWithUpdates().ListV2_Last(StartDate, EndDate, Status, isLastRecord, sessionUser);
        //    rv.LocalReport.DataSources.Add(new ReportDataSource("JobOrder", item));
        //    var file = rv.LocalReport.Render(Format == Format.PDF ? "pdf" : "EXCELOPENXML");
        //    Response.ContentType = Format == Format.PDF ? "application/pdf" : "application/vnd.ms-excel";
        //    Response.AddHeader("content-disposition", Format == Format.PDF ? $"inline;filename=ITSD {DateTime.Now:yyyyMMddhhmmss}.pdf" : $"inline;filename=ITSD {DateTime.Now:yyyyMMddhhmmss}.xlsx");
        //    Response.Buffer = true;
        //    Response.Clear();
        //    Response.BinaryWrite(file);
        //    Response.End();
        //    return View(file);
        //}

        //public enum Format
        //{
        //    PDF,
        //    Excel
        //}
    }
}