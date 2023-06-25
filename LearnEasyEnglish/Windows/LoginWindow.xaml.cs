using LearnEasyEnglish.Constants;
using LearnEasyEnglish.Repositories.Users;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton==MouseButtonState.Pressed) 
            {
                DragMove();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState=WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        public async Task<(string PasswordHash, string Salt,long Id)> LoginAsync(string name, string password)
        {
            long id = 0;
            string password_hash = string.Empty;
            string salt = string.Empty;
            await using (var connection = new NpgsqlConnection(DbConstants.DB_CONNECTIONSTRING))
            {
                await connection.OpenAsync();

                string query = "select * from users where first_name=@name;";

                await using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("name", name);
                    command.Parameters.AddWithValue("password", password);

                    var reader = await command.ExecuteReaderAsync();
                    if (await reader.ReadAsync())
                    {
                        id = reader.GetInt64(0);
                        password_hash = reader.GetString(4);
                        salt = reader.GetString(5);
                        
                    }
                }
                await connection.CloseAsync();
            }
            return (PasswordHash: password_hash, Salt: salt,Id: id);
        }
        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string password = tbPassword.Password;
            string name = tbName.Text.ToLower();
            try
            {
                bool a = false;
                var dbResult = await LoginAsync(name, password);
                a = PasswordHasher.Verify(password, dbResult.PasswordHash, dbResult.Salt);
                if (a)
                {
                    this.Hide();
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.tblUser.Text = tbName.Text;
                    mainWindow.tbId.Text =(dbResult.Id.ToString());
                    mainWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Username and/or Password is wrong.!");
                }
            }
            catch
            {
                MessageBox.Show("Username and/or Password is wrong. You can try again!");
            }




        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private async void Signup_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            SignupWindow signupWindow = new SignupWindow();
            signupWindow.Show();
        }
    }
}
