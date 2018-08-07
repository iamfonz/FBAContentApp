using FBAContentApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel;

namespace FBAContentApp.Models
{
    public class FBAShipment : INotifyPropertyChanged
    {
        #region Full Properties and Fields

        private string shipmentId;

        public string ShipmentID
        {
            get { return shipmentId; }
            set {
                shipmentId = value;
                OnPropertyChanged("ShipmentID");
            }

        }

        private DateTime shipmentDate;

        public DateTime ShipmentDate
        {
            get { return shipmentDate; }
            set {
                shipmentDate = value;
                OnPropertyChanged("ShipmentDate");
            }
        }


        private List<FBABox> boxes;

        public List<FBABox> Boxes
        {
            get { return boxes; }
            set {
                boxes = value;
                OnPropertyChanged("Boxes");
            }
        }

        private CompanyAddressModel companyShipFrom;

        public CompanyAddressModel CompanyShipFrom
        {
            get { return companyShipFrom; }
            set {
                companyShipFrom = value;
                OnPropertyChanged("CompanyShipFrom");
            }
        }

        private AmzWarehouseModel amzWarehouse;

        public AmzWarehouseModel FullfillmentShipTo
        {
            get { return amzWarehouse; }
            set {
                amzWarehouse = value;
                OnPropertyChanged("FullfillmentShipTo");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructors
        public FBAShipment()
        {
            shipmentId = "";
            boxes = new List<FBABox>();
            companyShipFrom = new CompanyAddressModel();
            amzWarehouse = new AmzWarehouseModel();
            shipmentDate = DateTime.Now;
        }
        
        #endregion

        #region Methods
        /// <summary>
        /// Sorts the shipment boxes by their box number order.
        /// </summary>
        public void SortBoxes()
        {
            int size = Boxes.Count;
            for (int i = 1; i < size; i++)
            {
                for (int j = 0; j < (size - i); j++)
                {
                    if (Boxes[j].BoxNumber > Boxes[j + 1].BoxNumber)
                    {
                        FBABox temp = Boxes[j];
                        Boxes[j] = Boxes[j + 1];
                        Boxes[j + 1] = temp;
                    }
                }
            }

        }

        /// <summary>
        /// Overridden ToString method that returns the object data in JSON format.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        protected void OnPropertyChanged(string name)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion


    }
}
