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

using System.Drawing.Printing;

using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging; 

namespace WindowsFormsApplication1
{
    public partial class RetailSale : Form
    {
        string conn = "datasource=localhost;username=root;password=";
        int g_quantity = 0;
        int g_price = 0;
        int g_total_amount = 0;
        int flag = 0;


        PrintDocument printdoc1 = new PrintDocument();
        PrintPreviewDialog previewdlg = new PrintPreviewDialog();
        Panel pannel = null;

       
        Bitmap MemoryImage;


        public RetailSale()
        {
            InitializeComponent();
          
            labelDate.Text = DateTime.Now.ToString();
            loadComboBox();
            printdoc1.PrintPage += new PrintPageEventHandler(printdoc1_PrintPage); 

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void loadComboBox()
        {
    
           
                string query = "SELECT * FROM med.medicine";
                MySqlConnection conn2 = new MySqlConnection(conn);

                MySqlDataAdapter sda = new MySqlDataAdapter(query, conn2);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    comboBox1.Items.Add(item[1].ToString());
                }
                
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string med_name = comboBox1.Text;
            getValues(med_name);


        }

        private void getValues(string med_name)
        {
          //  MessageBox.Show("getvalues");
            string query = "SELECT * FROM med.medicine where med_name = '"+med_name+"'";
          //  MessageBox.Show(query);
            MySqlConnection conn2 = new MySqlConnection(conn);

            MySqlDataAdapter sda = new MySqlDataAdapter(query, conn2);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            if (dt.Rows.Count >= 1)
            {
                g_quantity = Convert.ToInt32(dt.Rows[0][2].ToString());
                g_price = Convert.ToInt32(dt.Rows[0][7].ToString());
                priceBox.Text = g_price.ToString();
                //MessageBox.Show(g_price.ToString());
            }
            else
            {
                g_price = 0;
                g_quantity = 0;
            }

                
        }

        private void quantityBox_TextChanged(object sender, EventArgs e)
        {
          ////  if (g_quantity != 0)
         //   {
              //  if(g_quantity < Convert.ToInt32(quantityBox.Text)){
               //     MessageBox.Show("Insufficient stock");
                //    quantityBox.Text = "";
             //       return;
            //    }
          //  }
         //   else{
          //      MessageBox.Show("Choose a medicine first!");
           //     return;
          //  }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (priceBox.Text == "" || quantityBox.Text == "" || comboBox1.SelectedIndex == -1 || billBox.Text == "")
            {
                MessageBox.Show("Can not leave empty fields");
                return;
            }
            amountBox.Text = ((Convert.ToInt32(priceBox.Text)) * (Convert.ToInt32(quantityBox.Text))).ToString();

           
            MySqlConnection conn2 = new MySqlConnection(conn);

            string query = "INSERT INTO med.retailsale(name,quantity,total,price,bill_no) VALUES ('" + comboBox1.Text + "','" + quantityBox.Text + "','" + amountBox.Text + "','" + priceBox.Text + "','" + billBox.Text + "')";
          //  MessageBox.Show(query);
            MySqlCommand command = new MySqlCommand(query, conn2);
            MySqlDataReader myReader;
            conn2.Open();
            myReader = command.ExecuteReader();
            MessageBox.Show("Added to Order List!");
            g_price = 0;
            g_quantity = 0;
            g_total_amount += Convert.ToInt32(amountBox.Text);
            comboBox1.SelectedIndex = -1;
            quantityBox.Text = "";
            priceBox.Text = "";
            amountBox.Text = "";
            flag = 1;
            int bill_box_value = Convert.ToInt32(billBox.Text);
            display(bill_box_value);

    
        }

        private void display(int bill_no)
        {
            try
            {
                string query = "select * from med.retailsale where bill_no = "+bill_no+" ";
               
                MySqlConnection conn2 = new MySqlConnection(conn);

                MySqlDataAdapter sda = new MySqlDataAdapter(query, conn2);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item[1].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item[2].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item[3].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = item[4].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = item[5].ToString();
                   

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (flag  == 0 ||  billBox.Text == "")
            {
                MessageBox.Show("Order Something first!");
                return;
            }
            billTotalBox.Text = getTotal(Convert.ToInt32(billBox.Text)).ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (billDiscountBox.Text == "" || billTotalBox.Text == "")
            {
                MessageBox.Show("Empty Fields!");
                return;
            }
            if (billDiscountBox.Text != "0")
            {
                billingBox.Text = ((Convert.ToDouble(billTotalBox.Text)) - ((Convert.ToDouble(billTotalBox.Text) * (Convert.ToDouble(billDiscountBox.Text)) / 100))).ToString();
            }
            else billingBox.Text = billTotalBox.Text;
        }
        private double getTotal(int bill_no)
        {
            try
            {
                string query = "select total from med.retailsale where bill_no = "+bill_no+" ";
                double total_amount = 0;
                MySqlConnection conn2 = new MySqlConnection(conn);

                MySqlDataAdapter sda = new MySqlDataAdapter(query, conn2);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                //dataGridView1.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {

                    total_amount += Convert.ToDouble(item[0].ToString());

                }
                return total_amount;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return 0;
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Print(panelPrint);
        }

        //print
        public void GetPrintArea(Panel pnl)
        {
            MemoryImage = new Bitmap(pnl.Width, pnl.Height); 
             Rectangle rect = new Rectangle(0,0,pnl.Width ,pnl.Height); 
                pnl.DrawToBitmap(MemoryImage, new Rectangle(0, 0, pnl.Width, pnl.Height));
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (MemoryImage == null)
            {
                return;
            }
            e.Graphics.DrawImage(MemoryImage, 0, 0);
            base.OnPaint(e);
        }
        void printdoc1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds; 
            e.Graphics.DrawImage(MemoryImage,(pagearea.Width /2 )-(pannel.Width /2) ,pannel.Location.Y);
        }

        public void Print(Panel pnl)
        {
            pannel = pnl;
             GetPrintArea(pnl);     
            previewdlg.Document = printdoc1;
            previewdlg.ShowDialog(); 
        }
    }
}



