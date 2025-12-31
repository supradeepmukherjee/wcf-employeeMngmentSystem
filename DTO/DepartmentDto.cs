using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Learn.DTO
{
    [DataContract]
    public class DepartmentDto
    {
        [DataMember] public int DepartmentId { get; set; }
        [DataMember] public string Name { get; set; }
        [DataMember] public List<EmployeeDto> Employees { get; set; } = new List<EmployeeDto>();
    }
}