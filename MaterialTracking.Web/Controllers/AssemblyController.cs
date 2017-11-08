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
            BL.Assembly blAssembly = new BL.Assembly();
            List <AssemblyItem> assemblyItems = blAssembly.SelectAll();
            List <AssemblyViewModel> model = new List<AssemblyViewModel>();

            foreach (AssemblyItem item in assemblyItems)
            {
                AssemblyViewModel vm = new AssemblyViewModel
                {
                    IsActive = item.IsActive,
                    Name = item.Name,
                    AssemblyItemID = item.AssemblyItemID
                };
                model.Add(vm);
                
            }

            //Place in Viewbag for use in template
            return View(model);
        }

        #region AJAX Actions

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AssemblyItemUpdate([DataSourceRequest] DataSourceRequest request, AssemblyViewModel assemblyViewModel)
        {
            BL.Assembly blAssembly = new BL.Assembly();
            AssemblyItem item = new AssemblyItem
            {
                IsActive = assemblyViewModel.IsActive,
                Name = assemblyViewModel.Name,
                AssemblyItemID = assemblyViewModel.AssemblyItemID
            };
            blAssembly.Update(item);
            return Json(new[] { assemblyViewModel }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AssemblyItemCreate([DataSourceRequest] DataSourceRequest request, AssemblyViewModel assemblyViewModel)
        {
            BL.Assembly blAssembly = new BL.Assembly();
            AssemblyItem item = new AssemblyItem
            {
                IsActive = assemblyViewModel.IsActive,
                Name = assemblyViewModel.Name,
                AssemblyItemID = assemblyViewModel.AssemblyItemID
            };
            AssemblyItem model = blAssembly.Insert(item);
            assemblyViewModel.AssemblyItemID = item.AssemblyItemID;
            return Json(new[] { assemblyViewModel }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AssemblyItemDestroy([DataSourceRequest] DataSourceRequest request, AssemblyViewModel assemblyViewModel)
        {
            BL.Assembly blAssembly = new BL.Assembly();
            AssemblyItem item = new AssemblyItem
            {
                IsActive = assemblyViewModel.IsActive,
                Name = assemblyViewModel.Name,
                AssemblyItemID = assemblyViewModel.AssemblyItemID
            };
            blAssembly.SoftDelete(item);
            assemblyViewModel.IsActive = false;
            return Json(new[] { assemblyViewModel }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        #endregion AJAX Actions
    }
}