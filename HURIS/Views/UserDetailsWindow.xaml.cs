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
    /// Interaction logic for UserDetailsWindow.xaml
    /// </summary>
    public partial class UserDetailsWindow : Window
    {
        SystemUserController userCtrl = new SystemUserController();
        SystemUserModel userModel = new SystemUserModel();

        public UserDetailsWindow(SystemUserController userCtrl)
        {
            InitializeComponent();
            this.userCtrl = userCtrl;
            lblUsername.Content = userCtrl.Useraccess.ToString();
            lblUserID.Content = Convert.ToInt32(userCtrl.UserID.ToString());
            lblEmpNumber.Content = userCtrl.EmployeeNumber.ToString();
            lblUserType.Content = userCtrl.EmployeeType.ToString();

        }

        private void btnClose(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
