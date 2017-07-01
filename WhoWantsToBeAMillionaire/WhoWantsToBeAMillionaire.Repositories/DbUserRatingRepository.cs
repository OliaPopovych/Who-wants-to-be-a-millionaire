using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WhoWantsToBeAMillionaire.Repositories.Entities;

namespace WhoWantsToBeAMillionaire.Repositories
{
    public class DbUserRatingRepository : IUserRatingRepository, IDisposable
    {
        private readonly MilionaireContext context;
        private bool disposed;

        public DbUserRatingRepository(MilionaireContext context)
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

        public IList<User> GetAll()
        {
            return context.Set<User>().ToList();
        }

        public User GetById(int id)
        {
            return context.Set<User>().Where(u => u.UserID == id).FirstOrDefault();
        }

        public void Add(User user)
        {
            context.Entry(user).State = EntityState.Added;
        }

        public void Delete(User user)
        {
            context.Entry(user).State = EntityState.Deleted;
        }
    }
}
