using Dapper;
using Infrastructure.DataContext;
using Domain.Models;

namespace Infrastructure.Services;

public class SalariesService
{
    private readonly DapperContext _db;

    public SalariesService()
    {
        _db = new DapperContext();
    }

    public List<Salaries> GetSalaries()
    {
        var sql = "select * from salaries";
        return _db.Connection().Query<Salaries>(sql).ToList();
    }

    public void AddSalaries(Salaries Salaries)
    {
        var sql =
            "insert into Salaries(EmployeeId,Amount,Date)values (@EmployeeId,@Amount,@Date)";
        _db.Connection().Execute(sql, Salaries);
    }

    public void UpdateSalary(Salaries Salaries)
    {
        var sql = "update Salaries set EmployeeId = @EmployeeId,Amount = @Amount,Date = @Date where id = @id";
        _db.Connection().Execute(sql, Salaries);
    }

    public void DeleteSalaries(int id)
    {
        var sql = "delete from Salaries where id = @id";
        _db.Connection().Execute(sql, new { ID = id });
    }

    public List<EmployeesSalary> GetAvgByDepartment(int id)
    {
        var sql =
            "select avg(s.amount) from Salaries as s join employees as e on s.employeeId = e.id where e.departmentid= @id";
        return _db.Connection().Query<EmployeesSalary>(sql, new { Id = id }).ToList();
    }
    public List<EmployeesSalary> GetSumOfSalaries(DateTime date)
    {
        var sql = "select e.FirstName,e.LastName, sum(s.amount) from Salaries as s join Employees as e on s.employeeid = e.id where s.Date == @date";
        return _db.Connection().Query<EmployeesSalary>(sql,new{ Date = date.Month}).ToList();
    }

    public List<EmployeesSalary> GetEmployeeWithBigSalary(decimal amount)
    {
        var sql =
            "select e.FirstName , e.Lastname,s.Amount from Salaries as s join Employees as e on s.Employeeid = e.Id where s.Amount > @amount";
        return _db.Connection().Query<EmployeesSalary>(sql, new { Amount = amount }).ToList();
    }
}