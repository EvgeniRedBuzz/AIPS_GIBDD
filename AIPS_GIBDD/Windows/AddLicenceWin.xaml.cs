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
using AIPS_GIBDD.EF;
using static AIPS_GIBDD.ClassHelper.AppData;
using static AIPS_GIBDD.ClassHelper.PageNavigation;

namespace AIPS_GIBDD.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddLicenceWin.xaml
    /// </summary>
    public partial class AddLicenceWin : Window
    {
        public AddLicenceWin()
        {
            InitializeComponent();
            CmbGender.ItemsSource = context.Gender.ToList();
            CmbGender.DisplayMemberPath = "GenderName";
            CmbDepart.ItemsSource = context.Department.ToList();
            CmbDepart.DisplayMemberPath = "NameDepartment";
        }
    }
}
