using System;
using System.Web.Mvc;
using Kendo.Mvc.UI;

namespace MaterialTracking.Web.Controllers
{
    public class HomeController : BaseController
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Hello()
        {
            return View();
        }
        

    }
}