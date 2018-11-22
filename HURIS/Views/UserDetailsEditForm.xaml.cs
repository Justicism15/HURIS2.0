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
    /// Interaction logic for UserDetailsEditForm.xaml
    /// </summary>
    public partial class UserDetailsEditForm : Window
    {
        SystemUserController userCtrl = new SystemUserController();
        SystemUserController userModel = new SystemUserController();

        public UserDetailsEditForm(SystemUserController userCtrl)
        {
            InitializeComponent();
            this.userCtrl = userCtrl;
            txtUserID.Text = userCtrl.UserID.ToString();
            txtUsername.Text = userCtrl.Useraccess;
            txtPassword.Password = userCtrl.Userpassword;
            txtEmpNumber.Text = userCtrl.EmployeeNumber;
            txtUserType.Text = userCtrl.EmployeeType;
        }

        private void btnClose(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void ClickButtonEvent(object sender, RoutedEventArgs e)
        {
            if(sender == btnSave)
            {
                userCtrl.UserID = int.Parse(txtUserID.Text); ;
                userCtrl.Useraccess = txtUsername.Text;
                userCtrl.Userpassword = txtPassword.Password;
                userCtrl.EmployeeType = txtUserType.Text;
                userCtrl.EmployeeNumber = txtEmpNumber.Text;
   
                if (userCtrl.UserDetailsUpdate(userCtrl))
                {
                    MessageBox.Show("Record Updated Successfully!");
                    this.Close();
                }
                else
                    MessageBox.Show("Error!");
            }
        }
        
    }
}
