using LearnEasyEnglish.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEasyEnglish.Interfaces.Words
{
    public interface IWordServ
    {
        public Task<IPagedList<WordCreateViewModel>> GetPagedListAsync(int pageNumber, int pageSize);

    }
}
