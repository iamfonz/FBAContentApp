using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBAContentApp.Entities
{
    /// <summary>
    /// Entity model representing a company's 'Ship From' warehouse.
    /// </summary>
    public class CompanyAddress
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string City { get; set; }

        public virtual State State { get; set; }

        public string ZipCode { get; set; }

    }
}
