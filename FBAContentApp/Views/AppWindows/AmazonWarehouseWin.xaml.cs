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

        #endregion

        #region Constructors

        public AmazonWarehouseWin(AmzWarehouseModel warehouseModel)
        {
            InitializeComponent();
            amzWarehouse = warehouseModel;
            amzWarehouseVM = new AmzWarehouseViewModel(warehouseModel);
            PopulateGUI();

        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public AmazonWarehouseWin() : this(new AmzWarehouseModel())
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

        #endregion


        #region Events
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            //validate user input
            //set dialog result
            this.DialogResult = true;
            //close this window
            this.Close();

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
