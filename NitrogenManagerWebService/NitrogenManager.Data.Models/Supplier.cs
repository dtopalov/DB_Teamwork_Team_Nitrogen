namespace NitrogenManager.Data.Models
{
    using System.Runtime.Serialization;
    using System.Collections.Generic;

    [DataContract]
    public class Supplier
    {
        public Supplier()
        {
            this.Company = new Company();
            this.Places = new List<Place>();
        }

        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public Company Company { get; set; }

        [DataMember]
        public ICollection<Place> Places { get; set; }
    }
}
