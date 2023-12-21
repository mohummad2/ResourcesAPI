namespace ResourcesAPI.Data.Models;
public class Worker
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address1 { get; set; }
    public int DesignationId { get; set; }
    public bool IsActive { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
    public virtual Designation? Designation { get; set; }
    public virtual Compensation? Compensation { get; set; }
}
