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
    public partial class AddStaff : Form
    {
        string conn = "datasource=localhost;username=root;password=";
        public AddStaff()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (nameBox.Text == "" || ageBox.Text == "" || contactBox.Text == "" || mailBox.Text == "" || salaryBox.Text == "" || addressBox.Text == "" || comboBoxBlood.SelectedIndex == -1 || comboBoxGender.SelectedIndex == -1 || comboBoxmarital.SelectedIndex == -1)
            {
                MessageBox.Show("Empty Fields!");
                return;

            }
            MySqlConnection conn2 = new MySqlConnection(conn);

            string query = "INSERT INTO med.staff(`name`, `age`, `gender`, `marital_status`, `blood_group`, `address`, `contact_no`, `email`, `salary`, `joining_date`) VALUES ('" + nameBox.Text + "','" + ageBox.Text + "','" + comboBoxGender.Text + "','" + comboBoxmarital.Text + "','" + comboBoxBlood.Text + "','" + addressBox.Text + "','" + contactBox.Text + "','" + mailBox.Text + "','" + salaryBox.Text + "', '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "')";
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
    }
}
