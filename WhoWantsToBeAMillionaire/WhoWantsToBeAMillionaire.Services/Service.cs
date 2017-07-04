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
        private static Random rand = new Random();
        private List<Question> questionsList;
        public List<Question> QuestionsList
        {
            get
            {
                if (questionsList == null)
                {
                    questionsList = new List<Question>(questionRepository.GetAll());
                }
                return questionsList;
            }
        }

        public Service(string questionSource)
        {
            questionRepository = new XmlQuestionRepository(questionSource);
            statisticRepository = new DbStatisticsRepository();
            userRepository = new DbUserRatingRepository();
            SeedDataBase();           
        }

        private void SeedDataBase()
        {
            statisticRepository.SeedDatabase(false, QuestionsList);
        }

        public void LogAnswer(Question question, int answerId)
        {
            var entry = statisticRepository.GetByQuestion(question);

            if (entry != null)
            {
                entry.Answers[answerId].TimesSelected++;
                statisticRepository.Update(entry);
            }
            else
            {
                statisticRepository.Add(new Question(question));
            }
        }

        private int GetRandomOption(Question question)
        {
            int numb;
            while ((numb = rand.Next(0, 3)) == question.RightAnswerId);
            return numb;
        }

        private int GetOptionFromStatistic(Question question)
        {
            var entry = statisticRepository.GetByQuestion(question);
            if(entry != null)
            {
                int minIndex, i;

                if(question.RightAnswerId == 0)
                {
                    minIndex = 1;
                    i = 2;
                }
                else
                {
                    minIndex = 0;
                    i = 1;
                }

                for(; i < entry.Answers.Count; i++)
                {
                    if(question.RightAnswerId == i)
                    {
                        continue;
                    }
                    if(entry.Answers[i].TimesSelected < entry.Answers[minIndex].TimesSelected)
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
            if(statisticRepository.GetByQuestion(question).IsAnswersListEmpty() == true)
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
