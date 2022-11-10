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
using BE;
using BL;


namespace PLWPF
{
    /// <summary>
    /// Interaction logic for OrderDisplay.xaml
    /// </summary>
    public partial class OrderDisplay : Window
    {
        IBL bl = BlSingletonFactory.getBl_imp();
        String language;

        public OrderDisplay(String language)
        {
            InitializeComponent();

            this.language = language;

            List<Order> orders = bl.GetOrders();
            for (int i = 0; i < orders.Count; i++)
            {
                OrderUserControl tmp = new OrderUserControl(orders[i], language);
                Label label = new Label();
                label.HorizontalAlignment = HorizontalAlignment.Center;
                label.FontSize = 17;
                label.Content = "Order index: " + orders[i].OrderKey;
                SP.Children.Add(label);
                SP.Children.Add(tmp);
            }
        }

        private void GoBackButton(object sender, RoutedEventArgs e)
        {
            AdminWindow aw = new AdminWindow(language);
            aw.Show();
            this.Close();
        }
    }
}
