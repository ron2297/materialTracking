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
    public class POOrderController : Controller
    {
        // GET: POOrder
        public ActionResult Index()
        {
            return View();
        }
        #region AJAX Actions

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult POOrderSelectAll([DataSourceRequest] DataSourceRequest request)
        {
            BL.POOrderDetails blPO = new BL.POOrderDetails();
            List<POOrderDetail> model = blPO.SelectAll();
            return Json(model.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult POOrderUpdate([DataSourceRequest] DataSourceRequest request, POOrderDetail po)
        {
            BL.POOrderDetails blVendors = new BL.POOrderDetails();
            POOrderDetail model = blVendors.Update(po);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult POOrderCreate([DataSourceRequest] DataSourceRequest request, POOrderDetail po)
        {
            BL.POOrderDetails blVendors = new BL.POOrderDetails();
            POOrderDetail model = blVendors.Insert(po);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult POOrderDestroy([DataSourceRequest] DataSourceRequest request, int po)
        {
            BL.POOrderDetails blVendors = new BL.POOrderDetails();
            POOrderDetail model = blVendors.SoftDeleteByID(po);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        #endregion AJAX Actions

    }
}