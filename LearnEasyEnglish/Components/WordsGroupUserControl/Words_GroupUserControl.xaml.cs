using LearnEasyEnglish.Entities_Models.Words_Groups;
using LearnEasyEnglish.Pages;
using LearnEasyEnglish.Windows.AddWordMinWindow;
using LearnEasyEnglish.Windows.MemorizeWindow;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using LearnEasyEnglish.Pages;

namespace LearnEasyEnglish.Components.WordsGroup
{
    /// <summary>
    /// Interaction logic for Words_Group.xaml
    /// </summary>
    public partial class Words_Group : UserControl
    {
        public long Id { get; private set; }
        public Words_Group()
        {
            InitializeComponent();
        }
        public async void SetData(Word_Group word_group)
        {
            Id = word_group.id;
            ImgB.ImageSource =new  BitmapImage(new System.Uri(word_group.ImagePath, UriKind.Relative));
            lbName.Content = word_group.Group_Name;
            tbDescription.Text = word_group.Description;
        }

        private void grMain_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            
        }

        private async void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
           

        }

        private async void btAddWord_Click(object sender, RoutedEventArgs e)
        {
            AddWordMinWindow addWordMinWindow = new AddWordMinWindow(lbName.Content.ToString());
            addWordMinWindow.ShowDialog();
        }
    }
}
