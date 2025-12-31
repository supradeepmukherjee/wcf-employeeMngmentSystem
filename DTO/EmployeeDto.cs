using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Learn.DTO
{
    [DataContract]
    public class EmployeeDto
    {
        [DataMember] public int EmployeeId { get; set; }
        [DataMember] public string FirstName { get; set; }
        [DataMember] public string LastName { get; set; }
        [DataMember] public string Email { get; set; }

        [DataMember] public int? DepartmentId { get; set; }
        [DataMember] public DepartmentDto Department { get; set; }

        [DataMember] public EmployeeDetailDto Detail { get; set; }

        [DataMember] public List<ProjectDto> Projects { get; set; } = new List<ProjectDto>();
    }
}