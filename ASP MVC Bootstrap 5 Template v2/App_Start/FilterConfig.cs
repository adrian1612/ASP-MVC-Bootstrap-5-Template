﻿using System.Web;
using System.Web.Mvc;

namespace ASP_MVC_Bootstrap_5_Template_v2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}