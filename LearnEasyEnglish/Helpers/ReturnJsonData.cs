using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LearnEasyEnglish.Helpers
{
    public static class ReturnJsonData
    {
        public static async Task<string> GetJsonData(string word)
        {
            
            string apiUrl = $"https://api.dictionaryapi.dev/api/v2/entries/en/{word}";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                // JSON ma'lumotlarini olish va ma'lumotlar bilan ishlash
                client.Dispose();
                return json;

            }
            else
            {
                client.Dispose();
                return "HTTP Error!";
            }
        }
    }
}
