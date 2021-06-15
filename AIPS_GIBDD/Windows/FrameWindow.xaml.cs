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
using static AIPS_GIBDD.Pages.StartPage;
using static AIPS_GIBDD.ClassHelper.PageNavigation;

namespace AIPS_GIBDD.Windows
{
    public partial class FrameWindow : Window
    {
        public FrameWindow()
        {
            InitializeComponent();
            
            
        }

        private void BtnShutdown_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы хотите выйти?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Authorization authorization = new Authorization();
                this.Hide();
                authorization.Show();
                this.Close();
            }
        }

        private void BtnSearch_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            frame = MainFrame;
            AccUserPhoto.Source = new BitmapImage(new Uri(EmployeePhotoPath, UriKind.Relative));
            txtFioEmployee.Text = EmployeeeFio;
            frame.Navigate(new Pages.StartPage());
           
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Pages.SearchPage());
            BtnMenu.IsChecked = false;
        }

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                MainFrame.GoBack();
            }
        }

        

        private void BtnAccount_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Pages.AccountPage());
        }

        private void BtnRefund_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Pages.PenaltyPage());
            BtnMenu.IsChecked = false;

        }

        private void BtnAddTV_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Pages.RegistrationTVPage());
            BtnMenu.IsChecked = false;
        }

        private void BtnLicence_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Pages.Licence());
            BtnMenu.IsChecked = false;
        }
    }
}
