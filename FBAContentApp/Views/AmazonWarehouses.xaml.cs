using FBAContentApp.Models;
using FBAContentApp.Utilities;
using FBAContentApp.Views.AppWindows;
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
    /// Interaction logic for AmazonWarehouses.xaml
    /// </summary>
    public partial class AmazonWarehouses : UserControl, ISwitchable
    {
        public AmazonWarehouses()
        {
            InitializeComponent();
        }
        #region Events
        private void BackToMain_Button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainMenu());
        }
        private void addWhseBtn_Click(object sender, RoutedEventArgs e)
        {
            //open new window to add an Amazon Warehouse
            AmzWarehouseModel amzwhse = new AmzWarehouseModel();
            AmazonWarehouseWin amzWindow = new AmazonWarehouseWin(amzwhse);
            amzWindow.ShowDialog();
            if (amzWindow.DialogResult == true)
            {

            }
            else
            {

            }
        }

        #endregion

        #region ISwitchable Implementation
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}
