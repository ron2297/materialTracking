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
        //Error: OrderDetails is inacessible due to its protection level (Uncomment to see error

        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult OrderDetailSelectAll([DataSourceRequest] DataSourceRequest detail)
        //{
        //    BL.OrderDetails blOrderDetails = new BL.OrderDetails();
        //    List<OrderDetail> model = blOrderDetails.SelectAll();
        //    return Json(model.ToDataSourceResult(detail), JsonRequestBehavior.AllowGet);
        //}

        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult OrderDetailUpdate([DataSourceRequest] DataSourceRequest detail, OrderDetail OrderDetail)
        //{
        //    BL.OrderDetails blOrderDetails = new BL.OrderDetails();
        //    OrderDetail model = blOrderDetails.Update(OrderDetail);
        //    return Json(new[] { model }.ToDataSourceResult(detail, ModelState), JsonRequestBehavior.AllowGet);
        //}

        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult OrderDetailCreate([DataSourceRequest] DataSourceRequest detail, OrderDetail OrderDetail)
        //{
        //    BL.OrderDetails blOrderDetails = new BL.OrderDetails();
        //    OrderDetail model = blOrderDetails.Insert(OrderDetail);
        //    return Json(new[] { model }.ToDataSourceResult(detail, ModelState), JsonRequestBehavior.AllowGet);
        //}

        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult OrderDetailDestroy([DataSourceRequest] DataSourceRequest detail, OrderDetail OrderDetail)
        //{
        //    BL.OrderDetails blOrderDetails = new BL.OrderDetails();
        //    OrderDetail model = blOrderDetails.SoftDelete(OrderDetail);
        //    return Json(new[] { model }.ToDataSourceResult(detail, ModelState), JsonRequestBehavior.AllowGet);
        //}

        #endregion AJAX Actions
    }
}