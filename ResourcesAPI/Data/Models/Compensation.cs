namespace ResourcesAPI.Data.Models;
public class Compensation
{
    public int Id { get; set; }
    public int WorkerId { get; set; }
    public decimal Amount { get; set; }
    public decimal MaxExpenseAllowed { get; set; }
}
