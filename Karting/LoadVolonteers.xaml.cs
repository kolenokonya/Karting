using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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
    /// Логика взаимодействия для LoadVolonteers.xaml
    /// </summary>
    public partial class LoadVolonteers : Window
    {
        public LoadVolonteers()
        {
            InitializeComponent();
            timeToEnd.StartTimerOnCurrentWindow(currentTime, ToEnd);
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string ConnectBD = "Data Source = DESKTOP-I7R98U8; Initial Catalog = Karting; Integrated Security = True;";
            SqlConnection conn = new SqlConnection(ConnectBD);
            conn.Open();
            string[] data = File.ReadAllLines(dirStr.Text);

            SqlCommand cmnd = new SqlCommand("DELETE FROM [Volunteer]", conn);
            cmnd.ExecuteNonQuery();
            try
            {
                for (int i = 1; i < data.Length; i++)
                {

                    String[] word = data[i].Split(new char[] { ',' });

                    for (int j = 0; j < word.Length; j++)
                    {
                        SqlCommand commanSearchId = new SqlCommand("SELECT * FROM [Volunteer] WHERE [ID_Volunteer] = '" + word[0] + "'", conn);
                        bool t = true;
                        using (SqlDataReader reader = commanSearchId.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                t = false;
                            }

                        }

                        using (var reader = new StreamReader(dirStr.Text))
                        {

                            while (!reader.EndOfStream)
                            {
                                var line = reader.ReadLine();
                                var dataa = line.Split(',');

                                SqlCommand query = new SqlCommand("INSERT INTO [Volunteer] Values  ('" + dataa[0] + "', '" + dataa[2] + "', '" + dataa[1] + "', '" + dataa[3] + "', '" + dataa[4] + "')", conn);
                                query.ExecuteNonQuery();


                            }
                        }
                    }
                }
            }
            catch
            {

            }
            MessageBox.Show("Данные о волонтерах успешно добавлены!", "Оповещение системы");
            VolonteerManage vl = new VolonteerManage();
            vl.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            vl.Show();
            this.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = ".csv";
            ofd.Filter = "Doc (.csv)|*.csv*";
            if (ofd.ShowDialog() == true)
            {
                string filename = ofd.FileName;
                dirStr.Text = filename;
            }
        }
    }
}
