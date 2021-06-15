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
using System.Windows.Threading;
using static AIPS_GIBDD.ClassHelper.PageNavigation;

namespace AIPS_GIBDD.Pages
{
    /// <summary>
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void BtnRefundUser_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new PenaltyPage());

        }

        private void BtnAddTV_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new RegistrationTVPage());

        }

        private void BtnSearchUser_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new SearchPage());
        }

        private void BtnLicence_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Licence());
        }
    }
}
