using FBAContentApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBAContentApp.Models
{
    public class LabelFactory
    {
        #region Properties
        List<ZPLLabel> BoxLabels { get; set; }

        public List<FBABox> ShipmentBoxes { get; set; }

        public AmazonWarehouse AmzWarehouse { get; set; }

        public CompanyAddress ShipFromAddress { get; set; }

        #endregion


        #region Constructors
        public LabelFactory()
        {
            BoxLabels = new List<ZPLLabel>();
            ShipmentBoxes = new List<FBABox>();

        }

        public LabelFactory(List<FBABox> boxes, AmazonWarehouse shipTo, CompanyAddress shipFrom)
        {
            BoxLabels = new List<ZPLLabel>();
            AmzWarehouse = shipTo;
            ShipFromAddress = shipFrom;
            CreateLabels();

        }
        #endregion


        #region Methods

        public void CreateLabels()
        {
            int boxCount = ShipmentBoxes.Count;

            //iterate through each box in the shipmentBoxes objects
            foreach(FBABox box in ShipmentBoxes)
            {
                //create a new label for each box.
                ZPLLabel label = new ZPLLabel(AmzWarehouse, ShipFromAddress, box);
                //create the label, pass in box count so the label prints out "Box # of BoxCount"
                label.CreateLabel(boxCount);
                //add label to list of labels
                BoxLabels.Add(label);

            }
        }

        #endregion
    }
}
