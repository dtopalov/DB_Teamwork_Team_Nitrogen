namespace NitrogenManager.Data.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Place
    {
        public Place()
        {
        }

        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Address { get; set; }
    }
}