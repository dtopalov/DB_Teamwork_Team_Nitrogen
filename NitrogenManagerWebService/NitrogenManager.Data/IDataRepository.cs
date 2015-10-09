namespace NitrogenManager.Data.WebService
{
    using System.ServiceModel;
    using System.Collections.Generic;
    using NitrogenManager.Data.Models;

    [ServiceContract]
    public interface IDataRepository
    {
        [OperationContract]
        ICollection<Product> GetAllProducts();

        [OperationContract]
        ICollection<Employee> GetAllEmployees();

        [OperationContract]
        ICollection<Company> GetAllCompanies();
    }
}
