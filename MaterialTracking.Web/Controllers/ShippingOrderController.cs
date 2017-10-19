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
    public class ShippingOrderController : BaseController
    {
        // GET: ShippingOrder
        public ActionResult Index()
        {
            return View();
        }


        #region AJAX Actions

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ShippingOrderSelectAll([DataSourceRequest] DataSourceRequest request)
        {
            BL.ShippingOrders blShippingOrders = new BL.ShippingOrders();
            List<ShippingOrder> model = blShippingOrders.SelectAll();
            return Json(model.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ShippingOrderUpdate([DataSourceRequest] DataSourceRequest request, ShippingOrder shippingorder)
        {
            BL.ShippingOrders blShippingOrders = new BL.ShippingOrders();
            ShippingOrder model = blShippingOrders.Update(shippingorder);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ShippingOrderCreate([DataSourceRequest] DataSourceRequest request, ShippingOrder shippingorder)
        {
            BL.ShippingOrders blShippingOrders = new BL.ShippingOrders();
            ShippingOrder model = blShippingOrders.Insert(shippingorder);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ShippingOrderDestroy([DataSourceRequest] DataSourceRequest request, ShippingOrder vendor)
        {
            BL.ShippingOrders blShippingOrders = new BL.ShippingOrders();
            ShippingOrder model = blShippingOrders.SoftDelete(vendor);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        #endregion AJAX Actions
    }
}