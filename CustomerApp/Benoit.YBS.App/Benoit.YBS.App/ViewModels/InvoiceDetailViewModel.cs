using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using Benoit.YBS.App.Models;

namespace Benoit.YBS.App.ViewModels
{
    public class InvoiceDetailViewModel : BaseViewModel
    {
        public Invoice Invoice { get; set; }
        public IList<Item> ItemsList { get; set; }
        public string CustomerName { get; set; }
        public string SellerAddress { get; set; }
        public string TotalValue { get; set; }


        public InvoiceDetailViewModel(Invoice invoice = null)
        {
            Invoice = invoice;
            invoice.InvoiceNumber = string.IsNullOrEmpty(invoice.InvoiceNumber) ? "INV1.11" : invoice.InvoiceNumber;

            Title = invoice?.SellerName + "-" + invoice?.InvoiceDate;
            
            CustomerName =  "Manish";
            SellerAddress = "Bangalore";
            invoice.UserMobileNumber = "9886666666";
            ItemsList = new List<Item>();
            ItemsList.Add(new Item() { ItemName = "Item1111", Quantity = 1, TotalPrice = 230 });
            ItemsList.Add(new Item() { ItemName = "Item1122", Quantity = 3, TotalPrice = 230 });
            ItemsList.Add(new Item() { ItemName = "Item1133", Quantity = 1, TotalPrice = 230 });
            invoice.TotalValue = 232332;
            TotalValue = "Rs." + invoice.TotalValue.ToString();
            //using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(invoice?.ItemDetails)))
            //{
            //    DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(IList<Item>));
            //    ItemsList = (IList<Item>)deserializer.ReadObject(ms);
            //}

        }
    }
}
