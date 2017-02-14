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
    public class UserController : Controller
    {
        private UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        // GET: User/Edit/5
        public IActionResult Edit(string id)
        {
            try
            {
                User user = _userRepository.GetById(ObjectId.Parse(id));

                return View("Edit", user);
            }
            catch (Exception e)
            {
                HttpContext.Session.SetString("Exception", e.Message);
                return View("Error");
            }
        }

        // POST: User/Edit/5
        [HttpPost]
        public IActionResult Edit(int id, User user, FormCollection form)
        {
            try
            {
                _userRepository.Update(user);

                return RedirectToAction("Admin", "Home", new { MODEL = "User" });
            }
            catch (Exception e)
            {
                HttpContext.Session.SetString("Exception", e.Message);
                return View("Error");
            }
        }

        // GET: User/Delete/5
        public IActionResult Delete(string id)
        {
            try
            {
                _userRepository.Remove(ObjectId.Parse(id));

                return RedirectToAction("Admin", "Home", new { });
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View("Create");
        }

        // POST: User/Create
        [HttpPost]
        public IActionResult Create(User user)
        {
            try
            {
                _userRepository.Add(user);

                return RedirectToAction("Admin", "Home", new { MODEL = "User" });
            }
            catch (Exception e)
            {
                HttpContext.Session.SetString("Exception", e.Message);
                return View("Error");
            }
        }

        // GET: User
        public IActionResult List()
        {
            try
            {
                IEnumerable<User> users = _userRepository.All();

                if (AjaxRequestExtensions.IsAjaxRequest(Request))
                {
                    return PartialView("List", users);
                }
                else
                {
                    return View("List", users);
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