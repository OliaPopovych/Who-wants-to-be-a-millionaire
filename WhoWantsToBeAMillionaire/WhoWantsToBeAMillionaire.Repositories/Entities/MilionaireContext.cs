using System.Collections.Generic;
using System.Data.Entity;

namespace WhoWantsToBeAMillionaire.Repositories.Entities
{
    public class MillionaireContext : DbContext
    {
        public MillionaireContext(List<Question> list) : base("name=MillionaireDBConnectionString")
        {
            Database.SetInitializer<MillionaireContext>(new ListInitializer(list));
        }
        public MillionaireContext() : base("name=MillionaireDBConnectionString")
        {
        }
        public DbSet<StatisticsEntry> Statistics { get; set; }
        public DbSet<User> UsersRating { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }
}
