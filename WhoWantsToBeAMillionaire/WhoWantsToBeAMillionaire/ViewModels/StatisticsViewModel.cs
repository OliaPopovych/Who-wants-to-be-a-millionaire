using System.Collections.Generic;
using WhoWantsToBeAMillionaire.Repositories.Entities;

namespace WhoWantsToBeAMillionaire.ViewModels
{
    public class StatisticsViewModel
    {
        public IList<User> Users { get; set; }
    }
}