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
    public class VendorController : BaseController
    {
        // GET: Vendor
        public ActionResult Index()
        {
            return View();
        }


        #region AJAX Actions

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult VendorSelectAll([DataSourceRequest] DataSourceRequest request)
        {
            BL.Vendors blVendors = new BL.Vendors();
            List<Vendor> model = blVendors.SelectAll();
            return Json(model.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult VendorUpdate([DataSourceRequest] DataSourceRequest request, Vendor vendor)
        {
            BL.Vendors blVendors = new BL.Vendors();
            Vendor model = blVendors.Update(vendor);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult VendorCreate([DataSourceRequest] DataSourceRequest request, Vendor vendor)
        {
            BL.Vendors blVendors = new BL.Vendors();
            Vendor model = blVendors.Insert(vendor);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult VendorDestroy([DataSourceRequest] DataSourceRequest request, Vendor vendor)
        {
            BL.Vendors blVendors = new BL.Vendors();
            Vendor model = blVendors.SoftDelete(vendor);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        #endregion AJAX Actions
    }
}