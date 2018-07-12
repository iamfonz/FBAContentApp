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
        #endregion

        #region Constructors
        public FBAShipment()
        {
            Boxes = new List<FBABox>();
        }
        #endregion


    }
}
