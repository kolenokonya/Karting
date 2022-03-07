using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для UserManage.xaml
    /// </summary>
    public partial class UserManage : Window
    {
        public string email;
        User1[] users = ExecuteSql("SELECT * FROM [User]").ToArray();
        public UserManage(string email)
        {
            this.email = email;
            InitializeComponent();
            timeToEnd.StartTimerOnCurrentWindow(currentTime, ToEnd);
            
            listview.ItemsSource = users;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (RoleCB.Text != "Все роли") listview.ItemsSource = users.Where(p => p.ID_Role.Contains(RoleCB.Text)).ToList();
            else listview.ItemsSource = users;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listview.ItemsSource);
            if (SortCB.Text == "Имя")
            {
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription("First_Name", ListSortDirection.Ascending));
            }
            else if (SortCB.Text == "Фамилия")
            {
                view.SortDescriptions.Add(new SortDescription("Last_Name", ListSortDirection.Ascending));
            }
            else if (SortCB.Text == "Email")
            {
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription("Email", ListSortDirection.Ascending));
            }
            else if (SortCB.Text == "Роль")
            {
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription("ID_Role", ListSortDirection.Ascending));
            }
            else if (SortCB.Text == "-") view.SortDescriptions.Clear();

            if (Poisk.Text.Trim() != "") listview.ItemsSource = users.Where(p => p.First_Name.Contains(Poisk.Text)).ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddUser addPolzovatelya = new AddUser(email);
            addPolzovatelya.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            addPolzovatelya.Show();
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
        private void btn_return_menu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            mainwindow.Show();
            this.Close();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            User1 user = listview.Items.GetItemAt(listview.SelectedIndex) as User1;
            EditUser editPolzovatelya = new EditUser(email, user.Email);
            editPolzovatelya.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            editPolzovatelya.Show();
            this.Close();
        }

        static IEnumerable<User1> ExecuteSql(string sql)
        {

            SqlConnection conn = new SqlConnection(
                "Data Source = DESKTOP-I7R98U8; Initial Catalog = Karting; Integrated Security = True;"
                );

            using (conn)
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader read = cmd.ExecuteReader();

                string role = null;
                using (read)
                {
                    while (true)
                    {
                        if (read.Read() == false) break;
                        if (read["ID_Role"].ToString() == "R") role = "Гонщик";
                        else if (read["ID_Role"].ToString() == "C") role = "Координатор";
                        else if (read["ID_Role"].ToString() == "A") role = "Администратор";
                        User1 user = new User1()
                        {
                            First_Name = (string)read["First_Name"],
                            Last_Name = (string)read["Last_Name"],
                            Email = (string)read["Email"],
                            ID_Role = role
                        };

                        yield return user;
                    }
                }
            }
        }
    }

    public class User1
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string ID_Role { get; set; }
    }
}
