using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.Controllers.Bases;
using BLL.Services.Bases;
using BLL.Models;
using BLL.DAL;

// Generated from Custom Template.

namespace HospitalManagementMVC.Controllers
{
    public class PatientsController : MvcController
    {
        // Service injections:
        private readonly IService<Patient, PatientModel> _patientService;

        /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
        //private readonly IService<{Entity}, {Entity}Model> _{Entity}Service;

        public PatientsController(
			IService<Patient, PatientModel> patientService

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //, Service<{Entity}, {Entity}Model> {Entity}Service
        )
        {
            _patientService = patientService;

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //_{Entity}Service = {Entity}Service;
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            
            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //ViewBag.{Entity}Ids = new MultiSelectList(_{Entity}Service.Query().ToList(), "Record.Id", "Name");
        }

        // GET: Patients
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _patientService.Query().ToList();
            return View(list);
        }

        // GET: Patients/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _patientService.Query().SingleOrDefault(q => q.Record.PatientId == id);
            return View(item);
        }

        // GET: Patients/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Patients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PatientModel patient)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                var result = _patientService.Create(patient.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = patient.Record.PatientId });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(patient);
        }

        // GET: Patients/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _patientService.Query().SingleOrDefault(q => q.Record.PatientId == id);
            SetViewData();
            return View(item);
        }

        // POST: Patients/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PatientModel patient)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                var result = _patientService.Update(patient.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = patient.Record.PatientId });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(patient);
        }

        // GET: Patients/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _patientService.Query().SingleOrDefault(q => q.Record.PatientId == id);
            return View(item);
        }

        // POST: Patients/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var result = _patientService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
