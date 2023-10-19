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
using LearnEasyEnglish.Helpers;
using LearnEasyEnglish.Interfaces.Words;
using LearnEasyEnglish.Repositories.Words;
using LearnEasyEnglish.ViewModels;
using LearnEasyEnglish.Windows;
using LearnEasyEnglish.Windows.WordUpdate;
using PagedList;

namespace LearnEasyEnglish.Pages
{   
    public partial class WordsDeleteUpdatePage : Page
    {
        int PageNumber = 1;
        IPagedList<WordCreateViewModel> words;
        IWordServ service = new WordServ();
        public WordsDeleteUpdatePage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private async void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            words = await service.GetPagedListAsync(PageNumber, int.Parse(pageSize.Text));
            btnLeft.IsEnabled = words.HasPreviousPage;
            btnRight.IsEnabled = words.HasNextPage;
            dgData.ItemsSource = words;
        }

        private async void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            words = await service.GetPagedListAsync(--PageNumber, int.Parse(pageSize.Text));
            btnLeft.IsEnabled = words.HasPreviousPage;
            btnRight.IsEnabled = words.HasNextPage;
            dgData.ItemsSource = words;
        }

        private async void btnRight_Click(object sender, RoutedEventArgs e)
        {

            words = await service.GetPagedListAsync(++PageNumber, int.Parse(pageSize.Text));
            btnRight.IsEnabled = words.HasNextPage;
            btnLeft.IsEnabled = words.HasPreviousPage;
            dgData.ItemsSource = words;

        }

        private async void btnUpdate(object sender, RoutedEventArgs e)
        {
            var res = (WordCreateViewModel)dgData.SelectedItem;
            long UpdateId = res.Id;
            IdentitySingelton.SaveUpdateId(UpdateId);
            WordUpdate update = new WordUpdate();

            update.txWord.Text = res.Word;
            update.txTranslation.Text = res.Translate;
            update.txDifination.Text = res.Difination;
            update.ShowDialog();

            words = await service.GetPagedListAsync(PageNumber, int.Parse(pageSize.Text));
            btnLeft.IsEnabled = words.HasPreviousPage;
            btnRight.IsEnabled = words.HasNextPage;
            dgData.ItemsSource = words;

        }

        private void pageSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnInfo_click(object sender, RoutedEventArgs e)
        {
            try
            {
                var res = (WordCreateViewModel)dgData.SelectedItem;
                long id = res.Id;
                var result = words.First(x => x.Id == id);
                var desc = result.Difination;
                DifinationViewWindow difinationViewWindow = new DifinationViewWindow();
                difinationViewWindow.tbHelperShow.Text = desc;
                difinationViewWindow.Height = 270;
                difinationViewWindow.Width = 400;
                difinationViewWindow.ShowDialog();
            }
            catch
            {
                DifinationViewWindow difinationViewWindow = new DifinationViewWindow();
                difinationViewWindow.tbHelperShow.Text = "Sorry, Description is not found!";
                difinationViewWindow.ShowDialog();
            }
        }

        private async void btnDelete(object sender, RoutedEventArgs e)
        {
            IWordRepositorie wordRepository = new WordsRepository();
            var res = (WordCreateViewModel)dgData.SelectedItem;
            long DeletedId = res.Id;
            var result = await wordRepository.DeleteAsync(DeletedId);
            if (result == 1)
            {
                MessageBox.Show("Deleted!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

                words = await service.GetPagedListAsync(PageNumber, int.Parse(pageSize.Text));
                btnLeft.IsEnabled = words.HasPreviousPage;
                btnRight.IsEnabled = words.HasNextPage;
                dgData.ItemsSource = words;
            }
            else
            {
                MessageBox.Show("No Delete!", "Info", MessageBoxButton.OK, MessageBoxImage.Error);                
            }
        }
    }
}
