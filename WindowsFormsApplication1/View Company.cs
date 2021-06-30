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
    public partial class View_Company : Form
    {
        string search_query = "";
        string conn = "datasource=localhost;username=root;password=";
        public View_Company()
        {
            InitializeComponent();
            display();
            nameBox.ReadOnly = true;
            address_Box.ReadOnly = true;
           
            
            contactBox.ReadOnly = true;
            mailBox.ReadOnly = true;
           mobileBox.ReadOnly = true;
          
        }

        private void searchIDBox_TextChanged(object sender, EventArgs e)
        {
            if (searchIDBox.Text != "" && searchnameBox.Text == "")
            {
                search_query = "select * from med.company where id LIKE '%" + searchIDBox.Text + "%'";
                display();
            }
            else if (searchIDBox.Text != "" && searchnameBox.Text != "")
            {

                search_query = "select * from med.company where id LIKE '%" + searchIDBox.Text + "%' and name LIKE '%" + searchnameBox.Text + "%' ";
                display();
            }
            else
            {
                search_query = "";
                display();
            }
        }

        private void searchnameBox_TextChanged(object sender, EventArgs e)
        {
            if (searchIDBox.Text == "" && searchnameBox.Text != "")
            {
                search_query = "select * from med.company where name LIKE '%" + searchnameBox.Text + "%'";
                display();
            }
            else if (searchIDBox.Text != "" && searchnameBox.Text != "")
            {

                search_query = "select * from med.company where id LIKE '%" + searchIDBox.Text + "%' and name LIKE '%" + searchnameBox.Text + "%' ";
                display();
            }
            else
            {
                search_query = "";
                display();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;

            nameBox.Text = dataGridView1.Rows[r].Cells[1].Value.ToString();
            address_Box.Text = dataGridView1.Rows[r].Cells[2].Value.ToString();
           contactBox.Text = dataGridView1.Rows[r].Cells[3].Value.ToString();
            mobileBox.Text = dataGridView1.Rows[r].Cells[4].Value.ToString();
            mailBox.Text = dataGridView1.Rows[r].Cells[5].Value.ToString();
           

        }
        private void display()
        {
            try
            {
                string query = "select * from med.company ";
                if (search_query != "")
                {
                    query = search_query;
                }
                MySqlConnection conn2 = new MySqlConnection(conn);

                MySqlDataAdapter sda = new MySqlDataAdapter(query, conn2);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = item[2].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item[3].ToString();
                    dataGridView1.Rows[n].Cells[5].Value = item[4].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = item[5].ToString();
                   
                   


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
