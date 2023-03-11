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

        public EmployeeViewModel()
        {

        }

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

        [ObservableProperty]
        private Employee uiSelectedItem;

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
            await Task.CompletedTask;
        }

        [RelayCommand]
        private async Task ViewSelected()
        {
            if (UiSelectedItem != null)
                await ViewEmployeeAsync(UiSelectedItem.Id);
        }

        [RelayCommand]
        private async Task InitAsync()
        {
            var list = await employeeService.GetEmployeesAsync();
            Employees = new ObservableCollection<Employee>(list);
        }
    }
}
