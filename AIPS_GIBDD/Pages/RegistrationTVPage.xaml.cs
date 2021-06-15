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
using static AIPS_GIBDD.ClassHelper.AppData;

namespace AIPS_GIBDD.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationTVPage.xaml
    /// </summary>
    public partial class RegistrationTVPage : Page
    {
        public RegistrationTVPage()
        {
            InitializeComponent();
        }

        private void TxtNDL_TextChanged(object sender, TextChangedEventArgs e)
        {
            string PhotoUserPath;
            string FIO = context.User.Where(i => i.IdPerson == context.DriverLicence.Where(n => n.NumberDrivingLicence.Equals(TxtNDL.Text)).Select(m => m.IdPerson).FirstOrDefault()).Select(v => v.LastName + " " + v.FirstName + " " + v.Patronymic).FirstOrDefault();
            PhotoUserPath = context.User.Where(i => i.IdPerson == context.DriverLicence.Where(n => n.NumberDrivingLicence.Equals(TxtNDL.Text)).Select(m => m.IdPerson).FirstOrDefault()).Select(v => v.PhotoPath).FirstOrDefault();
            if(FIO != null)
            {
                TxtFIO.Text = FIO;
            }
            else
            {
                TxtFIO.Text = null;
            }
            if (PhotoUserPath != null)
            {
                PhotoUser.Source = new BitmapImage(new Uri(PhotoUserPath, UriKind.Relative));
            }
            else
            {
                PhotoUser.Source = null;
            }
        }
    }
}
