using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurnRed.Data;
using BurnRed.Services;
using BurnRed.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BurnRed.Controllers
{
    public class AppController : Controller
    {
        private readonly INullMailService _mailService;
        private readonly IRedRepository _repository;
       

        public AppController(INullMailService mailService,IRedRepository repository)
        {
            _mailService = mailService;
            _repository = repository;
        }
        public IActionResult Index()
        {
           return View();
        }
        [HttpGet("contact")]
        public IActionResult Contact()
        {

            ViewBag.Title = "Contact Us";
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                //email address
                _mailService.SendMessage("lisafahmidatasnim@gmail.com ", model.Subject, $"From:{model.Name}-{model.Email},Message:{model.Message}");
                ViewBag.UserMessage= "Mail Sent";
                ModelState.Clear();
            }

            else 
            { 
                //show error page 
            }
            
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About Us";
            return View();
        }

        public IActionResult Shop()
        {
            var results = _repository.GetAllProducts();
            return View(results);
        }
    }
}