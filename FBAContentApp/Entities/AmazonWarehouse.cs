using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBAContentApp.Entities
{
    /// <summary>
    /// Entity model representing an Amazon Fulfillment Warehouse
    /// </summary>
    public class AmazonWarehouse
    {
        public int Id { get; set; }

        public string WarehouseCode { get; set; }

        public string Name { get; set; }

        public string AddressLine { get; set; }

        public string City { get; set; }

        public virtual State State { get; set; }

        public string ZipCode { get; set; }
    }
}
