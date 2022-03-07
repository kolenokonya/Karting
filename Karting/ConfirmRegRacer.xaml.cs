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
    /// Логика взаимодействия для ConfirmRegRacer.xaml
    /// </summary>
    public partial class ConfirmRegRacer : Window
    {
        public string email;
        public ConfirmRegRacer(string email)
        {
            this.email = email;
            InitializeComponent();
            timeToEnd.StartTimerOnCurrentWindow(currentTime, ToEnd);

        }

        public ConfirmRegRacer()
        {
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            RacerMenu gon = new RacerMenu(email);
            gon.Show();
            this.Close();
        }

        private void btn_return_menu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Show();
            this.Close();
        }
    }
}
