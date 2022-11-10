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
using PLWPF.user_control;

namespace PLWPF.display_objects
{
    /// <summary>
    /// Interaction logic for HostDisplay.xaml
    /// </summary>
    public partial class HostDisplay : Window
    {
        IBL bl = BlSingletonFactory.getBl_imp();
        String language;
        public HostDisplay(String language)
        {
            InitializeComponent();

            this.language = language;

            List<Host> hosts = bl.getHosts();
            for (int i = 0; i < hosts.Count; i++)
            {
                HostUserControl tmp = new HostUserControl(hosts[i], language);
                Label label = new Label();
                label.HorizontalAlignment = HorizontalAlignment.Center;
                label.FontSize = 17;
                label.Content = "Host name: " + (hosts[i]).PrivateName;
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
