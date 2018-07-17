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
using System.Drawing.Printing;
using FBAContentApp.Entities;
using FBAContentApp.ViewModels;

namespace FBAContentApp.Views
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        Properties.Settings settings = new Properties.Settings();
        SettingsViewModel settingsVM = new SettingsViewModel();

        public SettingsView()
        {
            InitializeComponent();
            PopulateGUI();
        }

        #region Methods
        void PopulateGUI()
        {
            comboCompanyAddress.ItemsSource = settingsVM.CompanyAddresses;
            comboPrinters.ItemsSource = settingsVM.InstalledPrinters;

            comboPrinters.Items.Refresh();
            comboCompanyAddress.Items.Refresh();
        }

        #endregion

        #region Events
        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            //grab all values from window
            string saveDir = txtSaveLocation.Text;
            string labelPrinter = comboPrinters.SelectedItem as string;


            //verify input(check that directory exists)
            //save to settings for persistence

            //return to main menu
            Switcher.Switch(new MainMenu());
        }


        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            //do nothing and return to MainMenu page
            Switcher.Switch(new MainMenu());
        }

        private void comboCompanyAddress_Selected(object sender, RoutedEventArgs e)
        {
            if(comboCompanyAddress.SelectedItem is CompanyAddress)
            {
                CompanyAddress companyAddress = settingsVM.CompanyAddresses[comboCompanyAddress.SelectedIndex];
                txtBlockFullCompanyAddress.Text = companyAddress.CompanyName + "\n" + companyAddress.AddressLine1 + "\n" + companyAddress.AddressLine2 + "\n" + companyAddress.AddressLine3 + "\n" + companyAddress.City + ", " + companyAddress.State.Abbreviation + " " + companyAddress.ZipCode; ;
            }
        }


        #endregion


    }
}
