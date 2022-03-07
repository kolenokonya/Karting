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

namespace Karting
{
    /// <summary>
    /// Логика взаимодействия для MenuAdmin.xaml
    /// </summary>
    public partial class MenuAdmin : Window
    {
        public string email;
        public MenuAdmin(string email)
        {
            this.email = email;
            InitializeComponent();
            timeToEnd.StartTimerOnCurrentWindow(currentTime, ToEnd);
        }

        private void BlagOrganizacii_Click(object sender, RoutedEventArgs e)
        {
            CharityManage upravleniye = new CharityManage(email);
            upravleniye.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            upravleniye.Show();
            this.Close();
        }

        private void Volonteri_Click(object sender, RoutedEventArgs e)
        {
            VolonteerManage vl = new VolonteerManage();
            vl.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            vl.Show();
            this.Close();
        }

        private void btn_return_menu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            mainwindow.Show();
            this.Close();
        }

        private void Polzovateli_Click(object sender, RoutedEventArgs e)
        {
            UserManage upravleniye = new UserManage(email);
            upravleniye.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            upravleniye.Show();
            this.Close();
        }

        private void Inventar_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
