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
    public class VendorProductController : Controller
    {
        // GET: VendorProduct
        public ActionResult Index()
        {
            return View();
        }

        #region AJAX Actions

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult VendorProductSelectAll([DataSourceRequest] DataSourceRequest request)
        {
            BL.VendorProductXRefs blVendorProductXRefs= new BL.VendorProductXRefs();
            List<VendorProductXRef> model = blVendorProductXRefs.SelectAll();
            return Json(model.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult VendorProductUpdate([DataSourceRequest] DataSourceRequest request, VendorProductXRef vendorproduct)
        {
            BL.VendorProductXRefs blVendorProductXRefs= new BL.VendorProductXRefs();
            VendorProductXRef item = new VendorProductXRef
            {
                VendorID = vendorproduct.VendorID,
                ProductID = vendorproduct.ProductID,
                IsActive = vendorproduct.IsActive
            };
            VendorProductXRef model = blVendorProductXRefs.Update(item);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult VendorProductCreate([DataSourceRequest] DataSourceRequest request, VendorProductXRef vendorproduct)
        {
            BL.VendorProductXRefs blVendorProductXRefs= new BL.VendorProductXRefs();
            VendorProductXRef item = new VendorProductXRef
            {
                VendorID = vendorproduct.VendorID,
                ProductID = vendorproduct.ProductID,
                IsActive = vendorproduct.IsActive
            };
            VendorProductXRef model = blVendorProductXRefs.Insert(item);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult VendorProductDestroy([DataSourceRequest] DataSourceRequest request, VendorProductXRef vendorproduct)
        {
            BL.VendorProductXRefs blVendorProductXRefs= new BL.VendorProductXRefs();
            VendorProductXRef model = blVendorProductXRefs.SoftDelete(vendorproduct);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        #endregion AJAX Actions
    }
}