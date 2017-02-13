using System.Web.Mvc;
using MyPlaza.Models;
using System;
using System.Collections.Generic;

namespace MyPlaza.Controllers
{
    public class ReservationController : Controller
    {

        // GET: Reservation/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Reservation res = new Reservation();;

                return View("Edit", res);
            }
            catch (Exception e)
            {
                Session["Exception"] = e;
                return View("Error");
            }
        }

        // POST: Reservation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Reservation res, FormCollection form)
        {
            try
            {
                return RedirectToAction("Admin", "Home", new { enty = "Reservation" });
            }
            catch (Exception e)
            {
                Session["Exception"] = e;
                return View("Error");
            }
        }

        // GET: Reservation/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Reservation res = new Reservation();;
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
        public ActionResult Create(Reservation res)
        {
            try
            {
                return RedirectToAction("Admin", "Home", new { enty = "Reservation" });
            }
            catch (Exception e)
            {
                Session["Exception"] = e;
                return View("Error");
            }
        }

        // GET: Reservation
        public ActionResult List()
        {
            try
            {
               IEnumerable< Reservation> res = new List<Reservation>();
                if (Request.IsAjaxRequest())
                {
                    return PartialView("List",res);
                }
                else
                {
                    return View("List", res);
                }
            }
            catch (Exception e)
            {
                if (Request.IsAjaxRequest())
                {
                    Session["Exception"] = e;
                    return PartialView("Error");
                }
                Session["Exception"] = e;
                return View("Error");
            }

        }
    }

}