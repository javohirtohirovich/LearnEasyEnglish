using LearnEasyEnglish.Entities_Models.Words;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEasyEnglish.Interfaces.Words
{
    public interface IWordRepositorie:IRepository<Word>
    {
        public Task<int> CountAsync();
    }
}
