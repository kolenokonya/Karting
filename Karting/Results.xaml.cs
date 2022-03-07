using Karting.KartingDataSetTableAdapters;
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
    /// Логика взаимодействия для Results.xaml
    /// </summary>
    public partial class Results : Window
    {
        public string email;
        string a, b;
        string gender;
        DateTime dataa;
        public Results(string email)
        {
            this.email = email;
            InitializeComponent();
            timeToEnd.StartTimerOnCurrentWindow(currentTime, ToEnd);

            string ConnectBD = "Data Source = DESKTOP-I7R98U8; Initial Catalog = Karting; Integrated Security = True;";
            SqlConnection conn = new SqlConnection(ConnectBD);
            conn.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM [User] WHERE [Email] = '" + email + "'", conn);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    b = reader["Last_Name"].ToString();
                    a = reader["First_Name"].ToString();
                }
            }

            SqlCommand command1 = new SqlCommand("SELECT * FROM [Racer] WHERE [First_Name] = '" + a + "' AND [Last_Name] = '" + b + "'", conn);
            using (SqlDataReader reader1 = command1.ExecuteReader())
            {
                while (reader1.Read())
                {
                    gender = reader1["Gender"].ToString();
                    if (gender == "M")
                    {
                        pol.Content = "мужской";
                    }
                    else
                    {
                        pol.Content = "женский";
                    }
                    dataa = Convert.ToDateTime(reader1["DateOfBirth"].ToString());
                    if (dataa < Convert.ToDateTime("15.02.2004"))
                    {
                        vozrast.Content = "до 18";
                    }
                    else if ((Convert.ToDateTime("01.01.2004") > dataa) && (dataa > Convert.ToDateTime("01.01.1993")))
                    {
                        vozrast.Content = "от 18 до 29";
                    }
                    else if ((Convert.ToDateTime("01.01.1992") > dataa) && (dataa > Convert.ToDateTime("01.01.1983")))
                    {
                        vozrast.Content = "от 30 до 39";
                    }
                    else if ((Convert.ToDateTime("01.01.1982") > dataa) && (dataa > Convert.ToDateTime("01.01.1967")))
                    {
                        vozrast.Content = "от 56 до 70";
                    }
                    else vozrast.Content = "более 70";
                }
            }

            RezultsViewTableAdapter adapter = new RezultsViewTableAdapter();
            KartingDataSet.RezultsViewDataTable table = new KartingDataSet.RezultsViewDataTable();
            adapter.Fill(table, a, b);
            rez.ItemsSource = table;
        }

        private void btn_return_menu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            mainwindow.Show();
            this.Close();
        }

        private void btn_return_menu_Click_1(object sender, RoutedEventArgs e)
        {
            RacerMenu menu = new RacerMenu(email);
            menu.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            menu.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AllResults menu = new AllResults();
            menu.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            menu.Show();
            this.Close();
        }

    }
}
