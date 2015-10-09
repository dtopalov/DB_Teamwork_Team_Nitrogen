namespace NitrogenManager.Data.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Storage
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Address { get; set; }
    }
}
