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
using FBAContentApp.Models;
using Microsoft.Win32;
using System.Windows.Interop;


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
        private void newShipFrbtn_Click(object sender, RoutedEventArgs e)
        {
            //open a new window for adding a new Company Ship From.

        }

        private void browseBtn_Click(object sender, RoutedEventArgs e)
        {
            string selectedPath = "";
            //open a OpenFileDialog/Browser window so that user can set the output directoy of where to save the contents files
           using(var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();

                if(dialog.SelectedPath != null)
                {
                    selectedPath = dialog.SelectedPath;
                }
            }

            txtSaveLocation.Text = selectedPath;
        }


        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            //grab all values from window
            string saveDir = txtSaveLocation.Text;
            string labelPrinter = comboPrinters.SelectedItem as string;

            //first check that a company has been selected
            if(comboCompanyAddress.SelectedItem != null)
            {
                CompanyAddressModel comp = (CompanyAddressModel)comboCompanyAddress.SelectedItem;
                int compId = comp.Id;

                //save to settings for persistence
                if (saveDir != null & labelPrinter != null)
                {
                    settings.CompanyAddressId = compId;
                    settings.SaveFileDir = saveDir;
                    settings.LabelPrinter = labelPrinter;
                    settings.Save();
                    //return to main menu
                    Switcher.Switch(new MainMenu());
                }
                else
                {
                    MessageBox.Show("A label printer and save file directory must be selected.");
                }

            }
            else
            {
                MessageBox.Show("A company address must be selected.");
            }
            


            
        }


        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            //do nothing and return to MainMenu page
            Switcher.Switch(new MainMenu());
        }



        private void comboCompanyAddress_Selected(object sender, RoutedEventArgs e)
        {
            if(comboCompanyAddress.SelectedItem is CompanyAddressModel)
            {
                CompanyAddressModel companyAddress = settingsVM.CompanyAddresses[comboCompanyAddress.SelectedIndex];
                txtBlockFullCompanyAddress.Text = companyAddress.CompanyName + "\n" + companyAddress.AddressLine1 + "\n" + companyAddress.AddressLine2 + "\n" + companyAddress.AddressLine3 + "\n" + companyAddress.City + ", " + companyAddress.StateAbrv + " " + companyAddress.ZipCode; ;
            }
        }




        #endregion


    }
}
