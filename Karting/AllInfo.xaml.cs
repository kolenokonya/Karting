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
    /// Логика взаимодействия для AllInfo.xaml
    /// </summary>
    public partial class AllInfo : Window
    {
        public AllInfo()
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

        private void btn_kart_skills_Click(object sender, RoutedEventArgs e)
        {
            Map karta = new Map();
            karta.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            karta.Show();
            this.Close();
        }
        private void btn_spisok_blag_org_Click(object sender, RoutedEventArgs e)
        {
            CharityOrgs organizacii = new CharityOrgs();
            organizacii.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            organizacii.Show();
            this.Close();
        }

        private void btn_pred_rez_Click(object sender, RoutedEventArgs e)
        {
            AllResults rezultatyGonok = new AllResults();
            rezultatyGonok.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            rezultatyGonok.Show();
            this.Close();
        }
    }
}
