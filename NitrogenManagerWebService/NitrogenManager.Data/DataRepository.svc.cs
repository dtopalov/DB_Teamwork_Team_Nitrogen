namespace NitrogenManager.Data.WebService
{

    using System.Linq;
    using System.Collections.Generic;
    using NitrogenManager.Data.Models;
    using NitrogenManager.Data.WebService.App_Data;

    public class DataRepository : IDataRepository
    {
        public ICollection<Product> GetAllProducts()
        {
            using (var ctx = new NitrogenEntities())
            {
                var products = (from product in ctx.Products
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
            using (var ctx = new NitrogenEntities())
            {
                var employees = (from employee in ctx.Employees
                                 select new Employee
                                 {
                                     ID = employee.EmployeeID,
                                     FirstName = employee.FirstName,
                                     LastName = employee.LastName,
                                     Age = employee.Age,
                                     JobPosition = (from position in ctx.JobPositions
                                                    where position.JobPositionID == employee.JobPositionID
                                                    select position.Name).FirstOrDefault(),

                                     HasManager = ctx.Employees.Any(x => x.ManagerID == employee.EmployeeID)
                                 }).ToList();

                return employees;
            }
        }

        public ICollection<Company> GetAllCompanies()
        {
            using (var ctx = new NitrogenEntities())
            {
                //joining tables example
                var companies = (from c in ctx.Companies
                                 select new Company
                                 {
                                     ID = c.CompanyID,
                                     Name = c.Name,
                                     Bulstat = c.Bulstat,
                                     Places = (from p in ctx.Places
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
