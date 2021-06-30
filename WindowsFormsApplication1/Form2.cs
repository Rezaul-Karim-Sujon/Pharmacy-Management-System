using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddMed_Click(object sender, EventArgs e)
        {
            Form31 form31 = new Form31();
            this.Hide();
            form31.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form32 form32 = new Form32();
            this.Hide();
            form32.ShowDialog();
            this.Show();
        }

        private void buttonupdate_Click(object sender, EventArgs e)
        {
            Form33 form33 = new Form33();
            this.Hide();
            form33.ShowDialog();
            this.Show();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteMedicine delForm = new DeleteMedicine();
           
            this.Hide();
            delForm.ShowDialog();
            this.Show();
        }

        private void buttonAddStaff_Click(object sender, EventArgs e)
        {
            AddStaff staffaddform = new AddStaff();
          
            this.Hide();
            staffaddform.ShowDialog();
            this.Show();
        }

        private void buttonstaffView_Click(object sender, EventArgs e)
        {
            ViewStaff formstaffView = new ViewStaff();
            this.Hide();
            formstaffView.ShowDialog();
            this.Show();
        }

        private void buttonUpdateStaff_Click(object sender, EventArgs e)
        {
            UpdateStaff staffUpdateForm  = new UpdateStaff();
            this.Hide();
            staffUpdateForm.ShowDialog();
            this.Show();
        }

        private void buttonStaffDel_Click(object sender, EventArgs e)
        {
            DeleteStaff staffDeleteForm = new DeleteStaff();
            
            this.Hide();
            staffDeleteForm.ShowDialog();
            this.Show();
        }

        private void buttonAddCompany_Click(object sender, EventArgs e)
        {
            Add_Company formAddCompany = new Add_Company();
            this.Hide();
            formAddCompany.ShowDialog();
            this.Show();
        }

        private void buttonCompanyView_Click(object sender, EventArgs e)
        {
            View_Company formCompanyView = new View_Company();
            this.Hide();
            formCompanyView.ShowDialog();
            this.Show();
        }

        private void buttonUpdateCompany_Click(object sender, EventArgs e)
        {
            Update_Company formCompanyUpdate = new Update_Company();
            this.Hide();
            formCompanyUpdate.ShowDialog();
            this.Show();
        }

        private void buttonCompanyDel_Click(object sender, EventArgs e)
        {
            Delete_Company formCompanyDel = new Delete_Company();
            this.Hide();
            formCompanyDel.ShowDialog();
            this.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            RetailSale formRetail = new RetailSale();
            this.Hide();
            formRetail.ShowDialog();
            this.Show();
        }

        private void buttonRetailView_Click(object sender, EventArgs e)
        {
            View_Sale formviewSale = new View_Sale();
            this.Hide();
            formviewSale.ShowDialog();
            this.Show();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.ShowDialog();
            Close();
        }
    }
}
