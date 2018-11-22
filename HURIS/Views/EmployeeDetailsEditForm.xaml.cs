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
    /// Interaction logic for EmployeeDetailsEditForm.xaml
    /// </summary>
    public partial class EmployeeDetailsEditForm : Window
    {
        EmployeeModel empModel = new EmployeeModel();
        EmployeeController empCtrl = new EmployeeController();

        public EmployeeDetailsEditForm(EmployeeController empCtrl)
        {
            InitializeComponent();

            this.empCtrl = empCtrl;
            txtEmpID.Text = empCtrl.EmpID.ToString();
            txtFirstName.Text = empCtrl.FirstName;
            txtLastName.Text = empCtrl.LastName;
            txtMiddleName.Text = empCtrl.MiddleName;
            txtSuffix.Text = empCtrl.Suffix;
            txtDOB.Text = Convert.ToString(empCtrl.DOB);
            txtGender.Text = empCtrl.Gender;
            txtEmpCode.Text = empCtrl.EmployeeCode;
            txtPhone.Text = empCtrl.PhoneNumber;
        }

        private void ClickButtonEvent(object sender, RoutedEventArgs e)
        {
            if(sender == btnSubmit)
            {
                empCtrl.EmpID = int.Parse(txtEmpID.Text); ;
                empCtrl.FirstName = txtFirstName.Text;
                empCtrl.LastName = txtLastName.Text;
                empCtrl.MiddleName = txtMiddleName.Text;
                empCtrl.Suffix = txtSuffix.Text;
                empCtrl.Gender = txtGender.Text;
                empCtrl.DOB = Convert.ToDateTime(txtDOB.Text);
                empCtrl.EmployeeCode = txtEmpCode.Text;
                empCtrl.PhoneNumber = txtPhone.Text;

             

                if (empCtrl.EmployeeDetailsUpdate(empCtrl))
                {
                    MessageBox.Show("Record Updated Successfully!");
                    this.Close();
                }
                else
                    MessageBox.Show("Error!");
            }
        }

        private void btnClose(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
