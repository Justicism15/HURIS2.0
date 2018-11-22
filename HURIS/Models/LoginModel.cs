using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace HURIS
{
    public class LoginModel:DBConnectionController
    {
        public static SqlCommand cmd;
        public int UserID { get; set; }
        public string Useraccess { get; set; }
        public string Userpassword { get; set; }
 }
}
