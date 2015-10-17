namespace NitrogenManager.Data.WebService.Logic
{

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.

    using System;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;

    [ServiceContract]
    public interface IXmlFileParser
    {
        [OperationContract]
        string GenerateXmlFile();
    }
}
