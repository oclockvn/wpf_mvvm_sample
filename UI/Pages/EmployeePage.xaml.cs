using Core.ViewModels;
using System.Windows.Controls;

namespace UI.Pages
{
    /// <summary>
    /// Interaction logic for EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        EmployeeViewModel vm = new();

        public EmployeePage()
        {
            DataContext = vm;
            InitializeComponent();
        }
    }
}
