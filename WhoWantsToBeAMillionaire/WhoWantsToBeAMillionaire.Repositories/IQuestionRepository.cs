using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoWantsToBeAMillionaire.Repositories
{
    public interface IQuestionRepository
    {
        IList<Question> GetAll();
    }
}
