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
    /// Логика взаимодействия для BigMap.xaml
    /// </summary>
    public partial class BigMap : Window
    {
        public BigMap()
        {
            InitializeComponent();
            timeToEnd.StartTimerOnCurrentWindow(currentTime, ToEnd);
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Map karta = new Map();
            karta.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            karta.Show();
            this.Close();
        }
    }
}
