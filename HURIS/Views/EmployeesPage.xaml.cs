using System;
using HURIS.Views;
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
using System.Data;

namespace HURIS.Views
{
    /// <summary>
    /// Interaction logic for EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        EmployeeModel empModel = new EmployeeModel();
        EmployeeController empCtrl = new EmployeeController();


        DataTable dtEmployee = new DataTable();

        public EmployeePage()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dtEmployee = empCtrl.ViewEmployeeList(txtSearch.Text);
                dataGridView1.ItemsSource = dtEmployee.DefaultView;
            }         
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void ClickButtonEvent(object sender, RoutedEventArgs e)
        {
            try
            {
                //int index = int.Parse(((Button)e.Source).Uid);
                //GridCursor.Margin = new Thickness(-150 + (150 * index), 25, 0, 0);
                //Detects what's the value of sender
                if (sender == btnSearch)
                    LoadData();
                else if (sender == btnAddEmployee)
                {
                    EmployeeRegistrationForm emp = new EmployeeRegistrationForm();
                    emp.Show();
                    LoadData();
                    // SaveData();
                }
               // else if(sender == btnBulk)
              //  {
               //     BulkTest bulk = new BulkTest();
               //     bulk.Show();
              //      LoadData();
               // }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
        }

        private void btnEdit(object sender, MouseButtonEventArgs e)
        {
            DataRowView rowview = dataGridView1.SelectedItem as DataRowView;
            empCtrl.EmpID = Convert.ToInt32(rowview.Row["EmpID"]);
         
            empCtrl = empCtrl.EmployeeUpdateDetails(empCtrl);
            if (empCtrl.EmpID > 0)
            {  //
                EmployeeDetailsEditForm edt = new EmployeeDetailsEditForm(empCtrl);
                edt.Show();
                LoadData();
            }
            else //message box wrong user or password
                MessageBox.Show("Error");
     
        }

        private void btnView(object sender, MouseButtonEventArgs e)
        {
            DataRowView rowview = dataGridView1.SelectedItem as DataRowView;
            empCtrl.EmpID = Convert.ToInt32(rowview.Row["EmpID"]);

            empCtrl = empCtrl.EmployeeUpdateDetails(empCtrl);
            EmployeeDetailsWindow edt = new EmployeeDetailsWindow(empCtrl);
            edt.Show();
        }

    }
}
