using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhoWantsToBeAMillionaire.Models;

namespace WhoWantsToBeAMillionaire.Controllers
{
    public class UserController : Controller
    {
        // GET: User  

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (user.Name != null && user.Email != null)
            {
                Session["Name"] = user.Name.ToString();
                return Redirect("User/Start");
            }
            return View();
        }

        public ActionResult Start()
        {
            return View();
        }

        //public ActionResult Results()
        //{
        //    return View();
        //}
    }
}