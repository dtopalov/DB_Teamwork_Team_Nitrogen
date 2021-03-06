﻿namespace NitrogenManager.Data.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Product
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
