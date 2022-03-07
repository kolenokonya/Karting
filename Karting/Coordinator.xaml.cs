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
    /// Логика взаимодействия для Coordinator.xaml
    /// </summary>
    public partial class Coordinator : Window
    {
        public string email;
        public Coordinator(string email)
        {
            InitializeComponent();
            this.email = email;
            //timeToEnd.StartTimerOnCurrentWindow(currentTime, ToEnd);
        }


        private void btn_return_menu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            mainwindow.Show();
            this.Close();
        }

        private void Gonshiki_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Sponsori_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
