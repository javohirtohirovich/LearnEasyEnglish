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
    public string Sound_path { get; set; }=String.Empty;
    public string DifinationText { get; set; }= String.Empty;
    public string GroupName { get; set; }=String.Empty;
    public string TranslatedText { get; set; }= String.Empty;
    public object meanings { get; internal set; }
}