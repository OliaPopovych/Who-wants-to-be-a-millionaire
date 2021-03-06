﻿using System.Collections.Generic;
using System.Data.Entity;

namespace WhoWantsToBeAMillionaire.Repositories.Entities
{
    public class ListInitializer : DropCreateDatabaseIfModelChanges<MillionaireContext>
    {
        private List<Question> questionList;

        public ListInitializer(List<Question> list)
        {
            questionList = list;
        }

        protected override void Seed(MillionaireContext context)
        {
            for (int i = 0; i < questionList.Count; i++)
            {
                questionList[i].QuestionID = 0;
            }
            foreach(var item in questionList)
            {
                context.Statistics.Add(new StatisticsEntry(item));
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
