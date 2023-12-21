using Microsoft.AspNetCore.Mvc;
using ResourcesAPI.Services.Interfaces;
using ResourcesAPI.ViewModels;

namespace ResourcesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WorkersController : ControllerBase
{
    private readonly ILogger<WorkersController> _logger;
    private readonly IWorkersService _workersService;

    public WorkersController(ILogger<WorkersController> logger, IWorkersService workersService)
    {
        _logger = logger;
        _workersService = workersService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var workers = await _workersService.GetAllWorkers();
        return Ok(workers);
    }

    [HttpPost]
    public async Task<IActionResult> Add(WorkerViewModel workerViewModel)
    {
        await _workersService.AddWorker(workerViewModel);
        return Ok();
    }
}
