using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEasyEnglish.JsonReader;


public class TranslationResponse
{
    [JsonProperty ("data")]
    public TranslationData data { get; set; }
}

public class TranslationData
{
    [JsonProperty ("translations")]
    public Translation[] translations { get; set; }
}

public class Translation
{
    [JsonProperty("translatedText")]
    public string translatedText { get; set; }
}