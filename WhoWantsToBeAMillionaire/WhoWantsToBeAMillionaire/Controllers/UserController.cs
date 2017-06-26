using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WhoWantsToBeAMillionaire.Models;
using WhoWantsToBeAMillionaire.Repositories;
using WhoWantsToBeAMillionaire.ViewModels;

namespace WhoWantsToBeAMillionaire.Controllers
{
    public class UserController : Controller
    {
        IRepository<Question> repository;
        List<Question> questionsList;
        StartViewModel model = new StartViewModel();
        static int i = 0;

        public UserController()
        {
            repository = new XmlQuestionRepository();
            questionsList = new List<Question>(repository.GetAll());
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
                return Redirect("User/Start");
            }
            return View();
        }

        public ActionResult Start()
        {
            if(Session.Keys.Count == 0)
            {
                return Redirect("Login");
            }
            model.Question = questionsList[i];
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
            if (i > questionsList.Count) {
                return Content(Url.Action("GameOver", "User"));
            }
            model.Question = questionsList[i];
            if (!String.IsNullOrEmpty(id))
            {
                if (model.Question.Answers[int.Parse(id)].isTrue == true)
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
            for(int num = 0; num < questionsList[i].Answers.Count; num++)
            {
                if (questionsList[i].Answers[num].isTrue == true)
                {
                    return num;
                }
            }
            return -1;
        }
    }
}