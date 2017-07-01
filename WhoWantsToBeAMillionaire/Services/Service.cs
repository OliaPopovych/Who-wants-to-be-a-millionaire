using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoWantsToBeAMillionaire.Repositories;
using WhoWantsToBeAMillionaire.Repositories.Entities;

namespace WhoWantsToBeAMillionaire.Services
{
    public class Service : IService
    {
        private readonly IQuestionStatisticRepository statisticRepository;
        private readonly IUserRatingRepository userRepository;
        private readonly IQuestionRepository questionRepository;
        private static Random rand = new Random();

        public Service(string questionSource)
        {
            statisticRepository = new DbStatisticsRepository(new MilionaireContext);
            userRepository = new DbUserRatingRepository(new MilionaireContext);
            questionRepository = new XmlQuestionRepository("~/App_Data/questions.xml");
        }

        public void LogAnswer(Question question, int answerId)
        {
            var entry = statisticRepository.GetByQuestion(question);

            if (entry != null)
            {
                entry.CountAnswersForQuestion[answerId] += 1;
                statisticRepository.Update(entry);
            }
            else
            {
                statisticRepository.Add(new StatisticsEntry(question));
            }
        }

        public int GetRightAnswer(Question question)
        {
            for(int i = 0; i < question.Answers.Count; i++)
            {
                if(question.Answers[i].isTrue == true)
                {
                    return i;
                }
            }
            return -1;
        }

        public int GetRandomOption(Question question)
        {
            int numb;
            while ((numb = rand.Next(0, 3)) != GetRightAnswer(question));
            return numb;
        }

        public int GetOptionFromStatistic(Question question)
        {
            var entry = statisticRepository.GetByQuestion(question);
            if(entry != null)
            {
                int minIndex = 0;
                for(int i = 0; i < entry.CountAnswersForQuestion.Count; i++)
                {
                    if(GetRightAnswer(question) == i)
                    {
                        if(i == 0)
                        {
                            minIndex = 1;
                        }
                        continue;
                    }
                    if(entry.CountAnswersForQuestion[i] < entry.CountAnswersForQuestion[minIndex])
                    {
                        minIndex = i;
                    }
                }
                return minIndex;
            }
            return -1;
        }

        public void AddUserToDataBase(string name, int achivedSum)
        {

            userRepository.Add(new User(name, achivedSum));
        }
    }
}
