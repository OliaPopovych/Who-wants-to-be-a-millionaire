using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
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
            set
            {
                questionsList = value;
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
                entry.Question.Answers[answerId].TimesSelected++;
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

                for(; i < entry.Question.Answers.Count; i++)
                {
                    if(question.RightAnswerId == i)
                    {
                        continue;
                    }
                    if(entry.Question.Answers[i].TimesSelected < entry.Question.Answers[minIndex].TimesSelected)
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
            if(statisticRepository.GetByQuestion(question).Question.IsAnswersListEmpty() == true)
            {
                return GetRandomOption(question);
            }
            else
            {
                return GetOptionFromStatistic(question);
            }
        }

        public string SendMail(string From, string To, string Text)
        {
            try
            {
                var message = new MailMessage();
                message.From = new MailAddress(From);
                message.To.Add(To);
                message.Body = Text;
                message.Subject = "Millionaire game help";

                using (var smtp = new SmtpClient())
                {
                    smtp.Credentials = new NetworkCredential("usermail127@gmail.com", "12345qwe");
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Send(message);
                }
                return "success";
            } catch(Exception e)
            {
                return e.Message;
            }
        }

        public string FormMailText(int id)
        {
            var temp = new StringBuilder();
            temp.Append("Привіт. Допоможи з відповіддю\n");
            temp.Append(questionsList[id].Text);
            temp.Append("\nВаріанти:\n");
            temp.Append(questionsList[id].Answers[0].Text + "\n");
            temp.Append(questionsList[id].Answers[1].Text + "\n");
            temp.Append(questionsList[id].Answers[2].Text + "\n");
            temp.Append(questionsList[id].Answers[3].Text);
            return temp.ToString();
        }
    }
}
