using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.Controllers.Bases;
using BLL.Services.Bases;
using BLL.Models;
using BLL.DAL;

// Generated from Custom Template.

namespace HospitalManagementMVC.Controllers
{
    public class RoomsController : MvcController
    {
        // Service injections:
        private readonly IService<Room, RoomModel> _roomService;

        /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
        //private readonly IService<{Entity}, {Entity}Model> _{Entity}Service;

        public RoomsController(
			IService<Room, RoomModel> roomService

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //, Service<{Entity}, {Entity}Model> {Entity}Service
        )
        {
            _roomService = roomService;

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //_{Entity}Service = {Entity}Service;
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            
            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //ViewBag.{Entity}Ids = new MultiSelectList(_{Entity}Service.Query().ToList(), "Record.Id", "Name");
        }

        // GET: Rooms
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _roomService.Query().ToList();
            return View(list);
        }

        // GET: Rooms/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _roomService.Query().SingleOrDefault(q => q.Record.RoomID == id);
            return View(item);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Rooms/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RoomModel room)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                var result = _roomService.Create(room.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = room.Record.RoomID });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(room);
        }

        // GET: Rooms/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _roomService.Query().SingleOrDefault(q => q.Record.RoomID == id);
            SetViewData();
            return View(item);
        }

        // POST: Rooms/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RoomModel room)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                var result = _roomService.Update(room.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = room.Record.RoomID });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(room);
        }

        // GET: Rooms/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _roomService.Query().SingleOrDefault(q => q.Record.RoomID == id);
            return View(item);
        }

        // POST: Rooms/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var result = _roomService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
