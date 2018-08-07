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

        public List<ZPLLabel> BoxLabels { get; set; }

        public List<FBABox> ShipmentBoxes { get; set; }

        public AmzWarehouseModel AmzWarehouse { get; set; }

        public CompanyAddressModel ShipFromAddress { get; set; }

        public int BoxCount { get; set; }

        #endregion


        #region Constructors
        /// <summary>
        /// Default constructor. Initializes all components to allow for creation of ZPL box labels.
        /// </summary>
        public LabelFactory()
        {
            BoxLabels = new List<ZPLLabel>();
            ShipmentBoxes = new List<FBABox>();
            AmzWarehouse = new AmzWarehouseModel();
            ShipFromAddress = new CompanyAddressModel();
        }

        /// <summary>
        /// Overloaded constructor that automatically creates the labels with the passed in parameters.
        /// </summary>
        /// <param name="boxes">List of boxes to print.</param>
        /// <param name="shipTo">The Amazon Warehouse to ship to</param>
        /// <param name="shipFrom">The Company Address to ship from</param>
        public LabelFactory(List<FBABox> boxes, AmzWarehouseModel shipTo, CompanyAddressModel shipFrom, int boxCount)
        {
            ShipmentBoxes = boxes;
            BoxLabels = new List<ZPLLabel>();
            AmzWarehouse = shipTo;
            ShipFromAddress = shipFrom;
            BoxCount = boxCount;
            CreateLabels();

        }
        #endregion


        #region Methods

        /// <summary>
        /// Creates box labels for the list of FBABox items in the ShipmentBoxes list.
        /// </summary>
        public void CreateLabels()
        {
        

            //iterate through each box in the shipmentBoxes objects
            foreach(FBABox box in ShipmentBoxes)
            {
                //create a new label for each box.
                ZPLLabel label = new ZPLLabel(AmzWarehouse, ShipFromAddress, box);

                //create the label, pass in box count so the label prints out "Box # of BoxCount"
                label.CreateLabel(BoxCount);

                //add label to list of labels
                BoxLabels.Add(label);

            }
        }

        #endregion
    }
}
