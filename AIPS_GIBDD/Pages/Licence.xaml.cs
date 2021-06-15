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
using AIPS_GIBDD.EF;
using AIPS_GIBDD.Windows;
using static AIPS_GIBDD.ClassHelper.AppData;

namespace AIPS_GIBDD.Pages
{
    /// <summary>
    /// Логика взаимодействия для Licence.xaml
    /// </summary>
    public partial class Licence : Page
    {
        List<CategoryTV> categoryTVs = new List<CategoryTV>();

        public Licence()
        {
            InitializeComponent();
            categoryTVs = context.CategoryTV.ToList();
            categoryTVs.Insert(0, new CategoryTV { IndexCategory = "Все" });
            CmbCategory.ItemsSource = categoryTVs;
            CmbCategory.DisplayMemberPath = "IndexCategory";
            CmbCategory.SelectedIndex = 0;
            Filter();
        }

        private void Filter()
        {
            var UserDL = context.UserDriverLicence.Where(i => i.FIO.Contains(TxtFIO.Text) &&
            i.NumberDrivingLicence.Contains(TxtNumberDL.Text)).ToList();
            LvUserTV.ItemsSource = UserDL;
        }

        private void TxtFIO_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void TxtNumberDL_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void CmbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void AddLicence_Click(object sender, RoutedEventArgs e)
        {
            AddLicenceWin addLicenceWin = new AddLicenceWin();
            addLicenceWin.ShowDialog();
        }

        private void AddCategoryLicence_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddCategoryLicence addCategoryLicence = new AddCategoryLicence();
            addCategoryLicence.ShowDialog();
        }
    }
}
