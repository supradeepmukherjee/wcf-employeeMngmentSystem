using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Learn.DTO
{
    public class ProjectDto
    {
        [DataMember] public int ProjectId { get; set; }
        [DataMember] public string Title { get; set; }
        [DataMember] public string Description { get; set; }
        [DataMember] public List<EmployeeDto> Employees { get; set; } = new List<EmployeeDto>();
    }
}