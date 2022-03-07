using Karting.KartingDataSetTableAdapters;
using Microsoft.Win32;
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
    /// Логика взаимодействия для EditRacer.xaml
    /// </summary>
    public partial class EditRacer : Window
    {
        string a, b;
        public string email;

        private void btn_return_menu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            mainwindow.Show();
            this.Close();
        }

        public EditRacer(string email)
        {
            this.email = email;
            InitializeComponent();
            timeToEnd.StartTimerOnCurrentWindow(currentTime, ToEnd);

            GenderTableAdapter adapt = new GenderTableAdapter();
            KartingDataSet.GenderDataTable table1 = new KartingDataSet.GenderDataTable();
            adapt.Fill(table1);
            pol.ItemsSource = table1;
            pol.DisplayMemberPath = "ID_Gender";
            pol.SelectedValuePath = "ID_Gender";

            CountryTableAdapter adapt1 = new CountryTableAdapter();
            KartingDataSet.CountryDataTable table2 = new KartingDataSet.CountryDataTable();
            adapt1.Fill(table2);
            strana.ItemsSource = table2;
            strana.DisplayMemberPath = "ID_Country";
            strana.SelectedValuePath = "ID_Country";

            string ConnectBD = "Data Source = DESKTOP-I7R98U8; Initial Catalog = Karting; Integrated Security = True;";
            SqlConnection conn = new SqlConnection(ConnectBD);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM [User] WHERE [Email] = '" + email + "'", conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    pochta.Content = email;
                    fam.Text = reader["Last_Name"].ToString();
                    b = fam.Text;
                    imya.Text = reader["First_Name"].ToString();
                    a = imya.Text;
                    passwd.Text = reader["Password"].ToString();
                    passwd2.Text = reader["Password"].ToString();
                }
            }
            SqlCommand command1 = new SqlCommand("SELECT * FROM [Racer] WHERE [First_Name] = '" + imya.Text + "' AND [Last_Name] = '" + fam.Text + "'", conn);
            using (SqlDataReader reader1 = command1.ExecuteReader())
            {
                while (reader1.Read())
                {
                    pol.Text = reader1["Gender"].ToString();
                    strana.Text = reader1["ID_Country"].ToString();
                    rozd.Text = reader1["DateOfBirth"].ToString();
                    //photo.Text = reader1["Photo"].ToString();
                    try
                    {
                        var uriImageSource = new Uri(photo.Text, UriKind.RelativeOrAbsolute);
                        pikcha.Source = new BitmapImage(uriImageSource);
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка при загрузке фото");
                    }
                }
            }
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            if (passwd.Text.Trim() != "" && passwd2.Text.Trim() != "" && imya.Text.Trim() != "" && fam.Text.Trim() != "" && rozd.Text.Trim() != "" && pol.Text != null && strana.Text != null && photo.Text.Trim() != "")
            {
                if (photo.Text.Trim() != "")
                {
                    if (Regex.IsMatch(passwd.Text, @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,}$"))
                    {
                        if (passwd.Text == passwd2.Text)
                        {

                            string ConnectBD = "Data Source = DESKTOP-I7R98U8; Initial Catalog = Karting; Integrated Security = True;";
                            SqlConnection conn = new SqlConnection(ConnectBD);
                            conn.Open();

                            SqlCommand command = new SqlCommand("UPDATE [User] Set [Password] = '" + passwd.Text + "', [First_Name] = '" + imya.Text + "', [Last_Name] = '" + fam.Text + "' WHERE [Email] = '" + email + "'", conn);
                            command.ExecuteNonQuery();

                            SqlCommand command2 = new SqlCommand("UPDATE [Racer] Set [First_Name] = '" + imya.Text + "', [Last_Name] = '" + fam.Text + "', [Gender] = '" + Convert.ToString(pol.SelectedValue) + "', [DateOfBirth] = '" + rozd.Text + "', [ID_Country] = '" + Convert.ToString(strana.SelectedValue) + "', [Photo] = '" + photo.Text + "' WHERE [First_Name] = '" + a + "' AND [Last_Name] = '" + b + "'", conn);
                            command2.ExecuteNonQuery();

                            RacerMenu fm = new RacerMenu(email);
                            fm.Show();
                            this.Hide();

                        }
                        else MessageBox.Show("Пароли не совпадают!");
                    }
                    else MessageBox.Show("Пароль должен соответствовать следующим требованиям: минимум 6 символов, 1 прописная буква, минимум 1 цифра, по крайней мере один спец.символ!");
                }
                else MessageBox.Show("Выберите пожалуйста фотографию!");
            }
            else MessageBox.Show("Заполните пожалуйста все поля!");
        }

        private void prosmots_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog a = new OpenFileDialog();
            a.Filter = "Images|*.jpg;*.gif;*.png;*.bmp";
            if (a.ShowDialog() == true)
            {
                photo.Text = a.FileName;
                var uriImageSource = new Uri(photo.Text, UriKind.RelativeOrAbsolute);
                pikcha.Source = new BitmapImage(uriImageSource);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RacerMenu gonshika = new RacerMenu(email);
            gonshika.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            gonshika.Show();
            this.Close();
        }
    }
}
