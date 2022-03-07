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
using System.Windows.Threading;

namespace Karting
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            timeToEnd.StartTimerOnCurrentWindow(currentTime,ToEnd);

        }

        private void RegRacer_Click(object sender, RoutedEventArgs e)
        {
            RegRacer regist = new RegRacer();
            regist.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            regist.Show();
            this.Close();
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            LogIn login = new LogIn();
            login.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            login.Show();
            this.Close();
        }
        private void RegSpon_Click(object sender, RoutedEventArgs e)
        {
            RegSponsor regSponsor = new RegSponsor();
            regSponsor.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            regSponsor.Show();
            this.Close();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            AllInfo login = new AllInfo();
            login.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            login.Show();
            this.Close();
        }
    }
}
