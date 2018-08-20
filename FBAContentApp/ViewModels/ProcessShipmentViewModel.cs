using FBAContentApp.Entities;
using FBAContentApp.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using FBAContentApp.Exceptions;
using System.Net;

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
        public List<AmzWarehouseModel> AmzWarehouses { get; set; }

        /// <summary>
        /// Object that creates ZPL Labels of the box content for the shipment being processed.
        /// </summary>
        public LabelFactory LabelsFactory { get; set; }

        /// <summary>
        /// String name of the printer that will print the ZPL Labels.
        /// </summary>
        public string LabelPrinter { get; set; }

        /// <summary>
        /// String of the directory where box content files will be saved.
        /// </summary>
        public string SaveDirectory { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ProcessShipmentViewModel()
        {
            AmzWarehouses = new List<AmzWarehouseModel>();
            Shipment = new FBAShipment();
            LabelsFactory = new LabelFactory();
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
            AmzWarehouses = new List<AmzWarehouseModel>();
            PopulateAmazonWarehouse();

            Shipment = new FBAShipment();
            LabelsFactory = new LabelFactory();

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

            //set the shipmentID 
            Shipment.ShipmentID = poName;

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
            if (Shipment.Boxes != null)
            {
                //set properties to label factory
                LabelsFactory.ShipmentBoxes = Shipment.Boxes;
                LabelsFactory.AmzWarehouse = Shipment.FullfillmentShipTo;
                LabelsFactory.ShipFromAddress = Shipment.CompanyShipFrom;
                LabelsFactory.BoxCount = Shipment.Boxes.Count;

                //create the labels after the necessary items have been passed into the constructor
                LabelsFactory.CreateLabels();

            }
        }


        /// <summary>
        /// Clears all properties to process a new shipment.
        /// </summary>
        public void ClearAll()
        {
            Shipment.Boxes.Clear();
            Shipment.ShipmentID = "";
            Shipment.FullfillmentShipTo = new AmzWarehouseModel();
            LabelsFactory = new LabelFactory();
        }


        /// <summary>
        /// Grabs all AmazonWarehouses from the DbContext to populate the ListBox for the NewShipment.xaml view.
        /// </summary>
        private void PopulateAmazonWarehouse()
        {
            using (var db = new Models.AppContext())
            {
                List<AmazonWarehouse> warehousees = db.AmazonWarehouses.Include(s => s.State).ToList();

                foreach (AmazonWarehouse amz in warehousees)
                {
                    AmzWarehouseModel amzModel = new AmzWarehouseModel(amz);
                    AmzWarehouses.Add(amzModel);
                }

            }
        }

        /// <summary>
        /// Grabs the user default settings from the Settings in application and sets them accordingly.
        /// </summary>
        private void PopulateSettingDefaults()
        {
            using (var db = new Models.AppContext())
            {

                CompanyAddress company = db.CompanyAddresses.Where(b => b.Id == Properties.Settings.Default.CompanyAddressId).Include(b => b.State).FirstOrDefault();
                Shipment.CompanyShipFrom = new CompanyAddressModel(company);
            }

            if (Properties.Settings.Default.LabelPrinter != null)
            {
                LabelPrinter = Properties.Settings.Default.LabelPrinter;
            }

            if (Properties.Settings.Default.SaveFileDir != null)
            {
                SaveDirectory = Properties.Settings.Default.SaveFileDir;
            }
            else
            {
                SaveDirectory = Environment.CurrentDirectory;
            }


        }

        /// <summary>
        /// Saves the shipment data to the Database. If it exists in DB, it is edited; else it's added.
        /// </summary>
        public void SaveShipmentToDB()
        {
            using (var db = new Models.AppContext())
            {
                //create shipment entity and set props
                Entities.Shipment entShipment = new Shipment() { ShipmentId = Shipment.ShipmentID, Boxes = new List<ShipmentBox>(), ShipmentDate = Shipment.ShipmentDate };

                //add each box one to entShipment entity 
                foreach (var box in Shipment.Boxes)
                {
                    ShipmentBox entBox = new ShipmentBox
                    {
                        BoxContentString = box.FBALabel(),
                        BoxNumber = box.BoxNumber,
                        BoxId = box.BoxID,
                        Shipment = entShipment
                    };

                    entShipment.Boxes.Add(entBox);
                }//end foreach loop

                //get amazon warehouse entity and set to ShipmentEntity
                AmazonWarehouse amz = db.AmazonWarehouses.Where(a => a.Id == Shipment.FullfillmentShipTo.Id).FirstOrDefault();
                entShipment.ShipToCenter = amz;

                //get company address entity and set to shipmententity
                CompanyAddress comp = db.CompanyAddresses.Where(c => c.Id == Shipment.CompanyShipFrom.Id).FirstOrDefault();
                entShipment.ShipFromCenter = comp;

                //check if shipment exists in the database
                if (db.Shipments.Any(s => s.ShipmentId == Shipment.ShipmentID))
                {

                    Shipment shipmentDel = db.Shipments.Find(Shipment.ShipmentID);

               
                    var bx = db.Boxes.Where((b => b.Shipment.ShipmentId == shipmentDel.ShipmentId)).ToList();

                    for(int i =0; i < bx.Count(); i++)
                    {
                        db.Boxes.Remove(bx[i]);
                    }
                        
                    
                    db.SaveChanges();

                    //then delete the shipment with shipmentID
                    db.Shipments.Remove(shipmentDel);

                    //finally add the shipment back into shipments table
                    db.Shipments.Add(entShipment);
                }
                else
                {
                    //add shipment to DB and save
                    db.Shipments.Add(entShipment);
                }


                db.SaveChanges();

            }


        }

        /// <summary>
        /// Saves the shipment information to the current directory or the specified save file directory
        /// in settings, if the user has set one. May throw an exception if unable to save file to the directory. 
        /// Also saves the entire ZPL string to a text file, in case user doesn't have a ZPL thermal label, 
        /// an online tool can be used.
        /// </summary>
        public void SaveShipmentToFile()
        {
            //get the entire ZPL string
            string zplLabelsString = "";
            foreach (ZPLLabel label in LabelsFactory.BoxLabels)
            {
                zplLabelsString += label.ZPLCommand;
            }

            
            try
            {   //save shipment in txt file as JSON
                File.WriteAllText(SaveDirectory +"\\"+ Shipment.ShipmentID+ ".txt", Shipment.ToString());

                //save zpl string of labels to text file
                File.WriteAllText(SaveDirectory + "\\" + Shipment.ShipmentID + "-ZPL.txt", zplLabelsString);

            }
            catch (Exception ex)
            {
                throw new NonSaveableException(message: "Unable to save the contents of shipment '" + Shipment.ShipmentID + "' for the following reason:" + ex.Message);
            }



        }


        public void SaveLabelsToPDF()
        {
            string zpl = "";
            foreach(ZPLLabel label in LabelsFactory.BoxLabels)
            {
                zpl += label.ZPLCommand;
            }

            byte[] zplByte = Encoding.UTF8.GetBytes(zpl);

            // instantiate request object
            var request = (HttpWebRequest)WebRequest.Create("http://api.labelary.com/v1/printers/8dpmm/labels/4x8/");
            request.Method = "POST";
            request.Accept = "application/pdf";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = zplByte.Length;

            //adding headers
            request.Headers.Add("X-Rotation:90"); //rotate labels 90 degrees
            request.Headers.Add("X-Page-Size", "Letter");

            request.Headers.Add("X-Page-Layout:1x2"); // layout labels with 1 column and 3 rows (3 labels per page)

            var requestStream = request.GetRequestStream();
            requestStream.Write(zplByte, 0, zplByte.Length);
            requestStream.Close();
            try
            {
                //get the response from the request
                var response = (HttpWebResponse)request.GetResponse();
                //get the response stream
                var responseStream = response.GetResponseStream();
                //create file where response data will go
                var fileStream = File.Create(SaveDirectory + "\\" + Shipment.ShipmentID + "-Labels.pdf");
                //convert the responseStream to a file at specified path
                responseStream.CopyTo(fileStream);
                //close the stream
                responseStream.Close();
                fileStream.Close();

                //inform of success
                //Console.WriteLine("Successfully retrieved the PDF for the ZPL string!");

            }
            catch (WebException e)
            {

                //Console.WriteLine("ERROR: {0}\n", e.Message);
            }
        }


        #endregion




    }
}
