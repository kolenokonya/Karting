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
    /// Логика взаимодействия для LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
            timeToEnd.StartTimerOnCurrentWindow(currentTime, ToEnd);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (email.Text == "admin" && passwd.Text=="admin")
            {
                new MenuAdmin("").Show();
                this.Close();
                return;
            }

            if (email.Text == "c" && passwd.Text == "c")
            {
                new Coordinator("").Show();
                this.Close();
                return;
            }

            if (email.Text.Trim() != "" && passwd.Text.Trim() != "")
            {
                string ConnectBD = "Data Source = DESKTOP-I7R98U8; Initial Catalog = Karting; Integrated Security = True;";
                SqlConnection conn = new SqlConnection(ConnectBD);
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM [User] WHERE [Email] = '" + email.Text + "' AND [Password] = '" + passwd.Text + "'", conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        MessageBox.Show("Ошибка с поиске аккаунта");
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            if (reader["ID_Role"].ToString() == "R")
                            {
                                RacerMenu fm = new RacerMenu(email.Text);
                                fm.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                                fm.Show();
                                this.Hide();
                            }
                            if (reader["ID_Role"].ToString() == "A")
                            {
                                MenuAdmin fm = new MenuAdmin(email.Text);
                                fm.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                                fm.Show();
                                this.Hide();
                            }
                            if (reader["ID_Role"].ToString() == "C")
                            {
                                Coordinator fm = new Coordinator(email.Text);
                                fm.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                                fm.Show();
                                this.Hide();
                            }

                        }
                    }
                }

            }
            else MessageBox.Show("Ошибка. Пустые поля!");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            mainwindow.Show();
            this.Close();
        }
    }
}
