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
    /// Interaction logic for NewShipment.xaml
    /// </summary>
    public partial class NewShipment : UserControl, ISwitchable
    {
        public NewShipment()
        {
            InitializeComponent();
        }

        #region Events
        private void btn_BackToMain_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainMenu());
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
