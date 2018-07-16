using FBAContentApp.Entities;
using FBAContentApp.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBAContentApp.ViewModels
{
    public class ProcessShipmentViewModel
    {
        #region Properties
        /// <summary>
        /// Stores all the data for the shipment being processed
        /// </summary>
        public FBAShipment Shipment { get; set; }

        /// <summary>
        /// A List of AmazonWarehouse to be populated in the ListBox for selecting a ShipTo AmazonWarehouse
        /// </summary>
        public List<AmazonWarehouse> AmzWarehouses { get; set; }

        /// <summary>
        /// Object that creates ZPL Labels of the box content for the shipment being processed.
        /// </summary>
        public LabelFactory LabelFactory { get; set; }

        /// <summary>
        /// String name of the printer that will print the ZPL Labels.
        /// </summary>
        public string LabelPrinter { get; set; }

        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ProcessShipmentViewModel()
        {
            AmzWarehouses = new List<AmazonWarehouse>(); 
            Shipment = new FBAShipment();
            LabelFactory = new LabelFactory();
            PopulateAmazonWarehouse();
            PopulateSettingDefaults();

        }

        /// <summary>
        /// Overloaded constructor that takes in a file (expected to be an Excel Workbook, '.xlsx' extension) to process
        /// and get create a shipment based on that file. Each Worksheet in the file is expected to  
        /// represent one box in the shipment.
        /// </summary>
        /// <param name="file"></param>
        public ProcessShipmentViewModel(string file)
        {
            //initialize properties
            AmzWarehouses = new List<AmazonWarehouse>();
            PopulateAmazonWarehouse();

            Shipment = new FBAShipment();
            LabelFactory = new LabelFactory();

            PopulateSettingDefaults();
            //process the excel file to add box contents to Shipment.Boxes model.
            ReadExcelBook(file);
        }
        #endregion

       #region Methods


        /// <summary>
        /// Reads an excel workbook and grabs the content of each Worksheet. Each worksheet
        /// represents a box. Each box is added to the shipment being processed.
        /// </summary>
        /// <param name="xlFile"></param>
        public void ReadExcelBook(string xlFile)
        {
            List<FBABox> boxes = new List<FBABox>();

            //get file info for excel epplus package wrapper class
            FileInfo exlBook = new FileInfo(xlFile);

            //get the excel file name for naming the PO
            var splitPath = xlFile.Split('\\');
            var fSplit = splitPath[splitPath.Length - 1];
            var name = fSplit.Split('.');
            string poName = name[0];

            using (ExcelPackage xlPackage = new ExcelPackage(exlBook))
            {

                ExcelWorkbook book = xlPackage.Workbook;
                foreach (ExcelWorksheet sheet in book.Worksheets)
                {

                    //Console.WriteLine("Currently viewing sheet {0}", sheet.Name); //testing

                    //get the box/sheet number
                    var sname = sheet.Name.Split(new string[] { "Sheet" }, StringSplitOptions.None);
                    int boxNumber;
                    int.TryParse(sname[1], out boxNumber);

                    //get a boxID number with appropriate leading zeros. BoxNumber ID must be 3 digits long.
                    int countLen = boxNumber.ToString("D").Length;
                    if (countLen > 1) //use 1 leading zeros
                    {
                        countLen += 1;
                    }
                    else //use 2 leading zeros
                    {
                        countLen += 2;

                    }

                    //write a box ID with format of SHIPMENTID+U+001 
                    var boxId = poName + "U" + boxNumber.ToString("D" + countLen.ToString());
                    int col = 1;

                    //create a new box to be added to the shipment
                    FBABox newBox = new FBABox(boxId);
                    newBox.PO = poName;
                    newBox.BoxNumber = boxNumber;

                    //iterate through the first 100 rows
                    for (int i = 1; i < 100; i++)
                    {
                        if (sheet.Cells[i, col].Value == null)
                        {
                            //as soon as a null value appears, break out of the for loop
                            break;
                        }
                        else
                        {   //else(if cell value is not null), add the item ID to the box

                            //add new item to box, 
                            newBox.AddItem(new Item(sheet.Cells[i, col].Value.ToString()));
                        }
                    }//end of for loop

                    // add the new box to the list of boxes
                    boxes.Add(newBox);

                }// end of foreach loop, iterating throught each sheet in the workbook.

            }//end of excelPackage USE block

            //set the boxes from excel file to the Shipment object
            Shipment.Boxes = boxes;
        }


        /// <summary>
        /// Makes the labels once the boxes in the Shipment are populated.
        /// </summary>
        public void MakeBoxLabels()
        {
            if(Shipment.Boxes != null)
            {
                //re-instantiate a LabelFactory object with the overloaded constructor
                LabelFactory = new LabelFactory(Shipment.Boxes, Shipment.FullfillmentShipTo, Shipment.CompanyShipFrom);
                //create the labels after the necessary items have been passed into the constructor
                LabelFactory.CreateLabels();
            }
        }


        /// <summary>
        /// Clears all properties to process a new shipment.
        /// </summary>
        public void ClearAll()
        {
            Shipment.Boxes.Clear();
            Shipment.ShipmentID = "";
            Shipment.FullfillmentShipTo = new AmazonWarehouse();
            LabelFactory = new LabelFactory();
        }


        /// <summary>
        /// Grabs all AmazonWarehouses from the DbContext to populate the ListBox for the NewShipment.xaml view.
        /// </summary>
        private void PopulateAmazonWarehouse()
        {
            using (var db = new Models.AppContext())
            {
                AmzWarehouses = db.AmazonWarehouses.ToList();
            }
        }

        /// <summary>
        /// Grabs the user default settings from the Settings in application and sets them accordingly.
        /// </summary>
        private void PopulateSettingDefaults()
        {
            using (var db = new Models.AppContext())
            {
                if (Properties.Settings.Default["CompanyAddressId"] != null) //check if there's a default CompanyAddress to ship from
                {
                    int addressID = (int)Properties.Settings.Default["CompanyAddressId"];
                    CompanyAddress shipFr = new CompanyAddress();
                    shipFr = db.CompanyAddresses.Where(b => b.Id == addressID).FirstOrDefault();
                    Shipment.CompanyShipFrom = shipFr;
                }
                else
                {   //else use the sample default that was seeded in the DbContext Configuration
                    Shipment.CompanyShipFrom = db.CompanyAddresses.Where(b => b.Id == 0).FirstOrDefault();
                }
                
            }
            
        }

        /// <summary>
        /// Saves the shipment data to the Database.
        /// </summary>
        public void SaveShipmentToDB()
        {
            //saves all the shipment data to the Db
        }


        #endregion




    }
}
