namespace ResourcesAPI.Data.Models;
public class Designation
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int WageTypeId { get; set; }
    public bool IsActive { get; set; }
    public virtual WageType? WageType { get; set; }
}
