using FBAContentApp.Entities;
using FBAContentApp.Models;
using FBAContentApp.Utilities;
using FBAContentApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for History.xaml
    /// </summary>
    public partial class History : UserControl, ISwitchable

    {

        private ObservableCollection<FBAShipment> fbaShipments = new ObservableCollection<FBAShipment>();

        public ObservableCollection<FBAShipment> FBAShipments
        {
            get { return fbaShipments; }
            set { fbaShipments = value; }
        }

        private HistoryViewModel historyViewModel = new HistoryViewModel();

        #region Constructor
        public History()
        {
            InitializeComponent();
            PopulateShipments();
        }

        #endregion

        #region Methods
        private void PopulateShipments()
        {
            FBAShipments = historyViewModel.FBAShipments;

            DataContext = new
            {
                Shipments = FBAShipments
            };

            
        }


        #endregion




        #region Events
        private void BackToMain_Button_Click(object sender, RoutedEventArgs e)
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
