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
    /// Interaction logic for AddGuestRequst.xaml
    /// </summary>
    public partial class AddGuestRequest : Window
    {
        IBL bl = BlSingletonFactory.getBl_imp();
        String language;
        public AddGuestRequest(String language)
        {
            InitializeComponent();

            this.language = language;

            updateLanguage(language);

            this.areaComboBox.ItemsSource = Enum.GetValues(typeof(Area));
            this.childrenAttractionsComboBox.ItemsSource = Enum.GetValues(typeof(ChildrenAttractions));
            this.gardenComboBox.ItemsSource = Enum.GetValues(typeof(Garden));
            this.jacuzziComboBox.ItemsSource = Enum.GetValues(typeof(Jacuzzi));
            this.poolComboBox.ItemsSource = Enum.GetValues(typeof(Pool));
            this.typeComboBox.ItemsSource = Enum.GetValues(typeof(BE.Type));
            entryDateDatePicker.SelectedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }

        private void updateLanguage(String language)
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
                addButton.Content = "Add";
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
                addButton.Content = "הוסף";
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            GuestRequest gr = new GuestRequest();
            string msgText = "";

            #region privatename
            if (privateNameTextBox.Text == "")
            {
                privateNameTextBox.BorderBrush = Brushes.Red;
                msgText = msgText == "" ? new DataNotFilledException("private name").Message : msgText;
            }
            else if ((bl.GetGuestRequests()).Exists(GR => GR.PrivateName == privateNameTextBox.Text))
            {
                privateNameTextBox.BorderBrush = Brushes.Red;
                msgText = msgText == "" ? new AlreadyExistsException(privateNameTextBox.Text, "GuestRequest").Message : msgText;
            }
            else
            {
                privateNameTextBox.BorderBrush = Brushes.LimeGreen;
                gr.PrivateName = privateNameTextBox.Text;
            }
            #endregion

            #region familyname
            gr.FamilyName = familyNameTextBox.Text;
            familyNameTextBox.BorderBrush = Brushes.LimeGreen;
            #endregion

            #region mailaddress
            if (mailAddressTextBox.Text == "")
            {
                mailAddressTextBox.BorderBrush = Brushes.Red;
                msgText = msgText == "" ? new DataNotFilledException("mail").Message : msgText;
            }
            else if (!mailAddressTextBox.Text.Contains("@"))
            {
                mailAddressTextBox.BorderBrush = Brushes.Red;
                msgText = msgText == "" ? new ArgumentException("invalid input in mail").Message : msgText;
            }
            else
            {
                mailAddressTextBox.BorderBrush = Brushes.LimeGreen;
                gr.MailAddress = mailAddressTextBox.Text;
            }
            #endregion

            #region adults
            int num = 0;
            if (adultsTextBox.Text == "")
            {
                adultsTextBox.BorderBrush = Brushes.Red;
                msgText = msgText == "" ? new DataNotFilledException("adults").Message : msgText;
            }
            else if (!int.TryParse(adultsTextBox.Text, out num) || int.Parse(adultsTextBox.Text) < 1)
            {
                adultsTextBox.BorderBrush = Brushes.Red;
                msgText = msgText == "" ? new ArgumentException("invalid input in adults").Message : msgText;
            }
            else
            {
                adultsTextBox.BorderBrush = Brushes.LimeGreen;
                gr.Adults = int.Parse(adultsTextBox.Text);
            }
            #endregion

            #region children

            if (childrenTextBox.Text == "")
            {
                childrenTextBox.BorderBrush = Brushes.Red;
                msgText = msgText == "" ? new DataNotFilledException("children").Message : msgText;
            }
            else if (!int.TryParse(childrenTextBox.Text, out num) || int.Parse(childrenTextBox.Text) < 0)
            {
                childrenTextBox.BorderBrush = Brushes.Red;
                msgText = msgText == "" ? new ArgumentException("invalid input in children").Message : msgText;
            }
            else
            {
                childrenTextBox.BorderBrush = Brushes.LimeGreen;
                gr.Children = int.Parse(childrenTextBox.Text);
            }
            #endregion

            #region enterydate
            if (entryDateDatePicker.Text == "")
            {
                entryDateDatePicker.BorderBrush = Brushes.Red;
                msgText = msgText == "" ? new DataNotFilledException("entry date").Message : msgText;
            }
            else
            {
                entryDateDatePicker.BorderBrush = Brushes.LimeGreen;
                gr.EntryDate = DateTime.Parse(entryDateDatePicker.Text);
            }
            #endregion

            #region releasedate
            if (releaseDateDatePicker.Text == "")
            {
                releaseDateDatePicker.BorderBrush = Brushes.Red;
                msgText = msgText == "" ? new DataNotFilledException("release date").Message : msgText;
            }
            else if (DateTime.Parse(releaseDateDatePicker.Text).CompareTo(DateTime.Parse(entryDateDatePicker.Text)) <= 0)
            {
                releaseDateDatePicker.BorderBrush = Brushes.Red;
                msgText = msgText == "" ? new ArgumentException("invalid input in release date").Message : msgText;
            }
            else
            {
                releaseDateDatePicker.BorderBrush = Brushes.LimeGreen;
                gr.ReleaseDate = DateTime.Parse(releaseDateDatePicker.Text);
            }
            #endregion

            #region area
            areaComboBox.BorderBrush = Brushes.LimeGreen;
            gr.Area = (Area)Enum.Parse(typeof(Area), areaComboBox.Text);
            #endregion

            #region subarea
            subAreaTextBox.BorderBrush = Brushes.LimeGreen;
            gr.SubArea = subAreaTextBox.Text;
            #endregion

            #region type
            if (typeComboBox.Text == "")
            {
                typeComboBox.BorderBrush = Brushes.Red;
                msgText = msgText == "" ? new DataNotFilledException("type").Message : msgText;
            }
            else
            {
                typeComboBox.BorderBrush = Brushes.LimeGreen;
                gr.Type = (BE.Type)Enum.Parse(typeof(BE.Type), typeComboBox.Text);
            }
            #endregion

            #region pool
            poolComboBox.BorderBrush = Brushes.LimeGreen;
            gr.Pool = (Pool)Enum.Parse(typeof(Pool), poolComboBox.Text);
            #endregion

            #region jacuzzi
            jacuzziComboBox.BorderBrush = Brushes.LimeGreen;
            gr.Jacuzzi = (Jacuzzi)Enum.Parse(typeof(Jacuzzi), jacuzziComboBox.Text);
            #endregion

            #region garden
            gardenComboBox.BorderBrush = Brushes.LimeGreen;
            gr.Garden = (Garden)Enum.Parse(typeof(Garden), gardenComboBox.Text);
            #endregion

            #region childrenAttractions
            childrenAttractionsComboBox.BorderBrush = Brushes.LimeGreen;
            gr.ChildrenAttractions = (ChildrenAttractions)Enum.Parse(typeof(ChildrenAttractions), childrenAttractionsComboBox.Text);
            #endregion


            gr.Status = RequestStatus.Active;
            gr.RegistrationDate = DateTime.Now;
            gr.GuestRequestKey = Configuration.GuestRequestKey;

            if (msgText == "")
            {
                try
                {
                    bl.AddGuestRequest(gr);
                    MessageBox.Show("The request added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch(ArgumentException ae)
                {
                    MessageBox.Show(ae.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (AlreadyExistsException aee)
                {
                    MessageBox.Show(aee.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                Close();
                
            }
            else
                MessageBox.Show(msgText, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Enter))
            {
                AddButton_Click(this, new RoutedEventArgs());
            }
        }
    }
}