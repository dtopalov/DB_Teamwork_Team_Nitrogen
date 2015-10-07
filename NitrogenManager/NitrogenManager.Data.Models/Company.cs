namespace NitrogenManager.Data.Models
{
    using System.Collections.Generic;

    public class Company
    {
        public Company()
        {
            this.Places = new List<Place>();
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public string Bulstat { get; set; }

        public ICollection<Place> Places { get; set; }
    }
}
