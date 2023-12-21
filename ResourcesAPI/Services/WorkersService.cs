using ResourcesAPI.Data.Models;
using ResourcesAPI.Services.Interfaces;
using ResourcesAPI.ViewModels;
using ResourcesAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ResourcesAPI.Services;
public class WorkersService : IWorkersService
{
    private readonly IResourcesRepository<Worker> _workersRepository;
    private readonly IResourcesRepository<Designation> _designation;
    //private readonly IResourcesRepository<Worker> _workersRepository;
    //private readonly IResourcesRepository<Worker> _workersRepository;
    public WorkersService(IResourcesRepository<Worker> workersRepository)
    {
        _workersRepository = workersRepository;
    }
    
    public async Task AddWorker(WorkerViewModel workerViewModel)
    {
        var worker = new Worker()
        {
            FirstName = workerViewModel.FirstName,
            LastName = workerViewModel.LastName,
            Address1 = workerViewModel.Address1,
            DesignationId = workerViewModel.DesignationId,
            IsActive = true,
            DateCreated = DateTime.Now,
            DateModified = DateTime.Now,
            Compensation = new Compensation()
            {
                Amount = workerViewModel.CompensationAmount,
                MaxExpenseAllowed = workerViewModel.MaxExpenseAllowed
            }
        };

        try
        {
            await _workersRepository.Add(worker);
            await _workersRepository.SaveChanges();
        }
        catch (Exception ex) 
        {
            var msg = ex.ToString();
        }
    }

    public async Task<List<Worker>> GetAllWorkers()
    {
        var workers = (await _workersRepository.GetAll()).Include(x => x.Compensation).Include(x => x.Designation).ThenInclude(x => x.WageType).ToList();
        return workers;
    }
}
