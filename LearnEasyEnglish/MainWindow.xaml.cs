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
using System.Runtime.InteropServices; // Windowni tepaga yoki yonga suraganda windowni bir bo'lagini egalash uchun pakcge
using System.Windows.Interop; // Windowni tepaga yoki yonga suraganda windowni bir bo'lagini egalash uchun packge
using LearnEasyEnglish.Pages;
using LearnEasyEnglish.Utils;

namespace LearnEasyEnglish
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight; //
        }
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd,int wMsg,int wParam,int lParam);


        private void pnlContralBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);// Windowni harakatlantirish uchun
            SendMessage(helper.Handle, 161, 2, 0);
        }

        private void pnlContralBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            //Dasturni butunlay yopadi
            Application.Current.Shutdown();
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            //Agar window Default holatida turgan bo'lsa Maxmized qiladi
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState=WindowState.Maximized;
            }
            //Agar windwo Maxmized holatida turgan bo'lsa default holatiga qaytaradi
            else this.WindowState = WindowState.Normal; 
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            //Windowni Minimized qiladi
            this.WindowState = WindowState.Minimized;
        }

        private void rbDashboard_Click(object sender, RoutedEventArgs e)
        {

            
        }

        private void rbAddWordsGroup_Click(object sender, RoutedEventArgs e)
        {
           AddGroupWordsPage addGroupWordsPage = new AddGroupWordsPage();
           PageNavigator.Content= addGroupWordsPage;
        }

        private void rbTranslate_Click(object sender, RoutedEventArgs e)
        {
            Translate translate=new Translate();
            PageNavigator.Content = translate;
        }

        private void rbMemorizeWords_Click(object sender, RoutedEventArgs e)
        {
            MemorizeWordsPage memorizeWordsPage = new MemorizeWordsPage();
            PageNavigator.Content = memorizeWordsPage;
        }

        private void rbInfo_Click(object sender, RoutedEventArgs e)
        {
            InfoPage infoPage= new InfoPage();
            PageNavigator.Content = infoPage;
        }
    }
}
