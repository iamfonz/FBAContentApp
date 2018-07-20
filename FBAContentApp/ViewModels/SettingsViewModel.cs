using FBAContentApp.Entities;
using FBAContentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBAContentApp.ViewModels
{
    public class SettingsViewModel
    {
        #region Properties
        public List<CompanyAddressModel> CompanyAddresses { get; set; }

        public List<string> InstalledPrinters { get; set; }

        public string OuputDirectory { get; set; }

        #endregion

        #region Constructors
        public SettingsViewModel() {
            CompanyAddresses = new List<CompanyAddressModel>();
            InstalledPrinters = new List<string>();
            PopulateLists();
        }

        #endregion

        #region Methods
        private void PopulateLists()
        {
            //populate installed printers
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                InstalledPrinters.Add(printer);
            }

            //populate all companyaddresses saved in the DB
            using (var db = new Models.AppContext())
            {
                List<CompanyAddress> comps = db.CompanyAddresses.ToList();

                foreach(CompanyAddress comp in comps)
                {
                    CompanyAddresses.Add(new CompanyAddressModel(comp));
                }
            }
        }

        #endregion

    }
}
