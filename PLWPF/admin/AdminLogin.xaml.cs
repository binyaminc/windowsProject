using System;
using System.Windows;
using System.Windows.Input;
using Exceptions;

namespace PLWPF.admin
{
    /// <summary>
    /// Interaction logic for AdminLogin.xaml
    /// </summary>
    public partial class AdminLogin : Window
    {
        String language;
        public AdminLogin(String language)
        {
            InitializeComponent();
            this.language = language;
            updateLanguage(language);
        }
        private void updateLanguage(String language)
        {
            if (language == "English")
            {
                adminLoginLabel.Content = "Admin login";
                userLabel.Content = "User:";
                passwordLabel.Content = "Password:";
                loginButton.Content = "Login";
            }
            else
            {
                adminLoginLabel.Content = "כניסת מנהל";
                userLabel.Content = "שם משתמש:";
                passwordLabel.Content = "סיסמה:";
                loginButton.Content = "הכנס";
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = "admin";
            string password = "12345";

            if(Username.Text == username && Password.Password == password)
            {
                AdminWindow admin = new AdminWindow(language);
                admin.Show();
                Close();
            }
            else
            {
                Password.Password = "";
                MessageBox.Show(new IncorrectUserNameOrPassword().Message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Enter))
            {
                Login_Click(this, new RoutedEventArgs());
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow(language);
            mw.Show();
            this.Close();
        }
    }
}
