using ASP_MVC_Bootstrap_5_Template_v2.Models;
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
    public static SelectList Gender
    {
        get
        {
            return new SelectList(new string[] { "Male", "Female" });
        }
    }
}

public class UserSession
{
    public static tbl_User User { get { return (tbl_User)HttpContext.Current.Session["User"]; } }
}