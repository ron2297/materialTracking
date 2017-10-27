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
        public ActionResult VendorProductXRefSelectAll([DataSourceRequest] DataSourceRequest request)
        {
            BL.VendorProductXRefs blVendorProductXRefs= new BL.VendorProductXRefs();
            List<VendorProductXRef> model = blVendorProductXRefs.SelectAll();
            return Json(model.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult VendorProductXRefUpdate([DataSourceRequest] DataSourceRequest request, VendorProductXRef vendor)
        {
            BL.VendorProductXRefs blVendorProductXRefs= new BL.VendorProductXRefs();
            VendorProductXRef model = blVendorProductXRefs.Update(vendor);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult VendorProductXRefCreate([DataSourceRequest] DataSourceRequest request, VendorProductXRef vendor)
        {
            BL.VendorProductXRefs blVendorProductXRefs= new BL.VendorProductXRefs();
            VendorProductXRef model = blVendorProductXRefs.Insert(vendor);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult VendorProductXRefDestroy([DataSourceRequest] DataSourceRequest request, VendorProductXRef vendor)
        {
            BL.VendorProductXRefs blVendorProductXRefs= new BL.VendorProductXRefs();
            VendorProductXRef model = blVendorProductXRefs.SoftDelete(vendor);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        #endregion AJAX Actions
    }
}