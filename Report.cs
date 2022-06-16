using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagedList;

namespace Election_MS
{

    public partial class Report : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["datab"].ConnectionString;

        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && comboBox1.GetItemText(comboBox1.SelectedItem) != "")
            {
                SqlConnection conn = new SqlConnection(constring);
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec result @reg = '"+ comboBox1.GetItemText(comboBox1.SelectedItem) + "',@elid ="+textBox1.Text+"", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.SelectCommand = cmd;
                dt.Clear();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.ReadOnly = true;
            }
        }
        Bitmap bmp;
        private void iconButton2_Click(object sender, EventArgs e)
        {
            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
            bmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bmp, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            dataGridView1.Height = height;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp,0,0);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
