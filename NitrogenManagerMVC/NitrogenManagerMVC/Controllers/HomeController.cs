namespace NitrogenManagerMVC.Controllers
{
    using System.Web.Mvc;
    using System.Collections;
    using System.Collections.Generic;
    using NitrogenManagerWebService;

    public class HomeController : Controller
    {
        private readonly DataRepositoryClient nitrogenWS = new DataRepositoryClient();

        public ActionResult Index()
        {
            ICollection<Employee> employeesViewModel = nitrogenWS.GetAllEmployees();

            return View(employeesViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}