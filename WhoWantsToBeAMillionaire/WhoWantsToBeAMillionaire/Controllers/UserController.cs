using System;
using System.Web.Mvc;
using WhoWantsToBeAMillionaire.Models;
using WhoWantsToBeAMillionaire.Services;
using WhoWantsToBeAMillionaire.ViewModels;

namespace WhoWantsToBeAMillionaire.Controllers
{
    public class UserController : Controller
    {
        static IService service;
        static StartViewModel model;
        static int i = 0;

        public UserController()
        {
        }  

        static UserController()
        {
            service = new Service("~/App_Data/questions.xml");
            model = new StartViewModel();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        { 
            if (user.Name != null && user.Email != null)
            {
                Session["Name"] = user.Name.ToString();
                Session["FiftyButtonDisabl"] = "false";
                return Redirect("User/Start");
            }
            return View();
        }

        public ActionResult Start(StartViewModel model)
        {
            if(Session.Keys.Count == 0)
            {
                return Redirect("Login");
            }
            model.Question = service.QuestionsList[i];
            return View("Start", model);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GameOver()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Start(string id)
        {
            if (i > service.QuestionsList.Count) {
                return Content(Url.Action("GameOver", "User"));
            }
            model.Question = service.QuestionsList[i];
            if (!String.IsNullOrEmpty(id))
            {
                if (int.Parse(id) == model.Question.RightAnswerId)
                {
                    i++;
                    return Content(Url.Action("Start", "User"));
                }
                else
                {
                    return Content(Url.Action("GameOver", "User"));
                }
            }
            return View("Start", model);
        }

        [HttpPost]
        public int GetFifty()
        { 
            return service.GetFifty(model.Question);
        }
    }
}