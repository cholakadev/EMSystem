using System;
using System.Collections.Generic;

#nullable disable

namespace EMSystem.Data.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeContacts = new HashSet<EmployeeContact>();
            Supervisors = new HashSet<Supervisor>();
        }

        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Team { get; set; }
        public string JobTitle { get; set; }
        public decimal Salary { get; set; }

        public virtual ICollection<EmployeeContact> EmployeeContacts { get; set; }
        public virtual ICollection<Supervisor> Supervisors { get; set; }
    }
}
