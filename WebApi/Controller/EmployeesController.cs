using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller;
[ApiController]
[Route("controller")]

public class EmployeesController
{
    private readonly EmployeesService _employeesService;

    public EmployeesController()
    {
        _employeesService = new EmployeesService();
    }

    [HttpGet("get-all-employees")]
    public List<Employees> GetEmployees()
    {
        return _employeesService.GetEmployees();
    }

    [HttpPost("add-employee")]
    public void AddEmployee([FromForm] Employees employees)
    {
        _employeesService.AddEmployees(employees);
    }

    [HttpPut("update-employee")]
    public void UpdateEmployee([FromForm]Employees employees)
    {
        _employeesService.UpdateEmployee(employees);
    }

    [HttpDelete("delete-employee")]
    public void DeleteEmployee(int id)
    {
        _employeesService.DeleteEmployees(id);
    }
}