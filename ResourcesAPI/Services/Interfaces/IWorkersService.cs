using ResourcesAPI.Data.Models;
using ResourcesAPI.ViewModels;

namespace ResourcesAPI.Services.Interfaces
{
    public interface IWorkersService
    {
        Task AddWorker(WorkerViewModel workerViewModel);
        Task<List<Worker>> GetAllWorkers();
    }
}
