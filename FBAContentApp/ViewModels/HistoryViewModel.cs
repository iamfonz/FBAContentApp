using FBAContentApp.Entities;
using FBAContentApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

    }
}
