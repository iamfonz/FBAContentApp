using FBAContentApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBAContentApp.Models
{
    public class FBAShipment
    {
        #region Properties
        public string ShipmentID { get; set; }

        public List<FBABox> Boxes { get; set; }

        public CompanyAddress CompanyShipFrom { get; set; }

        public AmazonWarehouse FullfillmentShipTo { get; set; }
        #endregion

        #region Constructors
        public FBAShipment()
        {
            ShipmentID = "";
            Boxes = new List<FBABox>();
            CompanyShipFrom = new CompanyAddress();
            FullfillmentShipTo = new AmazonWarehouse();
        }
        #endregion


    }
}
