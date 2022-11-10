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
using BL;
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for GuestRequestDisplay.xaml
    /// </summary>
    public partial class GuestRequestDisplay : Window
    {
        IBL bl = BlSingletonFactory.getBl_imp();
        String language;
        public GuestRequestDisplay(String language)
        {
            InitializeComponent();

            this.language = language;

            List<GuestRequest> guestRequests = bl.GetGuestRequests();
            for (int i = 0; i < guestRequests.Count; i++)
            {
                GuestRequestUserControl tmp = new GuestRequestUserControl(guestRequests[i],this.language);
                Label label = new Label();
                label.HorizontalAlignment = HorizontalAlignment.Center;
                label.FontSize = 17;
                label.Content = "GuestRequest name: " + (guestRequests[i]).PrivateName;
                SP.Children.Add(label);
                SP.Children.Add(tmp);
            }
        }

        private void goBackButton(object sender, RoutedEventArgs e)
        {
            AdminWindow aw = new AdminWindow(language);
            aw.Show();
            this.Close();
        }
    }
}
//TODO: 