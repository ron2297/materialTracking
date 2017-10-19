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
    public class ShippingItemController : BaseController
    {
        // GET: ShippingItem
        public ActionResult Index()
        {
            return View();
        }


        #region AJAX Actions

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ShippingItemSelectAll([DataSourceRequest] DataSourceRequest request)
        {
            BL.ShippingItems blShippingItems = new BL.ShippingItems();
            List<ShippingItem> model = blShippingItems.SelectAll();
            return Json(model.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ShippingItemUpdate([DataSourceRequest] DataSourceRequest request, ShippingItem shippingitem)
        {
            BL.ShippingItems blShippingItems = new BL.ShippingItems();
            ShippingItem model = blShippingItems.Update(shippingitem);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ShippingItemCreate([DataSourceRequest] DataSourceRequest request, ShippingItem shippingitem)
        {
            BL.ShippingItems blShippingItems = new BL.ShippingItems();
            ShippingItem model = blShippingItems.Insert(shippingitem);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ShippingItemDestroy([DataSourceRequest] DataSourceRequest request, ShippingItem vendor)
        {
            BL.ShippingItems blShippingItems = new BL.ShippingItems();
            ShippingItem model = blShippingItems.SoftDelete(vendor);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        #endregion AJAX Actions
    }
}