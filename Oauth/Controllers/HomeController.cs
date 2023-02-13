using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oauth.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        //only registered user can access this method
        [Authorize]
        public ActionResult UserArea()
        {
            return View();
        }

        [Authorize]

        public ActionResult AdminArea()
        {
            return View();
        }
    }
}