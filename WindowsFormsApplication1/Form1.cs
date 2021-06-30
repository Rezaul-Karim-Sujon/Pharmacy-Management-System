using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        string conn = "datasource=localhost;username=root;password=";
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (nameBox.Text == "" || passBox.Text == "")
            {
                MessageBox.Show("Fields Can not be empty!");
                return;
            }
            MySqlConnection conn2 = new MySqlConnection(conn);
            string query = "SELECT * from med.admin where username COLLATE utf8_bin  = '" + nameBox.Text + "' and password = '" + passBox.Text + "' ";
            MySqlDataAdapter sda = new MySqlDataAdapter(query, conn2);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                Form2 form2 = new Form2();
                this.Hide();
                form2.ShowDialog();
                Close(); 
            }
            else
            {
                MessageBox.Show("Username/password didn't match!");
                return;
            }


         }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
