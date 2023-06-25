using LearnEasyEnglish.Entities_Models.Words_Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEasyEnglish.Interfaces.WordsGroup
{
    public interface IWordsGroupRepository : IRepository<Word_Group>
    {
        public Task<int> CountAsync();
    }
}
