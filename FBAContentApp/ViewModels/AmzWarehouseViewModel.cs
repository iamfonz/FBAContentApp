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

        public AmzWarehouseModel CurrentAmazonWhse { get; set; }

        /// <summary>
        /// Overloaded constructor passing in an AmzWarehouseModel object to edit one.
        /// </summary>
        /// <param name="comp">CompanyAddressModel to be edited.</param>
        public AmzWarehouseViewModel(AmzWarehouseModel amzWhse)
        {
            StateModels = new List<StateModel>();
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
        /// Populates the StateModels list for the UI combo box control.
        /// </summary>
        private void PopulateLists()
        {
            //populate stateModels property
            using (var db = new Models.AppContext())
            {
                List<State> dbStates = db.States.ToList();

                foreach (State state in dbStates)
                {
                    StateModels.Add(new StateModel(state));
                }
            }
        }
    }
}
