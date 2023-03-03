using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    public partial class EmployeeViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Employee> employees = new();

        [ObservableProperty]
        private Employee selectedEmployee;

        public EmployeeViewModel()
        {
            // todo: refactor using behavior
            InitAsync().GetAwaiter().GetResult();
        }

        [RelayCommand]
        private void AddEmployee()
        {

        }

        [RelayCommand]
        private async Task SaveEmployeeAsync()
        {

        }

        [RelayCommand]
        private async Task ViewEmployeeAsync(int id)
        {

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
