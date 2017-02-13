using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Plaza.Helpers;
using Plaza.Models;
using Plaza.Repositories;

namespace Plaza.Controllers
{
    public class RoomTypeController : Controller
    {
        private RoomTypeRepository _roomTypeRepository;

        public RoomTypeController(RoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }

        // GET: RoomType/Edit/5
        public IActionResult Edit(ObjectId id)
        {
            try
            {
                RoomType roomType = _roomTypeRepository.GetById(id); ;

                return View("Edit", roomType);
            }
            catch (Exception e)
            {
                HttpContext.Session.SetString("Exception", e.Message);
                return View("Error");
            }
        }

        // POST: RoomType/Edit/5
        [HttpPost]
        public IActionResult Edit(int id, RoomType roomType, FormCollection form)
        {
            try
            {
                _roomTypeRepository.Update(roomType);

                return RedirectToAction("Admin", "Home", new { enty = "RoomType" });
            }
            catch (Exception e)
            {
                HttpContext.Session.SetString("Exception", e.Message);
                return View("Error");
            }
        }

        // GET: RoomType/Delete/5
        public IActionResult Delete(ObjectId id)
        {
            try
            {
                _roomTypeRepository.Remove(id);

                return RedirectToAction("Admin", "Home", new { enty = "RoomType" });
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: RoomType/Create
        public IActionResult Create()
        {
            return View("Create");
        }

        // POST: RoomType/Create
        [HttpPost]
        public IActionResult Create(RoomType roomType)
        {
            try
            {
                _roomTypeRepository.Add(roomType);

                return RedirectToAction("Admin", "Home", new { enty = "RoomType" });
            }
            catch (Exception e)
            {
                HttpContext.Session.SetString("Exception", e.Message);
                return View("Error");
            }
        }

        // GET: RoomType
        public IActionResult List()
        {
            try
            {
                IEnumerable<RoomType> roomTypes = _roomTypeRepository.All();

                if (AjaxRequestExtensions.IsAjaxRequest(Request))
                {
                    return PartialView("List", roomTypes);
                }
                else
                {
                    return View("List", roomTypes);
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