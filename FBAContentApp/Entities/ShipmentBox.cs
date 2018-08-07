using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBAContentApp.Entities
{
    /// <summary>
    /// Entity model represnting a shipping box/carton for sending to Amazon Fulfillment center.
    /// </summary>
    public class ShipmentBox
    {
        [Key]
        public string BoxId { get; set; }

        public int BoxNumber { get; set; }

        public virtual Shipment Shipment{ get; set; }

        public string BoxContentString { get; set; }
    }
}
