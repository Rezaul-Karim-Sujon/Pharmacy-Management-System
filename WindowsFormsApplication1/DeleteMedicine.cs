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
    public partial class DeleteMedicine : Form
    {
        string conn = "datasource=localhost;username=root;password=";
        int med_id = 0;
        string search_query = "";
        public DeleteMedicine()
        {
            InitializeComponent();
            display();
            nameBox.ReadOnly = true;
            quantityBox.ReadOnly = true;
            categoryBox.ReadOnly = true;
            productionDateBox.ReadOnly = true;
            expiryDateBox.ReadOnly = true;
            buyBox.ReadOnly = true;
            sellBox.ReadOnly = true;
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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            MySqlConnection conn2 = new MySqlConnection(conn);

            string query = "delete from med.medicine where id = " + med_id + "";
            MessageBox.Show(query);
            MySqlCommand command = new MySqlCommand(query, conn2);
            MySqlDataReader myReader;
            conn2.Open();
            myReader = command.ExecuteReader();
            MessageBox.Show("Deleted!");
            nameBox.Text = "";
            quantityBox.Text = "";
            categoryBox.Text = "";
            productionDateBox.Text = "";
            expiryDateBox.Text = "";
            buyBox.Text = "";
            sellBox.Text = "";
            display();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            nameBox.Text = dataGridView1.Rows[r].Cells[1].Value.ToString();
            quantityBox.Text = dataGridView1.Rows[r].Cells[2].Value.ToString();
            categoryBox.Text = dataGridView1.Rows[r].Cells[3].Value.ToString();
            productionDateBox.Text = dataGridView1.Rows[r].Cells[4].Value.ToString();
            expiryDateBox.Text = dataGridView1.Rows[r].Cells[5].Value.ToString();
            buyBox.Text = dataGridView1.Rows[r].Cells[6].Value.ToString();
            sellBox.Text = dataGridView1.Rows[r].Cells[7].Value.ToString();
            med_id = Convert.ToInt32(dataGridView1.Rows[r].Cells[0].Value.ToString());
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
