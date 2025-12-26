using Learn.DTO;
using Learn.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Learn
{
    public class EmployeeService : IEmployeeService
    {
        public bool AssignEmployeeToProject(int employeeId, int projectId)
        {
            using (var ctx = new EmployeeMgmtDBEntities1())
            {
                var exists = ctx.EmployeeProjects.Find(employeeId, projectId);
                if (exists != null) return false;
                var ep = new EmployeeProject { EmployeeId = employeeId, ProjectId = projectId, AssignedDate = DateTime.UtcNow };
                ctx.EmployeeProjects.Add(ep);
                ctx.SaveChanges();
                return true;
            }
        }

        public DepartmentDto CreateDepartment(DepartmentDto dto)
        {
            using (var ctx = new EmployeeMgmtDBEntities1())
            {
                var dept = new Department { Name = dto.Name };
                ctx.Departments.Add(dept);
                ctx.SaveChanges();
                return dept.ToDtoWithoutEmployees();
            }
        }

        public EmployeeDto CreateEmployee(EmployeeDto dto)
        {
            using (var ctx = new EmployeeMgmtDBEntities1())
            {
                var e = new Employee
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Email = dto.Email,
                    DepartmentId = dto.DepartmentId
                };
                ctx.Employees.Add(e);
                ctx.SaveChanges();
                return ctx.Employees.Find(e.EmployeeId).ToDto();
            }
        }

        public EmployeeDetailDto CreateOrUpdateEmployeeDetail(EmployeeDetailDto dto)
        {
            using (var ctx = new EmployeeMgmtDBEntities1())
            {
                var d = ctx.EmployeeDetails.Find(dto.EmployeeDetailId);
                if (d == null)
                {
                    d = new EmployeeDetail
                    {
                        EmployeeDetailId = dto.EmployeeDetailId,
                        Address = dto.Address,
                        Phone = dto.Phone,
                        DateOfBirth = dto.DateOfBirth
                    };
                    ctx.EmployeeDetails.Add(d);
                }
                else
                {
                    d.Address = dto.Address;
                    d.Phone = dto.Phone;
                    d.DateOfBirth = dto.DateOfBirth;
                }
                ctx.SaveChanges();
                return d.ToDto();
            }
        }

        public ProjectDto CreateProject(ProjectDto dto)
        {
            using (var ctx = new EmployeeMgmtDBEntities1())
            {
                var p = new Project { Title = dto.Title, Description = dto.Description };
                ctx.Projects.Add(p);
                ctx.SaveChanges();
                return p.ToDtoWithoutEmployees();
            }
        }

        public bool DeleteDepartment(int id)
        {
            using (var ctx = new EmployeeMgmtDBEntities1())
            {
                var d = ctx.Departments.Find(id);
                if (d == null) return false;
                ctx.Departments.Remove(d);
                ctx.SaveChanges();
                return true;
            }
        }

        public bool DeleteEmployee(int id)
        {
            using (var ctx = new EmployeeMgmtDBEntities1())
            {
                var emp = ctx.Employees.Find(id);
                if (emp == null) return false;
                var detail = ctx.EmployeeDetails.Find(id);
                if (detail != null)ctx.EmployeeDetails.Remove(detail);
                ctx.Employees.Remove(emp);
                ctx.SaveChanges();
                return true;
            }
        }

        public List<DepartmentDto> GetAllDepartments()
        {
            using (var ctx = new EmployeeMgmtDBEntities1())
            {
                return ctx.Departments.ToList().Select(d => d.ToDtoWithoutEmployees()).ToList();
            }
        }

        public List<EmployeeDto> GetAllEmployees()
        {
            using (var ctx = new EmployeeMgmtDBEntities1())
            {
                var list = ctx.Employees
                    .Include("Department")
                    .Include("EmployeeDetail")
                    .Include("EmployeeProjects.Project")
                    .ToList();
                return list.Select(e => e.ToDto()).ToList();
            }
        }

        public List<ProjectDto> GetAllProjects()
        {
            using (var ctx = new EmployeeMgmtDBEntities1())
            {
                var list = ctx.Projects.Include("EmployeeProjects.Employee").ToList();
                return list.Select(p => p.ToDto()).ToList();
            }
        }

        public DepartmentDto GetDepartmentById(int id)
        {
            using (var ctx = new EmployeeMgmtDBEntities1())
            {
                return ctx.Departments.Find(id)?.ToDtoWithoutEmployees();
            }
        }

        public DepartmentDto GetDepartmentWithEmployees(int departmentId)
        {
            using (var ctx = new EmployeeMgmtDBEntities1())
            {
                var d = ctx.Departments.Include("Employees.EmployeeDetail").SingleOrDefault(x => x.DepartmentId == departmentId);
                return d?.ToDto();
            }
        }

        public EmployeeDto GetEmployeeById(int id)
        {
            using (var ctx = new EmployeeMgmtDBEntities1())
            {
                var e = ctx.Employees
                    .Include("Department")
                    .Include("EmployeeDetail")
                    .Include("EmployeeProjects.Project")
                    .SingleOrDefault(x => x.EmployeeId == id);
                return e?.ToDto();
            }
        }

        public EmployeeDetailDto GetEmployeeDetail(int employeeId)
        {
            using (var ctx = new EmployeeMgmtDBEntities1())
            {
                var d = ctx.EmployeeDetails.Find(employeeId);
                return d?.ToDto();
            }
        }

        public ProjectDto GetProjectWithEmployees(int projectId)
        {
            using (var ctx = new EmployeeMgmtDBEntities1())
            {
                var p = ctx.Projects.Include("EmployeeProjects.Employee.EmployeeDetail").SingleOrDefault(x => x.ProjectId == projectId);
                return p?.ToDto();
            }
        }

        public bool RemoveEmployeeFromProject(int employeeId, int projectId)
        {
            using (var ctx = new EmployeeMgmtDBEntities1())
            {
                var ep = ctx.EmployeeProjects.Find(employeeId, projectId);
                if (ep == null) return false;
                ctx.EmployeeProjects.Remove(ep);
                ctx.SaveChanges();
                return true;
            }
        }

        public EmployeeDto UpdateEmployee(EmployeeDto dto)
        {
            using (var ctx = new EmployeeMgmtDBEntities1())
            {
                var e = ctx.Employees.Find(dto.EmployeeId);
                if (e == null) return null;
                e.FirstName = dto.FirstName;
                e.LastName = dto.LastName;
                e.Email = dto.Email;
                e.DepartmentId = dto.DepartmentId;
                ctx.SaveChanges();
                return e.ToDto();
            }
        }
    }
}