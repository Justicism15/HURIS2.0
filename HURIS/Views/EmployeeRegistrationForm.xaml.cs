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
    /// Interaction logic for EmployeeRegistrationForm.xaml
    /// </summary>
    /// 
    public partial class EmployeeRegistrationForm : Window
    {
        DataTable dt = new DataTable();
        EmployeeModel empmodel = new EmployeeModel();
        EmployeeController empctrl = new EmployeeController();

        public EmployeeRegistrationForm()
        {
            InitializeComponent();
            relativeTab.IsEnabled = false;
            dt.Columns.Add("EmpID", typeof(int));
            dt.Columns.Add("FirstName", typeof(string));
            dt.Columns.Add("LastName", typeof(string));
            dt.Columns.Add("MiddleName", typeof(string));
        }

        private void ClickButtonEvent(object sender, RoutedEventArgs e)
        {
            if(sender == btnSubmit)
            {
                //if (dataGridView1.Items.Count > 0)
              //  {
                    empctrl.FirstName = txtFirstName.Text;
                    empctrl.MiddleName = txtMiddleName.Text;
                    empctrl.LastName = txtLastName.Text;
                    empctrl.Suffix = txtSuffix.Text;
                    empctrl.Gender = txtGender.Text;
                    empctrl.DOB = Convert.ToDateTime(txtDOB.Text);
                    empctrl.EmployeeCode = txtEmpCode.Text;
                    empctrl.PhoneNumber = txtPhone.Text;

                    if (empctrl.AddEmployee(empctrl))
                    {
                        MessageBox.Show("Added Successfully!");
                        empctrl.ViewEmployeeID(empctrl);
                        string empID = empctrl.EmpID.ToString();
                        MessageBox.Show(empID);
                        relativeTab.IsEnabled = true;
                        relativeTab.IsSelected = true;
                    }
                
              //  else
              //  {
               //     MessageBox.Show("Fill out the other form!!");
               // }
            }
            else if(sender == btnAddRelative)
            {
                empctrl.EmployeeCode = txtEmpCode.Text;
                empctrl.ViewEmployeeID(empctrl);
                EmployeeRelativeForm empRel = new EmployeeRelativeForm(empctrl);
                empRel.ShowDialog();

                if(empRel.DialogResult == true)
                {
                    dt.Rows.Add(empRel.cols);
                    this.dataGridView1.ItemsSource = dt.DefaultView; // empctrl.loadTable(dt).DefaultView;
                }
            }
        }

        private void btnClose(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btnEdit(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnDelete(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
