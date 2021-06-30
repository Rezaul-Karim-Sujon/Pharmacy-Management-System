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
    public partial class Form31 : Form
    {
        string conn = "datasource=localhost;username=root;password=";
        public Form31()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (medNameBox.Text == "" || buyBox.Text == "" || sellBox.Text == "" || quantityBox.Text == "")
            {
                MessageBox.Show("Empty Fields!");
                return;

            }
            MySqlConnection conn2 = new MySqlConnection(conn);
           
            string query = "insert into med.medicine (med_name,quantity, category, production_date,expiry_date,buying_price, selling_price) values('" + medNameBox.Text + "', " + Convert.ToInt32(quantityBox.Text) + ",'" + comboBox1.Text + "', '" + dateTimePickerproduction.Value.Date.ToString("yyyy-MM-dd") + "','" + dateTimePickerexpire.Value.Date.ToString("yyyy-MM-dd") + "',"+Convert.ToInt32(buyBox.Text)+","+Convert.ToInt32(sellBox.Text)+") ";
          //  MessageBox.Show(query);
            MySqlCommand command = new MySqlCommand(query, conn2);
            MySqlDataReader myReader;
            conn2.Open();
            myReader = command.ExecuteReader();
            MessageBox.Show("Saved!");
            conn2.Close();
    
           
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
