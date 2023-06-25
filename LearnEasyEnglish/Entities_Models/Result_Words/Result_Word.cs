using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEasyEnglish.Entities_Models.Result_Words
{
    public sealed class Result_Word:Auditable
    {
        public long result_id { get; set; }
        public string word { get; set; } = String.Empty;
        public short true_percentage { get; set; }

    }
}
