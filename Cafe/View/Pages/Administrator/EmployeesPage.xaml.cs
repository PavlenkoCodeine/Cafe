using Cafe.Model;
using System;
using System.Collections.Generic;
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

namespace Cafe.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        // Создаем программный список и заполняем его данными
        List<Employee> employees = App.context.Employee.ToList();   
        public EmployeesPage()
        {
            InitializeComponent();
            //передаем в качестве источника данных (ItemsSource) данные из программного списка в ListView
            EmployeesLv.ItemsSource = employees;
        }

        private void SearchTb_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void SearchTb_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void FilterByRoleCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddNewEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EmployeesLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EmployeeGrid.DataContext = EmployeesLv.SelectedItem as Employee;

            RoleCmb.ItemsSource = App.context.Role.ToList();
            RoleCmb.DisplayMemberPath = "Name";
            RoleCmb.SelectedValuePath = "ID";
            //Влияет на поиск. Выдает исключение типа NullReferenceException.
            //Если при поиске выбранный пользователь пропадает из списка, то нужно установить индекс на -1 (убрать выбор) из выпадающего списка.
            RoleCmb.SelectedIndex = EmployeesLv.SelectedItem as Employee != null ? (EmployeesLv.SelectedItem as Employee).RoleId - 1 : -1;
        }

        private void SaveEmployeeBth_Click(object sender, RoutedEventArgs e)
        {
            // Подхватываем изменения в роль из выпадающего списка.
            (EmployeesLv.SelectedItem as Employee).RoleId = Convert.ToInt32(RoleCmb.SelectedValue);
            App.context.SaveChanges();
            EmployeesLv.ItemsSource = employees = App.context.Employee.ToList();
            MessageBox.Show("Данные пользователя изменены!");
        }
    }
}
