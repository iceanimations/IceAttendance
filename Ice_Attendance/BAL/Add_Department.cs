using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Ice_Attendance.DAL;

namespace Ice_Attendance.BAL
{
    interface _Add_Department 
    {
        int insert(string txt1);
        int update(string txt1, string txt2);
        DataTable search();

    }
    class Add_Department : _Add_Department
    {
        SqlDataAdapter adp;
        DataSet ds;
        DataTable dt;
        SqlCommand scom;
        dbConnect obj = new dbConnect();

        public int insert(string txt1) 
        {
            string str1 = "SP_tbl_bin_Department_Add";
            int result;
            scom = new SqlCommand(str1, obj.openconnection());
            scom.CommandType = CommandType.StoredProcedure;
            scom.Parameters.Add("@Dept_Name", SqlDbType.VarChar).Value = txt1;
            result = scom.ExecuteNonQuery();
            obj.closeconnection();
            return result;
        }

        public int update(string txt1, string txt2)
        {
            string str1 = "SP_tbl_bin_Department_Edit";
            int result;
            scom = new SqlCommand(str1, obj.openconnection());
            scom.CommandType = CommandType.StoredProcedure;
            scom.Parameters.Add("@Dept_Name", SqlDbType.VarChar).Value = txt1;
            scom.Parameters.Add("@Dept_ID", SqlDbType.Int).Value = txt2;
            result = scom.ExecuteNonQuery();
            obj.closeconnection();
            return result;
        }

        public DataTable search()
        {
            string str1 = "SP_tbl_bin_Department_View";
            adp = new SqlDataAdapter(str1, obj.openconnection());
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt = new DataTable();
            adp.Fill(dt);
            obj.closeconnection();
            return dt;
        }


    }
}
