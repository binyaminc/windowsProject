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
using BL;
using BE;
using Exceptions;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for Host.xaml
    /// </summary>
    public partial class HostRegistrationWindow : Window
    {
        IBL bl = BlSingletonFactory.getBl_imp();
        String language;

        public HostRegistrationWindow(String language)
        {
            InitializeComponent();

            this.language = language;
            updateLanguage(language);

            BankBranchComboBox.ItemsSource = bl.GetBankBranches();
        }
        private void updateLanguage(String language)
        {
            if (language == "English")
            {
                privateNameLabel.Content = "Private Name:";
                familyNameLabel.Content = "Family Name:";
                phoneNumberLabel.Content = "Phone Number:";
                mailAddressLabel.Content = "Mail Address:";
                signUpPasswordLabel.Content = "Password:";
                collectionClearanceLabel.Content = "Collection Clearance:";
                bankAccountNumberLabel.Content = "Bank Account Number:";
                bankBrachLabel.Content = "Banck Branch:";
                signUpButton.Content = "Sign Up:";
                loginPasswordLabel.Content = "Password";
                userNameLabel.Content = "Name:";
                signUpPasswordLabel.Content = "Password:";
                loginButton.Content = "Log In:";
            }
            else
            {
                privateNameLabel.Content = "שם פרטי:";
                familyNameLabel.Content = "שם משפחה:";
                phoneNumberLabel.Content = "מספר טלפון:";
                mailAddressLabel.Content = "כתובת מייל:";
                signUpPasswordLabel.Content = "סיסמה:";
                collectionClearanceLabel.Content = "אישור גבייה:";
                bankAccountNumberLabel.Content = "מספר חשבון בנק:";
                bankBrachLabel.Content = "סניף:";
                signUpButton.Content = "הרשם";
                loginPasswordLabel.Content = "סיסמה:";
                userNameLabel.Content = "שם משתמש:";
                signUpPasswordLabel.Content = "סיסמה:";
                loginButton.Content = "התחבר";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow(language);
            mw.Show();
            this.Close();
        }

        private void LoginButton(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text == "" || PasswordBox.Password == "")
            {
                NameTextBox.BorderBrush = NameTextBox.Text == "" ? Brushes.Red : Brushes.LimeGreen;
                PasswordBox.BorderBrush = PasswordBox.Password == "" ? Brushes.Red : Brushes.LimeGreen;
                MessageBox.Show(new DataNotFilledException("name or password").Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            Host host = new Host();
            bool isExist = false;
            foreach (Host h in bl.getHosts())
            {
                if ((h.PrivateName == NameTextBox.Text) && (h.Password == PasswordBox.Password))
                {
                    host = h;
                    isExist = true;
                }
            }
            if (isExist)
            {
                HostPersonalArea hpa = new HostPersonalArea(host, language);
                hpa.Show();
                this.Close();
            }
            else
            {
                PasswordBox.Password = "";
                MessageBox.Show(new IncorrectUserNameOrPassword().Message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void SignUpButton(object sender, RoutedEventArgs e)
        {
            string msgText = "";
            Host host = new Host();

            host.CollectionClearance = (bool)(collectionClearanceCheckBox.IsChecked);

            #region bankAccountNumber
            int bankAccountNumber;
            if (bankAccountNumberTextBox.Text == "")
            {
                bankAccountNumberTextBox.BorderBrush = Brushes.Red;
                msgText = (msgText == "" ? new DataNotFilledException("bank account number").Message : msgText);
            }
            else if (!((int.TryParse(bankAccountNumberTextBox.Text, out bankAccountNumber)) && (bankAccountNumber <= 999999999)))
            {
                bankAccountNumberTextBox.BorderBrush = Brushes.Red;
                msgText = msgText == "" ? new ArgumentException("Invalid bank account number").Message : msgText;
            }
            else
            {
                host.BankAccountNumber = bankAccountNumber;
                bankAccountNumberTextBox.BorderBrush = Brushes.LimeGreen;
            }
            #endregion

            #region family name
            if (familyNameTextBox.Text == "")
            {
                familyNameTextBox.BorderBrush = Brushes.Red;
                msgText = msgText == "" ? new DataNotFilledException("family name").Message : msgText;
            }
            else
            {
                host.FamilyName = familyNameTextBox.Text;
                familyNameTextBox.BorderBrush = Brushes.LimeGreen;
            }
            #endregion

            #region phone number
            int phoneNumber = 0;
            if (phoneNumberTextBox.Text == "")
            {
                phoneNumberTextBox.BorderBrush = Brushes.Red;
                msgText = msgText == "" ? new DataNotFilledException("phone number").Message : msgText;
            }
            else if (!((int.TryParse(phoneNumberTextBox.Text, out phoneNumber)) && (phoneNumber <= 999999999)))
            {
                phoneNumberTextBox.BorderBrush = Brushes.Red;
                msgText = msgText == "" ? new ArgumentException("Invalid phone number").Message : msgText;
            }
            else
            {
                host.PhoneNumber = phoneNumber;
                phoneNumberTextBox.BorderBrush = Brushes.LimeGreen;
            }
            #endregion

            #region mail address
            if (mailAddressTextBox.Text == "")
            {
                mailAddressTextBox.BorderBrush = Brushes.Red;
                msgText = msgText == "" ? new DataNotFilledException("mail address").Message : msgText;
            }
            if (!(mailAddressTextBox.Text).Contains("@"))
            {
                mailAddressTextBox.BorderBrush = Brushes.Red;
                msgText = msgText == "" ? new ArgumentException("Invalid mail address").Message : msgText;
            }
            else
            {
                host.MailAddress = mailAddressTextBox.Text;
                mailAddressTextBox.BorderBrush = Brushes.LimeGreen;
            }
            #endregion

            #region password
            if (passwordTextBox.Text == "")
            {
                passwordTextBox.BorderBrush = Brushes.Red;
                msgText = msgText == "" ? new DataNotFilledException("password").Message : msgText;
            }
            else
            {
                passwordTextBox.BorderBrush = Brushes.LimeGreen;
                host.Password = passwordTextBox.Text;
            }
            #endregion

            #region private name
            if (privateNameTextBox.Text == "")
            {
                privateNameTextBox.BorderBrush = Brushes.Red;
                msgText = msgText == "" ? new DataNotFilledException("privte name").Message : msgText;
            }
            else if (bl.getHosts().Exists(h => h.PrivateName == privateNameTextBox.Text))
            {
                privateNameTextBox.BorderBrush = Brushes.Red;
                msgText = msgText == "" ? new AlreadyExistsException(privateNameTextBox.Text, "host").Message : msgText;
            }
            else
            {
                privateNameTextBox.BorderBrush = Brushes.LimeGreen;
                host.PrivateName = privateNameTextBox.Text;
            }
            #endregion

            #region bank branch
            if (BankBranchComboBox.Text == "")
            {
                BankBranchComboBox.BorderBrush = Brushes.Red;
                msgText = msgText == "" ? new DataNotFilledException("bank branch").Message : msgText;
            }
            else
            {
                BankBranchComboBox.BorderBrush = Brushes.LimeGreen;
                host.BankBranchDetails = (BE.BankBranch) BankBranchComboBox.SelectedItem;
            }
            #endregion


            if (msgText == "")
            {
                host.HostKey = Configuration.HostKey;//it will get a key only if all the other fields are valid, because otherwise there will be many unused keys
                try
                {
                    bl.AddHost(host);
                }
                catch (AlreadyExistsException aee)
                {
                    MessageBox.Show(aee.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                HostPersonalArea hpa = new HostPersonalArea(host, language);
                hpa.Show();
                Close();
            }
            else
            {
                MessageBox.Show(msgText, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

           
        }

        private void enterSighnUp(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Enter))
            {
                SignUpButton(this, new RoutedEventArgs());
            }
        }


        private void enterLogIn(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Enter))
            {
                LoginButton(this, new RoutedEventArgs());
            }
        }

    }
}
