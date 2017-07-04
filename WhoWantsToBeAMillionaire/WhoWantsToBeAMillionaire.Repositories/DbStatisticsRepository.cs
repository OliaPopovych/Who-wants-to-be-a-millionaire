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

        public IList<Question> GetAll()
        {
            using(var context = new MillionaireContext())
            {
                return context.Set<Question>().ToList();
            }  
        }

        public Question GetById(int id)
        {
            using (var context = new MillionaireContext())
            {
                return context.Set<Question>().Where(s => s.QuestionID == id).FirstOrDefault();
            }
        }

        public void Add(Question entry)
        {
            using (var context = new MillionaireContext())
            {
                context.Entry(entry).State = EntityState.Added;
            }

        }

        public void Delete(Question entry)
        {
            using (var context = new MillionaireContext())
            {
                context.Entry(entry).State = EntityState.Deleted;
            }
        }

        public void Update(Question entry)
        {
            using (var context = new MillionaireContext())
            {
                var question = context.Questions.Where(q => q.QuestionID == entry.QuestionID)
                    .Include(q => q.Answers).FirstOrDefault();
                int i = 0;
                foreach(var child in question.Answers)
                {
                    context.Entry(child).Entity.TimesSelected = entry.Answers[i++].TimesSelected;
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

        public Question GetByQuestion(Question question)
        {
            using (var context = new MillionaireContext())
            {
                    return context.Questions.Where(q => q.QuestionID == question.QuestionID)
                        .Include(q => q.Answers).FirstOrDefault();
            }
        }
    }
}
