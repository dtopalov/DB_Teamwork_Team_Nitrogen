namespace NitrogenManager.Data.Models
{
    public class Employee
    {
        public Employee()
        {
        }

        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string JobPosition { get; set; }

        public bool HasManager { get; set; }
    }
}
