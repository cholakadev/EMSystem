using System;
using System.Collections.Generic;

#nullable disable

namespace EMSystem.Data.Models
{
    public partial class EmployeeSupervisor
    {
        public Guid EmployeeSupervisorId { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid SupervisorId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Supervisor Supervisor { get; set; }
    }
}
