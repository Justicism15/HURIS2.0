using System.Windows;
using HURIS.Views;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;


namespace HURIS.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        LoginController loginCtrl = new LoginController();
        LoginModel loginModel = new LoginModel();
        public Dashboard()
        {
            InitializeComponent();
           // lblUsername.Text ="Welcome, " + label + "!"; 
        }

        private void btnLogout(object sender, RoutedEventArgs e)
        {
            MainWindow win1 = new MainWindow();
            win1.Show();
            this.Close();
        }

        private void btnEmployees(object sender, MouseButtonEventArgs e)
        {
            //Content.Content = new Employees();
            Content.Navigate(new EmployeePage());
            //Sample samp = new Sample();
            //samp.Show();
        }

        private void btnDashboard(object sender, MouseButtonEventArgs e)
        {
            //Content.Content = new DashboardContent();
        }

        private void btnSystemUsers(object sender, MouseButtonEventArgs e)
        {
            Content.Navigate(new UsersPage());
        }

        private void btnPayroll(object sender, MouseButtonEventArgs e)
        {
            // Content.Content = new PayrollManagement();
        }

        private void btnDepartment(object sender, MouseButtonEventArgs e)
        {
            // Content.Navigate(new Department());
        }

        private void btnLeaves(object sender, MouseButtonEventArgs e)
        {
            //Content.Content = new Leaves();
        }

        private void btnAttendance(object sender, MouseButtonEventArgs e)
        {
            // Content.Content = new Attendance();
        }

        private void btnSettings(object sender, MouseButtonEventArgs e)
        {
           // Content.Navigate(new Settings()); eee
        }

        private void btnMaintenance(object sender, MouseButtonEventArgs e)
        {
            Content.Navigate(new Maintenance()); 
        }
    }
}
