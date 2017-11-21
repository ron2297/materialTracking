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
    public class OrderDetailController : Controller
    {
        // GET: OrderDetail
        public ActionResult Index()
        {
            return View();
        }
        #region AJAX Actions

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OrderDetailSelectAll([DataSourceRequest] DataSourceRequest request)
        {
            BL.OrderDetails blOrderDetails = new BL.OrderDetails();
            List<OrderDetail> model = blOrderDetails.SelectAll();
            return Json(model.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OrderDetailUpdate([DataSourceRequest] DataSourceRequest request, OrderDetail location)
        {
            BL.OrderDetails blOrderDetails = new BL.OrderDetails();
            OrderDetail model = blOrderDetails.Update(location);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OrderDetailCreate([DataSourceRequest] DataSourceRequest request, OrderDetail location)
        {
            BL.OrderDetails blOrderDetails = new BL.OrderDetails();
            OrderDetail model = blOrderDetails.Insert(location);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OrderDetailDestroy([DataSourceRequest] DataSourceRequest request, OrderDetail location)
        {
            BL.OrderDetails blOrderDetails = new BL.OrderDetails();
            OrderDetail model = blOrderDetails.SoftDelete(location);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }


        #endregion AJAX Actions
    }
}