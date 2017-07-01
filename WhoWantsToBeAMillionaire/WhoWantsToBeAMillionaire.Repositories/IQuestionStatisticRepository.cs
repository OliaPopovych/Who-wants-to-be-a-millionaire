using System;
using WhoWantsToBeAMillionaire.Repositories.Entities;

namespace WhoWantsToBeAMillionaire.Repositories
{
    public interface IQuestionStatisticRepository : IBaseRepository<StatisticsEntry>
    {
        void Update(StatisticsEntry entry);
        StatisticsEntry GetByQuestion(Question question);
    }
}
