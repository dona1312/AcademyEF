using AcademyEF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcademyEF.Filters
{
    public class AuthorizationFilter : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (AuthenticationService.LoggedUser != null)
            {
                HttpContext.Current.Response.Redirect("~/Courses/List");
                filterContext.Result = new EmptyResult();
            }
        }
    }
}