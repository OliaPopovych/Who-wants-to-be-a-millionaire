namespace WhoWantsToBeAMillionaire.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MillionaireContext : DbContext
    {
        // Your context has been configured to use a 'MillionaireContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'WhoWantsToBeAMillionaire.Models.MillionaireContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MillionaireContext' 
        // connection string in the application configuration file.
        public MillionaireContext()
            : base("name=MillionaireContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }
    }    
}