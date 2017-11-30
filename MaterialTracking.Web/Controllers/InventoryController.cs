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
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult Index()
        {
            return View();
        }


        #region AJAX Actions

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult InventorySelectAll([DataSourceRequest] DataSourceRequest request)
        {
            BL.InventoryClass blInventoryClass = new BL.InventoryClass();
            List<Inventory> model = blInventoryClass.SelectAll();
            return Json(model.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult InventoryUpdate([DataSourceRequest] DataSourceRequest request, Inventory inventory)
        {
            BL.InventoryClass blInventoryClass = new BL.InventoryClass();
            Inventory model = blInventoryClass.Update(inventory);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult InventoryCreate([DataSourceRequest] DataSourceRequest request, Inventory inventory)
        {
            BL.InventoryClass blInventoryClass = new BL.InventoryClass();
            Inventory model = blInventoryClass.Insert(inventory);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult InventoryDestroy([DataSourceRequest] DataSourceRequest request, Inventory inventory)
        {
            BL.InventoryClass blInventoryClass = new BL.InventoryClass();
            Inventory model = blInventoryClass.SoftDelete(inventory);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        #endregion AJAX Actions




    }
}