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
        List<EF.Color> colors = new List<EF.Color>();
        public SearchPage()
        {
            InitializeComponent();
            brands = context.BrandTV.ToList();
            brands.Insert(0, new BrandTV() { NameBrand = "Все" });
            CmbBrand.ItemsSource = brands;
            CmbBrand.DisplayMemberPath = "NameBrand";
            CmbBrand.SelectedIndex = 0;
            colors = context.Color.ToList();
            colors.Insert(0, new EF.Color() { NameColor = "Все" });
            CmbColor.ItemsSource = colors;
            CmbColor.SelectedIndex = 0;
            CmbColor.DisplayMemberPath = "NameColor";
            models = context.ModelTV.ToList();
            models.Insert(0, new ModelTV() { NameModel = "Все" });
            CmbModel.ItemsSource = models;
            CmbModel.SelectedIndex = 0;
            CmbModel.DisplayMemberPath = "NameModel";
            Filter();
        }

        private void Filter()
        {
            var ListUserTV = context.UserTransportVehicle.ToList();
            ListUserTV = ListUserTV.Where(i => i.FIO.Contains(TxtFIO.Text) &&
                                          i.VIN.Contains(TxtVIN.Text) &&
                                          i.NumberTransportVehicle.Contains(TxtNumber.Text)).ToList();
            if (CmbBrand.SelectedIndex != 0)
            {
                ListUserTV = ListUserTV.Where(i => i.IdBrand == CmbBrand.SelectedIndex).ToList();
            }
            if (CmbModel.SelectedIndex != 0)
            {
                ListUserTV = ListUserTV.Where(i => i.Model == CmbModel.Text).ToList();
            }
            if (CmbColor.SelectedIndex != 0)
            {
                ListUserTV = ListUserTV.Where(i => i.Color == CmbColor.Text).ToList();
            }
            LvUserTV.ItemsSource = ListUserTV;
        }

        private void CmbBrand_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void CmbModel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void CmbColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            Filter();
        }

        private void TxtNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void TxtVIN_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void TxtFIO_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }
    }
}
