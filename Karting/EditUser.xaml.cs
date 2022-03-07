using Karting.KartingDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        public string email;
        public EditUser(string email, string user_email)
        {
            this.email = email;
            InitializeComponent();
            timeToEnd.StartTimerOnCurrentWindow(currentTime, ToEnd);

            RoleTableAdapter adapt1 = new RoleTableAdapter();
            KartingDataSet.RoleDataTable table1 = new KartingDataSet.RoleDataTable();
            adapt1.Fill(table1);
            rol.ItemsSource = table1;
            rol.DisplayMemberPath = "Role_Name";
            rol.SelectedValuePath = "ID_Role";

            SqlConnection conn = new SqlConnection("Data Source = DESKTOP-I7R98U8; Initial Catalog = Karting; Integrated Security = True;");
            using (conn)
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM [User]", conn);
                SqlDataReader read = cmd.ExecuteReader();
                using (read)
                {
                    while (true)
                    {
                        if (read.Read() == false) break;
                        if (read["Email"].ToString() == user_email)
                        {
                            pochta.Content = read["Email"].ToString();
                            imya.Text = read["First_Name"].ToString();
                            fam.Text = read["Last_Name"].ToString();
                            if (read["ID_Role"].ToString() == "R") rol.Text = "Racer";
                            else if (read["ID_Role"].ToString() == "C") rol.Text = "Coordinator";
                            else if (read["ID_Role"].ToString() == "A") rol.Text = "Administrator";
                            passwd.Text = read["Password"].ToString();
                            passwd2.Text = read["Password"].ToString();
                            break;
                        }
                    }
                }
            }
        }

        private void btn_return_menu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            mainwindow.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserManage um = new UserManage(email);
            um.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            um.Show();
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (passwd.Text.Trim() != "" && passwd2.Text.Trim() != "" && imya.Text.Trim() != "" && fam.Text.Trim() != "")
            {
                if (Regex.IsMatch(passwd.Text, @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,}$"))
                {
                    if (passwd.Text == passwd2.Text)
                    {
                        char roll = 'R';
                        if (rol.Text == "Racer") roll = 'R';
                        else if (rol.Text == "Coordinator") roll = 'C';
                        else if (rol.Text == "Administrator") roll = 'A';
                        new UserTableAdapter().UpdateQuery(passwd.Text, imya.Text, fam.Text, roll.ToString(), pochta.Content.ToString());

                        UserManage um = new UserManage(email);
                        um.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                        um.Show();
                        this.Close();
                    }
                    else MessageBox.Show("Пароли не совпадают!");
                }
                else MessageBox.Show("Пароль должен соответствовать следующим требованиям: минимум 6 символов, 1 прописная буква, минимум 1 цифра, по крайней мере один спец.символ!");
            }
            else MessageBox.Show("Заполните пожалуйста все поля!");
        }
    }
}
