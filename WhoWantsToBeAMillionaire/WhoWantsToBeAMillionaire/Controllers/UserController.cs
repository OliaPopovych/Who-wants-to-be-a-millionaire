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
            model = new StartViewModel();
            service = new Service("~/App_Data/questions.xml");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        { 
            if (user.Name != null)
            {
                Session["Name"] = user.Name.ToString();
                Session["FiftyButtonDisabl"] = false;
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
        public ActionResult GameOver()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Statistics()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AnswerSelected(string id)
        {
            if (i > service.QuestionsList.Count) {
                return Content(Url.Action("GameOver", "User"));
            }
            model.Question = service.QuestionsList[i];
            if (!String.IsNullOrEmpty(id))
            {
                if (int.Parse(id) == model.Question.RightAnswerId)
                {
                    service.LogAnswer(model.Question, int.Parse(id));
                    i++;
                    return Content(Url.Action("Start", "User"));
                }
                else
                {
                    service.LogAnswer(model.Question, int.Parse(id));
                    // service.AddUserToDataBase(Session["Name"].ToString(), int.Parse(Session["Sum"].ToString()));
                    return Content(Url.Action("GameOver", "User"));
                }
            }
            return View("Start", model);
        }

        [HttpPost]
        public int GetFifty()
        {
            Session["FiftyButtonDisabl"] = true;
            return service.GetFifty(service.QuestionsList[i]);
        }

        public ActionResult EmailDialog()
        {
            return PartialView("EmailForm");
        }
    }
}