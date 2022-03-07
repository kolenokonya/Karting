using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для CharityOrgs.xaml
    /// </summary>
    public partial class CharityOrgs : Window
    {
        public CharityOrgs()
        {
            InitializeComponent();
            timeToEnd.StartTimerOnCurrentWindow(currentTime, ToEnd);

            User[] users = ExecuteSql("SELECT * FROM Charity").ToArray();
            listviewUsers.ItemsSource = users;
        }

        static IEnumerable<User> ExecuteSql(string sql)
        {
            const string dir = @"C:\Users\golik\Desktop\МПТ\УП Михайлин\WSR kart\Сессия 3 новый\kart-skills-2016-charity-data (логотипы благотворительных)\marathon-skills-2016-charity-data\";

            SqlConnection conn = new SqlConnection("Data Source = DESKTOP-I7R98U8; Initial Catalog = Karting; Integrated Security = True;");

            using (conn)
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader read = cmd.ExecuteReader();

                using (read)
                {
                    while (true)
                    {
                        if (read.Read() == false) break;

                        User user = new User()
                        {
                            Charity_Name = (string)read["Charity_Name"],
                            Charity_Description = (string)read["Charity_Description"],
                            Charity_Logo = System.IO.Path.Combine(dir, (string)read["Charity_Logo"])
                        };

                        yield return user;
                    }
                }
            }
        }

        private void btn_return_menu_Click(object sender, RoutedEventArgs e)
        {
            AllInfo b = new AllInfo();
            b.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            b.Show();
            this.Close();
        }

        public class User
        {
            public string Charity_Name { get; set; }
            public string Charity_Description { get; set; }
            public string Charity_Logo { get; set; }
        }
    }
}
