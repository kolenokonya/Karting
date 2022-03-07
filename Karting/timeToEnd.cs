using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Karting
{
    class timeToEnd
    {
        public static DateTime DateDayX = new DateTime(2022, 3, 7, 14, 10, 0);
        public static Label dynamicDate;

        public static void ShowDate()
        {
            MessageBox.Show(new DateTime().ToString());
        }

        public static void StartTimerOnCurrentWindow(TextBlock staticDate, Label dynamicDatee)
        {
            staticDate.Text = String.Format("Москва, Россия {0} марта {1}", DateDayX.Day, DateDayX.Year);
            dynamicDate = dynamicDatee;
            DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(Timer);
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(500);
            dispatcherTimer.Start();
        }

        internal static void StartTimerOnCurrentWindow(object currentTime, object toEnd)
        {
            throw new NotImplementedException();
        }

        public static void Timer(object sender, EventArgs e)
        {
            TimeSpan timerTime = DateDayX.Subtract(DateTime.UtcNow);
            DateTime date = new DateTime() + timerTime;
            dynamicDate.Content = String.Format("До начала события осталось {0} лет, {1} меясцев, {2} дней, {3} часов, {4} минут и {5} секунд", date.Year - 1, date.Month - 1, date.Day - 1, date.Hour, date.Minute, date.Second);
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
