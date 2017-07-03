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
        public int CountOnFirstAnswer { get; set; }
        public int CountOnSecondAnswer { get; set; }
        public int CountOnThirdAnswer { get; set; }
        public int CountOnFourthAnswer { get; set; }
        public virtual Question Question { get; set; }
        public List<int> CountList;

        public StatisticsEntry(Question question)
        {
            Question = question;
            CountList = new List<int>(new int[4]);
        }
        public StatisticsEntry()
        {
            CountList = new List<int>(new int[4]);
        }
        public void CountAnswersForQuestion(int answerId)
        {
            switch (answerId)
            {
                case 0:
                    CountOnFirstAnswer++;
                    CountList[answerId]++;
                    break;
                case 1:
                    CountOnSecondAnswer++;
                    CountList[answerId]++;
                    break;
                case 2:
                    CountOnThirdAnswer++;
                    CountList[answerId]++;
                    break;
                case 3:
                    CountOnFourthAnswer++;
                    CountList[answerId]++;
                    break;
                default:
                    break;
            }
                
        }
    }
}
