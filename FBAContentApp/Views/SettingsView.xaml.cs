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


namespace FBAContentApp.Views
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
            PopulatePrinters();
        }

        #region Methods

        public void PopulatePrinters()
        {

            
            string pkInstalledPrinters;
            foreach(var printer in PrinterSettings.InstalledPrinters)
            {
                pkInstalledPrinters = printer.ToString();
                comboPrinters.Items.Add(pkInstalledPrinters);
            }

            comboPrinters.Items.Refresh();
        }

        #endregion

        #region Events
        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            //grab all values from window
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

        #endregion
    }
}
