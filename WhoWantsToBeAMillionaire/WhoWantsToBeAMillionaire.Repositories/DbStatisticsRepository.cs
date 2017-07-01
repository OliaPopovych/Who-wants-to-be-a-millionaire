using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WhoWantsToBeAMillionaire.Repositories.Entities;

namespace WhoWantsToBeAMillionaire.Repositories
{
    public class DbStatisticsRepository : IQuestionStatisticRepository, IDisposable
    {
        private readonly MilionaireContext context;
        private bool disposed;

        public DbStatisticsRepository(MilionaireContext context)
        {
            this.context = context;
        }

        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }

             disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IList<StatisticsEntry> GetAll()
        {
            return context.Set<StatisticsEntry>().ToList();
        }

        public StatisticsEntry GetById(int id)
        {
            return context.Set<StatisticsEntry>().Where(s => s.EntryID == id).FirstOrDefault();
        }

        public void Add(StatisticsEntry entry)
        {
            context.Entry(entry).State = EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(StatisticsEntry entry)
        {
            context.Entry(entry).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void Update(StatisticsEntry entry)
        {
            context.Entry(entry).State = EntityState.Modified;
            context.SaveChanges();
        }

        public StatisticsEntry GetByQuestion(Question question)
        {
            return context.Set<StatisticsEntry>().Where(s => s.Question == question).FirstOrDefault();
        }
    }
}
