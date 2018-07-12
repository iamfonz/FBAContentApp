using FBAContentApp.Entities;
using FBAContentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBAContentApp.ViewModels
{
    public class ProcessShipmentViewModel
    {
        #region Properties
        public FBAShipment Shipment { get; set; }

        public CompanyAddress CompanyShipFrom { get; set; }

        public AmazonWarehouse FullfillmentShipTo { get; set; }
        #endregion

        #region Constructors
        public ProcessShipmentViewModel()
        {

        }

        /// <summary>
        /// Overloaded constructor that takes in a file (expected to be an Excel Workbook, '.xlsx' extension) to process
        /// and get create a shipment based on that file. Each Worksheet in the file is expected to  
        /// represent one box in the shipment.
        /// </summary>
        /// <param name="file"></param>
        public ProcessShipmentViewModel(string file)
        {

        }
        #endregion

        #region Methods
        public void ReadExcelBook(string file)
        {

        }

        public void PrintZplLabel()
        {

        }

        #endregion




    }
}
