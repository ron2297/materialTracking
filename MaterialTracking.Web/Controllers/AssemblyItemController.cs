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
    public class AssemblyItemController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        #region AJAX Actions

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ProductSelectAll([DataSourceRequest] DataSourceRequest request)
        {
            BL.AssemblyItems blProducts = new BL.AssemblyItems();
            List<AssemblyItem> model = blProducts.SelectAll();
            return Json(model.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ProductUpdate([DataSourceRequest] DataSourceRequest request, AssemblyItem assemblyItem)
        {
            BL.AssemblyItems blProducts = new BL.AssemblyItems();
            AssemblyItem model = blProducts.Update(assemblyItem);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ProductCreate([DataSourceRequest] DataSourceRequest request, AssemblyItem assemblyItem)
        {
            BL.AssemblyItems blProducts = new BL.AssemblyItems();
            AssemblyItem model = blProducts.Insert(assemblyItem);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ProductDestroy([DataSourceRequest] DataSourceRequest request, AssemblyItem assemblyItem)
        {
            BL.AssemblyItems blProducts = new BL.AssemblyItems();
            AssemblyItem model = blProducts.SoftDelete(assemblyItem);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        #endregion AJAX Actions
    }
}