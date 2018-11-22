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
    /// Interaction logic for UserRegistrationForm.xaml
    /// </summary>
    public partial class UserRegistrationForm : Window
    {

        SystemUserController userCtrl = new SystemUserController();
        SystemUserController userModel = new SystemUserController();
        public UserRegistrationForm()
        {
            InitializeComponent();
        }

        private void ClickButtonEvent(object sender, RoutedEventArgs e)
        {
            if(sender == btnSave)
            {

                userCtrl.EmployeeNumber = txtEmpNumber.Text;
                userCtrl.Useraccess = txtUsername.Text;
                userCtrl.Userpassword = txtPassword.Password;
                userCtrl.EmployeeType = txtUserType.Text;


                if (userCtrl.AddUser(userCtrl))
                {
                    MessageBox.Show("User Added Successfully!");
                    this.Close();
                }
                else
                    MessageBox.Show("Error");
            }
        }

        private void btnClose(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
