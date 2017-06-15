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

        public ActionResult Login()
        {
            return View();
        }

        //public ActionResult Login(User userName)
        //{
        //    return View();
        //}
    }
}