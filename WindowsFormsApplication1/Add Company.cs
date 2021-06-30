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
    public partial class Add_Company : Form
    {
        string conn = "datasource=localhost;username=root;password=";
        public Add_Company()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (nameBox.Text == "" || phoneBox.Text == "" || contactBox.Text == "" || mailBox.Text == "" || addressBox.Text == "" )
            {
                MessageBox.Show("Empty Fields!");
                return;

            }
            MySqlConnection conn2 = new MySqlConnection(conn);

            string query = "INSERT INTO med.company(name,contact_person,address,email,phone) VALUES ('" + nameBox.Text + "','" + contactBox.Text + "','" + addressBox.Text + "','" + mailBox.Text + "','" + phoneBox.Text + "')";
           // MessageBox.Show(query);
            MySqlCommand command = new MySqlCommand(query, conn2);
            MySqlDataReader myReader;
            conn2.Open();
            myReader = command.ExecuteReader();
            MessageBox.Show("Saved!");
    
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void Add_Company_Load(object sender, EventArgs e)
        {

        }
    }
}
