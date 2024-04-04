using Microsoft.Reporting.WebForms;
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
        [SystemSession(ConnectionType = SystemConnectionString.Custom, ConnectionString = "SERVER=192.168.0.101\\MAYOGROUP;DATABASE=dbSystems;USER=SA;PWD=1234", Mode = Used.Developer, UserID = 216)]
        public ActionResult Index()
        {
            return View();
        }

        [SystemSession(ConnectionType = SystemConnectionString.Default, Mode = Used.User)]
        [AllowAnonymous]
        public ActionResult Redirect()
        {
            return RedirectToAction("Index");
        }

        public ActionResult RestrictedAccess()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return Redirect("/");
        }
    }
}