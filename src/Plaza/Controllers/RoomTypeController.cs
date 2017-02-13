using System;
using System.Collections.Generic;
using MyPlaza.Models;
using System.Web.Mvc;

namespace MyPlaza.Controllers
{
    public class RoomTypeController : Controller
    {

        // GET: RoomType/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                RoomType res = new RoomType(); ;

                return View("Edit", res);
            }
            catch (Exception e)
            {
                Session["Exception"] = e;
                return View("Error");
            }
        }

        // POST: RoomType/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, RoomType res, FormCollection form)
        {
            try
            {
                return RedirectToAction("Admin", "Home", new { enty = "RoomType" });
            }
            catch (Exception e)
            {
                Session["Exception"] = e;
                return View("Error");
            }
        }

        // GET: RoomType/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                RoomType res = new RoomType(); ;
                return RedirectToAction("Admin", "Home", new { enty = "RoomType" });
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: RoomType/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: RoomType/Create
        [HttpPost]
        public ActionResult Create(RoomType res)
        {
            try
            {
                return RedirectToAction("Admin", "Home", new { enty = "RoomType" });
            }
            catch (Exception e)
            {
                Session["Exception"] = e;
                return View("Error");
            }
        }

        // GET: RoomType
        public ActionResult List()
        {
            try
            {
                IEnumerable<RoomType> res = new List<RoomType>();
                if (Request.IsAjaxRequest())
                {
                    return PartialView("List", res);
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