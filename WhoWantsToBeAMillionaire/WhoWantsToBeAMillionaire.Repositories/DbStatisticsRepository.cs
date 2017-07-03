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
                context.Database.Initialize(force);
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
                var oldEntry = context.Statistics.Where(e => e.QuestionID == entry.QuestionID).FirstOrDefault();
                context.Entry(oldEntry).CurrentValues.SetValues(entry);
                // context.Entry(oldEntry).State = EntityState.Modified;
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
                    return context.Statistics.Where(s => s.Question.QuestionID == question.QuestionID).Include(s=>s.Question).FirstOrDefault();
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
