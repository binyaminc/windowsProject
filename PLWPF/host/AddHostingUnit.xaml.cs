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
    /// Interaction logic for AddHostingUnit.xaml
    /// </summary>
    public partial class AddHostingUnit : Window
    {
        IBL bl = BlSingletonFactory.getBl_imp();
        Host thisOwner = new Host();
        String language;

        public AddHostingUnit(Host owner, String language)
        {
            InitializeComponent();
            thisOwner = owner;

            this.language = language;
            updateLanguage(language);
        }
        private void updateLanguage(String language)
        {
            if (language == "English")
            {
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
            }
            else
            {
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
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource hostingUnitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hostingUnitViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // hostingUnitViewSource.Source = [generic data source]
        }

        private void AddButton(object sender, RoutedEventArgs e)
        {
            String msgText = "";
            HostingUnit hu = new HostingUnit();

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

            #region hosting unit name
            if (hostingUnitNameTextBox.Text == "")
            {
                hostingUnitNameTextBox.BorderBrush = Brushes.Red;
                msgText = msgText == "" ? new DataNotFilledException("hosting unit name").Message : msgText;
            }
            else
            {
                hostingUnitNameTextBox.BorderBrush = Brushes.LimeGreen;
                hu.HostingUnitName = hostingUnitNameTextBox.Text;
            }
            #endregion

            #region diary
            bool[,] diary = new bool[12, 31];
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    diary[i, j] = false;
                }
            }
            hu.Diary = diary;
            #endregion

            hu.Owner = thisOwner;

            #region type
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
                int f = Configuration.HostingUnitKey;
                hu.HostingUnitKey = f;
                try
                {
                    bl.AddHostingUnit(hu);
                }
                catch(AlreadyExistsException aee)
                {
                    MessageBox.Show(aee.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                AddButton(this, new RoutedEventArgs());
            }
        }
    }
}
