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
        /// Allows for a query to be performed on the database to a CompanyAddress Entity. 
        /// </summary>
        /// <param name="companyAddress">Modified CompanyAdrressModel to be passed to database.</param>
        /// <param name="dbQuery">The type of query to be performed on the database.</param>
        /// <returns>If successfully added to Db return True. </returns>
        public bool CompanyAddressToDb(CompanyAddressModel companyAddress, Utilities.DbQuery dbQuery)
        {
            if (companyAddress != null)
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
                        State = db.States.Where(s => s.Id == companyAddress.StateId).FirstOrDefault()

                    };

                    //perform correct DB query depending on what was passed in as dbentry.
                    switch (dbQuery)
                    {
                        case Utilities.DbQuery.Add:
                            db.CompanyAddresses.Add(company);
                            break;
                        case Utilities.DbQuery.Edit:
                            db.Entry(company).State = System.Data.Entity.EntityState.Modified;
                            break;
                        case Utilities.DbQuery.Delete:
                            CompanyAddress compDelete = db.CompanyAddresses.Find(company.Id);
                            db.CompanyAddresses.Remove(compDelete);
                            break;
                    }

                    //save DbContext
                    db.SaveChanges();

                    return true;
                }
            }
            else
            {
                return false;
            }

            

        }


    }
}
