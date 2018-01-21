using System.Runtime.Serialization;

namespace Benoit.YBS.App.Models
{
    [DataContract]
    public class Item : EntityBase
    {
        [DataMember]
        public string ItemName { get; set; }
        [DataMember]
        public double Quantity { get; set; }
        [DataMember]
        public double Rate { get; set; }
        [DataMember]
        public double TotalPrice { get; set; }
        [DataMember]
        public double Discount { get; set; }
    }
}