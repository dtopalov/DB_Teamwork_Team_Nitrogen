using System.Collections.Generic;
using System.Linq;
using NitrogenManager.Data.Models;

namespace NitrogenManager.Data
{
    public class DataRepository
    {
        private readonly NitrogenEntities nitrogenData = new NitrogenEntities();

        public ICollection<Product> GetAllProducts()
        {
            using (nitrogenData)
            {
                var products = (from product in nitrogenData.Products
                    select new Product
                    {
                        ID = product.ProductID,
                        Name = product.Name
                    }).ToList();

                return products;
            }
        }

        public ICollection<Employee> GetAllEmployees()
        {
            using (nitrogenData)
            {
                var employees = (from employee in nitrogenData.Employees
                                select new Employee
                                {
                                    ID = employee.EmployeeID,
                                    FirstName = employee.FirstName,
                                    LastName = employee.LastName,
                                    Age = employee.Age,
                                    JobPosition = (from position in nitrogenData.JobPositions
                                                   where position.JobPositionID == employee.JobPositionID
                                                   select position.Name).FirstOrDefault(),

                                    HasManager = nitrogenData.Employees.Any(x => x.ManagerID == employee.EmployeeID)
                                }).ToList();

                return employees;
            }
        }

        public ICollection<Company> GetAllCompanies()
        {
            using (nitrogenData)
            {
                //joining tables example
                var companies = (from c in nitrogenData.Companies
                                 select new Company
                                 {
                                     ID = c.CompanyID,
                                     Name = c.Name,
                                     Bulstat = c.Bulstat,
                                     Places = (from p in nitrogenData.Places
                                               where c.CompanyID == p.CompanyID
                                               select new Place
                                               {
                                                   ID = p.PlaceID,
                                                   Address = p.Address,
                                                   Name = p.Name,
                                               }).ToList()
                                 }).ToList();

                return companies;
            }
        }
    }
}
