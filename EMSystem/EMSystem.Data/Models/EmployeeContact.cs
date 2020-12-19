using System;
using System.Collections.Generic;

#nullable disable

namespace EMSystem.Data.Models
{
    public partial class EmployeeContact
    {
        public Guid ContactId { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public Guid EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
