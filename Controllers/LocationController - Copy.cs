using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using MaterialTracking.Types;

namespace MaterialTracking.Web.Controllers
{
    public class LocationController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        #region AJAX Actions

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult LocationSelectAll([DataSourceRequest] DataSourceRequest request)
        {
            BL.Locations blLocations = new BL.Locations();
            List<Location> model = blLocations.SelectAll();
            return Json(model.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult LocationUpdate([DataSourceRequest] DataSourceRequest request, Location location)
        {
            BL.Locations blLocations = new BL.Locations();
            Location model = blLocations.Update(location);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult LocationCreate([DataSourceRequest] DataSourceRequest request, Location location)
        {
            BL.Locations blLocations = new BL.Locations();
            Location model = blLocations.Insert(location);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult LocationDestroy([DataSourceRequest] DataSourceRequest request, Location location)
        {
            BL.Locations blLocations = new BL.Locations();
            Location model = blLocations.SoftDelete(location);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        #endregion AJAX Actions
    }
}