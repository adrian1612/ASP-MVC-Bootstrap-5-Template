using ASP_MVC_Bootstrap_5_Template_v2.Models;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_MVC_Bootstrap_5_Template_v2.Classes
{
    public class dbcontrol : MasterControl
    {
        public dbcontrol() : base("ASP_MVC_Bootstrap_5_Template_v2")
        {
            QueryException += Dbcontrol_QueryException;
        }

        private void Dbcontrol_QueryException(Exception e)
        {
            throw e;
        }
    }
}

public class Tool
{
    public static string GetUrl(string Action, string Controller, object RouteData)
    {
        var result = "";
        var request = HttpContext.Current.Request;
        var helper = new UrlHelper(request.RequestContext);
        result = helper.Action(Action, Controller, RouteData, request.Url.Scheme);
        return result;
    }

    public static SelectList Gender
    {
        get
        {
            return new SelectList(new string[] { "Male", "Female" });
        }
    }

    public static byte[] ReportWrapper(string ReportPath, string Filename, ReportFormat format, Action<List<ReportDataSource>, List<ReportParameter>> _data)
    {
        byte[] result;
        ReportViewer rv = new ReportViewer();
        rv.LocalReport.ReportPath = HttpContext.Current.Server.MapPath(ReportPath);
        List<ReportDataSource> dataSource = new List<ReportDataSource>();
        List<ReportParameter> dataParameters = new List<ReportParameter>();
        _data(dataSource, dataParameters);
        dataSource.ForEach(r => rv.LocalReport.DataSources.Add(r));
        dataParameters.ForEach(r => rv.LocalReport.SetParameters(r));
        string Render = "", ContentType = "", Extension = "";
        switch (format)
        {
            case ReportFormat.PDF:
                Render = "PDF";
                ContentType = "application/pdf";
                Extension = "pdf";
                break;
            case ReportFormat.EXCEL:
                Render = "EXCELOPENXML";
                ContentType = "application/vnd.ms-excel";
                Extension = "xlsx";
                break;
            default:
                break;
        }
        result = rv.LocalReport.Render(Render);
        HttpContext.Current.Response.ContentType = ContentType;
        HttpContext.Current.Response.AddHeader("content-disposition", $"inline;filename={HttpUtility.HtmlEncode(Filename)}.{Extension}");
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.BinaryWrite(result);
        HttpContext.Current.Response.End();
        return result;
    }
}

public class UserSession
{
    public static tbl_User User { get { return (tbl_User)HttpContext.Current.Session["User"]; } }
}


public enum ReportFormat
{
    PDF, EXCEL
}