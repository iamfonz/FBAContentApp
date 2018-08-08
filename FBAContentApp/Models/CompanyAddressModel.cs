using FBAContentApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBAContentApp.Models
{
    public class CompanyAddressModel
    {
        public int Id { get; set; }

        public string LegalEntityName { get; set; }

        public string CompanyName { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string City { get; set; }

        public int StateId { get; set; }

        public string StateAbrv { get; set; }

        public string ZipCode { get; set; }

        public CompanyAddressModel()
        {

        }

        public CompanyAddressModel(CompanyAddress entity)
        {
            Id = entity.Id;
            LegalEntityName = entity.LegalEntityName;
            CompanyName = entity.CompanyName;
            AddressLine1 = entity.AddressLine1;
            AddressLine2 = entity.AddressLine2;
            AddressLine3 = entity.AddressLine3;
            City = entity.City;
            StateId = entity.State.Id;
            StateAbrv = entity.State.Abbreviation;
            ZipCode = entity.ZipCode;
        }

        public override string ToString()
        {
            return LegalEntityName + "; " + CompanyName + ":  " + AddressLine1 + " " + City + ", " + StateAbrv;
        }
    }
}
