using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Ice_Attendance.BAL;

namespace Ice_Attendance
{
    public partial class Form1 : Form
    {
        DataTable dt;
        public Form1()
        {
            InitializeComponent();
        }

        private void ts_btn_AddEmp_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = true;
            tab_Add_Dept.Visible = false;
            tabControl3.Visible = false;
            tabControl4.Visible = false;
        }

        //Initial Interface
        //------------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            tab_Add_Dept.Visible = false;
            tabControl3.Visible = false;
            tabControl4.Visible = false;
            groupBox1.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Visible = false;
            lbl_Dept_ID.Visible = false;
        }
        //-----------------------------------------------------
        private void ts_btn_AddDept_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            tab_Add_Dept.Visible = true;
            tabControl3.Visible = false;
            tabControl4.Visible = false;
        }

        private void ts_btn_AddDesg_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            tab_Add_Dept.Visible = false;
            tabControl3.Visible = true;
            tabControl4.Visible = false;
        }

        private void ts_btn_Report_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            tab_Add_Dept.Visible = false;
            tabControl3.Visible = false;
            tabControl4.Visible = true;
        }

        private void ts_btn_Exit_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void ts_Add_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            designation_Name();
            department_Name();
            txt_Name.Focus();
        }


        public void designation_Name()
        {
            _Add_Employee obj = new Add_Employee();
            dt = new DataTable();
            dt = obj.Designation_Name();
            cb_Desg.DataSource = dt;
            cb_Desg.DisplayMember = "SP_tbl_bin_Designation_Name";
            cb_Desg.ValueMember = "Designation";
        }

        public void department_Name()
        {
            _Add_Employee obj = new Add_Employee();
            dt = new DataTable();
            dt = obj.Department_Name();
            cb_Dept.DataSource = dt;
            cb_Desg.DisplayMember = "SP_tbl_bin_Dept_Name";
            cb_Desg.ValueMember = "Department";
        }

        private void ts_Dept_Add_Click(object sender, EventArgs e)
        {
            groupBox3.Enabled = true;
            txt_Dept_Name.Focus();
        }

        private void ts_Dept_Save_Click(object sender, EventArgs e)
        {
            _Add_Department obj = new Add_Department();
            int result;
            try
            {
                result = obj.insert(txt_Dept_Name.Text);
                if (result == 0)
                {
                    MessageBox.Show("The Record Is Not Save", "Not Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    department_Search();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                obj = null;
            }
        }

        public void department_Search()
        {
            _Add_Department obj = new Add_Department();
            dt = new DataTable();
            try
            {
                dt = obj.search();

                dGV_Department.Columns[0].Name = "Column1";
                dGV_Department.Columns[0].HeaderText = "S.NO";
                dGV_Department.Columns[0].DataPropertyName = "S.NO";

                dGV_Department.Columns[1].Name = "Column2";
                dGV_Department.Columns[1].HeaderText = "Department Name";
                dGV_Department.Columns[1].DataPropertyName = "Department Name";

                dGV_Department.DataSource = dt;
                dGV_Department.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                obj = null;
            }
        }

        private void ts_Dept_Update_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
            _Add_Department obj = new Add_Department();
            int result;
            try
            {
                result = obj.update(txt_Dept_Name.Text, lbl_Dept_ID.Text);
                if (result == 0)
                {
                    MessageBox.Show("The Record is Not Updated", "Not Updated", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("The Record Is Updated", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txt_Dept_Name.Text = "";
                    txt_Dept_Name.Focus();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                obj = null;
            }
        }

        private void ts_Dept_Search_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
            department_Search();
        }

        private void ts_Dept_Cancel_Click(object sender, EventArgs e)
        {
            groupBox3.Enabled = false;
            groupBox4.Visible = false;
        }

        private void ts_Dept_Close_Click(object sender, EventArgs e)
        {
            
        }



    }
}
