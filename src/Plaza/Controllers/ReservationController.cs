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
    public class ReservationController : Controller
    {
        private ReservationRepository _reservationRepository;

        public ReservationController(ReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        // GET: Reservation/Edit/5
        public IActionResult Edit(ObjectId id)
        {
            try
            {
                Reservation reservation = _reservationRepository.GetById(id);

                return View("Edit", reservation);
            }
            catch (Exception e)
            {
                HttpContext.Session.SetString("Exception", e.Message);
                return View("Error");
            }
        }

        // POST: Reservation/Edit/5
        [HttpPost]
        public IActionResult Edit(int id, Reservation reservation, FormCollection form)
        {
            try
            {
                _reservationRepository.Update(reservation);
                return RedirectToAction("Admin", "Home", new { enty = "Reservation" });
            }
            catch (Exception e)
            {
                HttpContext.Session.SetString("Exception", e.Message);
                return View("Error");
            }
        }

        // GET: Reservation/Delete/5
        public IActionResult Delete(ObjectId id)
        {
            try
            {
                _reservationRepository.Remove(id);
                return RedirectToAction("Admin", "Home", new { enty = "Reservation" });
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Reservation/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Reservation/Create
        [HttpPost]
        public IActionResult Create(Reservation reservation)
        {
            try
            {
                _reservationRepository.Add(reservation);
                return RedirectToAction("Admin", "Home", new { enty = "Reservation" });
            }
            catch (Exception e)
            {
                HttpContext.Session.SetString("Exception", e.Message);
                return View("Error");
            }
        }

        // GET: Reservation
        public IActionResult List()
        {
            try
            {
                IEnumerable<Reservation> reservations = _reservationRepository.All();

                if (AjaxRequestExtensions.IsAjaxRequest(Request))
                {
                    return PartialView("List", reservations);
                }
                else
                {
                    return View("List", reservations);
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