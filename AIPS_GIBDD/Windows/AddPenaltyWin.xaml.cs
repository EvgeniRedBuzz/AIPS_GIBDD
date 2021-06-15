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
using static AIPS_GIBDD.ClassHelper.AppData;
using static AIPS_GIBDD.ClassHelper.PageNavigation;

namespace AIPS_GIBDD.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddPenaltyWin.xaml
    /// </summary>
    public partial class AddPenaltyWin : Window
    {
        public AddPenaltyWin()
        {
            InitializeComponent();
            CmbArticle.ItemsSource = context.Article.ToList();
            CmbArticle.DisplayMemberPath = "ArticleNumber";
            CmbArticle.SelectedIndex = 0;
        }

        private void AddPenalty_Click(object sender, RoutedEventArgs e)
        {
            if (TxtNDL.Text != null)
            {
                context.Penalty.Add(new EF.Penalty
                {
                    NumberDrivingLicence = TxtNDL.Text,
                    IdEmployee = EmployeeID,
                    Location = TxtLocation.Text,
                    DateOfReceipt = DateTime.Now,
                    IdArticle = CmbArticle.SelectedIndex
                });
                context.SaveChanges();
            }
        }

        private void CmbArticle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TxtDesc.Text = context.Article.Where(i => i.IdArticle == (CmbArticle.SelectedIndex + 1)).Select(n => n.Description).FirstOrDefault();
            TxtCost.Text = Convert.ToString(context.Article.Where(i => i.IdArticle == (CmbArticle.SelectedIndex + 1)).Select(n => n.Cost).FirstOrDefault());
        }
    }
}
