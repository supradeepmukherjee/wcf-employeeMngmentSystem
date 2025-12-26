using Learn.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Learn.Mapping
{
    public static class Mapper
    {
        public static DepartmentDto ToDto(this Department dept)
        {
            if (dept == null) return null;
            var dto = new DepartmentDto
            {
                DepartmentId = dept.DepartmentId,
                Name = dept.Name
            };
            if (dept.Employees != null)
            {
                dto.Employees = dept.Employees.Select(e => e.ToDtoWithoutDepartment()).ToList();
            }
            return dto;
        }

        // to avoid circular references
        public static EmployeeDto ToDtoWithoutDepartment(this Employee e)
        {
            if (e == null) return null;
            var dto = new EmployeeDto
            {
                EmployeeId = e.EmployeeId,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                DepartmentId = e.DepartmentId
            };
            if (e.EmployeeDetail != null)
            {
                dto.Detail = e.EmployeeDetail.ToDto();
            }
            if (e.EmployeeProjects != null)
            {
                dto.Projects = e.EmployeeProjects.Select(ep => ep.Project.ToDtoWithoutEmployees()).ToList();
            }
            return dto;
        }

        public static EmployeeDto ToDto(this Employee e)
        {
            var dto = e.ToDtoWithoutDepartment();
            if (e.Department != null)
                dto.Department = e.Department.ToDtoWithoutEmployees();
            return dto;
        }

        public static DepartmentDto ToDtoWithoutEmployees(this Department d)
        {
            if (d == null) return null;
            return new DepartmentDto { DepartmentId = d.DepartmentId, Name = d.Name };
        }

        public static EmployeeDetailDto ToDto(this EmployeeDetail d)
        {
            if (d == null) return null;
            return new EmployeeDetailDto
            {
                EmployeeDetailId = d.EmployeeDetailId,
                Address = d.Address,
                Phone = d.Phone,
                DateOfBirth = d.DateOfBirth
            };
        }

        public static ProjectDto ToDtoWithoutEmployees(this Project p)
        {
            if (p == null) return null;
            return new ProjectDto { ProjectId = p.ProjectId, Title = p.Title, Description = p.Description };
        }

        public static ProjectDto ToDto(this Project p)
        {
            var dto = p.ToDtoWithoutEmployees();
            if (p.EmployeeProjects != null)
            {
                dto.Employees = p.EmployeeProjects.Select(ep => ep.Employee.ToDtoWithoutDepartment()).ToList();
            }
            return dto;
        }
    }
}