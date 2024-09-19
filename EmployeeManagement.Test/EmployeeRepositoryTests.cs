using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Data;
using EmployeeManagement.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Test
{
    public class EmployeeRepositoryTests
    {
        private ApplicationDbContext _context;
        private EmployeeRepository _repository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "EmployeeTestDB")
                .Options;

            _context = new ApplicationDbContext(options);
            _repository = new EmployeeRepository(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public async Task AddEmployeeAsync_ShouldAddEmployee()
        {
            var employee = new Employee { Name = "Ali Ali", Department = "IT", Salary = 3000 };

            var result = await _repository.AddEmployeeAsync(employee);

            Assert.NotNull(result);
            Assert.AreEqual("Ali Ali", result.Name);
            Assert.AreEqual(1, await _context.Employees.CountAsync());
        }

        [Test]
        public async Task GetAllEmployeesAsync_ShouldReturnAllEmployees()
        {
            await _repository.AddEmployeeAsync(new Employee { Name = "Ali Ali", Department = "IT", Salary = 3000 });
            await _repository.AddEmployeeAsync(new Employee { Name = "Hossam Ali", Department = "HR", Salary = 4000 });

            var employees = await _repository.GetAllEmployeesAsync();

            Assert.AreEqual(2, employees.Count());
        }

        [Test]
        public async Task GetEmployeeByIdAsync_ShouldReturnEmployee()
        {
            var employee = await _repository.AddEmployeeAsync(new Employee { Name = "Ali Ali", Department = "IT", Salary = 3000 });

            var result = await _repository.GetEmployeeByIdAsync(employee.EmployeeID);

            Assert.NotNull(result);
            Assert.AreEqual("Ali Ali", result.Name);
        }

        [Test]
        public async Task UpdateEmployeeAsync_ShouldUpdateEmployee()
        {
            var employee = await _repository.AddEmployeeAsync(new Employee { Name = "Ali Ali", Department = "IT", Salary = 3000 });
            employee.Name = "Ali Updated";

            var result = await _repository.UpdateEmployeeAsync(employee);

            Assert.NotNull(result);
            Assert.AreEqual("Ali Updated", result.Name);
        }

        [Test]
        public async Task DeleteEmployeeAsync_ShouldRemoveEmployee()
        {
            var employee = await _repository.AddEmployeeAsync(new Employee { Name = "Ali Ali", Department = "IT", Salary = 3000 });

            await _repository.DeleteEmployeeAsync(employee.EmployeeID);

            Assert.AreEqual(0, await _context.Employees.CountAsync());
        }
    }
}