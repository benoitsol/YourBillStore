using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Model
{
    public class Invoice : BaseEntity, IDataErrorInfo
    {
        #region Private feilds

        private double _billAmount;
        private string _billItems;
        private string _sellerGstNumber;
        private double _totalGstAmount;
        private string _cashierName;
        private string _cashierId;
        private string _discountCuponCode;
        private int _discountPercent;
        private double _totalDisCount;
        private string _sellerName;
        private string _address;
        private long _sellerId;
        private string _countryCode;
        private string _phoneNumber;
        private string _invoiceNumber;
        private long _billId;
        private double _changeReturned;       

        #endregion

        public Invoice(string phoneNumber)
        {
            this.PhoneNumber = phoneNumber;
            this.InvoiceNumber = new Guid().ToString();
        }


        public Invoice() { }

        public long BillId
        {
            get => _billId;
            set
            {
                _billId = value;
                NotifyPropertyChanged("BillId");
            }
        }

        public string CountryCode
        {
            get => _countryCode;
            set
            {
                _countryCode = value;
                NotifyPropertyChanged("CountryCode");
            }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                NotifyPropertyChanged("PhoneNumber");
            }
        }       

        public string InvoiceNumber
        {
            get => _invoiceNumber;
            set
            {
                _invoiceNumber = value;
                NotifyPropertyChanged("InvoiceNumber");
            }
        }        

        public long SellerId
        {
            get => _sellerId;
            set
            {
                _sellerId = value;
                NotifyPropertyChanged("SellerId");
            }
        }      

        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                NotifyPropertyChanged("Address");
            }
        }          

        public string SellerName
        {
            get => _sellerName;
            set
            {
                _sellerName = value;
                NotifyPropertyChanged("SellerName");
            }
        }         

        // PaymentMode ModeOfPayment { get; set; }

        public string SellerGstNumber
        {
            get => _sellerGstNumber;
            set
            {
                _sellerGstNumber = value;
                NotifyPropertyChanged("SellerGstNumber");
            }
        }  
       

        public double TotalGstAmount
        {
            get => _totalGstAmount;
            set
            {
                _totalGstAmount = value;
                NotifyPropertyChanged("TotalGstAmount");
            }
        }        

        public string CashierName
        {
            get => _cashierName;
            set
            {
                _cashierName = value;
                NotifyPropertyChanged("CashierName");
            }
        }          

        public string CashierId
        {
            get => _cashierId;
            set
            {
                _cashierId = value;
                NotifyPropertyChanged("CashierId");
            }
        }       

        public string DiscountCuponCode
        {
            get => _discountCuponCode;
            set
            {
                _discountCuponCode = value;
                NotifyPropertyChanged("DiscountCuponCode");
            }
        }         

        public int DiscountPercent
        {
            get => _discountPercent;
            set
            {
                _discountPercent = value;
                NotifyPropertyChanged("DiscountPercent");
            }
        }        

        public double TotalDisCount
        {
            get => _totalDisCount;
            set
            {
                _totalDisCount = value;
                NotifyPropertyChanged("DiscountPercent");
            }
        }      
        

        public string BillItems { get => _billItems; set => _billItems = value; }

        public double BillAmount
        {
            get => _billAmount;
            set
            {
                _billAmount = value;
                NotifyPropertyChanged("BillAmount");
            }
        }       

        public double ChangeReturned
        {
            get => _changeReturned;
            set
            {
                _changeReturned = value;
                NotifyPropertyChanged("ChangeReturned");
            }
        }       

        public string Error => string.Empty;

        public string this[string columnName]
        {
            get
            {
                if (columnName == "PhoneNumber")
                {
                    Regex phone = new Regex(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}");
                    if (!phone.IsMatch(this.PhoneNumber))
                    {
                        return "phone number is invalid.";
                    }
                }

                if (columnName == "SellerGstNumber")
                {                   
                    if (string.IsNullOrEmpty(this.SellerGstNumber))
                    {
                        return "GST number is needed.";
                    }
                }

                if (columnName == "BillAmount")
                {
                    if (this._billAmount > 0)
                    {
                        return "Bill Amount cant be zero.";
                    }
                }

                if (columnName == "BillItems")
                {
                    if (string.IsNullOrEmpty(this.BillItems))
                    {
                        return "atleast one Bill Item should be there";
                    }
                }
                return null;
            }
        }        
    }
}
