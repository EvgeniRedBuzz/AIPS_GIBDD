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
using AIPS_GIBDD.Windows;
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
            filter.Add("Дата (по убыванию)");
            filter.Add("Дата(по возрастанию)");
            CmbFilter.ItemsSource = filter;
            Filter();
        }

        private void Filter()
        {
            var list = context.AllPenalty.Where(i => i.FIO.Contains(TxtFIO.Text)).ToList();
            if (DatePickReceipt.SelectedDate != null)
            {
                list = list.Where(i => i.DateOfReceipt.Date == DatePickReceipt.SelectedDate).ToList();
            }
            if (CheckColor.IsChecked == true)
            {
                LvUserTV.Visibility = Visibility.Collapsed;
                LvUserTV2.Visibility = Visibility.Visible;
            }
            else
            {
                LvUserTV2.Visibility = Visibility.Collapsed;
                LvUserTV.Visibility = Visibility.Visible;
            }
            switch(CmbFilter.SelectedIndex)
            {
                case 1:
                    list = list.OrderByDescending(i => i.FIO).ToList();
                    break;
                case 2:
                    list = list.OrderBy(i => i.FIO).ToList();
                    break;
                case 3:
                    list = list.OrderBy(i => i.DateOfReceipt).ToList();
                    break;
                case 4:
                    list = list.OrderByDescending(i => i.DateOfReceipt).ToList();
                    break;
            }
            LvUserTV.ItemsSource = list;
            LvUserTV2.ItemsSource = list;
        }

        private void TxtFIO_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void CmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void AddPenalty_Click(object sender, RoutedEventArgs e)
        {
            AddPenaltyWin addPenaltyWin = new AddPenaltyWin();
            addPenaltyWin.ShowDialog();
        }
    }
}
