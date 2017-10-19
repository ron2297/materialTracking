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
    public class OrderStatuController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        #region AJAX Actions

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OrderStatusSelectAll([DataSourceRequest] DataSourceRequest request)
        {
            BL.OrderStatus blOrderStatus = new BL.OrderStatus();
            List<OrderStatu> model = blOrderStatus.SelectAll();
            return Json(model.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OrderStatuUpdate([DataSourceRequest] DataSourceRequest request, OrderStatu orderstatu)
        {
            BL.OrderStatus blOrderStatus = new BL.OrderStatus();
            OrderStatu model = blOrderStatus.Update(orderstatu);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OrderStatuCreate([DataSourceRequest] DataSourceRequest request, OrderStatu orderstatu)
        {
            BL.OrderStatus blOrderStatus = new BL.OrderStatus();
            OrderStatu model = blOrderStatus.Insert(orderstatu);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }
        /*
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OrderStatuDestroy([DataSourceRequest] DataSourceRequest request, OrderStatu orderstatu)
        {
            BL.OrderStatus blOrderStatus = new BL.OrderStatus();
            OrderStatu model = blOrderStatus.SoftDelete(orderstatu);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }
        */
        #endregion AJAX Actions
    }
}