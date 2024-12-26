#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.Controllers.Bases;
using BLL.Services.Bases;
using BLL.Models;
using BLL.DAL;

// Generated from Custom Template.

namespace HospitalManagementMVC.Controllers
{
    public class BranchesController : MvcController
    {
        // Service injections:
        private readonly IService<Branch, BranchModel> _branchService;

        /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
        //private readonly IService<{Entity}, {Entity}Model> _{Entity}Service;

        public BranchesController(
			IService<Branch, BranchModel> branchService

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //, Service<{Entity}, {Entity}Model> {Entity}Service
        )
        {
            _branchService = branchService;

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //_{Entity}Service = {Entity}Service;
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            
            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //ViewBag.{Entity}Ids = new MultiSelectList(_{Entity}Service.Query().ToList(), "Record.Id", "Name");
        }

        // GET: Branches
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _branchService.Query().ToList();
            return View(list);
        }

        // GET: Branches/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _branchService.Query().SingleOrDefault(q => q.Record.BranchId == id);
            return View(item);
        }

        // GET: Branches/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Branches/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BranchModel branch)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                var result = _branchService.Create(branch.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = branch.Record.BranchId });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(branch);
        }

        // GET: Branches/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _branchService.Query().SingleOrDefault(q => q.Record.BranchId == id);
            SetViewData();
            return View(item);
        }

        // POST: Branches/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BranchModel branch)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                var result = _branchService.Update(branch.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = branch.Record.BranchId });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(branch);
        }

        // GET: Branches/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _branchService.Query().SingleOrDefault(q => q.Record.BranchId == id);
            return View(item);
        }

        // POST: Branches/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var result = _branchService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
