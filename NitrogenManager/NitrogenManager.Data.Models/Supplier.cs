namespace NitrogenManager.Data.Models
{
    using System.Collections.Generic;

    public class Supplier
    {
        public Supplier()
        {
            this.Company = new Company();
            this.Places = new List<Place>();
        }

        public int ID { get; set; }

        public string Address { get; set; }

        public Company Company { get; set; }

        public ICollection<Place> Places { get; set; }
    }
}
