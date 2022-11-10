using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Exceptions;

namespace PLWPF.order
{
    /// <summary>
    /// Interaction logic for OrdersPanel.xaml
    /// </summary>
    public partial class Orders : Window
    {
        IBL bl = BlSingletonFactory.getBl_imp();
        Host thisHost;
        String language;

        #region object to use when activate backgroundWorker

        Order orderBW;
        GuestRequest GRBW;
        HostingUnit HUBW;

        #endregion

        public Orders(Host host, String language)
        {
            InitializeComponent();
            thisHost = host;
            updateOrders();

            this.language = language;
            updateLanguage(language);
        }
        #region update elements
        private void updateOrders()
        {
            SP.Children.Clear();
            List<Order> orders = bl.getOrdersOfHost(thisHost);

            if (orders.Count == 0)
            {
                Label label = new Label();
                label.FontSize = 17;
                label.Content = "You don't have orders yet";
                SP.Children.Add(label);
            }
            for (int i = 0; i < orders.Count; i++)
            {
                OrderUserControl tmp = new OrderUserControl(orders[i],language);
                Label label = new Label();
                label.HorizontalAlignment = HorizontalAlignment.Center;
                label.FontSize = 17;
                label.Content = "Order index: " + orders[i].OrderKey;
                SP.Children.Add(label);
                SP.Children.Add(tmp);
            }

            orderNameCDComboBox.ItemsSource = from order in bl.getOrdersOfHost(thisHost)
                                              select order.OrderKey;
            orderNameSIComboBox.ItemsSource = from order in bl.getOrdersOfHost(thisHost)
                                              select order.OrderKey;

            orderNameCDComboBox.SelectedItem = null;
            closingTypeCDComboBox.SelectedItem = null;
            orderNameSIComboBox.SelectedItem = null;

        }
        private void updateLanguage(String language)
        {
            if (language == "English")
            {
                orderIndexLabel1.Content = "Order index:";
                closingTypeLabel.Content = "Closing type:";
                CloseDealButton.Content = "Close Deal";
                orderIndexLabel2.Content = "Order index:";
                SendInvitationButton.Content = "Send invitation";
                addOrderButton.Content = "Add order";
                deleteOrderButton.Content = "Delete order";
            }
            else
            {
                orderIndexLabel1.Content = "מספר הזמנה:";
                closingTypeLabel.Content = "סוג סגירה:";
                CloseDealButton.Content = "סגור עסקה";
                orderIndexLabel2.Content = "מספר הזמנה:";
                SendInvitationButton.Content = "שלח הזמנה";
                addOrderButton.Content = "הוסף הזמנה";
                deleteOrderButton.Content = "מחק הזמנה";
            }
        }
        #endregion
        private void AddOrderButton(object sender, RoutedEventArgs e)
        {
            AddOrder ao = new AddOrder(thisHost, language);
            ao.ShowDialog();
            updateOrders();
        }
        private void closeDealButton_Click(object sender, RoutedEventArgs e)
        {
            Order order = bl.getOrderByKey(int.Parse(orderNameCDComboBox.Text));
            MyOrder status = (MyOrder)Enum.Parse(typeof(MyOrder), closingTypeCDComboBox.Text);
            try
            {
                bl.closeDeal(order, status);
            }
            catch (ObjectNotFoundExcetion onfe)
            {
                MessageBox.Show(onfe.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (InvalidOperationException ioe)
            {
                MessageBox.Show(ioe.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            updateOrders();
        }

        private void sendInvitationButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //initializing the order, GR and HU to which we send a mail
                orderBW = bl.getOrderByKey(int.Parse(orderNameSIComboBox.Text));
                GRBW = orderBW.getGuestRequest();
                HUBW = orderBW.GetHostingUnit();

                bl.guestInvitation(orderBW);//change status

                //send mail using Gmail
                BackgroundWorker backgroundWorker = new BackgroundWorker();
                backgroundWorker.DoWork += sendInvitationOnGmailBackgroundWorker;
                backgroundWorker.RunWorkerAsync();
            }
            catch (ObjectNotFoundExcetion onfe)
            {
                MessageBox.Show(onfe.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (InvalidOperationException ioe)
            {
                MessageBox.Show(ioe.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            updateOrders();
        }
        private void sendInvitationOnGmailBackgroundWorker(Object sender, DoWorkEventArgs e)//, Order o, GuestRequest gr, HostingUnit hu
        {
            try
            {
                bl.sendInvitationOnGmail(orderBW, GRBW, HUBW);
            }
            catch (InvalidOperationException ioe)
            {
                throw ioe;
            }
        }

        private void deleteOrderButton_Click(object sender, RoutedEventArgs e)
        {
            Order order = bl.getOrderByKey(int.Parse(orderNameSIComboBox.Text));
            try
            {
                bl.DeleteOrder(order);
                updateOrders();
            }
            catch (InvalidOperationException ioe)
            {
                updateOrders();
                MessageBox.Show(ioe.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void goBackButton(object sender, RoutedEventArgs e)
        {
            HostPersonalArea aph = new HostPersonalArea(thisHost, language);
            aph.Show();
            Close();
        }

    }
}
