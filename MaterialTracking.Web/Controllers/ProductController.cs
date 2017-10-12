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
    public class ProductController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        #region AJAX Actions

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ProductSelectAll([DataSourceRequest] DataSourceRequest request)
        {
            BL.Products blProducts = new BL.Products();
            List<Product> model = blProducts.SelectAll();
            return Json(model.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ProductUpdate([DataSourceRequest] DataSourceRequest request, Product product)
        {
            BL.Products blProducts = new BL.Products();
            Product model = blProducts.Update(product);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ProductCreate([DataSourceRequest] DataSourceRequest request, Product product)
        {
            BL.Products blProducts = new BL.Products();
            Product model = blProducts.Insert(product);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ProductDestroy([DataSourceRequest] DataSourceRequest request, Product product)
        {
            BL.Products blProducts = new BL.Products();
            Product model = blProducts.SoftDelete(product);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        #endregion AJAX Actions
    }
}