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
    public class OrderRequestController : BaseController
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Hello()
        {
            return View();
        }

        #region AJAX Actions

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OrderRequestSelectAll([DataSourceRequest] DataSourceRequest request)
        {
            BL.OrderRequests blOrderRequests = new BL.OrderRequests();
            List<OrderRequest> model = blOrderRequests.SelectAll();
            return Json(model.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OrderRequestUpdate([DataSourceRequest] DataSourceRequest request, OrderRequest OrderRequest)
        {
            BL.OrderRequests blOrderRequests = new BL.OrderRequests();
            OrderRequest model = blOrderRequests.Update(OrderRequest);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OrderRequestCreate([DataSourceRequest] DataSourceRequest request, OrderRequest OrderRequest)
        {
            BL.OrderRequests blOrderRequests = new BL.OrderRequests();
            OrderRequest model = blOrderRequests.Insert(OrderRequest);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OrderRequestDestroy([DataSourceRequest] DataSourceRequest request, OrderRequest OrderRequest)
        {
            BL.OrderRequests blOrderRequests = new BL.OrderRequests();
            OrderRequest model = blOrderRequests.SoftDelete(OrderRequest);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        #endregion AJAX Actions

    }
}