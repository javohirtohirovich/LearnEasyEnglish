using LearnEasyEnglish.Entities_Models.Words;
using LearnEasyEnglish.Helpers;
using LearnEasyEnglish.Interfaces.Words;
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

namespace LearnEasyEnglish.Windows.WordUpdate
{
    /// <summary>
    /// Interaction logic for WordUpdate.xaml
    /// </summary>
    public partial class WordUpdate : Window
    {
        private string _group_name= string.Empty;
        public WordUpdate()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }

        private async void BtnUpdateWord_Click(object sender, RoutedEventArgs e)
        {
            IWordRepositorie wordRepository = new WordsRepository();

            Word word = new Word()
            {
                Word_text = txWord.Text,
                TranslatedText = txTranslation.Text,
                DifinationText = txDifination.Text              
            };
            _group_name = word.GroupName;
            var res = await wordRepository.UpdateAsync(IdentitySingelton.UpdateId().updateId, word);
            if (res>0)
            {
                MessageBox.Show("Updated!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("No Updated!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
