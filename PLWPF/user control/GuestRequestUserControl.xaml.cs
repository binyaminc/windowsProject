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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for GuestRequestUserControl.xaml
    /// </summary>
    public partial class GuestRequestUserControl : UserControl
    {
        public GuestRequestUserControl(GuestRequest gr, string language)
        {
            InitializeComponent();
            guestRequestUserControlGrid.DataContext = gr;
            updateLanguage(language);

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            // Do not load your data at design time.
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//Load your data here and assign the result to the CollectionViewSource.
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }
        }

        private void updateLanguage(string language)
        {
            if (language == "English")
            {
                privateNameLabel.Content = "Private Name:";
                familyNameLabel.Content = "Family Name:";
                mailAddressLabel.Content = "Mail Address:";
                adultsLabel.Content = "Adults:";
                childrenLabel.Content = "Children";
                entryDateLabel.Content = "Entry Date:";
                releaseDateLabel.Content = "Release Date:";
                areaLabel.Content = "Area:";
                subAreaLabel.Content = "Sub Area:";
                typeLabel.Content = "Type:";
                poolLabel.Content = "Pool:";
                jacuzziLabel.Content = "Jacuzzi:";
                gardenLabel.Content = "Garden:";
                childrenAttractionsLabel.Content = "Children Attractions:";
                registrationDateLabel.Content = "Registration Date:";
                statusLabel.Content = "Status:";
            }
            else
            {
                privateNameLabel.Content = "שם פרטי:";
                familyNameLabel.Content = "שם משפחה:";
                mailAddressLabel.Content = "כתובת מייל:";
                adultsLabel.Content = "מספר מבוגרים:";
                childrenLabel.Content = "מספר ילדים:";
                entryDateLabel.Content = "תאריך כניסה:";
                releaseDateLabel.Content = "תאריך יציאה:";
                areaLabel.Content = "אזור:";
                subAreaLabel.Content = "תת אזור:";
                typeLabel.Content = "סוג:";
                poolLabel.Content = "בריכה:";
                jacuzziLabel.Content = "ג'קוזי:";
                gardenLabel.Content = "גינה:";
                childrenAttractionsLabel.Content = "אטרקציות לילדים:";
                registrationDateLabel.Content = "תאריך הרשמה:";
                statusLabel.Content = "סטטוס:";
            }
        }
    }
}
