using LearnEasyEnglish.Windows.Step_1MemorizeWindow;
using LearnEasyEnglish.Windows.Step1Window;
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

namespace LearnEasyEnglish.Windows.MemorizeWindow
{
    /// <summary>
    /// Interaction logic for MemorizeWIndow.xaml
    /// </summary>
    public partial class MemorizeWIndow : Window
    {
        private string group_name;
        public MemorizeWIndow()
        {
            InitializeComponent();
        }
        public MemorizeWIndow(string group_nom)
        {
            InitializeComponent();
            group_name = group_nom;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btStep1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Step_1_MemorizeWindow step_1_MemorizeWindow = new Step_1_MemorizeWindow(group_name);
            step_1_MemorizeWindow.ShowDialog();
        }
    }
}
