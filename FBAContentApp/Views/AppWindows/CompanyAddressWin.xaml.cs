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
    /// Interaction logic for CompanyAddressWin.xaml
    /// </summary>
    public partial class CompanyAddressWin : Window
    {
        private CompanyAddressModel compAddress;

        public CompanyAddressModel CompanyAddressMod
        {
            get { return compAddress; }
            set { compAddress = value; }
        }

        public CompanyViewModel compVM { get; set; }


        #region Constructors

        /// <summary>
        /// Overloaded constructor for editing an existing company address.
        /// </summary>
        /// <param name="comp"></param>
        public CompanyAddressWin(CompanyAddressModel comp)
        {
            InitializeComponent();
            compAddress = comp;
            compVM = new CompanyViewModel(compAddress);
            PopulateGUI();

        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CompanyAddressWin():this(new CompanyAddressModel())
        {

        }
        #endregion

        #region Methods


        /// <summary>
        /// Populates the UI controls with values such as an existing company address or new one. Also fills in the combo box with states values.
        /// </summary>
        void PopulateGUI()
        {
            //set all UI controls to values
            txtCompName.Text = compAddress.CompanyName;
            txtCompAddress1.Text = compAddress.AddressLine1;
            txtCompAddress2.Text = compAddress.AddressLine2;
            txtCompAddress3.Text = compAddress.AddressLine3;

            comboState.ItemsSource = compVM.StateModels;

            if(compVM.CurrentCompanyAddress.StateAbrv!= null)
            {
                comboState.SelectedIndex = compVM.CurrentCompanyAddress.StateId -1 ;
            }

            txtCompCity.Text = compAddress.City;

            comboState.Items.Refresh();

            txtZip.Text = compAddress.ZipCode;

        }
        #endregion

        #region Events


        #endregion

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            //set dialog result to true
            DialogResult = true;
            //close window
            this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
