using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TemplateRouting.Models;

namespace TemplateRouting.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int id)
        {
            Customer contact = new Customer()
            {
                id = id,
                firstName = "Chris",
                lastName = "Woodruff"
            };
            return View(contact);
        }
    }
}
