using System.Collections.Generic;
using WhoWantsToBeAMillionaire.Repositories.Entities;

namespace WhoWantsToBeAMillionaire.Repositories
{
    public interface IQuestionStatisticRepository : IBaseRepository<Question>
    {
        void SeedDatabase(bool force, List<Question> list);
        void Update(Question entry);
        void SaveChanges();
        Question GetByQuestion(Question question);
    }
}
