using LearnEasyEnglish.Components.WordsGroup;
using LearnEasyEnglish.Interfaces.WordsGroup;
using LearnEasyEnglish.Repositories.WordsGroup;
using LearnEasyEnglish.Utils;
using LearnEasyEnglish.Windows.AddGroupWordWindow;
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
    /// Interaction logic for AddGroupWordsPage.xaml
    /// </summary>
    public partial class AddGroupWordsPage : Page
    {
        private readonly IWordsGroupRepository _wordsGroupRepository;
        private readonly string _uId;
        public AddGroupWordsPage()
        {
            InitializeComponent();
            _wordsGroupRepository = new WordsGroupRepository(); 
        }
        public AddGroupWordsPage(string uId): base()
        {
            InitializeComponent();
            this._uId = uId;
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
                Words_Group courseViewUserControl = new Words_Group();
                courseViewUserControl.SetData(group);
                wrpWordsGroup.Children.Add(courseViewUserControl);
                
            }
        }
        private void btnCreate_Click(object sender, RoutedEventArgs e)
         {
            AddGroupWordWindow addGroupWord =new AddGroupWordWindow(_uId);
            addGroupWord.ShowDialog();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await RefreshAsync();
        }
    }
}
