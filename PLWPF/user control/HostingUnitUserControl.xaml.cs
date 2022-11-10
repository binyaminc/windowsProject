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
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for HostingUnitUserControl.xaml
    /// </summary>
    public partial class HostingUnitUserControl : UserControl
    {
        public HostingUnitUserControl(HostingUnit hostingUnit, string language)
        {
            InitializeComponent();
            hostingUnitUserControlGrid.DataContext = hostingUnit;
            updateLanguage(language);
        }

        private void updateLanguage(string language)
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


    }
}
