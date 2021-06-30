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
    public partial class ViewStaff : Form
    {
        string search_query = "";
        string conn = "datasource=localhost;username=root;password=";
        public ViewStaff()
        {
            InitializeComponent();
            display();
            nameBox.ReadOnly = true;
            ageBox.ReadOnly = true;
            addressBox.ReadOnly = true;
            dateBox.ReadOnly = true;
           contactBox.ReadOnly = true;
            mailBox.ReadOnly = true;
           maritalBox.ReadOnly = true;
          bloodBox.ReadOnly = true;
           genderBox.ReadOnly = true;
          salaryBox.ReadOnly = true;
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
           
            nameBox.Text = dataGridView1.Rows[r].Cells[1].Value.ToString();
            ageBox.Text = dataGridView1.Rows[r].Cells[2].Value.ToString();
            genderBox.Text = dataGridView1.Rows[r].Cells[3].Value.ToString();
            maritalBox.Text = dataGridView1.Rows[r].Cells[4].Value.ToString();
            bloodBox.Text = dataGridView1.Rows[r].Cells[5].Value.ToString();
            contactBox.Text = dataGridView1.Rows[r].Cells[7].Value.ToString();
           mailBox.Text = dataGridView1.Rows[r].Cells[8].Value.ToString();
           dateBox.Text = dataGridView1.Rows[r].Cells[10].Value.ToString();
           salaryBox.Text = dataGridView1.Rows[r].Cells[9].Value.ToString();
          addressBox.Text = dataGridView1.Rows[r].Cells[6].Value.ToString();
         

        }
        private void display()
        {
            try
            {
                string query = "select * from med.staff ";
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
                    dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
                    dataGridView1.Rows[n].Cells[5].Value = item[5].ToString();
                    dataGridView1.Rows[n].Cells[6].Value = item[6].ToString();
                    dataGridView1.Rows[n].Cells[7].Value = item[7].ToString();
                    dataGridView1.Rows[n].Cells[8].Value = item[8].ToString();
                    dataGridView1.Rows[n].Cells[9].Value = item[9].ToString();
                    dataGridView1.Rows[n].Cells[10].Value = item[10].ToString();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void searchIDBox_TextChanged(object sender, EventArgs e)
        {
             if (searchIDBox.Text != "" && searchnameBox.Text == "")
            {
                search_query = "select * from med.staff where id LIKE '%" + searchIDBox.Text + "%'";
                display();
            }
             else if (searchIDBox.Text != "" && searchnameBox.Text != "")
             {

                 search_query = "select * from med.staff where id LIKE '%" + searchIDBox.Text + "%' and name LIKE '%" + searchnameBox.Text + "%' ";
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
                search_query = "select * from med.staff where name LIKE '%" + searchnameBox.Text + "%'";
                display();
            }
            else if (searchIDBox.Text != "" && searchnameBox.Text != "")
            {

                search_query = "select * from med.staff where id LIKE '%" + searchIDBox.Text + "%' and name LIKE '%" + searchnameBox.Text + "%' ";
                display();
            }
            else
            {
                search_query = "";
                display();
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

    }
}
