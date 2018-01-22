using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BillingItem : BaseEntity, IDataErrorInfo
    {
        private string _itemCode;
        private string _itemName;
        private string _discount;
        private double _taxPercent;
        private double _taxAmount;
        private double _netAmount;
        private double _grossAmount;
        private int _quantity;       

        public string ItemCode
        {
            get => _itemCode;
            set
            {
                _itemCode = value;
                NotifyPropertyChanged("ItemCode");
            }
        }

        public string ItemName
        {
            get => _itemName;
            set
            {
                _itemCode = value;
                NotifyPropertyChanged("ItemName");
            }
        }

        public string Discount
        {
            get => _discount;
            set
            {
                _discount = value;
                NotifyPropertyChanged("Discount");
            }
        }

        public double TaxPercent
        {
            get => _taxPercent;
            set
            {
                _taxPercent = value;
                NotifyPropertyChanged("TaxPercent");
            }
        }

        public double TaxAmount
        {
            get => _taxAmount;
            set
            {
                _taxAmount = value;
                NotifyPropertyChanged("TaxAmount");
            }
        }

        public double NetAmount
        {
            get => _netAmount;
            set
            {
                _netAmount = value;
                NotifyPropertyChanged("NetAmount");
            }
        }

        public double GrossAmount
        {
            get => _grossAmount;
            set
            {
                _grossAmount = value;
                NotifyPropertyChanged("GrossAmount");
            }
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                NotifyPropertyChanged("Quantity");
            }
        }

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                if (columnName == "SellerGstNumber")
                {
                    if (string.IsNullOrEmpty(this.ItemCode))
                    {
                        return "Item code is mandatory is needed.";
                    }
                }

                if (columnName == "ItemName")
                {
                    if (string.IsNullOrEmpty(this.ItemName))
                    {
                        return "Item Name is not present.";
                    }
                }

                if (columnName == "Quantity")
                {
                    if (this.Quantity == 0)
                    {
                        return "GST number is needed.";
                    }
                }

                return null;
            }
        }
    }
}
