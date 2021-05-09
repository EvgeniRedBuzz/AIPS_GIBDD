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
using static AIPS_GIBDD.ClassHelper.AppData;

namespace AIPS_GIBDD.Pages
{
    /// <summary>
    /// Логика взаимодействия для TestPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        List<BrandTV> brands = new List<BrandTV>();
        List<ModelTV> models = new List<ModelTV>();
        public SearchPage()
        {
            InitializeComponent();
            brands = context.BrandTV.OrderBy(i => i.NameBrand).ToList();
            brands.Insert(0, new BrandTV() { NameBrand = "Все" });
            CmbBrand.ItemsSource = brands;
            CmbBrand.DisplayMemberPath = "NameBrand";
            CmbBrand.SelectedIndex = 0;
            Filter();
            CmbModel.SelectedIndex = 0;
            CmbModel.DisplayMemberPath = "NameModel";
        }

        private void Filter()
        {
            if (CmbBrand.SelectedIndex == 0)
            {
                models = context.ModelTV.ToList();
                models.Insert(0, new ModelTV() { NameModel = "Все" });
                CmbModel.SelectedIndex = 0;
            }
            else
            {
                models = context.ModelTV.Where(i => i.IdBrandTV == CmbBrand.SelectedIndex).OrderBy(i => i.NameModel).ToList();
                models.Insert(0, new ModelTV() { NameModel = "Все" });
                CmbModel.SelectedIndex = 0;
            }

            CmbModel.ItemsSource = models;

            LvUserTV.ItemsSource = context.UserTransportVehicle.OrderByDescending(i => i.DateReceipt).ToList();
        }

        private void CmbBrand_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }
    }
}
