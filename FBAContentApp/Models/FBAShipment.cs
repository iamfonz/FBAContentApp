using FBAContentApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FBAContentApp.Models
{
    public class FBAShipment
    {
        #region Properties
        public string ShipmentID { get; set; }

        public List<FBABox> Boxes { get; set; }

        public CompanyAddressModel CompanyShipFrom { get; set; }

        public AmzWarehouseModel FullfillmentShipTo { get; set; }
        #endregion

        #region Constructors
        public FBAShipment()
        {
            ShipmentID = "";
            Boxes = new List<FBABox>();
            CompanyShipFrom = new CompanyAddressModel();
            FullfillmentShipTo = new AmzWarehouseModel();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Sorts the shipment boxes by their box number order.
        /// </summary>
        public void SortBoxes()
        {
            int size = Boxes.Count;
            for (int i = 1; i < size; i++)
            {
                for (int j = 0; j < (size - i); j++)
                {
                    if (Boxes[j].BoxNumber > Boxes[j + 1].BoxNumber)
                    {
                        FBABox temp = Boxes[j];
                        Boxes[j] = Boxes[j + 1];
                        Boxes[j + 1] = temp;
                    }
                }
            }

        }

        /// <summary>
        /// Overridden ToString method that returns the object data in JSON format.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }


        #endregion


    }
}
