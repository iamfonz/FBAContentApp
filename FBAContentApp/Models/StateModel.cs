using FBAContentApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBAContentApp.Models
{
    public class StateModel
    {
        public int Id { get; set; }

        public string Abbreviation { get; set; }


        public StateModel(Entities.State state)
        {
            this.Id = state.Id;
            this.Abbreviation = state.Abbreviation;
        }

        public override string ToString()
        {
            return this.Abbreviation;
        }
    }


}
