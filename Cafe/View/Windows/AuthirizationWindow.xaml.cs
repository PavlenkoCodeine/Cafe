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
using System.Windows.Shapes;

namespace Cafe.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthirizationWindow.xaml
    /// </summary>
    public partial class AuthirizationWindow : Window
    {
        public AuthirizationWindow()
        {
            InitializeComponent();

            // Заполняем поля для входа сохранёнными данными 
            LoginTb.Text = Properties.Settings.Default.LoginValue;
            PasswordPb.Password = Properties.Settings.Default.PasswordValue;
            RememberMeCb.IsChecked = Properties.Settings.Default.CheckValue;
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LoginTb.Text) && string.IsNullOrEmpty(PasswordPb.Password))
            {
                MessageBox.Show("Введите логин и пароль!");
            }
            else if (string.IsNullOrEmpty(LoginTb.Text) || string.IsNullOrEmpty(PasswordPb.Password))
            {
                MessageBox.Show("Введите логин и пароль!");
            }
            else
            {
                // Проверка данных, поиск пользователя в таблице БД
                Employee newEmployee = App.context.Employee.FirstOrDefault(employee => employee.Login
                == LoginTb.Text && employee.Password == PasswordPb.Password);
                if (newEmployee != null)
                {
                    // Запоминаем данные пользователя
                    if (RememberMeCb.IsChecked ==true)
                    {
                        Properties.Settings.Default.LoginValue = LoginTb.Text;
                        Properties.Settings.Default.PasswordValue = PasswordPb.Password;
                        Properties.Settings.Default.CheckValue = true;

                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        // Присваем значение по умолчанию
                        Properties.Settings.Default.Reset();
                    }
                    switch (newEmployee.RoleId)
                    {
                        case 1:
                            //Открываем страницу администратора
                            AdministratorWindow administratorWindow = new AdministratorWindow();
                            administratorWindow.Show();
                            break;
                        case 2:
                            //Открываем страницу официанта
                            WaiterWindow waiterWindow = new WaiterWindow();
                            waiterWindow.Show();
                            break;
                        case 3:
                            //Открываем страницу повара
                            CookWindow cookWindow = new CookWindow();
                            cookWindow.Show();
                            break;
                    }
                    Close();
                }
                else
                {
                    MessageBox.Show("Пользователь не найден!");
                }
            }
        }
    }
}
