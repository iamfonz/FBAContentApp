using FBAContentApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBAContentApp.Models
{
    public class ZPLLabel
    {
        #region Full properties and Fields

        public AmzWarehouseModel AmzWarehouse { get; set; }

        public CompanyAddressModel ShipFromAddress { get; set; }

        public FBABox Box { get; set; }

        private string command;

        public string ZPLCommand
        {
            get { return command; }
            set { command = value; }
        }

        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor for creating a ZPLLabel object.
        /// </summary>
        public ZPLLabel() : this(null, null, null)
        {
            AmzWarehouse = new AmzWarehouseModel();
            ShipFromAddress = new CompanyAddressModel();
            Box = new FBABox();
        }

        /// <summary>
        /// Overloaded constructor for creating a ZPLLabel Object for FBA Shipments.
        /// </summary>
        /// <param name="iwhse">The AMZWarehouse object that the shipment will be going to.</param>
        /// <param name="iboxes">A list of Box objects that are being shipped to Amazon.</param>
        public ZPLLabel(AmzWarehouseModel iwhse, CompanyAddressModel shipFromAddress, FBABox box )
        {
            command = "";
            AmzWarehouse = iwhse;
            ShipFromAddress = shipFromAddress;
            Box = box;
        }

        #endregion


        #region Methods

        /// <summary>
        /// Method formats text in ZPL2 to print a label for FBA shipment.
        /// </summary>
        /// <param name="boxCount">The number of boxes in a shipment.</param>
        public void CreateLabel(int boxCount)
        {
            command = "";
            //Below is the ZPL command being created for each label. 
            command = "^XA" + // ^XA starts the ZPL Command for the printer to interpret

            //start of the Amazon Warehouse Label
            "^FO50,50^ADN,40,20^FDFBA^FS" +
            "^FO450,50^ADN,40,20^FDBox " + Box.BoxNumber + " of " + boxCount + "^FS" +
            "^FO30,90^GB700,0,8^FS" +

            // ship from Company Address
            "^FO50,105^ADN,25,10^FDSHIP FROM:^FS" +
            "^FO50,125^ADN,25,10^FD"+ ShipFromAddress.CompanyName +"^FS" +
            "^FO50,145^ADN,25,10^FD"+ ShipFromAddress.AddressLine1 + "^FS" +
                 "^FO50,165^ADN,25,10^FD" + ShipFromAddress.AddressLine2 + "^FS" +
                 "^FO50,185^ADN,25,10^FD"+ ShipFromAddress.City + ", " + ShipFromAddress.StateAbrv + " " + ShipFromAddress.ZipCode + "^FS" +
                 "^FO50,205^ADN,25,10^FDUnited States^FS" +

                 //ShipTo Amazon warehouse address
                 "^FO450,105^ADN,25,10^FDSHIP TO:^FS" +
                 "^FO450,125^ADN,25,10^FDFBA:"+ ShipFromAddress.LegalEntityName+"^FS" +
                 "^FO450,145^ADN,25,10^FD" + AmzWarehouse.Name + "^FS" +
                 "^FO450,165^ADN,25,10^FD" + AmzWarehouse.AddressLine + "^FS" +
                 "^FO450,185^ADN,25,10^FD" + AmzWarehouse.City + ", " + AmzWarehouse.StateAbrv + " " + AmzWarehouse.ZipCode + "^FS" +
                 "^FO450,205^ADN,25,10^FDUnited States^FS" +
                 "^FO30,235^GB700,0,8^FS" +

                 //code 128 barcode for Amazon label of boxID
                 "^FO100,255^BY3" +
                 "^BCN,150,Y,N,N" +
                 "^FD" + Box.BoxID + "^FS" +
                 "^FO130,450,^BY3" +
                 //pdf417 barcode for Amazon Label of BOXID
                 "^B7N,8,6,,,N^FD" + Box.BoxID + "^FS" +
                 "^FO5, 700^ADN,30,15^FDPlease do not cover this label^FS" +
                 "^FO30,755^GB700,0,8^FS" +
                 "^FO50,780^ADN,40,20^FDBox Content^FS" +

                 //PDF417 barcode of the box content(string)
                 "^FO30,840,^BY" +
                 "^B7N,8,6,10,75,N^FD" + Box.FBALabel() + "^FS" +
                 "^FO5, 1550^ADN,30,15^FDPlease do not cover this label^FS" +
                 "^XZ";
        }




        #endregion
    }
}
