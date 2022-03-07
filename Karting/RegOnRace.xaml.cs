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
    /// Логика взаимодействия для RegOnRace.xaml
    /// </summary>
    public partial class RegOnRace : Window
    {
        public string email;
        public int value;
        public string runnerId;
        public string a, b;
        public RegOnRace(string email)
        {
            this.email = email;
            InitializeComponent();
            timeToEnd.StartTimerOnCurrentWindow(currentTime, ToEnd);

            CharityTableAdapter adapt = new CharityTableAdapter();
            KartingDataSet.CharityDataTable table1 = new KartingDataSet.CharityDataTable();
            adapt.Fill(table1);
            organizaciya.ItemsSource = table1;
            organizaciya.DisplayMemberPath = "Charity_Name";
            organizaciya.SelectedValuePath = "ID_Сharity";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (organizaciya.Text == "" || vznos.Text == "")
            {
                MessageBox.Show("Пожалуйста, выберете спонсора из числа благотворительных организаций и внесите сумму спонсорского взноса!", "Оповещение системы");
            }
            else
            {
                if ((Vid1.IsChecked == false) && (Vid2.IsChecked == false) && (Vid3.IsChecked == false))
                {
                    MessageBox.Show("Пожалуйста, выберете, как минимум, одну из представленных гонок!");
                }
                else
                {
                    if (Convert.ToInt32(vznos.Text) < 0)
                    {
                        MessageBox.Show("Пожалуйста, введите положительную сумму взноса!!");
                    }
                    else
                    {
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
                                runnerId = reader1["ID_Racer"].ToString();
                            }
                        }

                        string currentDate = DateTime.Now.Date.ToString();
                        int cost = Convert.ToInt32(pp.Content);
                        cost -= Convert.ToInt32(vznos.Text);


                        SqlCommand command2 = new SqlCommand("INSERT INTO [Registration] Values ('" + runnerId + "', '" + currentDate + "', '1', '" + cost + "', '" + Convert.ToString(organizaciya.SelectedValue) + "', '" + value + "')", conn);
                        command2.ExecuteNonQuery();

                        ConfirmRegRacer podtverzhdenie = new ConfirmRegRacer(email);
                        podtverzhdenie.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                        podtverzhdenie.Show();
                        this.Close();
                    }
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RegRacer registraciya = new RegRacer();
            registraciya.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            registraciya.Show();
            this.Close();
        }

        private void btn_return_menu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            mainwindow.Show();
            this.Close();
        }


        private void Vid1_Checked(object sender, RoutedEventArgs e)
        {
            value = Convert.ToInt32(pp.Content);
            value += 25;
            pp.Content = Convert.ToString(value);
        }

        private void Vid2_Checked(object sender, RoutedEventArgs e)
        {
            value = Convert.ToInt32(pp.Content);
            value += 40;
            pp.Content = Convert.ToString(value);
        }

        private void Vid3_Checked(object sender, RoutedEventArgs e)
        {
            value = Convert.ToInt32(pp.Content);
            value += 65;
            pp.Content = Convert.ToString(value);
        }

        private void var_A_Checked(object sender, RoutedEventArgs e)
        {
            value = Convert.ToInt32(pp.Content);
            value += 0;
            pp.Content = Convert.ToString(value);
        }

        private void var_B_Checked(object sender, RoutedEventArgs e)
        {
            value = Convert.ToInt32(pp.Content);
            value += 30;
            pp.Content = Convert.ToString(value);
        }

        private void var_C_Checked(object sender, RoutedEventArgs e)
        {
            value = Convert.ToInt32(pp.Content);
            value += 50;
            pp.Content = Convert.ToString(value);
        }

        private void vznos_TextChanged(object sender, TextChangedEventArgs e)
        {
            value = Convert.ToInt32(pp.Content);
            value += Convert.ToInt32(vznos.Text);
            pp.Content = Convert.ToString(value);
        }

        private void Vid3_Unchecked(object sender, RoutedEventArgs e)
        {
            value = Convert.ToInt32(pp.Content);
            value -= 65;
            pp.Content = Convert.ToString(value);
        }

        private void Vid1_Unchecked(object sender, RoutedEventArgs e)
        {
            value = Convert.ToInt32(pp.Content);
            value -= 25;
            pp.Content = Convert.ToString(value);
        }

        private void Vid2_Unchecked(object sender, RoutedEventArgs e)
        {
            value = Convert.ToInt32(pp.Content);
            value -= 40;
            pp.Content = Convert.ToString(value);
        }

        private void var_A_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void var_B_Unchecked(object sender, RoutedEventArgs e)
        {
            value = Convert.ToInt32(pp.Content);
            value -= 30;
            pp.Content = Convert.ToString(value);
        }

        private void var_C_Unchecked(object sender, RoutedEventArgs e)
        {
            value = Convert.ToInt32(pp.Content);
            value -= 50;
            pp.Content = Convert.ToString(value);
        }
    }
}
