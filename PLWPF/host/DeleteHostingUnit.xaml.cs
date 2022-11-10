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
    /// Interaction logic for DeleteHostingUnit.xaml
    /// </summary>
    public partial class DeleteHostingUnit : Window
    {
        IBL bl = BlSingletonFactory.getBl_imp();
        Host thisHost;
        String language;
        public DeleteHostingUnit(Host host, String language)
        {
            InitializeComponent();
            thisHost = host;
            List<HostingUnit> hostingUnitNames = bl.getHUsOfHost(host);
            IEnumerable<String> v = from h in hostingUnitNames
                                    select h.HostingUnitName;
            choiseComboBox.ItemsSource = v;

            this.language = language;
            updateLanguage(language);
        }
        private void updateLanguage(String language)
        {
            if (language == "English")
            {
                hostingUnitToDeleteLabel.Content = "Hosting unit to delete:";
                DeleteButton.Content = "Delete";
            }
            else
            {
                hostingUnitToDeleteLabel.Content = "יחידת אירוח למחיקה:";
                DeleteButton.Content = "מחק";
            }
        }

        private void deleteButton(object sender, RoutedEventArgs e)
        {
            String hostingUnitName = choiseComboBox.SelectedItem.ToString();
            HostingUnit hu = bl.getHUbyName(hostingUnitName);
            try
            {
                bl.DeleteHostingUnit(hu);
            }
            catch(ObjectNotFoundExcetion onfe)
            {
                MessageBox.Show(onfe.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(InvalidOperationException ioe)
            {
                MessageBox.Show(ioe.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Close();
        }
    }
}
