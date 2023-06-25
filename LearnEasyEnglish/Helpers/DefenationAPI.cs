using Google.Protobuf.WellKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Google.Rpc.Context.AttributeContext.Types;

namespace LearnEasyEnglish.Helpers;

public class Meaning
{
    public string partOfSpeech { get; set; }
    public Definition[] definitions { get; set; }
}

public class Definition
{
    public string definition { get; set; }
    public string example { get; set; }
    public string[] synonyms { get; set; }
    public string[] antonyms { get; set; }
}

public class WordData
{
    public string word { get; set; }
    public Meaning[] meanings { get; set; }
}

public static class  Difination
{
    public static async Task<string> GetDifination(string word)
    {
        string json =await ReturnJsonData.GetJsonData(word);

        WordData[] wordData = JsonConvert.DeserializeObject<WordData[]>(json);

        if (wordData.Length > 0)
        {
            Definition[] definitions = wordData[0].meanings[0].definitions;

            foreach (Definition definition in definitions)
            {
                string definitionText = definition.definition;
                return definitionText;
            }
        }
        return "Error!";
    }
}

