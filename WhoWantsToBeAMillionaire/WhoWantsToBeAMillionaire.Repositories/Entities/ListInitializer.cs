using System.Collections.Generic;
using System.Data.Entity;

namespace WhoWantsToBeAMillionaire.Repositories.Entities
{
    public class ListInitializer : DropCreateDatabaseAlways<MillionaireContext>
    {
        private List<Question> questionList = new List<Question>();

        public ListInitializer(List<Question> list)
        {
            foreach(var item in list)
            {
                questionList.Add(item);
            }
            for (int i = 0; i < questionList.Count; i++)
            {
                questionList[i].QuestionID = 0;
            }
        }

        protected override void Seed(MillionaireContext context)
        {
            
            foreach(var item in questionList)
            {
                context.Questions.Add(new Question(item));
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
