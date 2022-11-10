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
using PLWPF.order;
using Exceptions;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for HostPersonalArea.xaml
    /// </summary>
    public partial class HostPersonalArea : Window
    {
        IBL bl = BlSingletonFactory.getBl_imp();
        Host thisHost;
        String language;
        public HostPersonalArea(Host host, String language)
        {
            InitializeComponent();

            thisHost = host;
            updateHostingUnits();

            this.language = language;
            updateLanguage(language);
        }
        #region update values
        private void updateHostingUnits()
        {
            SP.Children.Clear();
            List<HostingUnit> hostingUnits = bl.getHUsOfHost(thisHost);

            if (hostingUnits.Count == 0)
            {
                Label label = new Label();
                label.FontSize = 17;
                label.Content = "You don't have hosting units yet";
                SP.Children.Add(label);
            }
            for (int i = 0; i < hostingUnits.Count; i++)
            {
                HostingUnitUserControl tmp = new HostingUnitUserControl(hostingUnits[i],this.language);
                Label label = new Label();
                label.HorizontalAlignment = HorizontalAlignment.Center;
                label.FontSize = 17;
                label.Content = "HostingUnit name: " + (hostingUnits[i]).HostingUnitName;
                SP.Children.Add(label);
                SP.Children.Add(tmp);
            }
        }
        private void updateLanguage(String language)
        {
            if (language == "English")
            {
                hostingUnitsLabel.Content = "hosting units:";
                addCollectionClearanceButton.Content = "Add collection clearance";
                DeleteCollectionClearanceButton.Content = "Delete colloection clearance";
                AddHostingUnitButton.Content = "Add hosting unit";
                UpdateHostingUnitButton.Content = "Update hosting unit";
                DeleteHostingUnitButton.Content = "Delete Hosting unit";
                OrdersButton.Content = "Orders";
                LogOutButton.Content = "Log Out";
            }
            else
            {
                hostingUnitsLabel.Content = "יחידות אירוח:";
                addCollectionClearanceButton.Content = "הוסף אישור גבייה";
                DeleteCollectionClearanceButton.Content = "בטל אישור גבייה";
                AddHostingUnitButton.Content = "הוסף יחידת אירוח";
                UpdateHostingUnitButton.Content = "עדכן יחידת אירוח";
                DeleteHostingUnitButton.Content = "מחק יחידת אירוח";
                OrdersButton.Content = "הזמנות";
                LogOutButton.Content = "התנתק";
            }
        }
        #endregion

        private void deleteCollectionClearanceButton(object sender, RoutedEventArgs e)
        {
            if (thisHost.CollectionClearance == false)
            {
                MessageBox.Show("Collection clearance was already deleted ", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                bool success = true;
                try
                {
                    bl.deleteCollectionClearance(thisHost);
                }
                catch(ObjectNotFoundExcetion onfe)
                {
                    MessageBox.Show(onfe.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    success = false;
                }
                catch (ArgumentException ae)
                {
                    MessageBox.Show(ae.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    success = false;
                }
                if (success)
                    MessageBox.Show("Collection clearance was deleted successfully", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void addCollectionClearnceButton(object sender, RoutedEventArgs e)
        {
            if (thisHost.CollectionClearance == true)
            {
                MessageBox.Show("Collection clearance was already added ", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                thisHost.CollectionClearance = true;
                bl.addCollectionClearance(thisHost);
                MessageBox.Show("Collection clearance was added successfully", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


        private void addHostingUnitButton(object sender, RoutedEventArgs e)
        {
            AddHostingUnit ahu = new AddHostingUnit(thisHost, language);
            ahu.ShowDialog();
            updateHostingUnits();
        }

        private void updateHostingUnitButton(object sender, RoutedEventArgs e)
        {

            UpdateHostingUnit uhu = new UpdateHostingUnit(thisHost, language);
            uhu.ShowDialog();
            updateHostingUnits();
        }

        private void deleteHostingUnitButton(object sender, RoutedEventArgs e)
        {
            DeleteHostingUnit dhu = new DeleteHostingUnit(thisHost, language);
            dhu.ShowDialog();
            updateHostingUnits();
        }

        private void ordersButton(object sender, RoutedEventArgs e)
        {
            Orders order = new Orders(thisHost, language);
            order.Show();
            this.Close();
            updateHostingUnits();
        }

        private void logOutButton(object sender, RoutedEventArgs e)
        {
            HostRegistrationWindow hw = new HostRegistrationWindow(language);
            hw.Show();
            this.Close();
        }
    }
}
