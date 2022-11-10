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
    /// Interaction logic for UpdateHostingUnit.xaml
    /// </summary>
    public partial class UpdateHostingUnit : Window
    {
        IBL bl = BlSingletonFactory.getBl_imp();
        Host thisHost;
        String language;
        public UpdateHostingUnit(Host host, String language)
        {
            InitializeComponent();

            this.language = language;
            updateLanguage(language);

            thisHost = host;
            List<HostingUnit> hostingUnitNames = bl.getHUsOfHost(host);
            IEnumerable<String> v = from h in hostingUnitNames
                                    select h.HostingUnitName;
            choiseComboBox.ItemsSource = v;

            this.typeComboBox.ItemsSource = Enum.GetValues(typeof(BE.Type));

        }

        private void updateLanguage(String language)
        {
            if (language == "English")
            {
                enterLabel.Content = "Enter hosting unit's name:";
                hostingUnitNameLabel.Content = "Hosting unit name:";
                areaLabel.Content = "Area:";
                subAreaLabel.Content = "Sub Area:";
                addressLabel.Content = "Address:";
                typeLabel.Content = "Type:";
                capacityLabel.Content = "Capacity";
                poolLabel.Content = "Pool:";
                jacuzziLabel.Content = "Jacuzzi:";
                gardenLabel.Content = "Garden:";
                childrenAttractionsLabel.Content = "Children Attractions:";
                UpdateButton.Content = "Update";
            }
            else
            {
                enterLabel.Content = "הכנס שם של יחידת אירוח:";
                hostingUnitNameLabel.Content = "שם יחידת אירוח:";
                areaLabel.Content = "אזור:";
                subAreaLabel.Content = "תת אזור:";
                addressLabel.Content = "כתובת:";
                typeLabel.Content = "סוג:";
                capacityLabel.Content = "תפוסה מלאה:";
                poolLabel.Content = "בריכה:";
                jacuzziLabel.Content = "ג'קוזי:";
                gardenLabel.Content = "גינה:";
                childrenAttractionsLabel.Content = "אטרקציות לילדים:";
                UpdateButton.Content = "עדכן";
            }
        }

        private void choiseComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String hostingUnitName = choiseComboBox.SelectedItem.ToString();
            HostingUnit hu = bl.getHUbyName(hostingUnitName);
            
            grid1.DataContext = hu;
            areaComboBox.Text = hu.Area.ToString();
            typeComboBox.SelectedItem = hu.Type;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource hostingUnitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hostingUnitViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // hostingUnitViewSource.Source = [generic data source]
        }

        private void updateButton(object sender, RoutedEventArgs e)
        {
            String msgText = "";
            HostingUnit hu = new HostingUnit();

            #region choise combo box
            if (choiseComboBox.Text == "")
            {
                choiseComboBox.BorderBrush = Brushes.Red;
                msgText = msgText == "" ? new DataNotFilledException("choise combo box").Message : msgText;
            }
            else
            {
                choiseComboBox.BorderBrush = Brushes.LimeGreen;
                String hostingUnitName = choiseComboBox.SelectedItem.ToString();
                hu = bl.getHUbyName(hostingUnitName);
            }
            #endregion

            #region address
            if (addressTextBox.Text == "")
            {
                addressTextBox.BorderBrush = Brushes.Red;
                msgText = msgText == "" ? new DataNotFilledException("address").Message : msgText;
            }
            else
            {
                addressTextBox.BorderBrush = Brushes.LimeGreen;
                hu.Address = addressTextBox.Text;
            }
            #endregion

            #region area
            if (areaComboBox.Text == "")
            {
                msgText = msgText == "" ? new DataNotFilledException("area").Message : msgText;
            }
            else hu.Area = (BE.Area)Enum.Parse(typeof(BE.Area), areaComboBox.Text);
            #endregion

            #region capacity
            int capacity = -1;
            if (capacityTextBox.Text == "")
            {
                capacityTextBox.BorderBrush = Brushes.Red;
                msgText = msgText == "" ? new DataNotFilledException("capacity").Message : msgText;
            }
            else if (!(int.TryParse(capacityTextBox.Text, out capacity) && capacity > 0))
            {
                capacityTextBox.BorderBrush = Brushes.Red;
                msgText = msgText == "" ? new ArgumentException("invalid capacity").Message : msgText;
            }
            else
            {
                capacityTextBox.BorderBrush = Brushes.LimeGreen;
                hu.Capacity = capacity;
            }
            #endregion

            #region area
            if (typeComboBox.Text == "")
            {
                msgText = msgText == "" ? new DataNotFilledException("type").Message : msgText;
            }
            else hu.Type = (BE.Type)Enum.Parse(typeof(BE.Type), typeComboBox.Text);
            #endregion


            hu.SubArea = subAreaTextBox.Text;

            hu.Pool = (bool)(poolCheckBox.IsChecked);
            hu.Jacuzzi = (bool)(jacuzziCheckBox.IsChecked);
            hu.Garden = (bool)(gardenCheckBox.IsChecked);
            hu.ChildrenAttractions = (bool)(childrensAttractionsCheckBox.IsChecked);

            if (msgText == "")
            {
                try
                {
                    bl.UpdateHostingUnit(hu);
                }
                catch (ObjectNotFoundExcetion onfe)
                {
                    MessageBox.Show(onfe.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                Close();
            }
            else
            {
                MessageBox.Show(msgText, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Enter))
            {
                updateButton(this, new RoutedEventArgs());
            }
        }

    }
}
