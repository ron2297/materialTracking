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
    public class ZoneTypeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        #region AJAX Actions

        
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ZoneTypeSelectAll([DataSourceRequest] DataSourceRequest request)
        {
            BL.ZoneTypes blZoneTypes = new BL.ZoneTypes();
            List<ZoneType> model = blZoneTypes.SelectAll();
            return Json(model.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ZoneTypeUpdate([DataSourceRequest] DataSourceRequest request, ZoneType zonetype)
        {
            BL.ZoneTypes blZoneTypes = new BL.ZoneTypes();
            ZoneType model = blZoneTypes.Update(zonetype);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ZoneTypeCreate([DataSourceRequest] DataSourceRequest request, ZoneType zonetype)
        {
            BL.ZoneTypes blZoneTypes = new BL.ZoneTypes();
            ZoneType model = blZoneTypes.Insert(zonetype);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ZoneTypeDestroy([DataSourceRequest] DataSourceRequest request, ZoneType zonetype)
        {
            BL.ZoneTypes blZoneTypes = new BL.ZoneTypes();
            ZoneType model = blZoneTypes.SoftDelete(zonetype);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

    

        #endregion AJAX Actions
    }
}