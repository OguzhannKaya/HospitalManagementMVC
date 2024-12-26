using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.Controllers.Bases;
using BLL.Services.Bases;
using BLL.Models;
using BLL.DAL;

// Generated from Custom Template.

namespace HospitalManagementMVC.Controllers
{
    public class AppointmentsController : MvcController
    {
        // Service injections:
        private readonly IService<Appointment, AppointmentModel> _appointmentService;
        private readonly IService<Branch, BranchModel> _branchService;
        private readonly IService<Doctor, DoctorModel> _doctorService;
        private readonly IService<Patient, PatientModel> _patientService;

        /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
        //private readonly IService<{Entity}, {Entity}Model> _{Entity}Service;

        public AppointmentsController(
			IService<Appointment, AppointmentModel> appointmentService
            , IService<Branch, BranchModel> branchService
            , IService<Doctor, DoctorModel> doctorService
            , IService<Patient, PatientModel> patientService

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //, Service<{Entity}, {Entity}Model> {Entity}Service
        )
        {
            _appointmentService = appointmentService;
            _branchService = branchService;
            _doctorService = doctorService;
            _patientService = patientService;

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //_{Entity}Service = {Entity}Service;
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            ViewData["BranchId"] = new SelectList(_branchService.Query().ToList(), "Record.BranchId", "Name");
            ViewData["DoctorId"] = new SelectList(_doctorService.Query().ToList(), "Record.DoctorId", "Name");
            ViewData["PatientId"] = new SelectList(_patientService.Query().ToList(), "Record.PatientId", "Name");
            
            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //ViewBag.{Entity}Ids = new MultiSelectList(_{Entity}Service.Query().ToList(), "Record.Id", "Name");
        }

        // GET: Appointments
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _appointmentService.Query().ToList();
            return View(list);
        }

        // GET: Appointments/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _appointmentService.Query().SingleOrDefault(q => q.Record.AppointmentId == id);
            return View(item);
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Appointments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AppointmentModel appointment)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                var result = _appointmentService.Create(appointment.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = appointment.Record.AppointmentId });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _appointmentService.Query().SingleOrDefault(q => q.Record.AppointmentId == id);
            SetViewData();
            return View(item);
        }

        // POST: Appointments/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AppointmentModel appointment)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                var result = _appointmentService.Update(appointment.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = appointment.Record.AppointmentId });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _appointmentService.Query().SingleOrDefault(q => q.Record.AppointmentId == id);
            return View(item);
        }

        // POST: Appointments/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var result = _appointmentService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
