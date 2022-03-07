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
    /// Логика взаимодействия для RegRacer.xaml
    /// </summary>
    public partial class RegRacer : Window
    {
        public RegRacer()
        {
            InitializeComponent();
            timeToEnd.StartTimerOnCurrentWindow(currentTime, ToEnd);
        }
        private void exit_Click(object sender, RoutedEventArgs e)
        {

            MainWindow mainwindow = new MainWindow();
            mainwindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            mainwindow.Show();
            this.Close();
        }

        private void yes_Click(object sender, RoutedEventArgs e)
        {
            LogIn vhod = new LogIn();
            vhod.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            vhod.Show();
            this.Close();
        }

        private void no_Click(object sender, RoutedEventArgs e)
        {
            RegRacerMenu menu = new RegRacerMenu();
            menu.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            menu.Show();
            this.Close();
        }
    }
}
