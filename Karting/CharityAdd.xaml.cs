using Karting.KartingDataSetTableAdapters;
using Microsoft.Win32;
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
    /// Логика взаимодействия для CharityAdd.xaml
    /// </summary>
    public partial class CharityAdd : Window
    {
        public string email;
        public bool fl;
        public int index;
        public CharityAdd(bool fl, string Name, string Description, string Logo, string email)
        {
            this.email = email;
            InitializeComponent();
            this.fl = fl;
            if (fl == true) 
                DataTransf(Name, Description, Logo);
        }

        private void Otmena_Click(object sender, RoutedEventArgs e)
        {
            CharityManage upravleniyeOrganizatsiyami = new CharityManage(email);
            upravleniyeOrganizatsiyami.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            upravleniyeOrganizatsiyami.Show();
            this.Close();
        }

        private void DataTransf(string Name, string Description, string Logo)
        {
            try
            {
                AddEditText.Text = "Редактирование благотворительных организаций";
                SqlConnection conn = new SqlConnection("Data Source = DESKTOP-I7R98U8; Initial Catalog = Karting; Integrated Security = True;");
                using (conn)
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Charity", conn);
                    SqlDataReader read = cmd.ExecuteReader();

                    string dir = @"C:\Users\golik\Desktop\МПТ\УП Михайлин\WSR kart\Сессия 3 новый\kart-skills-2016-charity-data (логотипы благотворительных)\marathon-skills-2016-charity-data\";
                    using (read)
                    {
                        while (true)
                        {
                            if (read.Read() == false) break;
                            if (read["Charity_Logo"].ToString().Contains('/')) dir = null;
                            if (read["Charity_Name"].ToString() == Name && read["Charity_Description"].ToString() == Description && System.IO.Path.Combine(dir, (string)read["Charity_Logo"]).ToString() == Logo)
                            {
                                index = Convert.ToInt32(read["ID_Сharity"]);
                                Naimenovanie.Text = Name;
                                Opisanie.Text = Description;
                                var uriImageSource = new Uri(Logo, UriKind.RelativeOrAbsolute);
                                pikcha.Source = new BitmapImage(uriImageSource);
                                photo.Text = Logo;
                                break;
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Naimenovanie.Text.Trim() != "" && Opisanie.Text.Trim() != "")
            {
                if (fl == false) new CharityTableAdapter().InsertQuery(Naimenovanie.Text, Opisanie.Text, photo.Text);
                else new CharityTableAdapter().UpdateQuery(Naimenovanie.Text, Opisanie.Text, photo.Text, index);
                CharityManage upravleniyeOrganizatsiyami = new CharityManage(email);
                upravleniyeOrganizatsiyami.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                upravleniyeOrganizatsiyami.Show();
                this.Close();
            }
            else MessageBox.Show("Поля Наименование и Описание не должны быть пустыми!");
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

        private void btn_return_menu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            mainwindow.Show();
            this.Close();
        }
    }
}
