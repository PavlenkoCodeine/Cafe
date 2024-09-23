using Cafe.View.Pages;
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
using System.Windows.Shapes;

namespace Cafe.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdministratorWindow.xaml
    /// </summary>
    public partial class AdministratorWindow : Window
    {
        public AdministratorWindow()
        {
            InitializeComponent();
        }

        private void EmployeeListBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.Navigate(new EmployeesPage());
        }

        private void OrderListBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.Navigate(new OrdersPage());
        }

        private void ShiftListBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.Navigate(new ShiftsPage());
        }
    }
}
