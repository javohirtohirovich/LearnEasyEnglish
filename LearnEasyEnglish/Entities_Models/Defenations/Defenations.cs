using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEasyEnglish.Entities_Models.Defenations
{
    public sealed class Defenation
    {
        public long word_id { get; set; }
        public string defenation_text { get; set;}=String.Empty;
    }
}
