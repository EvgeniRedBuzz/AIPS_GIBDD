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
using static AIPS_GIBDD.ClassHelper.PageNavigation;

namespace AIPS_GIBDD.Pages
{
    /// <summary>
    /// Логика взаимодействия для Account.xaml
    /// </summary>
    public partial class AccountPage : Page
    {
        public AccountPage()
        {
            InitializeComponent();
            UserPhoto.Source = new BitmapImage(new Uri(EmployeePhotoPath, UriKind.Relative));
        }
    }
}
