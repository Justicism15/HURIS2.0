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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HURIS.Views
{
    /// <summary>
    /// Interaction logic for UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        SystemUserController userCtrl = new SystemUserController();
        SystemUserController userModel = new SystemUserController();

        public UsersPage()
        {
            InitializeComponent();
            LoadData();
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
                else if (sender == btnAddUser)
                {
                    UserRegistrationForm emp = new UserRegistrationForm();
                    emp.Show();
                    LoadData();
                    // SaveData();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
        }

        private void btnEdit(object sender, MouseButtonEventArgs e)
        {
            DataRowView rowview = dataGridView1.SelectedItem as DataRowView;
            userCtrl.UserID = Convert.ToInt32(rowview.Row["UserID"]);

            userCtrl = userCtrl.UserUpdateDetails(userCtrl);
            if (userCtrl.UserID > 0)
            {  //
                UserDetailsEditForm edt = new UserDetailsEditForm(userCtrl);
                edt.Show();
                LoadData();
            }
            else //message box wrong user or password
                MessageBox.Show("Error");
        }

        private void btnView(object sender, MouseButtonEventArgs e)
        {
            DataRowView rowview = dataGridView1.SelectedItem as DataRowView;
            userCtrl.UserID = Convert.ToInt32(rowview.Row["UserID"]);

            userCtrl = userCtrl.UserUpdateDetails(userCtrl);
            UserDetailsWindow edt = new UserDetailsWindow(userCtrl);
            edt.Show();
        }

        private void LoadData()
        {
            try
            {
                dataGridView1.ItemsSource = userCtrl.ViewUserList(txtSearch.Text).DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
