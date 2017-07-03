using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhoWantsToBeAMillionaire.Repositories.Entities
{
    [Table("Statistics")]
    public class StatisticsEntry
    {
        [Key, ForeignKey("Question")]
        public int QuestionID { get; set; }
        public virtual Question Question { get; set; }

        public StatisticsEntry(Question question)
        {
            Question = question;
        }
        public StatisticsEntry()
        {
        }
    }
}
