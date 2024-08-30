using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CalendarDNF
{
    /// <summary>
    /// Логика взаимодействия для HolidaysList.xaml
    /// </summary>
    public partial class HolidaysList : Window
    {
        List<DateTime> dates;
        public List<DateTime> Dates { get => dates; set => dates = value; }

        UIElementCollection DatesControls { get => holidaysPanel.Children; }

        public HolidaysList()
        {
            InitializeComponent();
            dates = new List<DateTime>();
            SetHolidaysOnPanel();
            Initialize();
        }

        public HolidaysList(List<DateTime> dates)
        {
            InitializeComponent();
            this.dates = dates;
            SetHolidaysOnPanel();
            Initialize();
        }

        void Initialize()
        {
            dpHoliday.DisplayDate = DateTime.Today;
        }

        void SetHolidaysOnPanel()
        {
            holidaysPanel.Children.Clear();
            foreach (DateTime date in dates)
            {
                CheckBox cb = new CheckBox();
                cb.IsChecked = false;
                string str = date.Date.ToString();
                cb.Content = str.Remove(str.IndexOf(' '));
                holidaysPanel.Children.Add(cb);
            }
        }

        async public void LoadHolidays()
        {
            if(File.Exists(Directory.GetCurrentDirectory() + "holidays.json"))
            {
                using (FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "holidays.json", FileMode.OpenOrCreate))
                {
                    dates = await JsonSerializer.DeserializeAsync<List<DateTime>>(fs);
                }
            }
        }

        async public void SaveHolidays()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "holidays.json"))
            {
                File.Delete(Directory.GetCurrentDirectory() + "holidays.json");
            }
            using (FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "holidays.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<List<DateTime>>(fs, dates);
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (dpHoliday.SelectedDate == null) return;
            DateTime dt = (DateTime)dpHoliday.SelectedDate;
            dates.Add(dt);
            dates.Sort();
            SetHolidaysOnPanel();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < DatesControls.Count; i++)
            {
                CheckBox cbItem = (CheckBox)DatesControls[i];
                if ((bool)cbItem.IsChecked)
                {
                    for (int j = 0; j < dates.Count; j++)
                    {
                        DateTime dtItem = dates[j];
                        string str = dtItem.Date.ToString();
                        str = str.Remove(str.IndexOf(' '));
                        if (str == cbItem.Content.ToString())
                        {
                            dates.RemoveAt(j);
                            j--;
                            break;
                        }
                    }
                    DatesControls.RemoveAt(i);
                    i--;
                }
            }
        }

        private void selectAllButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (CheckBox item in DatesControls)
            {
                item.IsChecked = true;
            }
        }

        private void unselectAllButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (CheckBox item in DatesControls)
            {
                item.IsChecked = false;
            }
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            LoadHolidays();
            SetHolidaysOnPanel();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveHolidays();
                DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Close();
            }
        }
    }
}
