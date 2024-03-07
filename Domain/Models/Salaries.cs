namespace Domain.Models;

public class Salaries
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
}