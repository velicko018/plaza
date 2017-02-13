using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Plaza.Helpers;
using Plaza.Models;
using Plaza.Repositories;


namespace Plaza.Controllers
{
    public class RoomController : Controller
    {
        private RoomRepository _roomRepository;

        public RoomController(RoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        // GET: Room/Edit/5
        public IActionResult Edit(ObjectId id)
        {
            try
            {
                Room room = _roomRepository.GetById(id);

                return View("Edit", room);
            }
            catch (Exception e)
            {
                HttpContext.Session.SetString("Exception", e.Message);
                return View("Error");
            }
        }

        // POST: Room/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Room room, FormCollection form)
        {
            try
            {
                _roomRepository.Update(room);

                return RedirectToAction("Admin", "Home", new { enty = "Room" });
            }
            catch (Exception e)
            {
                HttpContext.Session.SetString("Exception", e.Message);
                return View("Error");
            }
        }

        // GET: Room/Delete/5
        public ActionResult Delete(ObjectId id)
        {
            try
            {
                _roomRepository.Remove(id);

                return RedirectToAction("Admin", "Home", new { enty = "Room" });
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Room/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Room/Create
        [HttpPost]
        public ActionResult Create(Room room)
        {
            try
            {
                _roomRepository.Add(room);

                return RedirectToAction("Admin", "Home", new { enty = "Room" });
            }
            catch (Exception e)
            {
                HttpContext.Session.SetString("Exception", e.Message);
                return View("Error");
            }
        }

        // GET: Room
        public ActionResult List()
        {
            try
            {
                IEnumerable<Room> rooms = _roomRepository.All();

                if (AjaxRequestExtensions.IsAjaxRequest(Request))
                {
                    return PartialView("List", rooms);
                }
                else
                {
                    return View("List", rooms);
                }
            }
            catch (Exception e)
            {
                if (AjaxRequestExtensions.IsAjaxRequest(Request))
                {
                    HttpContext.Session.SetString("Exception", e.Message);
                    return PartialView("Error");
                }
                HttpContext.Session.SetString("Exception", e.Message);
                return View("Error");
            }

        }
    }
}
