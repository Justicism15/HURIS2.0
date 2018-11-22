using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HURIS
{
    public class SystemUserController : SystemUserModel
    {

        /// <summary>
        /// ADD USERS
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool AddUser(SystemUserModel data)//(string fname,string lname,string contact)
        {
            cmd = new SqlCommand("usp_UserRegistration");
            cmd.Parameters.AddWithValue("@useraccess", data.Useraccess);
            cmd.Parameters.AddWithValue("@userpassword", data.Userpassword);
            cmd.Parameters.AddWithValue("@empNumber", data.EmployeeNumber);
            cmd.Parameters.AddWithValue("@empType", data.EmployeeType);


            return ExecNonQuery(cmd);
        }

        /// <summary>
        /// View user list
        /// </summary>
        /// <param name="Keywords"></param>
        /// <returns></returns>
        public DataTable ViewUserList(string Keywords)//(string fname,string lname,string contact)
        {
            Keywords = (string.IsNullOrEmpty(Keywords) == true ? "" : Keywords); //inline if-else condition

            //Connecting to  Stored Procedure
            SqlCommand cmd = new SqlCommand("usp_UserSearch");
            //Sends the  parameter keyword to the query
            cmd.Parameters.AddWithValue("@Keywords", Keywords);
            return ExecuteReaderWithParams(cmd);
        }

        public SystemUserController UserUpdateDetails(SystemUserController data)
        {

            cmd = new SqlCommand("usp_UserRecords");
            cmd.Parameters.AddWithValue("@UserID", data.UserID);

            DataTable dt = ExecuteReader(cmd);
            if (dt.Rows.Count > 0)
            {
                data.UserID = Convert.ToInt32(dt.Rows[0]["UserID"]);
                data.Useraccess = dt.Rows[0]["UserName"].ToString();
                data.Userpassword = dt.Rows[0]["UserPassword"].ToString();
                data.EmployeeNumber = dt.Rows[0]["EmployeeNumber"].ToString();
                data.EmployeeType = dt.Rows[0]["UserType"].ToString();
            }
            return data;
        }

        /// <summary>
        /// SAVE THE UPDATED USER DETAILS
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UserDetailsUpdate(SystemUserModel data)//(string fname,string lname,string contact)
        {
            cmd = new SqlCommand("usp_UserDetailsUpdate");
            cmd.Parameters.AddWithValue("@UserID", data.UserID);
            cmd.Parameters.AddWithValue("@useraccess", data.Useraccess);
            cmd.Parameters.AddWithValue("@userpassword", data.Userpassword);
            cmd.Parameters.AddWithValue("@EmployeeNumber", data.EmployeeNumber);
            cmd.Parameters.AddWithValue("@UserType", data.EmployeeType);


            return ExecNonQuery(cmd);
        }




    }
}
