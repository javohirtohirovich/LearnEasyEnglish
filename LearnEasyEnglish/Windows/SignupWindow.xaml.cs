using LearnEasyEnglish.Constants;
using LearnEasyEnglish.Entities_Models.Users;
using LearnEasyEnglish.Helpers;
using LearnEasyEnglish.Security;
using Npgsql;
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

namespace LearnEasyEnglish.Windows
{
    /// <summary>
    /// Interaction logic for SignupWindow.xaml
    /// </summary>
    public partial class SignupWindow : Window
    {
        public SignupWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var user = new User();
            user.First_Name = (tbFirstName.Text).ToLower();
            user.Last_Name= (tbLastName.Text).ToLower();
            user.Email = tbEmail.Text;
            user.CreatedAt= TimeHelper.GetDateTime();
            user.UpdatedAt= TimeHelper.GetDateTime();

            string password = tbPassword.Password;
            string again_password=tbPasswordAgain.Password;
            var hasherResult = PasswordHasher.Hash(password);
            user.Password_hash = hasherResult.PasswordHash;
            user.Salt=hasherResult.Salt;

            try
            {
                var dbResult = await RegisterAsync(user);
                if (dbResult) 
                { 
                    MessageBox.Show("Saved Successfully!", "Saved!", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                    LoginWindow loginWindow = new LoginWindow();
                    loginWindow.tbName.Text = tbFirstName.Text;
                    loginWindow.tbPassword.Password = tbPassword.Password;
                    loginWindow.Show();
                } 
                else { MessageBox.Show("Data not saved","Don't Saved!",MessageBoxButton.OK,MessageBoxImage.Exclamation); }
            }
            catch
            {
                MessageBox.Show("An error occurred, please try again!","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
        public async Task<bool> RegisterAsync(User user)
        {
            int result = 0;
            await using(var connection=new NpgsqlConnection(DbConstants.DB_CONNECTIONSTRING))
            {                                
                await connection.OpenAsync();
                String query = "INSERT INTO public.users(first_name, last_name, email,password_hash, salt, created_at, updated_at)" +
                    "VALUES (@first_name, @last_name, @email,@password_hash, @salt, @created_at, @updated_at);";
                await using (var command = new NpgsqlCommand(query,connection)) 
                {
                    command.Parameters.AddWithValue("first_name", user.First_Name);
                    command.Parameters.AddWithValue("last_name",user.Last_Name);
                    command.Parameters.AddWithValue("email", user.Email);
                    command.Parameters.AddWithValue("password_hash", user.Password_hash);
                    command.Parameters.AddWithValue("salt", user.Salt);
                    command.Parameters.AddWithValue("created_at", user.CreatedAt);
                    command.Parameters.AddWithValue("updated_at", user.UpdatedAt);
                    
                    result=await command.ExecuteNonQueryAsync();
                    
                }
                             
                await connection.CloseAsync();                
            }
            return result > 0;
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }
    }
}
