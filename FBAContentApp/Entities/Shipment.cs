using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBAContentApp.Entities
{
    /// <summary>
    /// Entity Model representing an FBA shipment. It contains the ShipTo `AmazonWarehouse` entity, 
    /// ShipFrom `CompanyAddress` entity, a list of `ShipmentBox` entites.
    /// </summary>
    public class Shipment
    {
        [Key]
        public string ShipmentId { get; set; }

        public virtual AmazonWarehouse ShipToCenter { get; set; }

        public virtual CompanyAddress ShipFromCenter { get; set; }

        public virtual ICollection<ShipmentBox> Boxes { get; set; }


    }
}
