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
    /// Логика взаимодействия для CharityManage.xaml
    /// </summary>
    public partial class CharityManage : Window
    {
        public string email;

        public CharityManage(string email)
        {
            this.email = email;
            InitializeComponent();
            timeToEnd.StartTimerOnCurrentWindow(currentTime, ToEnd);

            User2[] users = ExecuteSql("SELECT * FROM [Charity]").ToArray();
            listview.ItemsSource = users;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            bool fl = false;
            CharityAdd addOrganizii = new CharityAdd(fl, null, null, null, email);
            addOrganizii.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            addOrganizii.Show();
            this.Close();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            bool fl = true;
            User2 user = listview.Items.GetItemAt(listview.SelectedIndex) as User2;
            CharityAdd addOrganizii = new CharityAdd(fl, user.Charity_Name, user.Charity_Description, user.Charity_Logo, email);
            addOrganizii.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            addOrganizii.Show();
            this.Close();
        }
        private void btn_return_menu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            mainwindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RegRacer registraciya = new RegRacer();
            registraciya.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            registraciya.Show();
            this.Close();
        }

        private void SelectCurrentItem(object sender, KeyboardFocusChangedEventArgs e)
        {
            ListViewItem item = (ListViewItem)sender;
            item.IsSelected = true;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MenuAdmin menuAdministratora = new MenuAdmin(email);
            menuAdministratora.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            menuAdministratora.Show();
            this.Close();
        }

        static IEnumerable<User2> ExecuteSql(string sql)
        {
            string dir = @"C:\Users\golik\Desktop\МПТ\УП Михайлин\WSR kart\Сессия 3 новый\kart-skills-2016-charity-data (логотипы благотворительных)\marathon-skills-2016-charity-data\";

            SqlConnection conn = new SqlConnection(
                "Data Source = DESKTOP-I7R98U8; Initial Catalog = Karting; Integrated Security = True;"
                );

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
                        if (read["Charity_Logo"].ToString().Contains('/')) dir = null;
                        User2 user = new User2()
                        {
                            Charity_Logo = System.IO.Path.Combine(dir, (string)read["Charity_Logo"]),
                            Charity_Name = (string)read["Charity_Name"],
                            Charity_Description = (string)read["Charity_Description"]
                        };

                        yield return user;
                    }
                }
            }
        }
    }
    public class User2
    {
        public string Charity_Logo { get; set; }
        public string Charity_Name { get; set; }
        public string Charity_Description { get; set; }
    }
}
