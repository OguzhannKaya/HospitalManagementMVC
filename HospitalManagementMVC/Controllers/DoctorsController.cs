using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.Controllers.Bases;
using BLL.Services.Bases;
using BLL.Models;
using BLL.DAL;

// Generated from Custom Template.

namespace HospitalManagementMVC.Controllers
{
    public class DoctorsController : MvcController
    {
        // Service injections:
        private readonly IService<Doctor, DoctorModel> _doctorService;
        private readonly IService<Branch, BranchModel> _branchService;
        private readonly IService<Room, RoomModel> _roomService;

        /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
        //private readonly IService<{Entity}, {Entity}Model> _{Entity}Service;

        public DoctorsController(
			IService<Doctor, DoctorModel> doctorService
            , IService<Branch, BranchModel> branchService
            , IService<Room, RoomModel> roomService

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //, Service<{Entity}, {Entity}Model> {Entity}Service
        )
        {
            _doctorService = doctorService;
            _branchService = branchService;
            _roomService = roomService;

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //_{Entity}Service = {Entity}Service;
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            ViewData["BranchId"] = new SelectList(_branchService.Query().ToList(), "Record.BranchId", "Name");
            ViewData["RoomId"] = new SelectList(_roomService.Query().ToList(), "Record.RoomID", "Number");

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //ViewBag.{Entity}Ids = new MultiSelectList(_{Entity}Service.Query().ToList(), "Record.Id", "Name");
        }

        // GET: Doctors
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _doctorService.Query().ToList();
            return View(list);
        }

        // GET: Doctors/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _doctorService.Query().SingleOrDefault(q => q.Record.DoctorId == id);
            return View(item);
        }

        // GET: Doctors/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Doctors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DoctorModel doctor)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                var result = _doctorService.Create(doctor.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = doctor.Record.DoctorId });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(doctor);
        }

        // GET: Doctors/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _doctorService.Query().SingleOrDefault(q => q.Record.DoctorId == id);
            SetViewData();
            return View(item);
        }

        // POST: Doctors/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DoctorModel doctor)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                var result = _doctorService.Update(doctor.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = doctor.Record.DoctorId });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(doctor);
        }

        // GET: Doctors/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _doctorService.Query().SingleOrDefault(q => q.Record.DoctorId == id);
            return View(item);
        }

        // POST: Doctors/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var result = _doctorService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
