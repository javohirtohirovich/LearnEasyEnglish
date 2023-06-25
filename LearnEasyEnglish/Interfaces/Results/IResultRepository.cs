using LearnEasyEnglish.Entities_Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEasyEnglish.Interfaces.Results
{
    public interface IResultRepository:IRepository<Result>
    {
        public Task<int> Count();
    }
}
