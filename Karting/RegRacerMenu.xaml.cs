using Karting.KartingDataSetTableAdapters;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для RegRacerMenu.xaml
    /// </summary>
    public partial class RegRacerMenu : Window
    {
        public RegRacerMenu()
        {
            InitializeComponent();
            timeToEnd.StartTimerOnCurrentWindow(currentTime, ToEnd);

            GenderTableAdapter adapt = new GenderTableAdapter();
            KartingDataSet.GenderDataTable table1 = new KartingDataSet.GenderDataTable();
            adapt.Fill(table1);
            pol.ItemsSource = table1;
            pol.DisplayMemberPath = "Gender_Name";
            pol.SelectedValuePath = "ID_Gender";

            CountryTableAdapter adapt1 = new CountryTableAdapter();
            KartingDataSet.CountryDataTable table2 = new KartingDataSet.CountryDataTable();
            adapt1.Fill(table2);
            strana.ItemsSource = table2;
            strana.DisplayMemberPath = "Country_Name";
            strana.SelectedValuePath = "ID_Country";
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            if (email.Text.Trim() != "" && passwd.Text.Trim() != "" && passwd2.Text.Trim() != "" && imya.Text.Trim() != "" && fam.Text.Trim() != "" && rozd.Text.Trim() != "" && pol.Text != null && strana.Text != null && photo.Text.Trim() != "")
            {
                if (photo.Text.Trim() != "")
                {
                    if (Regex.IsMatch(email.Text, @"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$"))
                    {
                        if (Regex.IsMatch(passwd.Text, @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,}$"))
                        {
                            if (passwd.Text == passwd2.Text)
                            {
                                new RacerTableAdapter().InsertQuery(imya.Text, fam.Text, Convert.ToString(pol.SelectedValue), rozd.Text, Convert.ToString(strana.SelectedValue), photo.Text);
                                RacerTableAdapter adapter = new RacerTableAdapter();
                                KartingDataSet.RacerDataTable table = new KartingDataSet.RacerDataTable();
                                adapter.Fill(table);

                                new UserTableAdapter().InsertQuery(email.Text, passwd.Text, imya.Text, fam.Text, "R");
                                UserTableAdapter adapter1 = new UserTableAdapter();
                                KartingDataSet.UserDataTable table1 = new KartingDataSet.UserDataTable();
                                adapter1.Fill(table1);

                                RegOnRace gonki = new RegOnRace(email.Text);
                                gonki.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                                gonki.Show();
                                this.Close();
                            }
                            else MessageBox.Show("Пароли не совпадают!");
                        }
                        else MessageBox.Show("Пароль должен соответствовать следующим требованиям: минимум 6 символов, 1 прописная буква, минимум 1 цифра, по крайней мере один спец.символ!");
                    }
                    else MessageBox.Show("Введите корректную почту");
                }
                else MessageBox.Show("Выберите пожалуйста фотографию!");
            }
            else MessageBox.Show("Заполните пожалуйста все поля!");
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            mainwindow.Show();
            this.Close();
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
    }
}
