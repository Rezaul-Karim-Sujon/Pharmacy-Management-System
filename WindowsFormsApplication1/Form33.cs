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
    public partial class Form33 : Form
    {
        int med_id = 0;
        string search_query = "";
        string conn = "datasource=localhost;username=root;password=";
        public Form33()
        {
            InitializeComponent();
            display();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
         private void display()
        {
            try
            {
                string query = "select * from med.medicine ";
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
                 search_query = "select * from med.medicine where id LIKE '%" + searchIDBox.Text + "%'";
                 display();
             }
             else if (searchIDBox.Text != "" && searchnameBox.Text != "")
             {

                 search_query = "select * from med.medicine where id LIKE '%" + searchIDBox.Text + "%' and med_name LIKE '%" + searchnameBox.Text + "%' ";
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
                 search_query = "select * from med.medicine where med_name LIKE '%" + searchnameBox.Text + "%'";
                 display();
             }
             else if (searchIDBox.Text != "" && searchnameBox.Text != "")
             {

                 search_query = "select * from med.medicine where id LIKE '%" + searchIDBox.Text + "%' and med_name LIKE '%" + searchnameBox.Text + "%' ";
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
             quantityBox.Text = dataGridView1.Rows[r].Cells[2].Value.ToString();
             comboBox1.Text = dataGridView1.Rows[r].Cells[3].Value.ToString();
         
            // productionDateBox.Text = dataGridView1.Rows[r].Cells[4].Value.ToString();
            // expiryDateBox.Text = dataGridView1.Rows[r].Cells[5].Value.ToString();
             buyBox.Text = dataGridView1.Rows[r].Cells[6].Value.ToString();
             sellBox.Text = dataGridView1.Rows[r].Cells[7].Value.ToString();
             med_id = Convert.ToInt32(dataGridView1.Rows[r].Cells[0].Value.ToString());
         }

         private void buttonUpdate_Click(object sender, EventArgs e)
         {
             if (nameBox.Text == "" || quantityBox.Text == "" || buyBox.Text == "" || sellBox.Text == "")
             {
                 MessageBox.Show("Empty Fields!");
             }
             MySqlConnection conn2 = new MySqlConnection(conn);

             string query = "Update med.medicine set med_name = '" + nameBox.Text + "' ,  quantity = " + Convert.ToInt32(quantityBox.Text) + " , category = '" + comboBox1.Text + "' , production_date = '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "' , expiry_date = '" + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd") + "' , buying_price = " + Convert.ToInt32(buyBox.Text) + " , selling_price = " + Convert.ToInt32(sellBox.Text) + " where id = "+med_id+" ";
            // MessageBox.Show(query);
             MySqlCommand command = new MySqlCommand(query, conn2);
             MySqlDataReader myReader;
             conn2.Open();
             myReader = command.ExecuteReader();
             MessageBox.Show("Updated!");
             med_id = 0;
             display();
    
         }

         private void buttonBack_Click(object sender, EventArgs e)
         {
             this.DialogResult = System.Windows.Forms.DialogResult.OK;
         }
        
                     
                 
             
         


        
    }
}
