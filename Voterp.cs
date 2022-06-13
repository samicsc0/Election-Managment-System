using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Election_MS
{
    public partial class Voterp : Form
    {

        static string constring = ConfigurationManager.ConnectionStrings["datab"].ConnectionString;
        public String g;
        public Voterp(String govid)
        {
            InitializeComponent();
            
            g = govid;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Voterp_Load(object sender, EventArgs e)
        {
            confirm1.Hide();
            userClass u = new userClass();
            u = u.votinfo(g);
            iconButton3.Text = "Welcome, " + char.ToUpper(u.fname[0]) + u.fname.Substring(1)+"!";

            //loding into the datagrid view

            SqlConnection conn = new SqlConnection(constring);
            conn.Open();
            SqlCommand cmd = new SqlCommand("exec voter_choice @region = '"+u.region+"',@elid = "+u.elid+"", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.SelectCommand = cmd;
            dt.Clear();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.ReadOnly = true;
            dataGridView1.Width = 800;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            confirm1.Show();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void confirm1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
