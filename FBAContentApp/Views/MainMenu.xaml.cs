using FBAContentApp.Utilities;
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

namespace FBAContentApp.Views
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl, ISwitchable
    {
        public MainMenu()
        {
            InitializeComponent();
        }


        #region Events
        private void NewShipment_Button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new NewShipment());
        }

        private void History_Button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new History());
        }

        private void AmzWhse_Button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new AmazonWarehouses());
        }

        private void Settings_Button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new SettingsView());
        }

        private void helpBtn_Click(object sender, RoutedEventArgs e)
        {
            //Switcher.Switch(new HelpPage());
            //get project root path to grab html
            string htmlDir = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\" + "Views\\AppWindows\\Help.html"));

            System.Diagnostics.Process.Start(htmlDir);
        }

        #endregion

        #region ISwitchable Implementation
        void ISwitchable.UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
        #endregion


    }
}
