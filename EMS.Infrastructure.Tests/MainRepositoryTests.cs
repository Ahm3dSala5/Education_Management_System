using EMS.Infrastructure.Presistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using FakeItEasy;
using EMS.Infrastructure.Repositories;
using EMS.Infrastructure.Domain.Entities;
namespace EMS.Infrastructure.Tests
{
    // you must create testCase for each Entity Becuse you cannnot use test  With Genaric type
    public class MainRepositoryTests
    {
        private AppDbContext _app;
        private IConfiguration _config;
        private readonly MainRepository <Student>_repo;
        public MainRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
             .UseInMemoryDatabase("TestDatabase")
             .Options;
            _app = new AppDbContext(options);
            _config = A.Fake<IConfiguration>();
            _repo = new MainRepository<Student>(_app,_config);
        }

        [Fact]
        public async Task Create_ThrowArgumentNullException_WhenEntityIsNull()
        {
            Student entity = null;
            Func<Task> func = async () => await _repo.Create(entity);
            await Assert.ThrowsAsync<ArgumentNullException>(func);
        }

        [Fact]
        public async Task Create_ReturnsCreated_WhenValidStudentData()
        {
            var student = new Student() 
            { 
                FirstName = "Alyaa" 
                ,LastName = "S"
                ,Address = "a"
                ,Level = 1
                ,GPA =3
                ,DepartmentId =1
                ,Age =11
            };

            var actual = await _repo.Create(student);
            var expected = "Created";
            Assert.Equal(actual,expected);
        }

    }
}