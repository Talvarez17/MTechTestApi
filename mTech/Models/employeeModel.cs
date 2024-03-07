namespace mTech.Models
{
    public class Employee
    {
        //public int ID { get; set; }

        public  Guid? Id { get; set; }
        public string? Name { get; set; }

        public string? LastName { get; set; }

        public string? RFC { get; set; }

        public DateTime? BornDate { get; set; }

        public string? Status { get; set; }
    }

    //public enum EmployeeStatus
    //{
    //    NotSet,
    //    Active,
    //    Inactive,
    //}
}
