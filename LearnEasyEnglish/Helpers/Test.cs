using Google.Api.Gax;
using LearnEasyEnglish.Entities_Models.Words;
using LearnEasyEnglish.Interfaces.Words;
using LearnEasyEnglish.Repositories.Words;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEasyEnglish.Helpers
{
    public class GameService
    {
        public async Task<List<List<string>>> RandomTestAsync(string group_name)
        {
            Random random = new Random();
            List<List<string>> test = new List<List<string>>();
            IWordRepositorie repository = new WordsRepository();
           
            var ALLWORDS = (await repository.GetAllAsync()).ToList();
            var wordsDB = ALLWORDS.Where(x => x.GroupName == group_name).ToList();

            var words = Shuffle(wordsDB);
            if (words.Count >= 4)
            {
                for (int i = 0; i < words.Count; i++)
                {
                    List<string> list = new List<string>() { "", "", "", "", "", "" };
                    list[0] = words[i].Word_text;
                    list[random.Next(1, 4)] = words[i].TranslatedText;
                    list[5] = words[i].TranslatedText;
                    while (list[1] == "" || list[2] == "" || list[3] == "" || list[4] == "")
                    {
                        var res = words[random.Next(0, words.Count)].TranslatedText;
                        for (int l = 1; l < 5; l++)
                        {
                            if (list[l] == "" && !list.Contains(res))
                                list[l] = res;
                        }
                    }
                    test.Add(list);
                }
                return test;
            }
            else return new List<List<string>>();


        }
        public async Task<List<List<string>>> RandomTranslateTestAsync()
        {

            {
                Random random = new Random();
                List<List<string>> test = new List<List<string>>();
                IWordRepositorie repository = new WordsRepository();
                var id = IdentitySingelton.currentId().UserId;
                var ALLWORDS = (await repository.GetAllAsync()).ToList();
                var wordsDB = ALLWORDS.Where(x => x.id == id).ToList();

                var words = Shuffle(wordsDB);

                if (words.Count >= 4)
                {
                    for (int i = 0; i < words.Count; i++)
                    {
                        List<string> list = new List<string>() { "", "", "", "", "", "" };
                        list[0] = words[i].TranslatedText;
                        list[random.Next(1, 4)] = words[i].Word_text;
                        list[5] = words[i].Word_text;
                        while (list[1] == "" || list[2] == "" || list[3] == "" || list[4] == "")
                        {
                            var res = words[random.Next(0, words.Count)].Word_text;
                            for (int l = 1; l < 5; l++)
                            {
                                if (list[l] == "" && !list.Contains(res))
                                    list[l] = res;
                            }
                        }
                        test.Add(list);
                    }
                    return test;
                }
                else return new List<List<string>>();

            }
        }
        public static List<Word> Shuffle(List<Word> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Word value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }

        public async Task<List<Word>> RandomTestDescriptionAsync()
        {
            IWordRepositorie repository = new WordsRepository();
            var id = IdentitySingelton.currentId().UserId;
            var ALLWORDS = (await repository.GetAllAsync()).ToList();
            var wordsDb =  ALLWORDS.Where(x => x.id == id).ToList();
            var words = Shuffle(wordsDb);
            return words;
        }

       /* public async Task<List<Word>> RandomTestVoiceAsync()
        {
            IWordRepositorie repository = new WordsRepository();
            var id = IdentitySingelton.currentId().UserId;
            var ALLWORDS = (await repository.GetAllAsync()).ToList();
            var wordsDb = ALLWORDS.Where(x => x.id == id && (x. != null || x.AudioPath != "")).ToList();
            var words = Shuffle(wordsDb);
            return words;
        }*/
    }
}
