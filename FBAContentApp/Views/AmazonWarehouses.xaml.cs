using FBAContentApp.Models;
using FBAContentApp.Utilities;
using FBAContentApp.ViewModels;
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
        #region Properties
        public AmzWarehouseViewModel amzViewModel { get; set; }



        #endregion


        #region Constructors
        public AmazonWarehouses()
        {
            InitializeComponent();
            PopulateGUI();
        }

        #endregion

        #region Methods

        void PopulateGUI()
        {
            //initialize view model.
            amzViewModel = new AmzWarehouseViewModel();

            //set itemsSouce for list box of centers.
            CentersListBox.ItemsSource = amzViewModel.FulFillmentCenters;
            CentersListBox.Items.Refresh();

            //disable edit and delete buttons.
            editWhseBtn.IsEnabled = false;
            deleteWhseBtn.IsEnabled = false;
        }
        #endregion


        #region Events
        private void BackToMain_Button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainMenu());
        }

        /// <summary>
        /// Event when the 'Add' button is clicked on the view. ds to the warehouse.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addWhseBtn_Click(object sender, RoutedEventArgs e)
        {
            //open new window to add an Amazon Warehouse
            AmzWarehouseModel amzwhse = new AmzWarehouseModel();
            AmazonWarehouseWin amzWindow = new AmazonWarehouseWin(amzwhse, DbQuery.Add);
            amzWindow.titleLabel.Content = "Add An Amazon Warehouse";
            amzWindow.ShowDialog();
            if (amzWindow.DialogResult == true)
            {
                MessageBox.Show("The new Amazon Fulfillment Warehouse was successfully added to the Databse! :D");
                //refresh UI
                PopulateGUI();
            }
            else
            {
                MessageBox.Show("Unable to save the new Amazon Warehouse");
            }
        }

        private void editWhseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CentersListBox.SelectedItem is AmzWarehouseModel)
            {
                //grab selected item.
                AmzWarehouseModel amzSelected = (AmzWarehouseModel)CentersListBox.SelectedItem;

                //instantiate new AmazonWarehouseWin and pass in selected AmzWarehouseModel
                AmazonWarehouseWin amzWin = new AmazonWarehouseWin(amzSelected, Utilities.DbQuery.Edit);
                amzWin.titleLabel.Content = "Edit Amazon Fulfillment Warehouse";


                //show the window.
                amzWin.ShowDialog();

                if (amzWin.DialogResult == true) //warehouse edit is successful
                {
                    //save updated warehouse to database.
                    MessageBox.Show("Amazon Fulfillment Warehouse successfully saved.");
                    PopulateGUI();
                }
                else   //warehouse edit is unsuccessful
                {
                    //inform user nothing was done.
                    MessageBox.Show("Unable to save the Amazon Fulfillment Warehouse.");
                }

            }
        }

        private void deleteWhseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CentersListBox.SelectedItem is AmzWarehouseModel)
            {
                //grab selected item.
                AmzWarehouseModel amzSelected = (AmzWarehouseModel)CentersListBox.SelectedItem;

                //call db query to delete warehouse
                if(amzViewModel.AmzWarehouseDbQuery(amzSelected, DbQuery.Delete))
                {
                    MessageBox.Show("Amazon Warehouse: " + amzSelected.WarehouseCode + " successfully deleted from databse.");
                    //refresh UI
                    PopulateGUI();
                }
                else
                {
                    MessageBox.Show("Unable to delete Amazon Warehouse: " + amzSelected.WarehouseCode + ". :(");
                }
               

            }
        }

        /// <summary>
        /// Enables the edit and delete buttons on the UI for the selected item in the list box of Centers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CentersListBox_Selected(object sender, RoutedEventArgs e)
        {
            if (CentersListBox.SelectedItem is AmzWarehouseModel)
            {
                editWhseBtn.IsEnabled = true;
                deleteWhseBtn.IsEnabled = true;
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
