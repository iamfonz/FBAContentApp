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


        public HistoryViewModel()
        {
            PopulateShipments();

        }


        void PopulateShipments()
        {
            using (var db = new Models.AppContext())
            {

                //grab all shipments from DB
                List<Shipment> shipments = db.Shipments.ToList();

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
                        fba.Boxes.Add(new FBABox() { BoxID = bx.BoxId, ContentString = bx.BoxContentString });
                    }

                    FBAShipments.Add(fba);
                }

            }
        }


    }
}
