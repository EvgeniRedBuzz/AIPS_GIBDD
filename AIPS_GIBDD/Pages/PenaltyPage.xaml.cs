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
using static AIPS_GIBDD.ClassHelper.AppData;

namespace AIPS_GIBDD.Pages
{
    /// <summary>
    /// Логика взаимодействия для PenaltyPage.xaml
    /// </summary>
    public partial class PenaltyPage : Page
    {
        List<string> filter = new List<string>();

        public PenaltyPage()
        {
            InitializeComponent();
            filter.Add("ФИО (в алфавитном порядке)");
            filter.Add("ФИО (в обратном алфавитном порядке)");
            filter.Add("Неоплаченных штрафов (по возрастанию)");
            filter.Add("Неоплаченных штрафов (по убыванию)");
            filter.Add("Сумме штрафов (по возрастанию)");
            filter.Add("Сумме штрафов (по убыванию)");
            CmbFilter.ItemsSource = filter;
            Filter();
        }

        private void Filter()
        {
            var list = context.UserPenalty.Where(i => i.FIO.Contains(TxtFIO.Text)).ToList();

            switch(CmbFilter.SelectedIndex)
            {
                case 1:
                    list = list.OrderByDescending (i => i.FIO).ToList();
                    break;
                case 2:
                    list = list.OrderBy(i => i.FIO).ToList();
                    break;
                case 3:
                    list = list.OrderByDescending(i => i.Unpaid).ToList();
                    break;
                case 4:
                    list = list.OrderBy(i => i.Unpaid).ToList();
                    break;
                case 5:
                    list = list.OrderByDescending(i => i.SumPenalty).ToList();
                    break;
                case 6:
                    list = list.OrderBy(i => i.SumPenalty).ToList();
                    break;
            }

            LvUserTV.ItemsSource = list;
        }

        private void TxtFIO_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void CmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }
    }
}
