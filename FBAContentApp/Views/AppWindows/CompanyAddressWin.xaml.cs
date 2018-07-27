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
        /// <summary>
        /// Validates user input for the Company Address, sets DialogResult to TRUE.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                //set dialog result to true
                DialogResult = true;
                //close window
                this.Close();
            }
            else
            {
                MessageBox.Show("There are some fields not filled in. Please fill fields!");
            }

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }


        /// <summary>
        /// Checks to make sure CompanyName, AddressLine1(for the least), City, Zip, and State are filled in.
        /// </summary>
        /// <returns>Boolean</returns>
        bool ValidateInput()
        {
            //check nothing is null from UI controls
            if(txtCompAddress1.Text !=null & txtCompCity.Text != null & txtCompName.Text != null & txtZip.Text != null & comboState.SelectedItem != null)
            {
                CompanyAddressMod.CompanyName = txtCompName.Text;

                CompanyAddressMod.AddressLine1 = txtCompAddress1.Text;
                CompanyAddressMod.AddressLine2 = txtCompAddress2.Text;
                CompanyAddressMod.AddressLine3 = txtCompAddress3.Text;

                CompanyAddressMod.City = txtCompCity.Text;

                CompanyAddressMod.ZipCode = txtZip.Text;

                //get selected StateID
                CompanyAddressMod.StateId = comboState.SelectedIndex - 1;

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
