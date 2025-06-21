using BLL;
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

namespace GUI
{
    /// <summary>
    /// Interaction logic for VolunteerGUI.xaml
    /// </summary>
    public partial class VolunteerGUI : Window
    {
        VolunteerBLL VolunteerBLL = new VolunteerBLL();
        public VolunteerGUI()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtId.Text != "")
            {
                try
                {
                    MessageBox.Show(VolunteerBLL.GetCountHourMonth(txtId.Text).ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("enter valid id");

                }
            }
            else

                MessageBox.Show("enter id volunteer");

        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            int cv, cr,idS=Convert.ToInt32( txtIdService.Text);
            VolunteerBLL.CountVolunteerAndRequestsYearInService(idS,out cr, out cv);
            MessageBox.Show("count Volunteer:" + cv + " count Requests:" + cr);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int Ch;
            float Am; 
            string idV=txtidV.Text;
            VolunteerBLL.CountHoursAndAvgHourLastMonth(idV, out Ch, out Am);
            MessageBox.Show("count Hours:" + Ch + " Avg Month:" + Am);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            showGetUpcomingRequests.ItemsSource = VolunteerBLL.GetUpcomingRequestsForVolunteer(txtidV_1.Text).Select(x => new
            {
                x.Name,
                x.Phone,
                x.Address,
                x.ServiceName,
                x.RequestText,
                x.RequestDate
            }).ToList();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            DVolunteer.ItemsSource = VolunteerBLL.GetVolunteerMaxCountHourMonth(Convert.ToInt32( txtIdSer.Text)).Select(x => new
            { 
                x.IdVolunteer,
                x.Name,
                x.Phone,
            }).ToList();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(VolunteerBLL.GetCount_Unique_Services_By_Volunteer(IdV.Text).ToString());
        }
    }
}
