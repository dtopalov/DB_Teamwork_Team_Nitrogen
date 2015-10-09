using System.Runtime.Serialization;

namespace NitrogenManager.Data.Models
{
    [DataContract]
    public class Employee
    {
        public Employee()
        {
        }

        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public int Age { get; set; }

        [DataMember]
        public string JobPosition { get; set; }

        [DataMember]
        public bool HasManager { get; set; }
    }
}
