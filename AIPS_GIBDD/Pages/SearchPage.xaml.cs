﻿using System;
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
            GetModel();
            Filter();
        }
        

        private void GetModel()
        {
            if (CmbBrand.SelectedIndex == 0)
            {
                models = context.ModelTV.ToList();
                models.Insert(0, new ModelTV() { NameModel = "Все" });

            }
            else
            {
                models = context.ModelTV.Where(i => i.IdBrandTV == CmbBrand.SelectedIndex).ToList();
                models.Insert(0, new ModelTV() { NameModel = "Все" });

            }
            CmbModel.ItemsSource = models;
            CmbModel.DisplayMemberPath = "NameModel";
            if (CmbModel.SelectedItem == null)
            {
                CmbModel.SelectedItem = "Все";
            }
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

            LvUserTV.ItemsSource = ListUserTV;
        }

        private void CmbBrand_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetModel();
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
    }
}
