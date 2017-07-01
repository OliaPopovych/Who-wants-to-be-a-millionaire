using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoWantsToBeAMillionaire.Repositories.Entities
{
    public class MilionaireContext : DbContext
    {
        public MilionaireContext() : base("name=MilionaireDBConnectionString")
        {

        }
        public DbSet<StatisticsEntry> Statistics { get; set; }
        public DbSet<User> UsersRating { get; set; }
    }
}
