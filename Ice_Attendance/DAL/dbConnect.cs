using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Ice_Attendance.DAL
{
    class dbConnect
    {
        //  string str = ConfigurationManager.ConnectionStrings["BonanzaString"].ConnectionString;
        string str = @"Data source= ICE-TECH03;Initial Catalog=Ice_Attendance;Integrated Security=true;";
        // string str = @"Data Source=C:\Users\shariq\Documents\Visual Studio 2010\Projects\Bonanaza(ERP)\Bonanaza(ERP)\bin\Debug\ABC.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
        //  string str = "Data source=192.168.2.73;Initial Catalog=Costing; uid =sa; password=ssuet;";
        private SqlConnection sco;
        private SqlDataAdapter adp;

        public dbConnect()
        {
            adp = new SqlDataAdapter();
            // sco  = new SqlConnection(ConfigurationManager.ConnectionStrings
            //  ["App1.config"].ConnectionString);

            sco = new SqlConnection(str);
        }


        public SqlConnection openconnection()
        {
            if (sco.State == ConnectionState.Closed || sco.State ==
        ConnectionState.Broken)
            {
                sco.Open();
            }
            return sco;

        }


        public SqlConnection closeconnection()
        {
            if (sco.State == ConnectionState.Open || sco.State == ConnectionState.Fetching)
            {
                sco.Close();
                sco.Dispose();
            }
            return sco;
        }

    }
}
