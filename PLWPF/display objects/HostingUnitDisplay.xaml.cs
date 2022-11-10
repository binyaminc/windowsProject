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
    /// Interaction logic for HostingUnitDisplay.xaml
    /// </summary>
    public partial class HostingUnitDisplay : Window
    {
        IBL bl = BlSingletonFactory.getBl_imp();
        Host thisHost;
        String language;
        public HostingUnitDisplay(String language)
        {
            InitializeComponent();

            this.language = language;
            updateLanguage(language);

            List<Host> hosts = bl.getHosts();
            List<String> v = (from host in hosts
                                    select host.PrivateName).ToList();
            choiseComboBox.ItemsSource = v;
        }
        private void updateLanguage(String language)
        {
            if (language == "English")
                chooseHostLabel.Content = "choose host:";
            else
                chooseHostLabel.Content = "בחר מארח:";
        }

        private void choiseComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            String hostName = choiseComboBox.SelectedItem.ToString();
            thisHost = bl.getHostByName(hostName);
            List<HostingUnit> hostingUnits = bl.getHUsOfHost(thisHost);

            SP.Children.Clear();
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

        private void GoBackButton(object sender, RoutedEventArgs e)
        {
            AdminWindow aw = new AdminWindow(language);
            aw.Show();
            this.Close();
        }
    }
}
