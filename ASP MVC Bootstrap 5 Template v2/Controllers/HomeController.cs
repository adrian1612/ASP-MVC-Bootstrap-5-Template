﻿using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemRedirect;

namespace ASP_MVC_Bootstrap_5_Template_v2.Controllers
{
    [Authorized]
    public class HomeController : Controller
    {
        [SystemSession(ConnectionType = SystemConnectionString.Default, Mode = Used.Developer)]
        public ActionResult Index()
        {
            return View();
        }

        [SystemSession(ConnectionType = SystemConnectionString.Default, Mode = Used.User)]
        public ActionResult Redirect()
        {
            return RedirectToAction("Index");
        }

        public ActionResult RestrictedAccess()
        {
            return View();
        }

        //public ActionResult Print(int ID)
        //{
        //    ReportViewer rv = new ReportViewer(); //EXCELOPENXML FOR EXCEL & application/vnd.ms-excel FOR contentType
        //    rv.LocalReport.ReportPath = Server.MapPath("~/Reports/Report.rdlc");
        //    var data = new object { };
        //    rv.LocalReport.DataSources.Add(new ReportDataSource("Report", data));
        //    var file = rv.LocalReport.Render("pdf");
        //    Response.ContentType = "application/pdf";
        //    Response.AddHeader("content-disposition", $"inline;filename=Form.pdf");
        //    Response.Buffer = true;
        //    Response.Clear();
        //    Response.BinaryWrite(file);
        //    Response.End();
        //    return View(file);
        //}
    }
}