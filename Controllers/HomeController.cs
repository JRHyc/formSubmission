using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;
using formSubmission.Models;

namespace formSubmission.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(string first_name, string last_name, int age, string email, string password)
        {
            var user = new User
            {
                first_name = first_name,
                last_name = last_name,
                age = age,
                email = email,
                password = password,
            };
            if(TryValidateModel(user) == false)
            {
                ViewBag.errors = ModelState.Values;
                return View("Errors");
            }
            else
            {
                string query = $"INSERT INTO users (first_name, last_name, age, email, password, created_at, updated_at) VALUES ('{first_name}', '{last_name}', {age}, '{email}', '{password}', NOW(), NOW());";
                DbConnector.Execute(query);
                return RedirectToAction("Success");
            }
            
        }

        [HttpGet]
        [Route("success")]
        public IActionResult Success()
        {
            return View("Register");
        }
    }
}
