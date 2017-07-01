using System;
using System.Collections.Generic;
using WhoWantsToBeAMillionaire.Repositories;
using WhoWantsToBeAMillionaire.Repositories.Entities;

namespace WhoWantsToBeAMillionaire.Services
{
    public class Service : IService
    {
        private readonly IQuestionStatisticRepository statisticRepository;
        private readonly IUserRatingRepository userRepository;
        private readonly IQuestionRepository questionRepository;
        public List<Question> QuestionsList { get; set; }
        private static Random rand = new Random();

        public Service(string questionSource)
        {
            statisticRepository = new DbStatisticsRepository(new MilionaireContext());
            userRepository = new DbUserRatingRepository(new MilionaireContext());
            questionRepository = new XmlQuestionRepository(questionSource);
            QuestionsList = new List<Question>(questionRepository.GetAll());
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

        private int GetRandomOption(Question question)
        {
            int numb;
            while ((numb = rand.Next(0, 3)) != question.RightAnswerId);
            return numb;
        }

        private int GetOptionFromStatistic(Question question)
        {
            var entry = statisticRepository.GetByQuestion(question);
            if(entry != null)
            {
                int minIndex = 0;
                for(int i = 0; i < entry.CountAnswersForQuestion.Count; i++)
                {
                    if(question.RightAnswerId == i)
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

        public int GetFifty(Question question)
        {
            if(statisticRepository.GetByQuestion(question) == null)
            {
                return GetRandomOption(question);
            }
            else
            {
                return GetOptionFromStatistic(question);
            }
        }
    }
}
