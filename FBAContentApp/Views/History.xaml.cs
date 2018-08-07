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

        private ObservableCollection<FBAShipment> filteredShipments = new ObservableCollection<FBAShipment>();

        public ObservableCollection<FBAShipment> FilteredShipments
        {
            get { return filteredShipments; }
            set { filteredShipments =  value; }
        }


        private HistoryViewModel historyViewModel = new HistoryViewModel();

        #region Constructor
        public History()
        {
            InitializeComponent();
            InitializeGui();
        }

        #endregion

        #region Methods
        /// <summary>
        /// Loads the Data for the View.
        /// </summary>
        private void InitializeGui()
        {
            FBAShipments = historyViewModel.FBAShipments;

            DataContext = new
            {
                Shipments = FBAShipments
            };                
        }


        #endregion




        #region Events

        /// <summary>
        /// Finds a shipment ID from the FBAShipments list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string originalText = searchTextBox.Text;
            if(originalText != null || originalText != "") //check to see that search box is not empty to actually perform a search
            {
                string upper = originalText.ToUpper();
                string lower = originalText.ToLower();

                var myFilteredShipments = from ship in FBAShipments
                                    let shipID = ship.ShipmentID
                                    where  shipID.Contains(upper)
                                    select ship;
                DataContext = new
                {
                    Shipments = myFilteredShipments
                };
            }
            else //else provide the original FBAShipments list.
            {
                DataContext = new
                {
                    Shipments = FBAShipments
                };
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printBoxBtn_Click(object sender, RoutedEventArgs e)
        {
            //make a list of FBABoxes to print
            List<FBABox> printBoxes = new List<FBABox>();

            //get boxes from selected items in the listbox
            foreach(var item in boxListBox.SelectedItems)
            {
                if(item is FBABox) //check that only FBABox items are being grabbed
                {
                    FBABox newBox = (FBABox)item;
                    printBoxes.Add(newBox);
                }
            }

            //placeholder for the amazonwarehouse
            AmzWarehouseModel amzWarehouse = new AmzWarehouseModel();

            //placeholder for company ship from address
            CompanyAddressModel companyAddress = new CompanyAddressModel();

            int totalBoxCount = 1; ;

            //get the amz warehouse for the shipment
            if(shipmentListBox.SelectedItem is FBAShipment)
            {
                FBAShipment shipment = (FBAShipment)shipmentListBox.SelectedItem;

                amzWarehouse = shipment.FullfillmentShipTo;
                companyAddress = shipment.CompanyShipFrom;
                totalBoxCount = shipment.Boxes.Count;
            }

            //send the objects to viewmodel for reprinting.
            historyViewModel.ReprintLabels(printBoxes, amzWarehouse, companyAddress, totalBoxCount);

        }

        /// <summary>
        /// Returns to the main menu page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
