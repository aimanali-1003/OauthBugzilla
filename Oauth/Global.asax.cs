using Oauth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Oauth
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            using(DB db = new DB())
            {
                if (db.Roles.Count() == 0)
                {
                    var role1 = new UserRole();
                    var role2 = new UserRole();
                    var role3 = new UserRole();

                    role1.RoleName = "Manager";
                    role2.RoleName = "Developer";
                    role3.RoleName = "QA";
                        
                    db.Roles.Add(role1);
                    db.Roles.Add(role2);
                    db.Roles.Add(role3);
                    db.SaveChanges();
                }
            }
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
