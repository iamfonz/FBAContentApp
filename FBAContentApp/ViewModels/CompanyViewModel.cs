using FBAContentApp.Entities;
using FBAContentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBAContentApp.ViewModels
{
    public class CompanyViewModel
    {
        public List<StateModel> StateModels { get; set; }

        public CompanyAddressModel CurrentCompanyAddress { get; set; }

        /// <summary>
        /// Overloaded constructor passing in a CompanyAddressModel to edit one.
        /// </summary>
        /// <param name="comp">CompanyAddressModel to be edited.</param>
        public CompanyViewModel(CompanyAddressModel comp)
        {
            StateModels = new List<StateModel>();
            CurrentCompanyAddress = comp;

            PopulateLists();

        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public CompanyViewModel():this(new CompanyAddressModel())
        {
        }

        /// <summary>
        /// Populates the StateModels list for the UI combo box control.
        /// </summary>
        private void PopulateLists()
        {
            //populate stateModels property
            using(var db = new Models.AppContext())
            {
                List<State> dbStates = db.States.ToList();

                foreach(State state in dbStates)
                {
                    StateModels.Add(new StateModel(state));
                }
            }
        }

        /// <summary>
        /// Edits an existing CompanyAddress entity from the database.
        /// </summary>
        /// <param name="comp"></param>
        public void EditCompanyAddress(CompanyAddressModel companyAddress)
        {
            //edit companyAddress to db
            using (var db = new Models.AppContext())
            {
                //instantiate new CompanyAddress entity and fill fields
                CompanyAddress company = new CompanyAddress()
                {
                    Id = companyAddress.Id,
                    CompanyName = companyAddress.CompanyName,
                    AddressLine1 = companyAddress.AddressLine1,
                    AddressLine2 = companyAddress.AddressLine2,
                    AddressLine3 = companyAddress.AddressLine3,
                    City = companyAddress.City,
                    ZipCode = companyAddress.ZipCode,
                    State = (State)db.States.Where(s => s.Id == companyAddress.StateId)

                };

                //add edited item to DB context
                db.Entry(company).State = System.Data.Entity.EntityState.Modified;

                //save DbContext
                db.SaveChanges();


                //refresh items on gui

            }
        }

    }
}
