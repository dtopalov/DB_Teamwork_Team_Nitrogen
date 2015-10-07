namespace NitrogenManager.Data.Models
{
    using System.Collections.Generic;

    public class Place
    {
        public Place()
        {
            this.Employees = new List<Employee>();
            this.Suppliers = new List<Supplier>();
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public ICollection<Supplier> Suppliers { get; set; }
    }
}