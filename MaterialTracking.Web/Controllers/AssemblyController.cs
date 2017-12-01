using System;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using MaterialTracking.Types;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MaterialTracking.Web.Models;


namespace MaterialTracking.Web.Controllers
{
    public class AssemblyController : BaseController
    {
        // GET: Assembly
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditAssemblyProducts(int id)
        {

            BL.Assembly blAssembly = new BL.Assembly();
            AssemblyItem assemblyItem = blAssembly.SelectByID(id);
            ViewBag.AssemblyName = assemblyItem.Name;
            ViewBag.AssemblyItemID = id;
            return View();
        }

        #region AJAX Actions

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ProductSelectAll([DataSourceRequest] DataSourceRequest request)
        {
            BL.Products blProducts = new BL.Products();
            List<Product> model = blProducts.SelectAll().OrderBy(c => c.Name).ToList();
            return Json(model.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AssemblyItemSelectAll([DataSourceRequest] DataSourceRequest request)
        {
            BL.Assembly blAssembly = new BL.Assembly();
            List<AssemblyItem> model = blAssembly.SelectAll().OrderBy(c => c.Name).ToList();
            return Json(model.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AssemblyItemUpdate([DataSourceRequest] DataSourceRequest request, AssemblyItem assemblyItem)
        {
            BL.Assembly blAssembly = new BL.Assembly();
            blAssembly.Update(assemblyItem);
            return Json(new[] { assemblyItem }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AssemblyItemCreate([DataSourceRequest] DataSourceRequest request, AssemblyItem assemblyItem)
        {
            BL.Assembly blAssembly = new BL.Assembly();
            AssemblyItem item = new AssemblyItem
            {
                Name = assemblyItem.Name,
                IsActive = assemblyItem.IsActive
            };
            AssemblyItem model = blAssembly.Insert(item);
            assemblyItem.AssemblyItemID = model.AssemblyItemID;
            return Json(new[] { assemblyItem }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AssemblyItemDestroy([DataSourceRequest] DataSourceRequest request, AssemblyItem assemblyItem)
        {
            BL.Assembly blAssembly = new BL.Assembly();
            BL.AssemblyItemProducts blAssemblyItemProducts = new BL.AssemblyItemProducts();

            blAssembly.SoftDelete(assemblyItem);
            blAssemblyItemProducts.DeleteByAssemblyID(assemblyItem.AssemblyItemID);
            return Json(new[] { assemblyItem }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }



        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AssemblyItemProductInsert([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<AssemblyProductViewModel> assemblyProductViewModels)
        {
            BL.AssemblyItemProducts blAssemblyItemProducts = new BL.AssemblyItemProducts();
            List<AssemblyItemProduct> products = assemblyProductViewModels.Select(c => new AssemblyItemProduct
            {
                AssemblyItemID = c.AssemblyItemID,
                ProductID = c.ProductID,
                IsActive = c.IsActive,
                Quantity = c.Quantity
            }).ToList();

            var results = new List<AssemblyItemProduct>();
            foreach (AssemblyItemProduct assemblyItemProduct in products)
            {
                results.Add(blAssemblyItemProducts.Insert(assemblyItemProduct));
            }
            return Json(results.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AssemblyItemProductsSelectAll([DataSourceRequest] DataSourceRequest request, int id)
        {
            BL.AssemblyItemProducts blAssemblyItemProducts = new BL.AssemblyItemProducts();
            List<AssemblyProductViewModel> model = blAssemblyItemProducts.SelectByAssemblyID(id)
                .Select(c => new AssemblyProductViewModel
                {
                    AssemblyItemID = c.AssemblyItemID,
                    ProductID = c.ProductID,
                    ProductName = c.Product.Name,
                    Quantity = c.Quantity,
                    IsActive = c.IsActive
                }).ToList();
            return Json(model.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AssemblyItemProductsUpdate([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<AssemblyProductViewModel> assemblyProductViewModels)
        {
            BL.AssemblyItemProducts blAssemblyItemProducts = new BL.AssemblyItemProducts();
            List<AssemblyItemProduct> products = assemblyProductViewModels.Select(c => new AssemblyItemProduct
            {
                AssemblyItemID = c.AssemblyItemID,
                ProductID = c.ProductID,
                IsActive = c.IsActive,
                Quantity = c.Quantity
            }).ToList();
            foreach (AssemblyItemProduct assemblyItemProduct in products)
            {
                if (assemblyItemProduct.Quantity == 0)
                {
                    blAssemblyItemProducts.Delete(assemblyItemProduct);
                }
                else
                {
                    blAssemblyItemProducts.Update(assemblyItemProduct);
                }
                products = products.Where(c => c.Quantity > 0).ToList();  //remove the deleted items
            }
            return Json(products.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }


        #endregion AJAX Actions

    }
}