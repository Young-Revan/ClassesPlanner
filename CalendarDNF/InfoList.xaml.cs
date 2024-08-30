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
using System.Windows.Shapes;

namespace CalendarDNF
{
    /// <summary>
    /// Логика взаимодействия для InfoList.xaml
    /// </summary>
    public partial class InfoList : Window
    {
        public InfoList()
        {
            InitializeComponent();
        }

        public InfoList(List<DateHours> dates)
        {
            InitializeComponent();
            int month = 0;

            tb.Text += "\tВсего занятий: " + dates.Count;

            int ours = 0;
            foreach (DateHours day in dates)
            {
                if (month == 0 || day.Date.Month != month)
                {
                    month = day.Date.Month;
                    tb.Text += "\n\r\t" + day.Date.ToString("Y");
                }
                tb.Text += "\n\r" + day.Date.ToString("d") + "\t" + day.Hours.ToString() + " часов";
                ours += day.Hours;
            }
            tb.Text += "\n\n\rВсего часов: " + ours;
        }
    }
}
