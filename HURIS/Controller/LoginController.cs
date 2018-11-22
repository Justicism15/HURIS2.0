using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;

namespace HURIS
{

  
   public  class LoginController:LoginModel
    {
        DataTable dtItems = new DataTable();
        /// <summary>
        /// to add employee -> pass all required data/parameters.
        /// </summary>
        /// <param name="data">object of employee model</param>
        /// <returns></returns>
        /// 
        //dATATABLE OR
        //public bool Login(LoginModel data)
        //{
        //    cmd = new SqlCommand("usp_EmployeeLogin");
        //    cmd.Parameters.AddWithValue("@Username", data.Username);
        //    cmd.Parameters.AddWithValue("@Password", data.Password);
     
        //    return ExecuteReaderWithParams(cmd);
        //}

        public LoginController UserLogin (LoginController data)
        {
            LoginController emp = new LoginController();
            cmd = new SqlCommand("usp_UserLogin");
            cmd.Parameters.AddWithValue("@UserAccess", data.Useraccess);
            cmd.Parameters.AddWithValue("@UserPassword", data.Userpassword);
            DataTable dt = ExecuteReaderWithParams(cmd);
            if (dt.Rows.Count > 0)
            {
                emp.UserID = Convert.ToInt32(dt.Rows[0]["UserID"].ToString());
                emp.Useraccess = dt.Rows[0]["UserName"].ToString();
                emp.Userpassword= dt.Rows[0]["UserPassword"].ToString();
            }
            return emp;
        }
    }
}
