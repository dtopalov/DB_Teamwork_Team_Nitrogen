

namespace NitrogenManager.Data.Models
{
    using System.Runtime.Serialization;
    using System.Collections.Generic;

    [DataContract]
    public class Company
    {
        public Company()
        {
            this.Places = new List<Place>();
        }

        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Bulstat { get; set; }

        [DataMember]
        public ICollection<Place> Places { get; set; }
    }
}
