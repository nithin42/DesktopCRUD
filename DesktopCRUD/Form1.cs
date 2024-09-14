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
            string query = $"delete teacher where id='{txtTeacherId.Text.ToString()}'";
            cmd.CommandText = query;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            ClearText();
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
            //clearname
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

        private void BtnShowAll_Click(object sender, EventArgs e)
        {
            string query = $"select * from teacher where id='{txtTeacherId.Text.ToString()}'";
            cmd.CommandText = query;
            try
            {
                // Open the connection
                conn.Open();

                // Execute the query and retrieve the data
                SqlDataReader reader = cmd.ExecuteReader();

                // If the data is available, read it and display in the fields
                if (reader.Read())
                {
                    txtName.Text = reader["Name"].ToString();
                    txtAddress.Text = reader["Address"].ToString();
                    txtSalary.Text = reader["Salary"].ToString();
                }
                else
                {
                    MessageBox.Show("No data found for the given TeacherId.");
                }

                // Close the reader
                reader.Close();
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                // Ensure the connection is closed
                conn.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void BtnDisplay_Click(object sender, EventArgs e)
        {
              // The query to select all data from the teacher table
            string query = "SELECT * FROM teacher";

            // Set the command query
            cmd.CommandText = query;

            try
            {
                // Open the connection
                conn.Open();

                // Create a data adapter to execute the query and fill the data into a DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                // Create a DataTable to hold the query result
                DataTable dataTable = new DataTable();

                // Fill the DataTable with the query result
                adapter.Fill(dataTable);

                // Bind the DataTable to the DataGridView to display the data
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                // Ensure the connection is closed
                conn.Close();
            }
        }
    }
}
