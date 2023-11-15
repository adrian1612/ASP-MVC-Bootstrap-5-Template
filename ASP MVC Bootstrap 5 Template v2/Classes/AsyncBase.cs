using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.OleDb;

namespace ASP_MVC_Bootstrap_5_Template_v2.Classes
{
    public class AsyncBase<T> : Controller
    {
        // GET: Area/Barangay
        public ActionResult Index()
        {
            return View();
        }

        public  ActionResult List(T obj)
        {
            return AsyncResult<T>.Async(obj);
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

        public ActionResult CreateTable()
        {
            return AsyncResult<string>.Async(DateTime.Now.ToLongTimeString());
        }

        public ActionResult RecreateTable()
        {
            return AsyncResult<string>.Async(DateTime.Now.ToLongTimeString());
        }

        public ActionResult CopyTable()
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

        public ActionResult Excel_TableLink()
        {
            return AsyncResult<string>.Async(DateTime.Now.ToLongTimeString());
        }

        public ActionResult Excel_TableDisplay()
        {
            return AsyncResult<string>.Async(DateTime.Now.ToLongTimeString());
        }

        private DataTable GetDataTable(string sql, string connectionString)
        {
            DataTable dt = null;

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    using (OleDbDataReader rdr = cmd.ExecuteReader())
                    {
                        dt.Load(rdr);
                        return dt;
                    }
                }
            }
        }

        private void GetExcel()
        {
            string fullPathToExcel = @"<C:\Users\JM01\Desktop\sample excel reading.xls>"; //ie C:\Temp\YourExcel.xls
            string connString = string.Format("Provider=System.Data.OleDb;Data Source={0};Extended Properties='Excel 12.0;HDR=yes'", fullPathToExcel);
            DataTable dt = GetDataTable("SELECT * from [SheetName$]", connString);

            foreach (DataRow dr in dt.Rows)
            {
                //Do what you need to do with your data here
            }
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