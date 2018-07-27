using FBAContentApp.Entities;
using FBAContentApp.Utilities;
using FBAContentApp.ViewModels;
using FBAContentApp.Exceptions;
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
using FBAContentApp.Models;
using FBAContentApp.Views.AppWindows;

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

        #region Methods

        #endregion

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
            if(ProcessShipmentVM.Shipment.Boxes.Count > 0)// Check that there are boxes
            {
                if(cmbx_AmazonWhses.SelectedItem is AmzWarehouseModel)//check that an Amazon Warehouse has been selected
                {
                    string messageString = "";


                    //send them to the printer, only if a printer is configured
                    ProcessShipmentVM.LabelPrinter = "Zebra  ZP 450-200 dpi";

                    //set amazon fulfillment center to view model shipment
                    ProcessShipmentVM.Shipment.FullfillmentShipTo = (AmzWarehouseModel)cmbx_AmazonWhses.SelectedItem;

                    // make viewModel create ZPL labels.
                    ProcessShipmentVM.MakeBoxLabels();

                    if (ProcessShipmentVM.LabelPrinter != null) //check for a default printer.
                    {
                        foreach (var label in ProcessShipmentVM.LabelsFactory.BoxLabels) //send each BoxLabel to printer.
                        {
                            RawPrinterHelper.SendStringToPrinter(ProcessShipmentVM.LabelPrinter, label.ZPLCommand);
                        }

                        //save the shipment to database from the ViewModel
                        try
                        {
                            ProcessShipmentVM.SaveShipmentToDB();
                            messageString += "Saved Shipment " + ProcessShipmentVM.Shipment.ShipmentID + " to database.";
                        }catch(AlreadyExistsInDBException ex)
                        {
                            messageString += ex.Message;
                        }
                        
                        //save shipment file
                        try
                        {
                            ProcessShipmentVM.SaveShipmentToFile();
                            messageString += "\nSaved the contents file successfully!";
                        }
                        catch (Exceptions.NonSaveableException exc)
                        {
                            messageString += "\n" + exc.Message;
                        }

                        //show dialogbox that it was processed successfully
                        MessageBox.Show(messageString);
                    }
                    else
                    {
                        MessageBox.Show("A default printer is not set in the settings. Go to Main Menu>Settings and select an installed printer and click 'Save'. Then try again.");
                    }
                    
                }
                else
                {
                    MessageBox.Show("You must select an Amazon warehouse from the drop-down menu.");
                }   

            }
            else
            {
                MessageBox.Show("There are no boxes loaded into the shipment! Clicl 'Add Boxes' and select and Excel Workbook that contains box content.");
            }

            //showDialog boxes informing user of what's missing.

        }

        /// <summary>
        /// Clears all data from the process shipment view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            //clear GUI items
            lsbx_AddedBoxes.ItemsSource = new List<FBABox>() ;
            lsbx_AddedBoxes.Items.Refresh();

            cmbx_AmazonWhses.ItemsSource = new List<AmzWarehouseModel>();
            cmbx_AmazonWhses.ItemsSource = ProcessShipmentVM.AmzWarehouses;
            cmbx_AmazonWhses.Items.Refresh();
            lbl_BoxCount.Content = "0";
            //clear view model.
            ProcessShipmentVM.ClearAll();
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
