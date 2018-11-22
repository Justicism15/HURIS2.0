using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HURIS
{
    public class SystemUserModel : DBConnectionController
    {
        public static SqlCommand cmd;
    
        public string EmployeeNumber { get; set; }
        public string EmployeeType { get; set; }
        public string Useraccess { get; set; }
        public int UserID { get; set; }
        public string Userpassword { get; set; }
        public string Keywords { get; set; }
    }
}
