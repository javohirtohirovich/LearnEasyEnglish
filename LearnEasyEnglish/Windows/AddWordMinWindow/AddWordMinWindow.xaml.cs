using LearnEasyEnglish.Entities_Models.Words;
using LearnEasyEnglish.Entities_Models.Words_Groups;
using LearnEasyEnglish.Helpers;
using LearnEasyEnglish.Repositories.Words;
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
using System.Windows.Shapes;

namespace LearnEasyEnglish.Windows.AddWordMinWindow
{
    /// <summary>
    /// Interaction logic for AddWordMinWindow.xaml
    /// </summary>
    public partial class AddWordMinWindow : Window
    {
        private readonly string _group_name;
        private readonly WordsRepository _wordRepository;
        public AddWordMinWindow()
        {
            this._wordRepository = new WordsRepository();
            InitializeComponent();
        }
        public AddWordMinWindow(string group_name)
        {
            this._wordRepository = new WordsRepository();
            _group_name = group_name;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbSelectLang.SelectedIndex = 1;
        }

        private async void btSaveWord_Click(object sender, RoutedEventArgs e)
        {
            Word word = new Word();
            word.Word_text = tbWord.Text;
            word.Sound_path = "asdasd";
            word.DifinationText = tbDifination.Text;
            word.GroupName = _group_name;
            word.TranslatedText = tbWordTranslate.Text;
            word.CreatedAt = TimeHelper.GetDateTime();
            word.UpdatedAt = TimeHelper.GetDateTime();

            var result = await _wordRepository.CreateAsync(word);
            if (result > 0)
            {
                MessageBox.Show("Muvaffaqqiyatli guruh saqlandi");
                this.Close();
            }
            else { MessageBox.Show("Saqlanmadi!"); }

        }

        private async void btGetTranslate_Click(object sender, RoutedEventArgs e)
        {
            string from = cbSelectLang.SelectedValue.ToString().ToLower();
            if (from == "en")
            {
                tbWordTranslate.Text = await GoogleTranslate.Translate(from,"uz",tbWord.Text.ToLower());
            }
            else if(from=="uz")
            {
                tbWordTranslate.Text = await GoogleTranslate.Translate(from, "en", tbWord.Text.ToLower());
            }
        }
    }
}
