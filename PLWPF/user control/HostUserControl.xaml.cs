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

namespace PLWPF.user_control
{
    /// <summary>
    /// Interaction logic for HostUserControl.xaml
    /// </summary>
    public partial class HostUserControl : UserControl
    {
        public HostUserControl(Host host, String language)
        {
            InitializeComponent();
            hostUserControlGrid.DataContext = host;
            updateLanguage(language);
        }
        private void updateLanguage(String language)
        {
            if (language == "English")
            {
                privateNameLabel.Content = "Private Name:";
                familyNameLabel.Content = "Family Name:";
                phoneNumberLabel.Content = "Phone Number:";
                mailAddressLabel.Content = "Mail Address:";
                bankAccountNumberLabel.Content = "Bank Account Number:";
                collectionClearanceLabel.Content = "Collection Clearance:";
                passwordLabel.Content = "Password:";
                bankNameLabel.Content = "Bank Name:";
            }
            else
            {
                privateNameLabel.Content = "שם פרטי:";
                familyNameLabel.Content = "שם משפחה:";
                phoneNumberLabel.Content = "מספר טלפון:";
                mailAddressLabel.Content = "כתובת מייל:";
                bankAccountNumberLabel.Content = "מספר חשבון בנק:";
                collectionClearanceLabel.Content = "הרשאת חיוב:";
                passwordLabel.Content = "סיסמה:";
                bankNameLabel.Content = "מספר בנק:";
            }
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
    }
}
