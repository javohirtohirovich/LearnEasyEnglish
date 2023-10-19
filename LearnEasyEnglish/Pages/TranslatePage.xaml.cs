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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var lang = tbFirst.Text;
            tbFirst.Text = tbSecond.Text;
            tbSecond.Text = lang;

            var text = txFirst.Text;
            txFirst.Text = txSecond.Text;
            txSecond.Text = text;
        }

        private async void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbFirst.Text.Length > 0)
            {
                if (tbFirst.Text == "Uzbek")
                {
                    var res = await GoogleTranslate.GetTranslatedWordAsync("uz", "en", txFirst.Text.ToLower());
                    if (res.isSuccessful == true)
                    {
                        txSecond.Text = res.TranslatedWord;
                    }
                    else
                    {
                        txSecond.Text = res.TranslatedWord;
                    }
                }
                if (tbFirst.Text == "English")
                {
                    var res = await GoogleTranslate.GetTranslatedWordAsync("en", "uz", txFirst.Text.ToLower());
                    if (res.isSuccessful == true)
                    {
                        txSecond.Text = res.TranslatedWord;
                    }
                    else
                    {
                        txSecond.Text = res.TranslatedWord;
                    }
                }
            }
            else
            {
                tbSecond.Text = "";
            }
        }
    }
}
