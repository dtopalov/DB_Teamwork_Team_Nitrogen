namespace NitrogenManager.Data.Models
{
    public class Employee
    {
        public Employee()
        {
            this.Manager = new Employee();
        }

        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string JobPosition { get; set; }

        public Employee Manager { get; set; }
    }
}
