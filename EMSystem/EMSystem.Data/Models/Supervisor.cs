using System;
using System.Collections.Generic;

#nullable disable

namespace EMSystem.Data.Models
{
    public partial class Supervisor
    {
        public Guid SupervisorId { get; set; }
        public Guid EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
