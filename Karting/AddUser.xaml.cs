using Karting.KartingDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Karting
{
    /// <summary>
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        public string email;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserManage upravleniyePolzovatelyami = new UserManage(email);
            upravleniyePolzovatelyami.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            upravleniyePolzovatelyami.Show();
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (passwd.Text.Trim() != "" && passwd2.Text.Trim() != "" && imya.Text.Trim() != "" && fam.Text.Trim() != "" && pochta.Text.Trim() != "")
                {
                    if (Regex.IsMatch(pochta.Text, @"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$"))
                    {
                        if (Regex.IsMatch(passwd.Text, @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,}$"))
                        {
                            if (passwd.Text == passwd2.Text)
                            {
                                char roll = 'R';
                                if (rol.Text == "Racer") roll = 'R';
                                else if (rol.Text == "Coordinator") roll = 'C';
                                else if (rol.Text == "Administrator") roll = 'A';
                                new UserTableAdapter().InsertQuery(pochta.Text, passwd.Text, imya.Text, fam.Text, roll.ToString());

                                UserManage upravleniyePolzovatelyami = new UserManage(email);
                                upravleniyePolzovatelyami.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                                upravleniyePolzovatelyami.Show();
                                this.Close();
                            }
                            else MessageBox.Show("Пароли не совпадают!");
                        }
                        else MessageBox.Show("Пароль должен соответствовать следующим требованиям: минимум 6 символов, 1 прописная буква, минимум 1 цифра, по крайней мере один спец.символ!");
                    }
                    else MessageBox.Show("Введите корректную почту!");
                }
                else MessageBox.Show("Заполните пожалуйста все поля!");
            }
            catch
            {
                MessageBox.Show("Данный email уже используется!");
            }
        }

        private void btn_return_menu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            mainwindow.Show();
            this.Close();
        }

        public AddUser(string email)
        {
            this.email = email;
            InitializeComponent();
            timeToEnd.StartTimerOnCurrentWindow(currentTime, ToEnd);

            RoleTableAdapter adapt1 = new RoleTableAdapter();
            KartingDataSet.RoleDataTable table1 = new KartingDataSet.RoleDataTable();
            adapt1.Fill(table1);
            rol.ItemsSource = table1;
            rol.DisplayMemberPath = "Role_Name";
            rol.SelectedValuePath = "ID_Role";
        }
    }
}
