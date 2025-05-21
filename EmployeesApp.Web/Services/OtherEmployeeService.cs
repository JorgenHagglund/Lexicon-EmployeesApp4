using EmployeesApp.Web.Models;

namespace EmployeesApp.Web.Services
{
    public class OtherEmployeeService : IEmployeeService
    {
        readonly List<Employee> employees =
        [
            new Employee()
            {
                Id = 1,
                Name = "Kalle Karlsson",
                Email = "KalleK@outlook.com",
            },
            new Employee()
            {
                Id = 5,
                Name = "Amanda Lantz",
                Email = "AmandaL@outlook.com",
            },
            new Employee()
            {
                Id = 15662,
                Name = "Kim Widencrantz",
                Email = "KimW@outlook.com",
            },
        ];

        public void Add(Employee employee)
        {
            employee.Id = employees.Count < 0 ? 1 : employees.Max(e => e.Id) + 1;
            employees.Add(employee);
        }

        public Employee[] GetAll() => [.. employees.OrderBy(e => e.Name)];

        public Employee GetById(int id) => employees
            .Single(e => e.Id == id);

        public bool CheckIsVIP(Employee employee) =>
            employee.Email.StartsWith("ADMIN", StringComparison.CurrentCultureIgnoreCase);
    }
}

