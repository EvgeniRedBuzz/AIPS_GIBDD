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
using static AIPS_GIBDD.ClassHelper.PageNavigation;
using static AIPS_GIBDD.ClassHelper.AppData;

namespace AIPS_GIBDD.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        
        

        public Authorization()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            
            var log = context.Employee.Where(i => i.Login.Equals(TxtLog.Text) &&
                              i.Password.Equals(TxtPass.Password)).ToList();
            int idEmployee = context.Employee.Where(i => i.Login.Equals(TxtLog.Text) &&
                         i.Password.Equals(TxtPass.Password)).Select(n => n.IdPerson).FirstOrDefault();

            EmployeePhotoPath = context.User.Where(i => i.IdPerson == idEmployee).Select(n => n.PhotoPath).FirstOrDefault();
            EmployeeID = idEmployee;
            EmployeeeFio = context.User.Where(i => i.IdPerson == idEmployee).Select(n => n.LastName).FirstOrDefault() + " " +
                context.User.Where(i => i.IdPerson == idEmployee).Select(n => n.FirstName).FirstOrDefault() + " " +
                context.User.Where(i => i.IdPerson == idEmployee).Select(n => n.Patronymic).FirstOrDefault();
            if (log.Count > 0)
            {
                FrameWindow frameWindow = new FrameWindow();
                this.Hide();
                frameWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnShutdown_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы хотите выйти?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Close();
            }
        }
    }
}
