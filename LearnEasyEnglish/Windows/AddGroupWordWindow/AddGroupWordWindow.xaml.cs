using EduCenter.Desktop.Constants;
using EduCenter.Desktop.Helpers;
using LearnEasyEnglish.Entities_Models.Words;
using LearnEasyEnglish.Entities_Models.Words_Groups;
using LearnEasyEnglish.Helpers;
using LearnEasyEnglish.Interfaces.Words;
using LearnEasyEnglish.Interfaces.WordsGroup;
using LearnEasyEnglish.Repositories.Words;
using LearnEasyEnglish.Repositories.WordsGroup;
using Microsoft.VisualBasic.Devices;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace LearnEasyEnglish.Windows.AddGroupWordWindow
{
    /// <summary>
    /// Interaction logic for AddGroupWordWindow.xaml
    /// </summary>
    
    public partial class AddGroupWordWindow : Window
    {
        private readonly WordsGroupRepository _groupRepository;
        private readonly WordsRepository _wordRepository;
        private readonly string _user_id;
        public AddGroupWordWindow()
        {
            InitializeComponent();
            this._groupRepository = new WordsGroupRepository();
            this._wordRepository = new WordsRepository();
        }
        public AddGroupWordWindow(string uId) : base()
        {
            InitializeComponent();
            this._groupRepository = new WordsGroupRepository();
            this._wordRepository = new WordsRepository();
            this._user_id = uId;
        }

        //Ishlatilmayapti
        private void btnGetFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath=openFileDialog.FileName;
                string text = File.ReadAllText(filePath);
               
            }
                
        }
        //Button Save Ma'lumotlarni saqlash
        private async void btSave_Click(object sender, RoutedEventArgs e)
        {
           
            //Write Word_Group
            Word_Group word_Group = new Word_Group();
            word_Group.Group_Name=tbGroupName.Text;
            word_Group.Description= tbDescription.Text;
            word_Group.CreatedAt = TimeHelper.GetDateTime();
            word_Group.UpdatedAt = TimeHelper.GetDateTime();
            MainWindow mainWindow = new MainWindow();
            word_Group.User_id = int.Parse(_user_id);

            //image save
            string imagepath = ImgBImage.ImageSource.ToString();
            if (!String.IsNullOrEmpty(imagepath))
                word_Group.ImagePath = await CopyImageAsync(imagepath,
                    ContentConstants.IMAGE_CONTENTS_PATH);            
          
            var result = await _groupRepository.CreateAsync(word_Group);
            if (result > 0)
            {
                MessageBox.Show("Muvaffaqqiyatli guruh saqlandi");
                this.Close();
            }
            else { MessageBox.Show("Saqlanmadi!"); }
        }
        //papkaga image ni saqlash va databasaga image path ni saqlash
        private async Task<string> CopyImageAsync(string imgPath, string destinationDirectory)
        {
            if (!Directory.Exists(destinationDirectory))
                Directory.CreateDirectory(destinationDirectory);

            var imageName = ContentNameMaker.GetImageName(imgPath);

            string path = System.IO.Path.Combine(destinationDirectory, imageName);

            byte[] image = await File.ReadAllBytesAsync(imgPath);

            await File.WriteAllBytesAsync(path, image);

            return path;
        }

        //Image tanlash uchun Button
        private void btnImageSelector_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = GetImageDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string imgPath = openFileDialog.FileName;
                ImgBImage.ImageSource = new BitmapImage(new Uri(imgPath, UriKind.Relative));
            }
        }
        //Image tanlash uchun Filter va oynani ochish
        private OpenFileDialog GetImageDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif|All files (*.*)|*.*";
            return openFileDialog;
        }
    }
}
