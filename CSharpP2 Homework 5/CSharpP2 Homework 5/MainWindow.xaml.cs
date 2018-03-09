using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSharpP2_Homework_5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Employee> employees = new ObservableCollection<Employee>();        ObservableCollection<Department> departments = new ObservableCollection<Department>();

        public MainWindow()
        {
            InitializeComponent();
            FillEmployeeList();
            FillDepartments();
        }

        void FillEmployeeList()
        {
            employees.Add(new Employee("Иванов", "Иван", "Иванович"));
            employees.Add(new Employee("Петров", "Василий", "Андреевич"));
            spEmployee.ItemsSource = employees;
        }

        void FillDepartments()
        {
            departments.Add(new Department("Бухгалтерия"));
            departments.Add(new Department("Маркетинг"));

            Department dep = departments.Select(x => x.Name == "Маркетинг") as Department;
            //dep.Add((employees.Select(x => x.ID == 1) as Employee ).ID);
        }

        private void btnAddEmployee(object sender, RoutedEventArgs e)
        {
        }

        private void OnAddEmpDialogClosing(object sender, DialogClosingEventArgs eventArgs)
        {
            Console.WriteLine("SAMPLE 1: Closing dialog with parameter: " + (eventArgs.Parameter ?? ""));

            //you can cancel the dialog close:
            //eventArgs.Cancel();

            if (!Equals(eventArgs.Parameter, true)) return;

            employees.Add(new Employee(tbEmpSurname.Text, tbEmpName.Text, tbEmpPatronimyc.Text));
        }
    }
}
