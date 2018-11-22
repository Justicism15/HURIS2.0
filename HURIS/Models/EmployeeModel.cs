using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HURIS
{
    public class EmployeeModel : DBConnectionController
    {
        public static SqlCommand cmd;
        public int EmpID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string EmployeeNumber { get; set; }
        public string EmployeeType { get; set; }
        public string EmployeeCode { get; set; }
        public string PhoneNumber { get; set; }

        public string Suffix { get; set; }
        public string ContactNo { get; set; }
        public string Useraccess { get; set; }
        public int UserID { get; set; }
        public string Userpassword { get; set; }
        public string Keywords { get; set; }

        public string relFname { get; set; }
        public string relLname { get; set; }
        public string relMname { get; set; }
        public string relAddress { get; set; }
        public string relEmail { get; set; }
        public string relRelationship { get; set; }
        public string relContactNo { get; set; }
        public DataTable bulkTest { get; set; }
    }


    //public class EmployeeModel:EmployeesModel
    //{
    //    public static int EmployeeID { get; set; }
    //}

}
