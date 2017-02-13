using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MyPlaza.Models;

namespace MyPlaza.Controllers
{
    public class UserController : Controller
    {

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                User res = new User(); ;

                return View("Edit", res);
            }
            catch (Exception e)
            {
                Session["Exception"] = e;
                return View("Error");
            }
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User res, FormCollection form)
        {
            try
            {
                return RedirectToAction("Admin", "Home", new { enty = "User" });
            }
            catch (Exception e)
            {
                Session["Exception"] = e;
                return View("Error");
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                User res = new User(); ;
                return RedirectToAction("Admin", "Home", new { enty = "User" });
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User res)
        {
            try
            {
                return RedirectToAction("Admin", "Home", new { enty = "User" });
            }
            catch (Exception e)
            {
                Session["Exception"] = e;
                return View("Error");
            }
        }

        // GET: User
        public ActionResult List()
        {
            try
            {
                IEnumerable<User> res = new List<User>();
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