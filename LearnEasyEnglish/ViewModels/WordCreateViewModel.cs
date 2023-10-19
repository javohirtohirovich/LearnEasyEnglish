using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEasyEnglish.ViewModels
{
    public class WordCreateViewModel
    {
       
        public long Id { get; set; }
        public string Word { get; set; } = string.Empty;
        public string Translate { get; set; } = string.Empty;
        public string Difination { get; set; } = string.Empty;
        public string Groups_Name { get; set; } = String.Empty;
    }
}
