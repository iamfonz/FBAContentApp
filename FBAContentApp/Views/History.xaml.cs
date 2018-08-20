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


        /// <summary>
        /// Grabs the selected boxes from the List Box.
        /// </summary>
        /// <returns>List of FBABox from the listbox.</returns>
        private List<FBABox> GetSelectedBoxes()
        {
            List<FBABox> selectedBoxes = new List<FBABox>();

            //get boxes from selected items in the listbox
            foreach (var item in boxListBox.SelectedItems)
            {
                if (item is FBABox) //check that only FBABox items are being grabbed
                {
                    FBABox newBox = (FBABox)item;
                    selectedBoxes.Add(newBox);
                }
            }

            return selectedBoxes;

        }

        /// <summary>
        /// Grabs the selected shipment from the List Box.
        /// </summary>
        /// <returns>FBAShipment model.</returns>
        private FBAShipment GetShipment()
        {
            FBAShipment shipment = new FBAShipment();
            //get the amz warehouse for the shipment
            if (shipmentListBox.SelectedItem is FBAShipment)
            {
                shipment = (FBAShipment)shipmentListBox.SelectedItem;
            }

            return shipment;
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
        /// Reprints the selected boxes to the default label printer in the settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printBoxBtn_Click(object sender, RoutedEventArgs e)
        {
            //Get selected boxes from listBox to print
            List<FBABox> printBoxes = GetSelectedBoxes();

            //get selected shipments for details
            FBAShipment shipment = GetShipment();

            //send the objects to viewmodel for reprinting.
            historyViewModel.ReprintLabels(printBoxes, shipment.FullfillmentShipTo, shipment.CompanyShipFrom, shipment.Boxes.Count);

        }

        private void printPDFBtn_Click(object sender, RoutedEventArgs e)
        {
            //get selected boxes from listbox
            List<FBABox> selectedBoxes = GetSelectedBoxes();

            //get the selected shipment
            FBAShipment shipment = GetShipment();

            //send objects to ViewModel to print to PDF
            try
            {
                historyViewModel.ReprintToPDF(selectedBoxes, shipment.FullfillmentShipTo, shipment.CompanyShipFrom, shipment.Boxes.Count, shipment.ShipmentID);
                MessageBox.Show("Labels successfully printed to PDF. Reprinted labels were saved to: \n" + Properties.Settings.Default.SaveFileDir, "Successfully Printed to PDF");
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error trying to print to PDF.\n" + ex.Message, "Unsuccessful Print to PDF");
            }
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
