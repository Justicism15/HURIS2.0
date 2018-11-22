using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for EmployeeRelativeForm.xaml
    /// </summary>
    public partial class EmployeeRelativeForm : Window
    {
        public DataTable dt = new DataTable();
        public object[] cols = new object[4];
        EmployeeController empCtrl = new EmployeeController();
        EmployeeModel empModel = new EmployeeModel();
        public EmployeeRelativeForm(EmployeeController empCtrl)
        {
            InitializeComponent();

            this.empCtrl = empCtrl;

            txtEmpID.Text = empCtrl.EmpID.ToString();
            dt.Columns.Add("EmpID", typeof(int));
            dt.Columns.Add("FirstName", typeof(string));
            dt.Columns.Add("LastName", typeof(string));
            dt.Columns.Add("MiddleName", typeof(string));
        }

        private void ClickButtonEvent(object sender, RoutedEventArgs e)
        {
            if(sender == btnRelative)
            {
                cols[0] = txtEmpID.Text;
                cols[1] = txtRelFirstName.Text;
                cols[2] = txtLastName.Text;
                cols[3] = txtMiddleName.Text;
                this.DialogResult = true;
            }
        }
    }
}
