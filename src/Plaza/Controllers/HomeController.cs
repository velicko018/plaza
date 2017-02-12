using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plaza.Models;
using Plaza.Repositories;


namespace Plaza.Controllers
{
    public class HomeController : Controller
    {
        private UserRepository _userRepository;

        public HomeController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                _userRepository.Add(user);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login user)
        {
            if (ModelState.IsValid)
            {
                User tmpUser = _userRepository.GetUser(user.Email, user.Password);
                HttpContext.Session.SetString("ID", tmpUser.Id.ToString());
                HttpContext.Session.SetString("ADMIN", tmpUser.Admin.ToString());

                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }

        public IActionResult Logout()
        {
                HttpContext.Session.Clear();

                return RedirectToAction("Index");
        }

        public IActionResult Booking()
        {
            return View();
        }

        public IActionResult Rooms()
        {
            return View();
        }

        public IActionResult Room()
        {
            return View();
        }

        public IActionResult Gallery()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
