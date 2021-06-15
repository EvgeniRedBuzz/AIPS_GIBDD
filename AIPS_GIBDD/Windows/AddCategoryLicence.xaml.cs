using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для AddCategoryLicence.xaml
    /// </summary>
    public partial class AddCategoryLicence : Window
    {
        ObservableCollection<CategoryTV> supplierList = new ObservableCollection<CategoryTV>();
        public AddCategoryLicence()
        {
            InitializeComponent();
            CmbCategory.ItemsSource = context.CategoryTV.ToList();
            CmbCategory.DisplayMemberPath = "IndexCategory";
            LvCategory.ItemsSource = context.DrivingLicenceCategory.Where(i => i.NumberDrivingLicence.Equals(NumberDL)).ToList();
        }
    }
}
