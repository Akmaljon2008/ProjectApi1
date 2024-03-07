using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller;
using Domain.Models;
using Infrastructure.Services;
[ApiController]
[Route("controller")]
public class SalariesController
{
    private readonly SalariesService _salaryService;

    public SalariesController()
    {
        _salaryService = new SalariesService();
    }

    [HttpGet("get-all-salaries")]
    public List<Salaries> GetSalaries()
    {
        return _salaryService.GetSalaries();
    }

    [HttpPost("add-salary")]
    public void AddSalaries([FromForm] Salaries Salaries)
    {
        _salaryService.AddSalaries(Salaries);
    }

    [HttpPut("update-salary")]
    public void UpdateSalary([FromForm]Salaries Salaries)
    {
        _salaryService.UpdateSalary(Salaries);
    }

    [HttpDelete("delete-salary")]
    public void DeleteSalary(int id)
    {
        _salaryService.DeleteSalaries(id);
    }

    [HttpGet("get-avg")]
    public List<EmployeesSalary> GetSumOfSalaries(DateTime date)
    {
        return _salaryService.GetSumOfSalaries(date);
    }

    [HttpGet("get-employee-with-bigger-salary-salaries")]
    public List<EmployeesSalary> GetEmployeeWithBigSalary(decimal amount)
    {
        return _salaryService.GetEmployeeWithBigSalary(amount);
    }

    [HttpGet("get-avg-department")]
    public List<EmployeesSalary> GetAvgByDepartment(int id)
    {
        return _salaryService.GetAvgByDepartment(id);
    }
}