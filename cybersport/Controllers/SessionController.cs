using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cybersport.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity.Name != null)
                HttpContext.Session.SetString("sessionUser", User.Identity.Name);
            else
                ViewData["noSession"] = "Please log in";
            return View();
        }

        public IActionResult About()
        {
            ViewData["session"] = HttpContext.Session.GetString("sessionUser");
            return View();
        }
    }
}
