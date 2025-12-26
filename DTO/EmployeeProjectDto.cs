using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Learn.DTO
{
    public class EmployeeProjectDto
    {
        [DataMember] public int EmployeeId { get; set; }
        [DataMember] public int ProjectId { get; set; }
        [DataMember] public DateTime AssignedDate { get; set; }
    }
}