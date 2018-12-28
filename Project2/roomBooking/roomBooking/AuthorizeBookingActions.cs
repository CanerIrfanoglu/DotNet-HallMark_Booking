using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace roomBooking
{
    public class AuthorizeBookingActions : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authorized = base.AuthorizeCore(httpContext);
            if (!authorized)
            {
                return false;
            }

            if (System.Web.HttpContext.Current.User.IsInRole("Admin")) { return true; }

            String userid = HttpContext.Current.User.Identity.GetUserId();

            
          //  if User.IsInRole("Role_name")

            var rd = httpContext.Request.RequestContext.RouteData;

            var id = rd.Values["id"];
            var userName = httpContext.User.Identity.Name;

           // Submission submission = unit.SubmissionRepository.GetByID(id);
           // User user = unit.UserRepository.GetByUsername(userName);

           return true;
        }

    }
}