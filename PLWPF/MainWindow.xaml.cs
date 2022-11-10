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
using BL;
using BE;
using PLWPF.admin;
using System.ComponentModel;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL bl = BlSingletonFactory.getBl_imp();

        String language = "English";

        public MainWindow()
        {
            InitializeComponent();

            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += loadBankBranches;
            backgroundWorker.RunWorkerAsync("");
            
        }
        public MainWindow(String language)
        {
            InitializeComponent();

            this.language = language;
            updateLanguage(language);
             
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += loadBankBranches;
            backgroundWorker.RunWorkerAsync("");
            
        }

        private void English_Click(object sender, RoutedEventArgs e)
        {
            language = "English";
            updateLanguage(language);
        }

        private void Hebrew_Click(object sender, RoutedEventArgs e)
        {
            language = "עברית";
            updateLanguage(language);
        }

        private void loadBankBranches(Object sender, DoWorkEventArgs e)
        {
            bl.loadBankBranches();
        }

        private void Guest_Click(object sender, RoutedEventArgs e)
        {
            AddGuestRequest AGR = new AddGuestRequest(language);
            AGR.ShowDialog();
        }

        private void Host_Click(object sender, RoutedEventArgs e)
        {
            HostRegistrationWindow host = new HostRegistrationWindow(language);
            host.Show();
            this.Close();
        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            AdminLogin adminLogin = new AdminLogin(language);
            adminLogin.Show();
            Close();
        }
        private void updateLanguage(String language)
        {
            if (language == "English")
            {
                guestButton.Content = "Guest request";
                hostButton.Content = "Login as host";
                adminButton.Content = "Login as admin";
                exitButton.Content = "Exit program";
            }
            else
            {
                guestButton.Content = "בקשת אירוח";
                hostButton.Content = "התחברות כמארח";
                adminButton.Content = "התחברות כמנהל";
                exitButton.Content = "יציאה מהתוכנה";
            }
        }

        private void ExitProggram_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("are you sure you want to cancel?", "Cancel?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Close();
                Environment.Exit(0);
            }
        }

    }
}
