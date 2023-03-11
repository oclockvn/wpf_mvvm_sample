using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Core.Models;
using Core.Services;
using System.Collections.ObjectModel;

namespace Core.ViewModels
{
    public partial class EmployeeViewModel : ObservableObject
    {
        private readonly IEmployeeService employeeService;

        public EmployeeViewModel(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [ObservableProperty]
        private ObservableCollection<Employee> _employees = new();

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HasSelectedEmployee))]
        private Employee _selectedEmployee;

        public bool HasSelectedEmployee => SelectedEmployee != null;

        //public EmployeeViewModel()
        //{
        //    // todo: refactor using behavior
        //    InitAsync().GetAwaiter().GetResult();
        //}

        [RelayCommand]
        private void AddEmployee()
        {
            SelectedEmployee = new();
        }

        [RelayCommand]
        private async Task SaveEmployeeAsync()
        {
            if (SelectedEmployee.Id == 0)
            {
                // todo: call service
                SelectedEmployee.Id = Employees.Count + 1;
                Employees.Add(SelectedEmployee);
            }
            else
            {
                // todo: call service
                var updatingEmplyee = Employees.Single(e => e.Id == SelectedEmployee.Id);
                updatingEmplyee.Update(SelectedEmployee);
            }
        }

        [RelayCommand]
        private async Task ViewEmployeeAsync(int id)
        {
            SelectedEmployee = new Employee(Employees.Single(e => e.Id == id));
        }

        [RelayCommand]
        private async Task InitAsync()
        {
            for (int i = 0; i < 10; i++)
            {
                Employees.Add(new Employee
                {
                    Id = i,
                    FirstName = "First " + i,
                    LastName = "Last " + i,
                    Email = $"first_last_{i}@example.com",
                    IsRemote = i % 2 == 0,
                    Phone = "01234568" + i,
                    Gender = i % 2 == 0 ? "Male" : "Female",
                });
            }
        }
    }
}
