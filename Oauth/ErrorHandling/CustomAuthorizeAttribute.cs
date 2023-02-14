using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Oauth.ErrorHandling
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                // If the user is authenticated but not authorized, redirect to a custom "Access Denied" page
                filterContext.Result = new RedirectResult("~/Error/UnauthorizedError");
            }
            else
            {
                // If the user is not authenticated, redirect to the login page
                filterContext.Result = new RedirectResult("~/Account/Login");
            }
        }
    }
}