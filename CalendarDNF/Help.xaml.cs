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
    /// Логика взаимодействия для Help.xaml
    /// </summary>
    public partial class Help : Window
    {
        public Help()
        {
            InitializeComponent();

            textField.Text += "Имя программы - программа для автоматизации выбора дат для проведения занятий.";
            textField.Text += "\n\rОна может помочь, например, преподователю для составления календарно-тематических планов.";
            textField.Text += "\n\rДостаточно выбрать дни недели, по которым будут проводиться занятия, количество академических часов в этот день и общее количество часов в учебном году.";
            textField.Text += "\n\rПосле чего нажмите кнопку \"Рассчитать\" и на экран будет выведен список дат занятий. Пользуйтесь!";
            textField.Text += "\n\rP.S. По умолчанию начало учебного года стоит на 4 сентября, а конец - 31 мая. При необходимости можно изменить, нажав на \"Выбор даты\"";
        }
    }
}
