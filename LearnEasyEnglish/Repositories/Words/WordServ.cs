using LearnEasyEnglish.Helpers;
using LearnEasyEnglish.Interfaces.Words;
using LearnEasyEnglish.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEasyEnglish.Repositories.Words
{
    public class WordServ : IWordServ
    {
        public async Task<IPagedList<WordCreateViewModel>> GetPagedListAsync(int pageNumber, int pageSize)
        {
            List<WordCreateViewModel> list = new List<WordCreateViewModel>();
            IWordRepositorie repository = new WordsRepository();
            var result = await repository.GetAllAsync();
            var res = result.ToList();
            foreach (var item in res)
            {
                WordCreateViewModel model = new WordCreateViewModel()
                {                 
                    Id = item.id,
                    Difination = item.DifinationText,
                    Word = item.Word_text,
                    Translate = item.TranslatedText,
                    Groups_Name = item.GroupName
                };
                list.Add(model);
            }
            return list.ToPagedList(pageNumber, pageSize);
        }
    }
}
