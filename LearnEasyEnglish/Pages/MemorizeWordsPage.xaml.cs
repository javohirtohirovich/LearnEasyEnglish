using LearnEasyEnglish.Components.MemorizeUseControl;
using LearnEasyEnglish.Components.WordsGroup;
using LearnEasyEnglish.Interfaces.WordsGroup;
using LearnEasyEnglish.Repositories.WordsGroup;
using LearnEasyEnglish.Utils;
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

namespace LearnEasyEnglish.Pages
{

    /// <summary>
    /// Interaction logic for MemorizeWordsPage.xaml
    /// </summary>
    public partial class MemorizeWordsPage : Page
    {
        private readonly IWordsGroupRepository _wordsGroupRepository;
        public MemorizeWordsPage()
        {
            InitializeComponent();
            _wordsGroupRepository = new WordsGroupRepository();
        }
        private async Task RefreshAsync()
        {
            wrpWordsGroup.Children.Clear();
            PagenationParams paginationParams = new PagenationParams()
            {
                PageNumber = 1,
                PageSize = 30
            };
            var groups = await _wordsGroupRepository.GetAllAsync(paginationParams);

            foreach (var group in groups)
            {
                Memorize_WordGroup_UseControl WordGroupViewUserControl = new Memorize_WordGroup_UseControl();
                WordGroupViewUserControl.SetData(group);
                wrpWordsGroup.Children.Add(WordGroupViewUserControl);

            }
        }
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await RefreshAsync();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
