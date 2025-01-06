using EMS.Infrastructure.Presistence.Context;
using EMS.Service.EMS.Implementations.Business;
using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class DepartmentServiceTests
{
    private readonly AppDbContext appDbContextMock;
    private readonly IConfiguration configurationMock;
    private readonly DepartmentService departmentService;

    public DepartmentServiceTests()
    {
        // you must fake option for to be can declare fake instance from context;
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("TestDatabase")
            .Options;

        this.appDbContextMock = new AppDbContext(options);
        this.configurationMock = A.Fake<IConfiguration>();

        this.departmentService = new DepartmentService(appDbContextMock, configurationMock);
    }

    [Fact]
    public async Task GetDepartmentCourses_ThrowArgumentNullException_WhenIdNegative()
    {
        int id = -10;
        Func<Task> func = async () => await departmentService.GetDepartmentCourses(id);
        await Assert.ThrowsAsync<ArgumentNullException>(func);
    }

    [Fact]
    public async Task GetDepartmentStudents_ThrwoArgumentNullException_WhenNegativeOrNullId()
    {
        int id = -1;
        Func<Task> func = async () => await departmentService.GetDepartmentStudents(id);
        await Assert.ThrowsAsync<ArgumentNullException>(func);
    }

    [Fact]
    public async Task GetDepartmentInstractors_ThrowArgementNullException_WhenNegativeOrNullId()
    {
        int id = 0;
        Func<Task> func = async () => await departmentService.GetDepartmentInstructor(id);
        await Assert.ThrowsAsync<ArgumentNullException>(func);
    }
}