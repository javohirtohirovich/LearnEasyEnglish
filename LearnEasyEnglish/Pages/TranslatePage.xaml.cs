using Google.Apis.Util;
using LearnEasyEnglish.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Google.Cloud.Translate.V3;
using System.Net.Http.Headers;
using System.Net.Http;
using LearnEasyEnglish.JsonReader;
using Newtonsoft.Json;

namespace LearnEasyEnglish.Pages
{
    /// <summary>
    /// Interaction logic for Translate.xaml
    /// </summary>
    public partial class Translate : Page
    {
        public Translate()
        {
            InitializeComponent();
        }

        private async void btTranlate_Click(object sender, RoutedEventArgs e)
        {
            string text = new TextRange(rtbLanguage_1.Document.ContentStart, rtbLanguage_1.Document.ContentEnd).Text;
            string result=await GoogleTranslate.Translate("uz", "en", text);
            if(result == "Erorr!")
            {
                MessageBox.Show("Connection Error!","Error!",MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                string json = result;

                TranslationResponse response = JsonConvert.DeserializeObject<TranslationResponse>(json);

                if (response.data != null && response.data.translations.Length > 0)
                {
                    string translatedText = response.data.translations[0].translatedText;
                    TextRange txt = new TextRange(rtbLanguage_2.Document.ContentStart, rtbLanguage_2.Document.ContentEnd);
                    txt.Text = "";
                    rtbLanguage_2.AppendText(translatedText);

                }
            }
        }
    }
}
