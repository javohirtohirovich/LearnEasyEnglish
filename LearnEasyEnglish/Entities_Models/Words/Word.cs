using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEasyEnglish.Entities_Models.Words;
public sealed class Word : Auditable
{
    public string Word_text { get; set; } = String.Empty;
    public bool Is_Have_Defenation { get;set; }
    public string Sound_path { get; set; }=String.Empty;
    public string Image_path { get; set; }= String.Empty;
}