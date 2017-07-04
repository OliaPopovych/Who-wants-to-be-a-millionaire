using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WhoWantsToBeAMillionaire.Repositories.Entities;

namespace WhoWantsToBeAMillionaire.Repositories
{
    public class DbUserRatingRepository : IUserRatingRepository
    {
        public IList<User> GetAll()
        {
            using (var context = new MillionaireContext())
            {
                return context.Set<User>().ToList();
            }
        }

        public User GetById(int id)
        {
            using (var context = new MillionaireContext())
            {
                return context.Set<User>().Where(u => u.UserID == id).FirstOrDefault();
            }
        }

        public void Add(User user)
        {
            using (var context = new MillionaireContext())
            {
                context.Entry(user).State = EntityState.Added;
            }
        }

        public void Delete(User user)
        {
            using (var context = new MillionaireContext())
            {
                context.Entry(user).State = EntityState.Deleted;
            }
        }
    }
}
