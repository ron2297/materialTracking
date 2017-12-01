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
    public class OrderRequestController : BaseController
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditOrderDetails(int id)
        {

            BL.OrderRequests blOrderRequests = new BL.OrderRequests();
            OrderRequest request = blOrderRequests.SelectByID(id);
            ViewBag.OrderRequestID = id;
            return View();
        }

        #region AJAX Actions

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OrderRequestSelectAll([DataSourceRequest] DataSourceRequest request)
        {
            BL.OrderRequests blOrderRequests = new BL.OrderRequests();
            List<OrderRequest> model = blOrderRequests.SelectAll();
            return Json(model.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OrderRequestUpdate([DataSourceRequest] DataSourceRequest request, OrderRequest OrderRequest)
        {
            BL.OrderRequests blOrderRequests = new BL.OrderRequests();
            OrderRequest model = blOrderRequests.Update(OrderRequest);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OrderRequestCreate([DataSourceRequest] DataSourceRequest request, OrderRequest OrderRequest)
        {
            BL.OrderRequests blOrderRequests = new BL.OrderRequests();
            OrderRequest model = blOrderRequests.Insert(OrderRequest);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OrderRequestDestroy([DataSourceRequest] DataSourceRequest request, OrderRequest OrderRequest)
        {
            BL.OrderRequests blOrderRequests = new BL.OrderRequests();
            OrderRequest model = blOrderRequests.SoftDelete(OrderRequest);
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        //start here for Order Details 

//        [AcceptVerbs(HttpVerbs.Post)]
//        public ActionResult ProductSelectAll([DataSourceRequest] DataSourceRequest request)
//        {
//            BL.Products blProducts = new BL.Products();
//            List<Product> model = blProducts.SelectAll().OrderBy(c => c.Name).ToList();
//            return Json(model.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
//        }

//        [AcceptVerbs(HttpVerbs.Post)]
//        public ActionResult OrderDetailsSelectAll([DataSourceRequest] DataSourceRequest request)
//        {
//            BL.OrderDetails blAssembly = new BL.OrderDetails();
//            List<OrderDetail> model = blAssembly.SelectAll().OrderBy(c => c.OrderDetailID).ToList();
//            return Json(model.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
//        }


//        [AcceptVerbs(HttpVerbs.Post)]
//        public ActionResult OrderDetailsUpdate([DataSourceRequest] DataSourceRequest request, OrderDetail order)
//        {
//            BL.OrderDetails blAssembly = new BL.OrderDetails();
//            blAssembly.Update(order);
//            return Json(new[] { order }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
//        }

//        [AcceptVerbs(HttpVerbs.Post)]
//        public ActionResult OrderDetailsCreate([DataSourceRequest] DataSourceRequest request, OrderDetail order)
//        {
//            BL.Assembly blAssembly = new BL.Assembly();
//            OrderDetail item = new OrderDetail()
//            {
//                OrderDetailID = order.OrderDetailID;
//                IsActive = order.
//            };
//            AssemblyItem model = blAssembly.Insert(item);
//            assemblyItem.AssemblyItemID = model.AssemblyItemID;
//            return Json(new[] { assemblyItem }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
//        }

//        [AcceptVerbs(HttpVerbs.Post)]
//        public ActionResult AssemblyItemDestroy([DataSourceRequest] DataSourceRequest request, AssemblyItem assemblyItem)
//        {
//            BL.Assembly blAssembly = new BL.Assembly();
//            BL.AssemblyItemProducts blAssemblyItemProducts = new BL.AssemblyItemProducts();

//            blAssembly.SoftDelete(assemblyItem);
//            blAssemblyItemProducts.DeleteByAssemblyID(assemblyItem.AssemblyItemID);
//            return Json(new[] { assemblyItem }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
//        }



//        [AcceptVerbs(HttpVerbs.Post)]
//        public ActionResult AssemblyItemProductInsert([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<AssemblyProductViewModel> assemblyProductViewModels)
//        {
//            BL.AssemblyItemProducts blAssemblyItemProducts = new BL.AssemblyItemProducts();
//            List<AssemblyItemProduct> products = assemblyProductViewModels.Select(c => new AssemblyItemProduct
//            {
//                AssemblyItemID = c.AssemblyItemID,
//                ProductID = c.ProductID,
//                IsActive = c.IsActive,
//                Quantity = c.Quantity
//            }).ToList();

//            var results = new List<AssemblyItemProduct>();
//            foreach (AssemblyItemProduct assemblyItemProduct in products)
//            {
//                results.Add(blAssemblyItemProducts.Insert(assemblyItemProduct));
//            }
//            return Json(results.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
//        }

//        [AcceptVerbs(HttpVerbs.Post)]
//        public ActionResult AssemblyItemProductsSelectAll([DataSourceRequest] DataSourceRequest request, int id)
//        {
//            BL.AssemblyItemProducts blAssemblyItemProducts = new BL.AssemblyItemProducts();
//            List<AssemblyProductViewModel> model = blAssemblyItemProducts.SelectByAssemblyID(id)
//                .Select(c => new AssemblyProductViewModel
//                {
//                    AssemblyItemID = c.AssemblyItemID,
//                    ProductID = c.ProductID,
//                    ProductName = c.Product.Name,
//                    Quantity = c.Quantity,
//                    IsActive = c.IsActive
//                }).ToList();
//            return Json(model.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
//        }

//        [AcceptVerbs(HttpVerbs.Post)]
//        public ActionResult AssemblyItemProductsUpdate([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<AssemblyProductViewModel> assemblyProductViewModels)
//        {
//            BL.AssemblyItemProducts blAssemblyItemProducts = new BL.AssemblyItemProducts();
//            List<AssemblyItemProduct> products = assemblyProductViewModels.Select(c => new AssemblyItemProduct
//            {
//                AssemblyItemID = c.AssemblyItemID,
//                ProductID = c.ProductID,
//                IsActive = c.IsActive,
//                Quantity = c.Quantity
//            }).ToList();
//            foreach (AssemblyItemProduct assemblyItemProduct in products)
//            {
//                if (assemblyItemProduct.Quantity == 0)
//                {
//                    blAssemblyItemProducts.Delete(assemblyItemProduct);
//                }
//                else
//                {
//                    blAssemblyItemProducts.Update(assemblyItemProduct);
//                }
//                products = products.Where(c => c.Quantity > 0).ToList();  //remove the deleted items
//            }
//            return Json(products.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
//        }


//        #endregion AJAX Actions

//    }
//}

        #endregion AJAX Actions

    }
}