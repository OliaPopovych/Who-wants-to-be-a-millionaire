using System.Collections.Generic;
using WhoWantsToBeAMillionaire.Repositories.Entities;

namespace WhoWantsToBeAMillionaire.Repositories
{
    public interface IQuestionStatisticRepository : IBaseRepository<StatisticsEntry>
    {
        void SeedDatabase(bool force, List<Question> list);
        void Update(StatisticsEntry entry);
        void SaveChanges();
        StatisticsEntry GetByQuestion(Question question);
    }
}
