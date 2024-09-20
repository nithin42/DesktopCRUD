using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DesktopCRUD
{
    public static class HelperClass
    {
        // Method to set values into text boxes
        public static void SetTextBoxValuesFromRow(TextBox txtTeacherId, TextBox txtName, TextBox txtAddress, TextBox txtSalary, DataRow row)
        {
            txtTeacherId.Text = row["Id"].ToString();
            txtName.Text = row["Name"].ToString();
            txtAddress.Text = row["Address"].ToString();
            txtSalary.Text = row["Salary"].ToString();
        }
    }
}

