using Dapper;
using Infrastructure.DataContext;
using Domain.Models;
namespace Infrastructure.Services;

public class EmployeesService
{
    private readonly DapperContext _db;

    public EmployeesService()
    {
        _db = new DapperContext();
    }

    public List<Employees> GetEmployees()
    {
        var sql = "select * from employees";
        return _db.Connection().Query<Employees>(sql).ToList();
    }

    public void AddEmployees(Employees employees)
    {
        var sql =
            "insert into Employees(FirstName,LastName,DepartmentId,Position,HireDate)values(@FirstName,@LastName,@DepartmentId,@Position,@HireDate)";
        _db.Connection().Execute(sql, employees);
    }

    public void UpdateEmployee(Employees employees)
    {
        var sql = "update Employees set FirstName = @FirstName,LastName = @lastName,DepartmentId = @DepartmentId,Position = @Position,HireDate = @HireDate where u=id = @id";
        _db.Connection().Execute(sql, employees);
    }

    public void DeleteEmployees(int id)
    {
        var sql = "delete from Employees where id = @id";
        _db.Connection().Execute(sql, new { ID = id });
    }
    
    
    
}