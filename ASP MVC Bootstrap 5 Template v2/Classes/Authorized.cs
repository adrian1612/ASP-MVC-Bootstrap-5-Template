using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_MVC_Bootstrap_5_Template_v2
{
    public class Authorized : AuthorizeAttribute
    {
        private readonly string[] allowedroles;
        public Authorized(params string[] roles)
        {
            this.allowedroles = roles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            foreach (var role in allowedroles)
            {
                //var user = new UserSessions();
                //if (user.Level.ToString() == role || role == user.User.User)
                //{
                //    authorize = true;
                //}
            }
            return authorize;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary { {"controller", "Home" }, { "action", "RestrictedAccess" } });
        }
    }

    /// <summary>
    /// Author: Adrian Aranilla Jaspio
    /// Position: Programmer
    /// Date: June 23, 2023 3:30 PM
    /// 
    /// Subordinate: Jose Lamud Montenegro
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class FilterDisplay : FilterAttribute, IAuthorizationFilter
    {
        //Change model according to structure, make sure the model has Role or filtering properties
        /*tbl_user*/ object session { get { return HttpContext.Current.Session["user"] as /*tbl_user*/ object; } }

        //1) Add properties to filter
        public string Add { get; set; } = "";
        public string Edit { get; set; } = "";
        public string Delete { get; set; } = "";

        void FilterCore(FilterDisplay obj)
        {
            if (obj == null) return;
            string output = string.Empty;
            var dict = new Dictionary<string[], string>();
            //2) Add items here to filter the front-end
            dict.Add(obj.Add.Split(','), "[data-role='Add']");
            dict.Add(obj.Edit.Split(','), "[data-role='Edit']");
            dict.Add(obj.Delete.Split(','), "[data-role='Delete']");

            //Do not touch this!
            foreach (KeyValuePair<string[], string> col in dict)
            {
                var condition = col.Key.ToList().Exists(f => f.Contains($"{1/*session?.Role*/}"));
                if (!condition)
                {
                    output += $"{col.Value},";
                }
            }
            if (!string.IsNullOrEmpty(output))
            {
                string final = $"{output.Substring(0, output.Length - 1)}{{ display: none !important; }}";
                HttpContext.Current.Response.Write($"<style>{final}</style>");
            }
        }

        void IAuthorizationFilter.OnAuthorization(AuthorizationContext filterContext)
        {
            var item = (from a in filterContext.ActionDescriptor.GetCustomAttributes(true) select a).FirstOrDefault();
            FilterCore((FilterDisplay)item);
        }
    }
}

