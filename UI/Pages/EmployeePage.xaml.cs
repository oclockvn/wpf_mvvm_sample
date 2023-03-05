using Core.ViewModels;
using System.Windows.Controls;

namespace UI.Pages
{
    /// <summary>
    /// Interaction logic for EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        public EmployeePage(EmployeeViewModel vm)
        {
            DataContext = vm;
            InitializeComponent();
        }
    }
}
