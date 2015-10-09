namespace NitrogenManager.Data.Models
{
    using System.Runtime.Serialization;
    using System.Collections.Generic;

    [DataContract]
    public class ProductGroup
    {
        public ProductGroup()
        {
            this.Products = new List<Product>();
        }

        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public ICollection<Product> Products { get; set; }
    }
}
