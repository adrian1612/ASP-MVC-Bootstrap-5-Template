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
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}