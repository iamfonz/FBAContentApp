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

    }
}
