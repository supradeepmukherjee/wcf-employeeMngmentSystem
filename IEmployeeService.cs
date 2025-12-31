using Learn.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Learn
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract] List<DepartmentDto> GetAllDepartments();
        [OperationContract] DepartmentDto GetDepartmentById(int id);
        [OperationContract] DepartmentDto CreateDepartment(DepartmentDto dto);
        [OperationContract] DepartmentDto UpdateDepartment(DepartmentDto dto);
        [OperationContract] bool DeleteDepartment(int id);

        [OperationContract] List<EmployeeDto> GetAllEmployees();
        [OperationContract] List<EmployeeDto> GetEmployeesByDepartmentId(int departmentId);
        [OperationContract] EmployeeDto GetEmployeeById(int id);
        [OperationContract] EmployeeDto CreateEmployee(EmployeeDto dto);
        [OperationContract] EmployeeDto UpdateEmployee(EmployeeDto dto);
        [OperationContract] bool DeleteEmployee(int id);

        [OperationContract] EmployeeDetailDto GetEmployeeDetail(int employeeId);
        [OperationContract] EmployeeDetailDto CreateOrUpdateEmployeeDetail(EmployeeDetailDto dto);

        [OperationContract] List<ProjectDto> GetAllProjects();
        [OperationContract] ProjectDto GetProjectById(int id);
        [OperationContract] ProjectDto CreateProject(ProjectDto dto);
        [OperationContract] ProjectDto UpdateProject(ProjectDto dto);
        [OperationContract] bool DeleteProject(int id);
        [OperationContract] bool AssignEmployeeToProject(int employeeId, int projectId);
        [OperationContract] bool RemoveEmployeeFromProject(int employeeId, int projectId);

        [OperationContract] DepartmentDto GetDepartmentWithEmployees(int departmentId);
        [OperationContract] ProjectDto GetProjectWithEmployees(int projectId);
        [OperationContract] List<ProjectDto> GetProjectsForEmployee(int employeeId);
    }
}
