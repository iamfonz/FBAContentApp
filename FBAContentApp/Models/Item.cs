using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBAContentApp.Models
{

    public class Item: IEquatable<Item>
    {
        #region Properties

        public string ItemCode { get; set; }

        public int Quantity { get; set; }

        #endregion


        #region Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Item() 
        {
        }
        
        /// <summary>
        /// Overloaded constructor to create Item object.
        /// </summary>
        /// <param name="iItem">Item Code string (FNSKU)</param>
        public Item(string iItem)
        {
            ItemCode = iItem;
            Quantity = 1;
        }
        #endregion


        #region Methods
        /// <summary>
        /// Overridden ToString method. Formats the object as "FNSKU:(value),QTY:(Value)".
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string format = "FNSKU:" + ItemCode + ",QTY:" + Quantity;

            return format;
        }

        public bool Equals(Item obj)
        {
            if (obj == null) return false;
            return string.Equals(ItemCode, obj.ItemCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as Item);
        }

        public override int GetHashCode()
        {
            return ItemCode.GetHashCode();
        }


        #endregion
    }
}
