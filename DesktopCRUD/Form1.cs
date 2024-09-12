using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DesktopCRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        SqlConnection conn;
        SqlCommand cmd;

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection("Data Source=DESKTOP-R9LR31F;DATABASE=SAMPLEDATA;Integrated Security=True;");
            cmd = new SqlCommand();
            cmd.Connection = conn;
        }


        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            //int a = Convert.ToInt32(txtTeacherId.Text);
            //string b = txtName.Text;
            //string c = txtAddress.Text;
            //int d = Convert.ToInt32(txtSalary.Text);

            string query = $"insert into teacher values('{txtTeacherId.Text.ToString()}','{txtName.Text}','{txtAddress.Text}','{txtSalary.Text.ToString()}')"
;
            cmd.CommandText = query;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            ClearText();
            // Testing for Github
            // Testing for github on 09/12/2024..
        }
       
        public void ClearText()
        {
            txtName.Clear();
            txtAddress.Clear();
            txtSalary.Clear();
            txtTeacherId.Clear();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "update teacher set name='" + txtName.Text + "',Address='" + txtAddress.Text + "',salary='" + txtSalary.Text.ToString() + "' where id='" + txtTeacherId.Text.ToString() + "' ";

                //string query = $"insert into teacher values('{txtTeacherId.Text.ToString()}','{txtName.Text}','{txtAddress.Text}','{txtSalary.Text.ToString()}')"
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                conn.Close();
                ClearText();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
