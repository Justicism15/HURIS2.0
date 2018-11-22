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

namespace HURIS.Views
{
    /// <summary>
    /// Interaction logic for EmployeeDetailsWindow.xaml
    /// </summary>
    public partial class EmployeeDetailsWindow : Window
    {
        EmployeeController empCtrl = new EmployeeController();
        EmployeeModel empModel = new EmployeeModel();

        public EmployeeDetailsWindow(EmployeeController empCtrl)
        {
            InitializeComponent();
            this.empCtrl = empCtrl;
            lblName.Content = empCtrl.FirstName.ToString() + " " + empCtrl.LastName.ToString();
            lblMiddleName.Content = empCtrl.MiddleName.ToString();
            lblSuffix.Content = empCtrl.Suffix.ToString();
            lblDOB.Content = empCtrl.DOB.ToString();
            lblEmpCode.Content = empCtrl.EmployeeCode.ToString();
            lblPhone.Content = empCtrl.PhoneNumber.ToString();
            lblGender.Content = empCtrl.Gender.ToString(); 
        }

        private void btnClose(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
