using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoWantsToBeAMillionaire.Repositories.Entities
{
    public class StatisticsEntry
    {
        [Key]
        public int EntryID { get; set; }
        //public int CountOnFirstQuestion { get; set; }
        //public int CountOnSecondQuestion { get; set; }
        //public int CountOnThirdQuestion { get; set; }
        //public int CountOnFourthQuestion { get; set; }
        public List<int> CountAnswersForQuestion { get; set; }
        public virtual Question Question { get; set; }

        public StatisticsEntry(Question question)
        {
            Question = question;
        }
    }
}
