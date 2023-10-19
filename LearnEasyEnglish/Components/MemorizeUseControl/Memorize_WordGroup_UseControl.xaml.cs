using LearnEasyEnglish.Entities_Models.Words_Groups;
using LearnEasyEnglish.Windows.MemorizeWindow;
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

namespace LearnEasyEnglish.Components.MemorizeUseControl
{
    /// <summary>
    /// Interaction logic for Memorize_WordGroup_UseControl.xaml
    /// </summary>
    public partial class Memorize_WordGroup_UseControl : UserControl
    {
        public long Id { get; private set; }
        private string group_name=String.Empty;
        public Memorize_WordGroup_UseControl()
        {
            InitializeComponent();
        }
        public void SetData(Word_Group word_group)
        {
            Id = word_group.id;
            ImgB.ImageSource = new BitmapImage(new System.Uri(word_group.ImagePath, UriKind.Relative));
            group_name = word_group.Group_Name;
            lbName.Content = word_group.Group_Name;
            tbDescription.Text = word_group.Description;
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MemorizeWIndow memorizeWIndow = new MemorizeWIndow(group_name);
            memorizeWIndow.ShowDialog();
        }

        private void grMain_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
