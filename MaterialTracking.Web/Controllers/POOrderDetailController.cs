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
    public class POOrderDetailController : Controller
    {
        // GET: POOrderDetail
        public ActionResult Index()
        {
            return View();
        }
        #region AJAX Actions

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult POOrderDetailSelectAll([DataSourceRequest] DataSourceRequest request)
        {
            BL.POOrderDetails blPO = new BL.POOrderDetails();
            List<POOrderDetail> model = blPO.SelectAll();
            return Json(model.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult POOrderDetailUpdate([DataSourceRequest] DataSourceRequest request, POOrderDetail po)
        {
            BL.POOrderDetails blPo = new BL.POOrderDetails();
            POOrderDetail model = blPo.Update(po);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult POOrderDetailCreate([DataSourceRequest] DataSourceRequest request, POOrderDetail po)
        {
            BL.POOrderDetails blPo = new BL.POOrderDetails();
            POOrderDetail model = blPo.Insert(po);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult POOrderDetailDestroy([DataSourceRequest] DataSourceRequest request, int po)
        {
            BL.POOrderDetails blPo = new BL.POOrderDetails();
            POOrderDetail model = blPo.SoftDeleteByID(po);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        #endregion AJAX Actions

    }
}