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
    /// Логика взаимодействия для RacerMenu.xaml
    /// </summary>
    public partial class RacerMenu : Window
    {
        public string email;
        public RacerMenu(string email)
        {
            this.email = email;
            InitializeComponent();
            timeToEnd.StartTimerOnCurrentWindow(currentTime, ToEnd);
        }

        private void btn_return_menu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            mainwindow.Show();
            this.Hide();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            EditRacer edit = new EditRacer(email);
            edit.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            edit.Show();
            this.Hide();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Results myRezult = new Results(email);
            myRezult.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            myRezult.Show();
            this.Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Contacts contact = new Contacts();
            contact.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            contact.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RegOnRace naGonku = new RegOnRace(email);
            naGonku.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            naGonku.Show();
            this.Hide();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }
    }
}
