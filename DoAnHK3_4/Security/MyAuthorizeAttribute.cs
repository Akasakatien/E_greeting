using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security;
using System.Web.Mvc;
using DoAnHK3_4.Security;
using System.Web.Routing;
using DoAnHK3_4.Models;

namespace DoAnHK3_4.Security
{
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        private GreetingDatabaseEntities db = new GreetingDatabaseEntities();

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (string.IsNullOrEmpty(MySession.Username))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "Error" }));
            }
            else
            {

                Account account = db.Accounts.SingleOrDefault(a=>a.username.Equals(MySession.Username));
                //Account account = db.find(MySession.Username);
                CustomPrincipal customPrincipal = new CustomPrincipal(account);
                if (!customPrincipal.IsInRole(Roles))
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "Error" }));
                }
            }
        }
    }
}