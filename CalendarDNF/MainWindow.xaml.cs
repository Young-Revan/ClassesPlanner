using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalendarDNF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DatesHandler handler;

        public MainWindow()
        {
            InitializeComponent();

            handler = new DatesHandler();
            DateTime today = DateTime.Today;
            dpBegin.DisplayDate = new DateTime(today.Year, 9, 4);
            dpEnd.DisplayDate = new DateTime(today.Year + 1, 5, 31);
        }

        private void procesButton_Click(object sender, RoutedEventArgs e)
        {
            if (dpBegin.SelectedDate != null) dpBegin.DisplayDate = (DateTime)dpBegin.SelectedDate;
            if (dpEnd.SelectedDate != null) dpEnd.DisplayDate = (DateTime)dpEnd.SelectedDate;
            handler.Begining = dpBegin.DisplayDate;
            handler.Ending = dpEnd.DisplayDate;
            int alltime;
            if (int.TryParse(tbAllTime.Text, out alltime)) handler.HoursCount = alltime;
            else
            {
                MessageBox.Show("Не забудьте указать количество часов в году!");
                return;
            }

            List<DayHour> days = new List<DayHour>();

            if (cbMonday.IsChecked != null && (bool)cbMonday.IsChecked)
            {
                int hours;
                if (!int.TryParse(tbMonday.Text, out hours))
                {
                    MessageBox.Show("Неверно указано количество часов в понедельник!");
                    return;
                }
                days.Add(new DayHour(DayOfWeek.Monday, hours));
            }

            if (cbTuesday.IsChecked != null && (bool)cbTuesday.IsChecked)
            {
                int hours;
                if (!int.TryParse(tbTuesday.Text, out hours))
                {
                    MessageBox.Show("Неверно указано количество часов во вторник!");
                    return;
                }
                days.Add(new DayHour(DayOfWeek.Tuesday, hours));
            }

            if (cbWednesday.IsChecked != null && (bool)cbWednesday.IsChecked)
            {
                int hours;
                if (!int.TryParse(tbWednesday.Text, out hours))
                {
                    MessageBox.Show("Неверно указано количество часов в среду!");
                    return;
                }
                days.Add(new DayHour(DayOfWeek.Wednesday, hours));
            }

            if (cbThursday.IsChecked != null && (bool)cbThursday.IsChecked)
            {
                int hours;
                if (!int.TryParse(tbThursday.Text, out hours))
                {
                    MessageBox.Show("Неверно указано количество часов в четверг!");
                    return;
                }
                days.Add(new DayHour(DayOfWeek.Thursday, hours));
            }

            if (cbFriday.IsChecked != null && (bool)cbFriday.IsChecked)
            {
                int hours;
                if (!int.TryParse(tbFriday.Text, out hours))
                {
                    MessageBox.Show("Неверно указано количество часов в пятницу!");
                    return;
                }
                days.Add(new DayHour(DayOfWeek.Friday, hours));
            }

            if (cbSaturday.IsChecked != null && (bool)cbSaturday.IsChecked)
            {
                int hours;
                if (!int.TryParse(tbSaturday.Text, out hours))
                {
                    MessageBox.Show("Неверно указано количество часов в субботу!");
                    return;
                }
                days.Add(new DayHour(DayOfWeek.Saturday, hours));
            }

            if (cbSunday.IsChecked != null && (bool)cbSunday.IsChecked)
            {
                int hours;
                if (!int.TryParse(tbSunday.Text, out hours))
                {
                    MessageBox.Show("Неверно указано количество часов в воскресенье!");
                    return;
                }
                days.Add(new DayHour(DayOfWeek.Sunday, hours));
            }

            handler.Days = days;

            List<DateHours> dates = handler.Process();
            InfoList form = new InfoList(dates);
            form.Show();
        }

        private void cbMonday_Checked(object sender, RoutedEventArgs e)
        {
            tbMonday.IsEnabled = true;
            tbMonday.Text = 2.ToString();
        }

        private void cbMonday_Unchecked(object sender, RoutedEventArgs e)
        {
            tbMonday.IsEnabled = false;
            tbMonday.Text = string.Empty;
        }

        private void cbTuesday_Checked(object sender, RoutedEventArgs e)
        {
            tbTuesday.IsEnabled = true;
            tbTuesday.Text = 2.ToString();
        }

        private void cbTuesday_Unchecked(object sender, RoutedEventArgs e)
        {
            tbTuesday.IsEnabled = false;
            tbTuesday.Text = string.Empty;
        }

        private void cbWednesday_Checked(object sender, RoutedEventArgs e)
        {
            tbWednesday.IsEnabled = true;
            tbWednesday.Text = 2.ToString();
        }

        private void cbWednesday_Unchecked(object sender, RoutedEventArgs e)
        {
            tbWednesday.IsEnabled = false;
            tbWednesday.Text = string.Empty;
        }

        private void cbThursday_Checked(object sender, RoutedEventArgs e)
        {
            tbThursday.IsEnabled = true;
            tbThursday.Text = 2.ToString();
        }

        private void cbThursday_Unchecked(object sender, RoutedEventArgs e)
        {
            tbThursday.IsEnabled = false;
            tbThursday.Text = string.Empty;
        }

        private void cbFriday_Checked(object sender, RoutedEventArgs e)
        {
            tbFriday.IsEnabled = true;
            tbFriday.Text = 2.ToString();
        }

        private void cbFriday_Unchecked(object sender, RoutedEventArgs e)
        {
            tbFriday.IsEnabled = false;
            tbFriday.Text = string.Empty;
        }

        private void cbSaturday_Checked(object sender, RoutedEventArgs e)
        {
            tbSaturday.IsEnabled = true;
            tbSaturday.Text = 2.ToString();
        }

        private void cbSaturday_Unchecked(object sender, RoutedEventArgs e)
        {
            tbSaturday.IsEnabled = false;
            tbSaturday.Text = string.Empty;
        }

        private void cbSunday_Checked(object sender, RoutedEventArgs e)
        {
            tbSunday.IsEnabled = true;
            tbSunday.Text = 2.ToString();
        }

        private void cbSunday_Unchecked(object sender, RoutedEventArgs e)
        {
            tbSunday.IsEnabled = false;
            tbSunday.Text = string.Empty;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Help form = new Help();
            form.Show();
        }

        private void holidaysButton_Click(object sender, RoutedEventArgs e)
        {
            HolidaysList form = new HolidaysList(handler.Holidays);
            if ((bool)form.ShowDialog())
            {
                handler.Holidays = form.Dates;
            }
        }

        private void miSave_Click(object sender, RoutedEventArgs e)
        {
            handler.SaveHolidays();
        }

        private void miLoad_Click(object sender, RoutedEventArgs e)
        {
            handler.LoadHolidays();
        }
    }
}