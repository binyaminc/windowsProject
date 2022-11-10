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
using Exceptions;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for CreateOrder.xaml
    /// </summary>
    public partial class AddOrder : Window
    {
        IBL bl = BlSingletonFactory.getBl_imp();
        Host thisHost;
        String language;
        public AddOrder(Host host, String language)
        {
            InitializeComponent();

            this.language = language;
            updateLanguage(language);

            thisHost = host;
            List<HostingUnit> hostingUnitNames = bl.getHUsOfHost(host);
            IEnumerable<String> v = from h in hostingUnitNames
                                    select h.HostingUnitName;
            hostingUnitComboBox.ItemsSource = v;
        }

        private void updateLanguage(String language)
        {
            if (language == "English")
            {
                optionalGuestRequestLabel.Content = "Optional guest request";
                hostingUnitLabel.Content = "Hosting unit:";
                guestRequestLabel.Content = "Guest request:";
                AddOrderButton.Content = "Add order";
            }
            else
            {
                optionalGuestRequestLabel.Content = "בקשות אירוח אפשריות";
                hostingUnitLabel.Content = "יחידת אירוח:";
                guestRequestLabel.Content = "בקשות אירוח:";
                AddOrderButton.Content = "הוסף הזמנה";
            }
        }

        private void hostingUnitComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String hostingUnitName = hostingUnitComboBox.SelectedItem.ToString();
            HostingUnit hu = bl.getHUbyName(hostingUnitName);
            List<GuestRequest> guestRequests = bl.getGRsFitToHU(hu);
            List<string> guestRequestNames = new List<string>();
            
            foreach (GuestRequest gr in guestRequests)
                guestRequestNames.Add(gr.PrivateName);
            guestRequestComboBox.ItemsSource = guestRequestNames;

            //enter to userControl
            SP.Children.Clear();
            for (int i = 0; i < guestRequests.Count; i++)
            {
                GuestRequestUserControl tmp = new GuestRequestUserControl(guestRequests[i],this.language);
                Label label = new Label();
                label.HorizontalAlignment = HorizontalAlignment.Center;
                label.FontSize = 24;
                label.Content = "GuestRequest name: " + (guestRequests[i]).PrivateName;
                SP.Children.Add(label);
                SP.Children.Add(tmp);
            }
        }

        private void addOrderButton(object sender, RoutedEventArgs e)
        {
            String hostingUnitName = hostingUnitComboBox.Text;
            HostingUnit host = bl.getHUbyName(hostingUnitName);
            String guestRequestName = guestRequestComboBox.Text;
            GuestRequest gr = bl.getGRbyName(guestRequestName);
            Order o = new Order();
            //fill fields and enter to BL
            o.OrderKey = Configuration.OrderKey;
            o.GuestRequestKey = gr.GuestRequestKey;
            o.HostingUnitKey = host.HostingUnitKey;
            o.Status = MyOrder.NotYetTreated;
            o.CreateDate = DateTime.Now;
            o.Commission = 0;//not yet closed. calculated in "close deal"
            o.SentMailDate = new DateTime(1, 1, 1);
            try
            {
                bl.AddOrder(o);
            }
            catch(ArgumentNullException ane)
            {
                MessageBox.Show(ane.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(AlreadyExistsException aee)
            {
                MessageBox.Show(aee.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(InvalidOperationException ioe)
            {
                MessageBox.Show(ioe.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            
            this.Close();//close window
        }

    }
}
