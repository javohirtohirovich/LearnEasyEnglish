using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEasyEnglish.Entities_Models.Words_Groups;

public sealed class Word_Group : Auditable
{
    [MaxLength(50)]
    public string Group_Name { get; set; } = String.Empty;
    public string Description { get; set;}= String.Empty;
}
