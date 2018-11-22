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
    /// Interaction logic for BulkTest.xaml
    /// </summary>
    public partial class BulkTest : Window
    {
        EmployeeController empCtrl = new EmployeeController();
        EmployeeModel empModel = new EmployeeModel();

        DataTable dt = new DataTable();

        public BulkTest()
        {
            InitializeComponent();
            dt.Columns.AddRange(new DataColumn[2] {new DataColumn("ID",typeof(int)),
            new DataColumn("FirstName",typeof(string))});
        }

        private void ClickButtonHandler(object sender, RoutedEventArgs e)
        {
            if (sender == btnSave)
            {
                dt.Rows.Add(txtID.Text, txtFname.Text);
                this.dataGrid1.ItemsSource = dt.DefaultView;
            }
            else if (sender == btnBulkInsert)
            {
                empCtrl.bulkTestFunc(dt);
            }
        }

        //   private DataTable GetDataTable()
        //    {
        //        DataTable tbl = new DataTable();

        //        tbl.Columns.Add("ID", typeof(int));
        //        tbl.Columns.Add("FirstName", typeof(string));

        //        for (int i = 0; i < tbl.Rows.Count; i++)
        //        {

        //        return tbl;
        //    } 
        //}
    }
}
