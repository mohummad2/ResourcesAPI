using FluentAssertions;
using Moq;
using ResourcesAPI.Data.Models;
using ResourcesAPI.Repositories.Interfaces;
using ResourcesAPI.Services;
using ResourcesAPI.ViewModels;

namespace ResourcesAPI.UnitTests.Services;
public class WorkersServiceTests
{
    private readonly WorkersService _workersService;
    private readonly Mock<IResourcesRepository<Worker>> _resourcesRepository;

    public WorkersServiceTests()
    {
        _resourcesRepository = new Mock<IResourcesRepository<Worker>>();

        _workersService = new WorkersService(_resourcesRepository.Object);
    }

    [Fact]
    public void AddWorker_Fail()
    {
        //Arrange
        var workerViewModel = new WorkerViewModel { };
        _resourcesRepository.Setup(x => x.Add(It.IsAny<Worker>())).Throws(new Exception("Internal Server Error"));

        //Act
        Func<Task> AddWorker = () => _workersService.AddWorker(workerViewModel);

        //Assert
        AddWorker.Should().ThrowAsync<Exception>();
    }

    [Fact]
    public void AddWorker_Pass()
    {
        //Arrange
        var workerViewModel = new WorkerViewModel { };
        _resourcesRepository.Setup(x => x.Add(It.IsAny<Worker>()));

        //Act
        Func<Task> AddWorker = () => _workersService.AddWorker(workerViewModel);

        //Assert
        AddWorker.Should().NotThrowAsync();
    }

    [Fact]
    public void GetAllWorkers_Fail()
    {
        //Arrange
        _resourcesRepository.Setup(x => x.GetAll()).Throws(new Exception("Internal Server Error"));

        //Act
        Func<Task> getWorkers = () => _workersService.GetAllWorkers();

        //Assert
        getWorkers.Should().ThrowAsync<Exception>();
    }

    [Fact]
    public void GetAllWorkers_Pass()
    {
        //Arrange
        var data = new List<Worker>() { new Worker { Id = 1 } }.AsQueryable();

        _resourcesRepository.Setup(x => x.GetAll()).ReturnsAsync(data);

        //Act
        var workers = _workersService.GetAllWorkers().Result;

        //Assert
        _resourcesRepository.Verify(x => x.GetAll(), Times.Once());
        workers.Should().HaveCount(1);
    }

}
