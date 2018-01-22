using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Model
{
    public class Seller : BaseEntity
    {
        private string _sellerName;
        private string _sellerCategory;
        private string _sellerId;
        private string _sellerGstNumber;
        private string _sellerAddress;
        private string _sellerCountry;
        private string _sellerCity;
        private string _sellerPinCode;
        private string _phoneNumber;

        public Seller(string sellerCountry, string phoneNumber)
        {
            this.SellerCountry = sellerCountry;
            this.PhoneNumber = phoneNumber;
            this.SellerId = new Guid().ToString();
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

        public string SellerCategory
        {
            get => _sellerCategory;
            set
            {
                _sellerCategory = value;
                NotifyPropertyChanged("SellerCategory");
            }
        }
        

        public string SellerId
        {
            get => _sellerId;
            set
            {
                _sellerId = value;
                NotifyPropertyChanged("SellerId");
            }
        }
    
        public string SellerGstNumber
        {
            get => _sellerGstNumber;
            set
            {
                _sellerGstNumber = value;
                NotifyPropertyChanged("SellerGstNumber");
            }
        }
        

        public string SellerAddress
        {
            get => _sellerAddress;
            set
            {
                _sellerAddress = value;
                NotifyPropertyChanged("SellerAddress");
            }
        }
       

        public string SellerCountry
        {
            get => _sellerCountry;
            set
            {
                _sellerCountry = value;
                NotifyPropertyChanged("SellerCountry");
            }
        }
      
        public string SellerCity
        {
            get => _sellerCity;
            set
            {
                _sellerCity = value;
                NotifyPropertyChanged("SellerCity");
            }
        }
        

        public string SellerPinCode
        {
            get => _sellerPinCode;
            set
            {
                _sellerPinCode = value;
                NotifyPropertyChanged("SellerPinCode");
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
    
        public string Error => throw new NotImplementedException();        

        public string this[string columnName]
        {
            get
            {
                if (columnName == "SellerGstNumber")
                {
                    if (string.IsNullOrEmpty(this.SellerGstNumber))
                    {
                        return "GST number is needed.";
                    }
                }
                
                return null;
            }
        }
    }
}
