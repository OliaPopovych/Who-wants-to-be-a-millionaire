using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WhoWantsToBeAMillionaire.Repositories.Entities;

namespace WhoWantsToBeAMillionaire.Repositories
{
    public class DbStatisticsRepository : IQuestionStatisticRepository
    {
        public void SeedDatabase(bool force, List<Question> list)
        {
            using (var context = new MillionaireContext(list))
            {
                try
                {
                    context.Database.Initialize(force);
                }
                catch (Exception)
                {

                }
            }
        }

        public IList<StatisticsEntry> GetAll()
        {
            using(var context = new MillionaireContext())
            {
                return context.Set<StatisticsEntry>().ToList();
            }  
        }

        public StatisticsEntry GetById(int id)
        {
            using (var context = new MillionaireContext())
            {
                return context.Set<StatisticsEntry>().Where(s => s.QuestionID == id).FirstOrDefault();
            }
        }

        public void Add(StatisticsEntry entry)
        {
            using (var context = new MillionaireContext())
            {
                context.Entry(entry).State = EntityState.Added;
            }

        }

        public void Delete(StatisticsEntry entry)
        {
            using (var context = new MillionaireContext())
            {
                context.Entry(entry).State = EntityState.Deleted;
            }
        }

        public void Update(StatisticsEntry entry)
        {
            using (var context = new MillionaireContext())
            {
                var question = context.Questions.Where(q => q.QuestionID == entry.QuestionID)
                    .Include(q => q.Answers).FirstOrDefault();
                int i = 0;
                foreach(var child in question.Answers)
                {
                    context.Entry(child).Entity.TimesSelected = entry.Question.Answers[i++].TimesSelected;
                    context.Entry(child).State = EntityState.Modified;
                }
                context.SaveChanges();
            }
        }

        public void SaveChanges()
        {
            using (var context = new MillionaireContext())
            {
                context.SaveChanges();
            }
        }

        public StatisticsEntry GetByQuestion(Question question)
        {
            using (var context = new MillionaireContext())
            {
                if (context.Statistics.Any(s => s.QuestionID == question.QuestionID))
                {
                    return context.Statistics.Where(s => s.Question.QuestionID == question.QuestionID)
                        .Include(s=>s.Question.Answers).FirstOrDefault();
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
