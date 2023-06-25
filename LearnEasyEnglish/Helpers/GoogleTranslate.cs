using Google.Apis.Auth.OAuth2;
using Google.Apis.Translate.v2;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows;

namespace LearnEasyEnglish.Helpers;
public static class GoogleTranslate
{
    public static async Task<string> Translate(string from,string to,string text)
    {
        try
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://google-translate1.p.rapidapi.com/language/translate/v2"),
                Headers ={
                            { "X-RapidAPI-Key", "bb8c5562famsh340822a348d3276p121254jsn419847bc0b1f" },
                            {"X-RapidAPI-Host", "google-translate1.p.rapidapi.com" },
                          },
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "q", text },
                    { "target", to },
                    { "source", from },
                }),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return body;
            }
        }
        catch { return "Erorr!"; }
    }
}

