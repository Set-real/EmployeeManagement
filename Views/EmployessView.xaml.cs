using EmployeeManagement.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EmployeeManagement.Views
{
    /// <summary>
    /// Логика взаимодействия для EmployessView.xaml
    /// </summary>
    public partial class EmployessView : Window
    {
        public EmployessView()
        {
            InitializeComponent();
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListView_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;

            if (item is null )
            {
                return;
            }

            var employee = item as Employee;

            MessageBox.Show($"{employee.FirstName} {employee.LastName} Возраст: {employee.Age} Компания: {employee.CompanyName} " +
                $"Должность: {employee.Position} Город: {employee.CityName}");
            
        }
    }
}
