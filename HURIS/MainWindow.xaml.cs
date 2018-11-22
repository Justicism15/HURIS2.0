using System;
using HURIS.Views;
using System.Data;
using System.Windows;
using System.Data.SqlClient;


namespace HURIS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LoginModel loginmodel = new LoginModel();
        LoginController loginctrl = new LoginController();
        public MainWindow()
        {
            //Initializing and connecting to database.
            InitializeComponent();

        }
       
        private void ClickButtonEvent(object sender, RoutedEventArgs e)
        {
            loginctrl.Useraccess = txtUsername.Text;
            loginctrl.Userpassword = txtPassword.Password;

            if (sender == btnLogin)
            {
                loginctrl = loginctrl.UserLogin(loginctrl);

                if (loginctrl.UserID > 0)
                {
                    Dashboard dash = new Dashboard();
                    dash.Show();
                    this.Close();
                }
                else
                {
                    txtPassword.Password = "";
                    txtUsername.Text = "";
                    MessageBox.Show("Invalid Username or Password!");
                }
            }
        }
    }
}
