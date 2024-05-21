// See https://aka.ms/new-console-template for more information
// Xem https://aka.ms/new-console-template để biết thêm thông tin
using Bai_Tap_2;
using OOP2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Khởi tạo danh sách nhân viên
            List<Employee> employees = new List<Employee>
            {
                new Employee("HaBT", "Ha Noi", 50000),
                new Employee("PhongDT", "Da Nang", 70000),
                new Employee("HanhKT", "Ho Chi Minh", 60000)
            };
            // Khởi tạo danh sách khách hàng
            List<Customer> customers = new List<Customer>
            {
                new Customer("HangLT", "Nghe An", 1800),
                new Customer("HongHT", "Ha Tinh", 300)
            };

            // Hiển thị danh sách nhân viên
            Console.WriteLine("Employess: ");
            employees.ForEach(e => e.Display());

            // Hiển thị danh sách khách hàng
            Console.WriteLine("\nCustomers: ");
            customers.ForEach(c => c.Display());

            // Tìm nhân viên có lương cao nhất và hiển thị
            var highestPaidEmployee = FindHighestPaidEmployee(employees);
            Console.WriteLine("\nHighest Paid Employee:");
            highestPaidEmployee.Display();

            // Tìm khách hàng có số dư thấp nhất và hiển thị
            var customerWithLowestBalance = FindCustomerWithLowestBalance(customers);
            Console.WriteLine("\nCustomer with Lowest Balance:");
            customerWithLowestBalance.Display();

            // Tìm nhân viên theo tên và hiển thị kết quả tìm kiếm
            Console.WriteLine("\nEnter employee name to search:");
            string searchName = Console.ReadLine();
            var searchedEmployee = FindEmployeeByName(employees, searchName);
            if (searchedEmployee != null)
            {
                Console.WriteLine("\nFound Employee:");
                searchedEmployee.Display();
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }

            try
            {
                // Thêm nhân viên mới
                Console.WriteLine("\nEnter new employee name:");
                string newName = Console.ReadLine();
                Console.WriteLine("Enter new employee address:");
                string newAddress = Console.ReadLine();
                Console.WriteLine("Enter new employee salary:");
                int newSalary = int.Parse(Console.ReadLine());
                employees.Add(new Employee(newName, newAddress, newSalary));
            }
            catch (FormatException)
            {
                // Xử lý lỗi nhập liệu không hợp lệ
                Console.WriteLine("Invalid input. Please enter a valid number for salary.");
            }
        }

        // Phương thức tìm nhân viên có lương cao nhất
        static Employee FindHighestPaidEmployee(List<Employee> employees) =>
            employees.Count == 0 ? null : employees.OrderByDescending(e => e.Salary).FirstOrDefault();

        // Phương thức tìm khách hàng có số dư thấp nhất
        static Customer FindCustomerWithLowestBalance(List<Customer> customers) =>
            customers.Count == 0 ? null : customers.OrderBy(c => c.Balance).FirstOrDefault();

        // Phương thức tìm nhân viên theo tên
        static Employee FindEmployeeByName(List<Employee> employees, string name) =>
            employees.FirstOrDefault(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}

