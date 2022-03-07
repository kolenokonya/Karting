using Karting.KartingDataSetTableAdapters;
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
    /// Логика взаимодействия для VolonteerManage.xaml
    /// </summary>
    public partial class VolonteerManage : Window
    {
        public string email;
        public VolonteerManage()
        {
            InitializeComponent();
            timeToEnd.StartTimerOnCurrentWindow(currentTime, ToEnd);

            VolunteerTableAdapter adapter = new VolunteerTableAdapter();
            KartingDataSet.VolunteerDataTable table = new KartingDataSet.VolunteerDataTable();
            adapter.Fill(table);
            volonterr.ItemsSource = table;
            int t = volonterr.Items.Count;
            kolvo.Content = t;
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            mainwindow.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoadVolonteers zagruzka = new LoadVolonteers();
            zagruzka.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            zagruzka.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MenuAdmin menuAdministratora = new MenuAdmin(email);
            menuAdministratora.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            menuAdministratora.Show();
            this.Close();
        }
    }
}
