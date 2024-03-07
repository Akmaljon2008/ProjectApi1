using Dapper;
using Infrastructure.DataContext;
using Domain.Models;

namespace Infrastructure.Services;

public class DeprtmentService
{   
    private readonly DapperContext _db;

    public DeprtmentService()
    {
        _db = new DapperContext();
    }

    public List<Department> GetDepartment()
    {
        var sql = "select * from Department";
        return _db.Connection().Query<Department>(sql).ToList();
    }

    public void AddDepartment(Department department)
    {
        var sql =
            "insert into Department(DepartmentName)values(@DepartmentName)";
        _db.Connection().Execute(sql, department);
    }

    public void UpdateDepartment(Department department)
    {
        var sql = "update Department set DepartmentName = @DepartmentName where id = @id";
        _db.Connection().Execute(sql, department);
    }

    public void DeleteDepartment(int id)
    {
        var sql = "delete from Department where id = @id";
        _db.Connection().Execute(sql, new { ID = id });
    }

    public List<Employees> GetByDepartmentId(int id)
    {
        var sql = "select * from employees where departmentid = @id";
        return _db.Connection().Query<Employees>(sql, new { Id = id }).ToList();
    }

}