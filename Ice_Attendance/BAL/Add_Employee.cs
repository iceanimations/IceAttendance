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
    /* This class is used for the add employee form and it contains all the data regarding to add employee form*/
    interface _Add_Employee 
    {
        int insert(string txt1, string txt2, string txt3, string txt4, string txt5, string txt6, string txt7, string txt8, string txt9);
        DataTable Department_ID(string txt1);
        DataTable Designation_ID(string txt1);
        DataTable Designation_Name();
        DataTable Department_Name();
        DataTable emp_Auto_ID();
        DataTable emp_View();
    }
    class Add_Employee: _Add_Employee
    {

        SqlDataAdapter adp;
        DataSet ds;
        DataTable dt;
        SqlCommand scom;
        dbConnect obj = new dbConnect();


        //Abhi shift aur employee code id ka kaam baqi hai
        public int insert(string txt1, string txt2, string txt3, string txt4, string txt5, string txt6, string txt7, string txt8, string txt9)
        {
            string str1 = "SP_tbl_bin_Employee_Add";
            int result;
            scom = new SqlCommand(str1, obj.openconnection());
            scom.CommandType = CommandType.StoredProcedure;
            scom.Parameters.Add("@Emp_Name", SqlDbType.VarChar).Value = txt1;
            scom.Parameters.Add("@Emp_Father_name", SqlDbType.VarChar).Value = txt2;
            scom.Parameters.Add("@Emp_Date_Of_Birth", SqlDbType.VarChar).Value = txt3;
            scom.Parameters.Add("@Designation_ID", SqlDbType.Int).Value = txt4;
            scom.Parameters.Add("@Dept_ID", SqlDbType.Int).Value = txt5;
            scom.Parameters.Add("@Emp_CNIC", SqlDbType.VarChar).Value = txt6;
            scom.Parameters.Add("@Emp_Address", SqlDbType.VarChar).Value = txt7;
            scom.Parameters.Add("@Emp_Contact_No", SqlDbType.VarChar).Value = txt8;
            scom.Parameters.Add("@Employee_Code_ID", SqlDbType.VarChar).Value = txt9;

            result = scom.ExecuteNonQuery();
            obj.closeconnection();
            return result;
        }



        // To bring department id into the table of add employee
        public DataTable Department_ID(string txt1)
        {
            string str1 = "SP_tbl_bin_Select_Dept_ID";
            adp = new SqlDataAdapter(str1, obj.openconnection());
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@Dept_Name", SqlDbType.VarChar).Value = txt1;
            dt = new DataTable();
            adp.Fill(dt);
            obj.closeconnection();
            return dt;
        }

        //to bring designation id into the table of add employee
        public DataTable Designation_ID(string txt1)
        {
            string str1 = "SP_tbl_bin_Select_Desg_ID";
            adp = new SqlDataAdapter(str1, obj.openconnection());
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.Add("@Designation_Name", SqlDbType.VarChar).Value = txt1;
            dt = new DataTable();
            adp.Fill(dt);
            obj.closeconnection();
            return dt;
        }

        //Bringing Designations
        public DataTable Designation_Name()
        {
            string str1 = "SP_tbl_bin_Designation_Name";
            adp = new SqlDataAdapter(str1, obj.openconnection());
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt = new DataTable();
            adp.Fill(dt);
            obj.closeconnection();
            return dt;
        }

        //Bringing departments
        public DataTable Department_Name()
        {
            string str1 = "SP_tbl_bin_Dept_Name";
            adp = new SqlDataAdapter(str1, obj.openconnection());
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt = new DataTable();
            adp.Fill(dt);
            obj.closeconnection();
            return dt;
        }

        //Method for fetching employee id automatically
        public DataTable emp_Auto_ID()
        {
            string str1 = "SP_tbl_bin_Employee_Auto_ID";
            adp = new SqlDataAdapter(str1, obj.openconnection());
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt = new DataTable();
            adp.Fill(dt);
            obj.closeconnection();
            return dt;
        }
        // Method for fetching all the data to show in gridview
        public DataTable emp_View()
        {
            string str1 = "SP_tbl_bin_Employee_View";
            adp = new SqlDataAdapter(str1, obj.openconnection());
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt = new DataTable();
            adp.Fill(dt);
            obj.closeconnection();
            return dt;

        }
    }
}
