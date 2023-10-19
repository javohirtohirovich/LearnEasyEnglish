using LearnEasyEnglish.Entities_Models.Words;
using LearnEasyEnglish.Helpers;
using LearnEasyEnglish.Windows.Step1Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LearnEasyEnglish.Windows.Step_1MemorizeWindow;

/// <summary>
/// Interaction logic for Step_1_MemorizeWindow.xaml
/// </summary>
public partial class Step_1_MemorizeWindow : Window
{
    static int index = 0;
    static int correctPoints = 0;
    static int maxPage;
    static List<List<string>> res;
    static List<RandomTestViewModel> listTestAnswer = new List<RandomTestViewModel>();
    private string group_name;
    public Step_1_MemorizeWindow()
    {
        InitializeComponent();
    }
    public Step_1_MemorizeWindow(string group_nom)
    {
        InitializeComponent();
        group_name = group_nom;
    }
    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        try
        {
            GameService gameService = new GameService();
            res = await gameService.RandomTestAsync(group_name);
            if (res.Count == 0)
            {
                throw new Exception();
            }
            lbRandomWord.Content = res[index][0];
            aBtn.Content = res[index][1];
            bBtn.Content = res[index][2];
            cBtn.Content = res[index][3];
            dBtn.Content = res[index][4];
            if (res.Count <= 15)
            {
                lbPage.Content = $"{index + 1}/{res.Count}";
                maxPage = res.Count;
            }
            else
            {
                lbPage.Content = $"{index + 1}/{15}";
                maxPage = 15;
            }

        }
        catch
        {
            
            //this.Close();
            System.Windows.MessageBox.Show("Word Enough!", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void aBtn_Click(object sender, RoutedEventArgs e)
    {
        RandomTestViewModel viewModel = new RandomTestViewModel()
        {
            id = index + 1,
            Word = res[index][0],
            Translate = res[index][5],
            Choice = aBtn.Content.ToString(),
            Status = "F"


        };
        if (aBtn.Content.ToString() == res[index][5])
        {
            correctPoints++;
            viewModel.Status = "T";
        }
        index++;
        listTestAnswer.Add(viewModel);
        if (index == res.Count || index >= 15)
        {
            RunTransGameResWindow gameResWindow = new RunTransGameResWindow();
            gameResWindow.dgData.ItemsSource = listTestAnswer;
            gameResWindow.lbResultgame.Content = string.Format("Result: {0}/{1}", correctPoints, listTestAnswer.Count);
            this.Close();
            gameResWindow.ShowDialog();
            index = 0;
            correctPoints = 0;

        }
        lbRandomWord.Content = res[index][0];
        aBtn.Content = res[index][1];
        bBtn.Content = res[index][2];
        cBtn.Content = res[index][3];
        dBtn.Content = res[index][4];
        lbPage.Content = $"{index + 1}/{maxPage}";

    }

    private void bBtn_Click(object sender, RoutedEventArgs e)
    {
        RandomTestViewModel viewModel = new RandomTestViewModel()
        {
            id = index + 1,
            Word = res[index][0],
            Translate = res[index][5],
            Choice = bBtn.Content.ToString(),
            Status = "F"


        };
        if (bBtn.Content.ToString() == res[index][5])
        {
            correctPoints++;
            viewModel.Status = "T";
        }
        index++;
        listTestAnswer.Add(viewModel);

        if (index == res.Count || index >= 15)
        {
            RunTransGameResWindow gameResWindow = new RunTransGameResWindow();
            gameResWindow.dgData.ItemsSource = listTestAnswer;
            gameResWindow.lbResultgame.Content = string.Format("Result: {0}/{1}", correctPoints, listTestAnswer.Count);
            this.Close();
            gameResWindow.ShowDialog();
            index = 0;
            correctPoints = 0;
        }
        lbRandomWord.Content = res[index][0];
        aBtn.Content = res[index][1];
        bBtn.Content = res[index][2];
        cBtn.Content = res[index][3];
        dBtn.Content = res[index][4];
        lbPage.Content = $"{index + 1}/{maxPage}";
    }

    private void cBtn_Click(object sender, RoutedEventArgs e)
    {
        RandomTestViewModel viewModel = new RandomTestViewModel()
        {
            id = index + 1,
            Word = res[index][0],
            Translate = res[index][5],
            Choice = cBtn.Content.ToString(),
            Status = "F"


        };
        if (cBtn.Content.ToString() == res[index][5])
        {
            correctPoints++;
            viewModel.Status = "T";
        }
        index++;
        listTestAnswer.Add(viewModel);

        if (index == res.Count || index >= 15)
        {
            RunTransGameResWindow gameResWindow = new RunTransGameResWindow();
            gameResWindow.dgData.ItemsSource = listTestAnswer;
            gameResWindow.lbResultgame.Content = string.Format("Result: {0}/{1}", correctPoints, listTestAnswer.Count);
            this.Close();
            gameResWindow.ShowDialog();
            index = 0;
            correctPoints = 0;

        }
        lbRandomWord.Content = res[index][0];
        aBtn.Content = res[index][1];
        bBtn.Content = res[index][2];
        cBtn.Content = res[index][3];
        dBtn.Content = res[index][4];
        lbPage.Content = $"{index + 1}/{maxPage}";
    }

    private void dBtn_Click(object sender, RoutedEventArgs e)
    {
        RandomTestViewModel viewModel = new RandomTestViewModel()
        {
            id = index + 1,
            Word = res[index][0],
            Translate = res[index][5],
            Choice = dBtn.Content.ToString(),
            Status = "F"


        };
        if (dBtn.Content.ToString() == res[index][5])
        {
            correctPoints++;
            viewModel.Status = "T";
        }
        index++;
        listTestAnswer.Add(viewModel);

        if (index == res.Count || index >= 15)
        {
            RunTransGameResWindow gameResWindow = new RunTransGameResWindow();
            gameResWindow.dgData.ItemsSource = listTestAnswer;
            gameResWindow.lbResultgame.Content = string.Format("Result: {0}/{1}", correctPoints, listTestAnswer.Count);
            this.Close();
            gameResWindow.ShowDialog();
            index = 0;
            correctPoints = 0;
        }
        lbRandomWord.Content = res[index][0];
        aBtn.Content = res[index][1];
        bBtn.Content = res[index][2];
        cBtn.Content = res[index][3];
        dBtn.Content = res[index][4];
        lbPage.Content = $"{index + 1}/{maxPage}";
    }

    private void mouse(object sender, MouseButtonEventArgs e)
    {

    }
}
