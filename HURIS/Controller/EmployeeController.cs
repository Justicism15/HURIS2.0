using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace HURIS
{
    public class EmployeeController : EmployeeModel
    {

        public DataTable loadTable(DataTable dt)
        {
            return dt;
        }
        /// <summary>
        /// to add employee -> pass all required data/parameters.
        /// </summary>
        /// <param name="data">object of employee model</param>
        /// <returns></returns>
        public bool AddEmployee(EmployeeModel data)//(string fname,string lname,string contact)
        {
            cmd = new SqlCommand("usp_EmployeeRegistration");
            cmd.Parameters.AddWithValue("@fname", data.FirstName);
            cmd.Parameters.AddWithValue("@lname", data.LastName);
            cmd.Parameters.AddWithValue("@gender", data.Gender);
            cmd.Parameters.AddWithValue("@dob", data.DOB.ToShortDateString());
            cmd.Parameters.AddWithValue("@suffix", data.Suffix);
            cmd.Parameters.AddWithValue("@mname", data.MiddleName);
            cmd.Parameters.AddWithValue("@empcode", data.EmployeeCode);
            cmd.Parameters.AddWithValue("@phone", data.PhoneNumber);

            return ExecNonQuery(cmd);
        }



        public bool EmployeeDetailsUpdate(EmployeeModel data)//(string fname,string lname,string contact)
        {
            cmd = new SqlCommand("usp_EmployeeDetailsUpdate");
            cmd.Parameters.AddWithValue("@EmpID", data.EmpID);
            cmd.Parameters.AddWithValue("@fname", data.FirstName);
            cmd.Parameters.AddWithValue("@lname", data.LastName);
            cmd.Parameters.AddWithValue("@gender", data.Gender);
            cmd.Parameters.AddWithValue("@dob", data.DOB);
            cmd.Parameters.AddWithValue("@suffix", data.Suffix);
            cmd.Parameters.AddWithValue("@mname", data.MiddleName);
            cmd.Parameters.AddWithValue("@empNumber", data.EmployeeNumber);
            cmd.Parameters.AddWithValue("@empType", data.EmployeeType);

            return ExecNonQuery(cmd);
        }

        public DataTable ViewEmployeeList(string Keywords)//(string fname,string lname,string contact)
        {
            Keywords = (string.IsNullOrEmpty(Keywords) == true ? "" : Keywords); //inline if-else condition

            //Connecting to  Stored Procedure
            SqlCommand cmd = new SqlCommand("usp_EmployeeSearch");
            
            //Sends the  parameter keyword to the query
            cmd.Parameters.AddWithValue("@Keywords",Keywords);
            return ExecuteReaderWithParams(cmd);
        }


        /// <summary>
        /// to PASS ID FROM EMPLOYEE TO RELATIVE FORMS
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>

        public EmployeeController ViewEmployeeID(EmployeeController data)
        {
         
            cmd = new SqlCommand("usp_GetEmployeeID");
            cmd.Parameters.AddWithValue("@empCode", data.EmployeeCode);

            DataTable dt = ExecuteReader(cmd);
            if (dt.Rows.Count > 0)
            {
                data.EmpID = Convert.ToInt32(dt.Rows[0]["EmpID"]);
            }
            return data;
        }



        /// <summary>
        /// to view specific information of employee
        /// </summary>
        /// <param name="StudentID">primary of employee to search in db</param>
        /// <returns></returns>
        /// 


        public EmployeeController EmployeeUpdateDetails(EmployeeController data)
        {
          
            cmd = new SqlCommand("usp_EmployeeIndividualRecord");
            cmd.Parameters.AddWithValue("@EmpID", data.EmpID);

            DataTable dt = ExecuteReader(cmd);
            if (dt.Rows.Count > 0)
            {
                data.EmpID = Convert.ToInt32(dt.Rows[0]["EmpID"]);
                data.FirstName = dt.Rows[0]["FirstName"].ToString();
                data.LastName = dt.Rows[0]["LastName"].ToString();
                data.MiddleName = dt.Rows[0]["Middlename"].ToString();
                data.Suffix = dt.Rows[0]["Suffix"].ToString();
                data.DOB = Convert.ToDateTime(dt.Rows[0]["Birthdate"]);
                data.Gender = dt.Rows[0]["Gender"].ToString();
                data.EmployeeCode = dt.Rows[0]["EmpCode"].ToString();
                data.PhoneNumber = dt.Rows[0]["PhoneNo"].ToString();

            }
            return data;
        }

        public bool bulkTestFunc(DataTable data)
        {
            cmd = new SqlCommand("usp_TestBulkInsert");
            cmd.Parameters.AddWithValue("@dtItems", data);

            return ExecNonQuery(cmd);
        }


    }
}
