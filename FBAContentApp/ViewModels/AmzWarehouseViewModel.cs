using FBAContentApp.Entities;
using FBAContentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBAContentApp.ViewModels
{
    public class AmzWarehouseViewModel
    {
        public List<StateModel> StateModels { get; set; }

        public List<AmzWarehouseModel> FulFillmentCenters { get; set; }

        public AmzWarehouseModel CurrentAmazonWhse { get; set; }

        /// <summary>
        /// Overloaded constructor passing in an AmzWarehouseModel object to edit one.
        /// </summary>
        /// <param name="comp">CompanyAddressModel to be edited.</param>
        public AmzWarehouseViewModel(AmzWarehouseModel amzWhse)
        {
            StateModels = new List<StateModel>();
            FulFillmentCenters = new List<AmzWarehouseModel>();
            CurrentAmazonWhse = amzWhse;

            PopulateLists();

        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public AmzWarehouseViewModel() : this(new AmzWarehouseModel())
        {
        }

        /// <summary>
        /// Populates the StateModels and FullfillmentCenters list for the UI.
        /// </summary>
        private void PopulateLists()
        {
            using (var db = new Models.AppContext())
            {
                //populate states
                List<State> dbStates = db.States.ToList();

                foreach (State state in dbStates)
                {
                    StateModels.Add(new StateModel(state));
                }

                //populate fullfillment centers
                List<AmazonWarehouse> amazonWarehouses = db.AmazonWarehouses.ToList();
                amazonWarehouses.OrderBy(i => i.WarehouseCode);

                foreach(AmazonWarehouse amz in amazonWarehouses)
                {
                    FulFillmentCenters.Add(new AmzWarehouseModel(amz));
                }

                //sort fullfillment centers by WarehouseIDgit do    
                FulFillmentCenters.OrderBy(i => i.WarehouseCode);
            }
        }


        /// <summary>
        /// Allows for a query to be performed on the database to an AmazonWarehouse Entity. 
        /// </summary>
        /// <param name="amzWarehouse">AmazonWarehouse entity to be passed to database.</param>
        /// <param name="dbQuery">The type of query to be performed on the database.</param>
        /// <returns>If successfully added to Db return True. </returns>
        public bool AmzWarehouseDbQuery(AmzWarehouseModel amzWarehouse, Utilities.DbQuery dbQuery)
        {
            if (amzWarehouse != null)
            {
                using (var db = new Models.AppContext())
                {
                    //instantiate new AmazonWarehouse entity and fill fields
                    AmazonWarehouse amazon = new AmazonWarehouse()
                    {
                        Id = amzWarehouse.Id,
                        WarehouseCode = amzWarehouse.WarehouseCode,
                        Name = amzWarehouse.Name,
                        AddressLine = amzWarehouse.AddressLine,
                        City = amzWarehouse.City,
                        ZipCode = amzWarehouse.ZipCode,
                        State = db.States.Where(s => s.Id == amzWarehouse.StateId).FirstOrDefault()

                    };

                    //perform correct DB query depending on what was passed in as dbentry.
                    switch (dbQuery)
                    {
                        case Utilities.DbQuery.Add:
                            db.AmazonWarehouses.Add(amazon);
                            break;
                        case Utilities.DbQuery.Edit:
                            db.Entry(amazon).State = System.Data.Entity.EntityState.Modified;
                            break;
                        case Utilities.DbQuery.Delete:
                            AmazonWarehouse compDelete = db.AmazonWarehouses.Find(amazon.Id);
                            db.AmazonWarehouses.Remove(compDelete);
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
