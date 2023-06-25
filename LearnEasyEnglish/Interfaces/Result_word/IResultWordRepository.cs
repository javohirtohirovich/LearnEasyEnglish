using LearnEasyEnglish.Entities_Models.Result_Words;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEasyEnglish.Interfaces.Result_word
{
    public interface IResultWordRepository:IRepository<Result_Word>
    {
        public Task<int> Count();
    }
}
