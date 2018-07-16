using FBAContentApp.Entities;
using FBAContentApp.Utilities;
using FBAContentApp.ViewModels;
using Microsoft.Win32;
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
        public ProcessShipmentViewModel ProcessShipmentVM { get; set; }


        public NewShipment()
        {
            InitializeComponent();

            //initialize a ProcessShipmentViewModel
            ProcessShipmentVM = new ProcessShipmentViewModel();

            //set the items in the AmazonWarehouse listbox
            cmbx_AmazonWhses.ItemsSource = ProcessShipmentVM.AmzWarehouses;

        }

        #region Events

        /// <summary>
        /// Returns to the MainMenu view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_BackToMain_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainMenu());
        }

        private void btn_AddWhse_Click(object sender, RoutedEventArgs e)
        {
            //open new window to add an Amazon Warehouse
        }

        /// <summary>
        /// Sets the Shipment.FullfillmentShipTo object to the selected item from the AmazonWarehouses ComboBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbx_AmazonWhses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProcessShipmentVM.Shipment.FullfillmentShipTo = ProcessShipmentVM.AmzWarehouses[cmbx_AmazonWhses.SelectedIndex];
        }

        /// <summary>
        /// Opens a OpenFileDialog for the user to select an Excel Workbook of a shipment.
        /// Parses it, sets the ProcessShipmentViewModel.Shipment object, getting it ready for printing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddBoxes_Click(object sender, RoutedEventArgs e)
        {
            //create and shoe an OpenFileDialog window to have user select the "shipment" file
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == true)
            {
                //check if any files are selected
                if (openFileDialog1.FileName != null || openFileDialog1.FileNames != null)
                {
                    //check if the file selected is an excel file
                    if (openFileDialog1.FileNames.Length == 1 & openFileDialog1.SafeFileName.Contains(".xlsx"))
                    {
                        //get the full path of excel workbook
                        string excelFile = openFileDialog1.FileName;

                        //process the excel workbook and set the boxes inside ViewModel.shipment
                        ProcessShipmentVM.ReadExcelBook(excelFile);

                        //add the boxes from the shipment to 
                        lsbx_AddedBoxes.ItemsSource = ProcessShipmentVM.Shipment.Boxes;

                        //reset the openFileDialog box
                        openFileDialog1.Reset();

                        //refresh the GUI with new data.
                        lsbx_AddedBoxes.Items.Refresh();
                        lbl_BoxCount.Content = ProcessShipmentVM.Shipment.Boxes.Count;
                    }
                    else
                    {
                        MessageBox.Show("Please select an Excel Workbook. For more info, go to Main Menu and click 'Help'");
                    }

                }
            }

        }


        /// <summary>
        /// Prints the ZPL labels of the Shipment to the printer in the default settings and saves the shipment to the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_PrintBoxes_Click(object sender, RoutedEventArgs e)
        {
            // Check that there are boxes
                //check that an Amazon Warehouse has been selected
                    //if both above are true, make viewModel create ZPL labels.
                    //send them to the printer.
                    //show dialogbox that it was processed successfully
                    //save the shipment to database from the ViewModel
            
            //showDialog boxes informing user of what's missing.

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
