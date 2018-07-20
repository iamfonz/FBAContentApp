using FBAContentApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBAContentApp.Models
{
    public class AmzWarehouseModel
    {
        public int Id { get; set; }

        public string WarehouseCode { get; set; }

        public string Name { get; set; }

        public string AddressLine { get; set; }

        public string City { get; set; }

        public int StateId { get; set; }

        public string StateAbrv { get; set; }

        public string ZipCode { get; set; }

        public AmzWarehouseModel()
        {
        }

        public AmzWarehouseModel(AmazonWarehouse entity)
        {
            Id = entity.Id;
            WarehouseCode = entity.WarehouseCode;
            Name = entity.Name;
            AddressLine = entity.AddressLine;
            City = entity.City;
            StateId = entity.State.Id;
            StateAbrv = entity.State.Abbreviation;
            ZipCode = entity.ZipCode;
        }


        public override string ToString()
        {
            return WarehouseCode + " : " + AddressLine + " " + City + ", " + StateAbrv;
        }
    }
}
