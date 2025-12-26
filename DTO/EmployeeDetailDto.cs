using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Learn.DTO
{
    public class EmployeeDetailDto
    {
        [DataMember] public int EmployeeDetailId { get; set; } // EmployeeId
        [DataMember] public string Address { get; set; }
        [DataMember] public string Phone { get; set; }
        [DataMember] public DateTime? DateOfBirth { get; set; }
    }
}