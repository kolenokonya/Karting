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
    /// Логика взаимодействия для Map.xaml
    /// </summary>
    public partial class Map : Window
    {
        public Map()
        {
            InitializeComponent();
            timeToEnd.StartTimerOnCurrentWindow(currentTime, ToEnd);
        }

        private void btn_karta_trassi_Click(object sender, RoutedEventArgs e)
        {
            BigMap g = new BigMap();
            g.Show();
            this.Close();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            AllInfo b = new AllInfo();
            b.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            b.Show();
            this.Close();
        }
    }
}
