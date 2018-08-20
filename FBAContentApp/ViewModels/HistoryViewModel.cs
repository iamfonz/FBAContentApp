using FBAContentApp.Entities;
using FBAContentApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FBAContentApp.ViewModels
{
    public class HistoryViewModel
    {
        private ObservableCollection<FBAShipment> shipments = new ObservableCollection<FBAShipment>();

        public ObservableCollection<FBAShipment> FBAShipments
        {
            get { return shipments; }
            set { shipments = value; }
        }

        public LabelFactory LabelFactory { get; set; }


        public HistoryViewModel()
        {
            PopulateShipments();
            LabelFactory = new LabelFactory();

        }

        /// <summary>
        /// Retrieves all the shipments from the DB and populates the FBAShipments list.
        /// </summary>
        void PopulateShipments()
        {
            using (var db = new Models.AppContext())
            {

                //grab all shipments from DB
                List<Shipment> shipments = db.Shipments.ToList();

                //sort by shipment date
                shipments.Sort((s1, s2) => DateTime.Compare(s2.ShipmentDate, s1.ShipmentDate));

                //iterate through all shipments and add to list
                foreach (Shipment ship in shipments)
                {
                    FBAShipment fba = new FBAShipment();
                    fba.ShipmentID = ship.ShipmentId;
                    fba.FullfillmentShipTo = new AmzWarehouseModel(ship.ShipToCenter);
                    fba.CompanyShipFrom = new CompanyAddressModel(ship.ShipFromCenter);
                    fba.Boxes = new List<FBABox>();
                    fba.ShipmentDate = ship.ShipmentDate;

                    //fill in the boxes.
                    foreach (ShipmentBox bx in ship.Boxes)
                    {
                        fba.Boxes.Add(new FBABox() { BoxID = bx.BoxId, ContentString = bx.BoxContentString, BoxNumber = bx.BoxNumber });
                    }

                    FBAShipments.Add(fba);
                }

            }
               
        }


        /// <summary>
        /// Sends a list of boxes to the default label printer to be printed.
        /// </summary>
        /// <param name="boxestoPrint">List of boxes to print</param>
        /// <param name="amzWarehouse">The Amazon Fulfillment Center for the box label</param>
        /// <param name="companyAddress">The Company Address for the box label</param>
        public void ReprintLabels(List<FBABox> boxestoPrint, AmzWarehouseModel amzWarehouse, CompanyAddressModel companyAddress, int totalBoxCount)
        {
            //reinitialize the labelfactory
            LabelFactory = new LabelFactory(boxestoPrint, amzWarehouse, companyAddress, totalBoxCount);

            //grab default label printer
            string labelPrinter = Properties.Settings.Default.LabelPrinter;

            //send each label to the printer.
            foreach (var label in LabelFactory.BoxLabels) //send each BoxLabel to printer.
            {
                RawPrinterHelper.SendStringToPrinter(labelPrinter, label.ZPLCommand);
            }
        }

        /// <summary>
        /// Reprints FBA Box labels to PDF using labelry.com API service.
        /// </summary>
        /// <param name="boxestoPrint">List of FBABox to be reprinted</FBABox></param>
        /// <param name="amzWarehouse">Ship To Amazon Warehouse</param>
        /// <param name="companyAddress">Ship From Company Address</param>
        /// <param name="totalBoxCount">Total boxes in the shipment</param>
        /// <param name="shipmentID">The Shipment Id of the boxes.</param>
        public void ReprintToPDF(List<FBABox> boxestoPrint, AmzWarehouseModel amzWarehouse, CompanyAddressModel companyAddress, int totalBoxCount, string shipmentID)
        {
            //empty string to fill zpl command
            string zpl = "";
            string boxesPrinted = "";

            //instantiate new LabelFactory with passed in parameters.
            LabelFactory = new LabelFactory(boxestoPrint, amzWarehouse, companyAddress, totalBoxCount);

            //fill in string for ZPL command
            foreach (ZPLLabel label in LabelFactory.BoxLabels)
            {
                zpl += label.ZPLCommand;
                boxesPrinted += label.Box.BoxNumber + "-";
            }

            //make a savepath string
            string filePath = Properties.Settings.Default.SaveFileDir + "\\" + shipmentID + "_BOXES_" + boxesPrinted + " _Reprinted_Labels.pdf";

            //get string in UTF8 bytes
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
                var fileStream = File.Create(filePath);
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

    }
}
