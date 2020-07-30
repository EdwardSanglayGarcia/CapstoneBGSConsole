using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneBGSConsole
{
    using System.Data.SqlClient;
    using System.Configuration;

    public class DataAccess
    {

        protected static string constring = ConfigurationManager.ConnectionStrings["CapstoneDemo"].ConnectionString;
        //ABCDEFG HGIJIJIJ
        int TRY;
        /*
         * ABAAA
         */
        int Y;
        protected static SqlConnection con;
        protected static SqlCommand cmd;
        protected static SqlDataAdapter da;
        protected static SqlDataReader dr;
        protected static SqlTransaction trx;
    }
}
