namespace NitrogenManager.Data.Models
{
    using System.Collections.Generic;

    public class ProductGroup
    {
        public ProductGroup()
        {
            this.Products = new List<Product>();
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
