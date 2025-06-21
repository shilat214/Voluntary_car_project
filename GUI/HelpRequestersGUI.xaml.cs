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
    /// Interaction logic for HelpRequestersGUI.xaml
    /// </summary>
    public partial class HelpRequestersGUI : Window
    {
        CarHelpRequestersBLL CarHelpRequestersBLL=new CarHelpRequestersBLL();
        public HelpRequestersGUI()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(CarHelpRequestersBLL.IsServiceHoursSufficientThisMonth(Convert.ToInt32(txtId.Text))==true?"True":"False");
        }
    }
}
