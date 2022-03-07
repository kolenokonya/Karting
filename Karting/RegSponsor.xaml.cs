using Karting.KartingDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для RegSponsor.xaml
    /// </summary>
    public partial class RegSponsor : Window
    {
        public RegSponsor()
        {
            InitializeComponent();
            timeToEnd.StartTimerOnCurrentWindow(currentTime, ToEnd);

            cvc.CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, OnPasteCommand));
            mec.CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, OnPasteCommand));
            god.CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, OnPasteCommand));
            nomer.CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, OnPasteCommand));

            DataGrid data = new DataGrid();
            RacerTableAdapter a = new RacerTableAdapter();
            KartingDataSet.RacerDataTable b = new KartingDataSet.RacerDataTable();
            a.FillBy(b);
            data.ItemsSource = b;
            gonshik.DisplayMemberPath = "Display";
            gonshik.SelectedValuePath = "ID_Racer";
            gonshik.ItemsSource = b;
            gonshik.SelectedIndex = 0;
        }

        public void OnPasteCommand(object sender, ExecutedRoutedEventArgs e) { }

        private void oplata_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            if (imya.Text != null && vladelec.Text != null && nomer.Text.Length == 16 && mec.Text.Length == 2 && god.Text.Length == 4 && cvc.Text.Length == 3)
            {
                SponsorshipTableAdapter adapter = new SponsorshipTableAdapter();
                KartingDataSet.SponsorshipDataTable table = new KartingDataSet.SponsorshipDataTable();
                adapter.Fill(table);
                bool fl = false;
                foreach (var item in table)
                {
                    string name = item.SponsorName;
                    if (name == imya.Text)
                    {
                        new SponsorshipTableAdapter().UpdateQuery(imya.Text, item.Amount + Convert.ToDecimal(money.Text), item.ID_Sponsorship);
                        fl = true;
                        break;
                    }
                }
                if (fl == false) new SponsorshipTableAdapter().InsertQuery(imya.Text, Convert.ToDecimal(money.Text));

                SponsorConfirm sponsor = new SponsorConfirm(money.Text, (gonshik.SelectedItem as DataRowView).Row.ItemArray[8].ToString());
                sponsor.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                sponsor.Show();
                this.Close();
            }
            else MessageBox.Show("Ошибка");
            }
            catch { }

        }

        private void money_TextChanged(object sender, TextChangedEventArgs e)
        {
            int a = Convert.ToInt32(money.Text);
            pp.Content = "$" + money.Text;
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(money.Text) > 10)
            {
                int a = Convert.ToInt32(money.Text);
                a -= 10;
                money.Text = Convert.ToString(a);
                pp.Content = "$" + money.Text;
            }
            else MessageBox.Show("Сумма пожертвования не должна быть меньше 10!");
        }

        private void otmena_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            mainwindow.Show();
            this.Close();
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(money.Text) >= 10)
            {
                int a = Convert.ToInt32(money.Text);
                a += 10;
                money.Text = Convert.ToString(a);
                pp.Content = "$" + money.Text;

            }
            else MessageBox.Show("Сумма пожертвования не должна быть меньше 10!");
        }

        private new void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.Text, 0);
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            mainwindow.Show();
            this.Close();
        }
    }
}
