using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoWantsToBeAMillionaire.Repositories;

namespace WhoWantsToBeAMillionaire.Services
{
    public interface IService
    {
        void LogAnswer(Question question, int answerId);
        int GetRightAnswer(Question question);
        int GetRandomOption(Question question);
        int GetOptionFromStatistic(Question question);
        void AddUserToDataBase(string name, int achivedSum);
    }
}
