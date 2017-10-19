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
    public class ZoneController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        #region AJAX Actions

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ZoneSelectAll([DataSourceRequest] DataSourceRequest request)
        {
            BL.Zones blZones = new BL.Zones();
            List<Zone> model = blZones.SelectAll();
            return Json(model.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ZoneUpdate([DataSourceRequest] DataSourceRequest request, Zone zone)
        {
            BL.Zones blZones = new BL.Zones();
            Zone model = blZones.Update(zone);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ZoneCreate([DataSourceRequest] DataSourceRequest request, Zone zone)
        {
            BL.Zones blZones = new BL.Zones();
            Zone model = blZones.Insert(zone);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ZoneDestroy([DataSourceRequest] DataSourceRequest request, Zone zone)
        {
            BL.Zones blZones = new BL.Zones();
            Zone model = blZones.SoftDelete(zone);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        #endregion AJAX Actions
    }
}