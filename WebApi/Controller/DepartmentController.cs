using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Infrastructure.Services;
namespace WebApi.Controller;
[ApiController]
[Route("controller")]
public class DepartmentController
{
    private readonly DeprtmentService _departmentService;

    public DepartmentController()
    {
        _departmentService = new DeprtmentService();
    }

    [HttpGet("get-all-Department")]
    public List<Department> GetDepartment()
    {
        return _departmentService.GetDepartment();
    }

    [HttpPost("add-Department")]
    public void AddDepartment([FromForm] Department department)
    {
        _departmentService.AddDepartment(department);
    }

    [HttpPut("update-Department")]
    public void UpdateDepartment([FromForm]Department department)
    {
        _departmentService.UpdateDepartment(department);
    }

    [HttpDelete("delete-Department")]
    public void DeleteDepartment(int id)
    {
        _departmentService.DeleteDepartment(id);
    }

    [HttpGet("get-employees-by-department-id")]
    public List<Employees> GetByDepartmentId(int id)
    {
        return _departmentService.GetByDepartmentId(id);
    }
}