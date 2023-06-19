using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEasyEnglish.Entities_Models.Results;

public sealed class Result : Auditable
{
    public long user_id { get;set; }
    public long group_id { get;set;}
    public short result_percentage { get; set; }
    
}
