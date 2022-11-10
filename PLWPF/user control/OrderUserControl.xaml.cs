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
    /// Interaction logic for OrderUserControl.xaml
    /// </summary>
    public partial class OrderUserControl : UserControl
    {
        IBL bl = BlSingletonFactory.getBl_imp();
        public OrderUserControl(Order order, string language)
        {
            InitializeComponent();
            orderUserControlGrid.DataContext = order;
            orderKeyLabel.Content = order.OrderKey;
            guestRequestNameLabel2.Content = bl.getGRNameByKey(order.GuestRequestKey);
            hostingUnitNameLabel2.Content = bl.getHUNameByKey(order.HostingUnitKey);
            updateLanguage(language);
        }

        private void updateLanguage(string language)
        {
            if(language == "English")
            {
                guestRequestNameLabel.Content = "guest request name:";
                hostingUnitNameLabel.Content = "hosting unit name:";
                commissionLabel.Content = "commission:";
                createDateLabel.Content = "create date:";
                orderKeyLabel.Content = "order key:";
                sentMailDateLabel.Content = "sent mail date:";
                statusLabel.Content = "status:";
            }
            else
            {
                guestRequestNameLabel.Content = "בקשת אירוח:";
                hostingUnitNameLabel.Content = "שם יחידת אירוח:";
                commissionLabel.Content = "עמלה:";
                createDateLabel.Content = "תאריך יצירת הזמנה:";
                orderKeyLabel.Content = "מספר הזמנה";
                sentMailDateLabel.Content = "תאריך שליחת מייל:";
                statusLabel.Content = "סטטוס:";
            }
            
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
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
