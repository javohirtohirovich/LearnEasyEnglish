using Google.Apis.Auth.OAuth2;
using Google.Apis.Translate.v2;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows;
using LearnEasyEnglish.Pages;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using LearnEasyEnglish.Repositories.TranslateAPIModels;

namespace LearnEasyEnglish.Helpers;
public static class GoogleTranslate
{
    public  static async Task<(bool isSuccessful, string TranslatedWord)> GetTranslatedWordAsync(string from, string to, string word)
    {      
        try
        {
            string str1 = "[{\"Text\":" + "\"" + word + "\"}]";
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"https://microsoft-translator-text.p.rapidapi.com/translate?to%5B0%5D={to}&api-version=3.0&from={from}&profanityAction=NoAction&textType=plain"),
                Headers =
                    {
                        { "X-RapidAPI-Key", "c841369174mshd86c036960342b2p120b2fjsn7ed9906f461e"},
                        { "X-RapidAPI-Host", "microsoft-translator-text.p.rapidapi.com" },
                    },
                Content = new StringContent(str1)
                {
                    Headers =
                        {
                            ContentType = new MediaTypeHeaderValue("application/json")
                        }
                }
            };
            var response = await client.SendAsync(request);
            if ((int)response.StatusCode > 400) { }
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<List<Translater>>(body);
            var tranlatedWord = json[0].Translations[0].Text;
            if (tranlatedWord != null) return (true, tranlatedWord);
            else return (false, "No translation found for this word");

        }
        catch (Exception)
        {
            return (false, "No Internet");
        }
    }

}

