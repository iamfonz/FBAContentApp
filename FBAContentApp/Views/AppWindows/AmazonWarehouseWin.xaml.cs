using FBAContentApp.Models;
using FBAContentApp.ViewModels;
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
using System.Windows.Shapes;

namespace FBAContentApp.Views.AppWindows
{
    /// <summary>
    /// Interaction logic for AmazonWarehouseWin.xaml
    /// </summary>
    public partial class AmazonWarehouseWin : Window
    {
        #region Properties
        private AmzWarehouseModel amzWarehouse;

        public AmzWarehouseModel AmzWarehouse
        {
            get { return amzWarehouse; }
            set { amzWarehouse = value; }
        }

        public AmzWarehouseViewModel amzWarehouseVM { get; set; }

        public Utilities.DbQuery DbQuery { get; set; }
        #endregion

        #region Constructors

        public AmazonWarehouseWin(AmzWarehouseModel warehouseModel, Utilities.DbQuery dbQuery)
        {
            InitializeComponent();
            amzWarehouse = warehouseModel;
            amzWarehouseVM = new AmzWarehouseViewModel(warehouseModel);
            DbQuery = dbQuery;
            PopulateGUI();

        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public AmazonWarehouseWin() : this(new AmzWarehouseModel(), Utilities.DbQuery.Add)
        {

        }


        #endregion

        #region Methods

        void PopulateGUI()
        {
            txtWhseID.Text = amzWarehouseVM.CurrentAmazonWhse.WarehouseCode;
            txtCompName.Text = amzWarehouseVM.CurrentAmazonWhse.Name;
            txtAddressLine.Text = amzWarehouseVM.CurrentAmazonWhse.AddressLine;
            txtCity.Text = amzWarehouseVM.CurrentAmazonWhse.City;
            txtZip.Text = amzWarehouseVM.CurrentAmazonWhse.ZipCode;
            comboState.ItemsSource = amzWarehouseVM.StateModels;

            if (amzWarehouseVM.CurrentAmazonWhse.StateAbrv != null)
            {
                comboState.SelectedIndex = amzWarehouseVM.CurrentAmazonWhse.StateId - 1;
            }
            comboState.Items.Refresh();


        }

        /// <summary>
        /// Checks to make sure AmazonWarehouseModel, AddressLine1(for the least), City, Zip, and State are filled in.
        /// </summary>
        /// <returns>Bool</returns>
        bool ValidateInput()
        {
            //check nothing is null from UI controls
            if (txtWhseID.Text != "" & txtAddressLine.Text != "" & txtCity.Text != "" & txtCompName.Text != "" & txtZip.Text != "" & comboState.SelectedItem != null)
            {

                AmzWarehouse.WarehouseCode = txtWhseID.Text;

                AmzWarehouse.Name = txtCompName.Text;

                AmzWarehouse.AddressLine = txtAddressLine.Text;
                AmzWarehouse.City = txtCity.Text;

                AmzWarehouse.ZipCode = txtZip.Text;

                //get selected StateID
                AmzWarehouse.StateId = comboState.SelectedIndex + 1;

                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion


        #region Events
        /// <summary>
        /// Event from 'Save' button that verifies required fields have been entered, then submits to DB.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {

            if (ValidateInput()) //if the required items have been input
            {
                if (amzWarehouseVM.AmzWarehouseDbQuery(AmzWarehouse, DbQuery)) //call method to query database.
                {
                    //set dialog result to true
                    DialogResult = true;
                    //close window
                    this.Close();
                }
                else //if the quert is unsuccessful
                {
                    MessageBox.Show("Unable to save the Amazon Fullfillment Center to database.", "Unsuccessful save to DB.");
                    DialogResult = false;
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("There are some fields not filled in. Please fill fields!", "Required Fields Missing!");
            }

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            //set dialog result
            this.DialogResult = false;
            //close this window
            this.Close();

        }

        #endregion
    }
}
