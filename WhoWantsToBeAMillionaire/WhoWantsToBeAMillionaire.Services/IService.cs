using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoWantsToBeAMillionaire.Repositories;
using WhoWantsToBeAMillionaire.Repositories.Entities;

namespace WhoWantsToBeAMillionaire.Services
{
    public interface IService
    {
        List<Question> QuestionsList { get; set; } 
        void LogAnswer(Question question, int answerId);
        int GetFifty(Question question);
        void AddUserToDataBase(string name, string achivedSum);
        IList<User> GetUsersList();
        string SendMail(string From, string To, string Text);
        string FormMailText(int id);
    }
}
