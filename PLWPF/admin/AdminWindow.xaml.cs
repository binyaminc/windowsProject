using PLWPF.display_objects;
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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private IBL bl = BlSingletonFactory.getBl_imp();
        String language;
        public AdminWindow(String language)
        {
            InitializeComponent();
            this.language = language;
            updateLanguage(language);
        }
        private void updateLanguage(String language)
        {
            if (language == "English")
            {
                GuestRequestButton.Content = "Show guest requests";
                HostingUnitButton.Content = "Show hosting units";
                HostsButton.Content = "Show hosts";
                OrdersButton.Content = "Show orders";
            }
            else
            {
                GuestRequestButton.Content = "הצגת בקשות אירוח";
                HostingUnitButton.Content = "הצגת יחידות אירוח";
                HostsButton.Content = "הצגת מארחים";
                OrdersButton.Content = "הצגת הזמנות";
            }
        }

        private void guestRequestButton(object sender, RoutedEventArgs e)
        {
            if (bl.GetGuestRequests().Count() > 0)
            {
                GuestRequestDisplay grd = new GuestRequestDisplay(language);
                grd.Show();
                Close();
            }
            else
                MessageBox.Show("There are no guest requests in this system", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        private void hostingUnitsButton(object sender, RoutedEventArgs e)
        {
            if (bl.GetHostingUnits().Count() > 0)
            {
                HostingUnitDisplay hrd = new HostingUnitDisplay(language);
                hrd.Show();
                Close();
            }
            else
                MessageBox.Show("There are no hosting units in this system", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        private void hostsButton(object sender, RoutedEventArgs e)
        {
            if (bl.getHosts().Count() > 0)
            {
                HostDisplay hd = new HostDisplay(language);
                hd.Show();
                Close();
            }
            else
                MessageBox.Show("There are no hosts in this system", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        private void ordersButton(object sender, RoutedEventArgs e)
        {
            if (bl.GetOrders().Count() > 0)
            {
                OrderDisplay od = new OrderDisplay(language);
                od.Show();
                Close();
            }
            else
                MessageBox.Show("There are no orders in this system", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void GoBackButton(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow(language);
            mw.Show();
            this.Close();
        }
    }
}
