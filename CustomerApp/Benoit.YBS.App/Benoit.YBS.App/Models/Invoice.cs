namespace Benoit.YBS.App.Models
{
    public class Invoice : EntityBase
    {
        public string InvoiceId
        {
            get { return Id; }
            set { Id = value; }
        }
        public string UserMobileNumber { get; set; }
        public string InvoiceNumber { get; set; }
        public string SellerId { get; set; }
        public string BillingAddress { get; set; }
        public string SellerName { get; set; }
        public string ItemDetails { get; set; }
        public string GstNumber { get; set; }
        public string InvoiceDate { get; set; }
        public double TotalValue { get; set; }

    }
}