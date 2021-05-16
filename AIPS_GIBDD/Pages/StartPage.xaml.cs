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
        private DispatcherTimer timer = null;
        private int x;
        private string Hour;
        private string Minute;
        private string Second;


        private void timerStart()
        {
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            timer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            x++;
            Time();
        }

        private void Time()
        {
            LbTimer.Content = DateTime.Now.ToString();
        }

        public StartPage()
        {
            InitializeComponent();
            timerStart();
            Time();
        }

        private void BtnRefundUser_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new PenaltyPage());
        }
    }
}
