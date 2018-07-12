using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBAContentApp.Models
{
    public class FBABox
    {
        #region Full Properties and Fields
        /// <summary>
        /// Full properites and fields to represent contents of a FBA shipment box.
        /// </summary>
        /// 
        private string boxid;

        public string BoxID
        {
            get { return boxid; }
            set { boxid = value; }
        }

        private int boxnumber;

        public int BoxNumber
        {
            get { return boxnumber; }
            set { boxnumber = value; }
        }


        private List<Item> contents = new List<Item>();

        public List<Item> Contents
        {
            get { return contents; }
            set { contents = value; }
        }

        private string po;
        public string PO
        {
            get { return po; }
            set { po = value; }

        }


        #endregion


        #region Constructors

        /// <summary>
        /// Default constructor of Box object.
        /// </summary>
        public FBABox() : this(new List<Item>(), "TBD")
        {


        }

        /// <summary>
        /// Overloaded constructor of Box object where a list of items is passed in.
        /// </summary>
        /// <param name="iItems"> List of Items class object to instantiate Box object</param>
        public FBABox(List<Item> iItems, string iName)
        {
            contents = iItems;
            boxid = iName;
        }

        /// <summary>
        /// Overloaded constructor for Box object. 
        /// </summary>
        /// <param name="fdh">Pass in a FileDataHolder object and all properties are set.</param>
        public FBABox(string boxId)
        {
            this.BoxID = boxId;

        }

        #endregion

        #region Methods
        /// <summary>
        /// Overidden ToString
        /// </summary>
        /// <returns>Returns box ID</returns>
        public override string ToString()
        {
            return boxid;
        }

        public string ContentsToFile()
        {
            string format = "BoxID:" + boxid + Environment.NewLine;
            foreach (Item i in contents)
            {
                format += i.ToString() + Environment.NewLine;
            }
            format += Environment.NewLine;

            return format;

        }


        /// <summary>
        /// Adds item to the list of scanned items List. If the item is already in the List, 1 quantity is added; else the item is added with 1 qty.
        /// </summary>
        /// <param name="itm">Item to be added to the contents of this box.</param>
        public void AddItem(Item itm)
        {
            if (Contents.Contains(itm)) //check if item is in the box
            {
                var indexItem = Contents.IndexOf(itm); //find it's index
                Contents[indexItem].Quantity += 1; //add 1 quantity
            }
            else
            {//else add the new item
                Contents.Add(itm);
            }
        }

        /// <summary>
        /// Formats the proper string for Amazon's Fulfillment 2D barcode requires
        /// </summary>
        /// <returns>Returns formatted string for Amazon's 2d Barcode requirements</returns>
        public string FBALabel()
        {
            string format = "AMZN,PO:" + po + ",";
            foreach (Item i in contents)
            {
                format += i.ToString();
            }

            return format;
        }
        #endregion
    }
}
