using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using MaterialTracking.BL;
using MaterialTracking.Types;

namespace MaterialTracking.Web.Controllers
{
    public class ShipperController : BaseController
    {
        // GET: Shipper
        public ActionResult Index()
        {
            return View();
        }


        #region AJAX Actions

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ShipperSelectAll([DataSourceRequest] DataSourceRequest request)
        {
            BL.Shippers blShippers = new BL.Shippers();
            List<Shipper> model = blShippers.SelectAll();
            return Json(model.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ShipperUpdate([DataSourceRequest] DataSourceRequest request, Shipper shipper)
        {
            BL.Shippers blShippers = new BL.Shippers();
            Shipper model = blShippers.Update(shipper);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ShipperCreate([DataSourceRequest] DataSourceRequest request, Shipper shipper)
        {
            BL.Shippers blShippers = new BL.Shippers();
            Shipper model = blShippers.Insert(shipper);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ShipperDestroy([DataSourceRequest] DataSourceRequest request, Shipper shipper)
        {
            BL.Shippers blShippers = new BL.Shippers();
            Shipper model = blShippers.SoftDelete(shipper);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        #endregion AJAX Actions
    }
}