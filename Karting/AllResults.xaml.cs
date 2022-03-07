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
    /// Логика взаимодействия для AllResults.xaml
    /// </summary>
    public partial class AllResults : Window
    {
        //User12[] users = ExecuteSql("SELECT * FROM [RezultsView]").ToArray();
        public AllResults()
        {
            InitializeComponent();
            timeToEnd.StartTimerOnCurrentWindow(currentTime, ToEnd);
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {

        }

        //static IEnumerable<User12> ExecuteSql(string v)
        //{
        //    throw new NotImplementedException();
        //}

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AllInfo menuAdministratora = new AllInfo();
            menuAdministratora.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            menuAdministratora.Show();
            this.Close();
        }
    }

    //public class User12
    //{
    //    public string First_Name { get; set; }
    //    public string Last_Name { get; set; }
    //    public string Email { get; set; }
    //    public string ID_Role { get; set; }
    //}
}
