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

namespace Election_MS
{
    public partial class RegCan : UserControl
    {
        string imgLoc;
        public RegCan()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void RegCan_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            string constring = ConfigurationManager.ConnectionStrings["datab"].ConnectionString;
            SqlConnection conn = new SqlConnection(constring);
            try
            {
                
                userClass u = new userClass();
                Candidate candidate = new Candidate();
                candidate.govid = textBox1.Text;
                candidate.fname = textBox2.Text;
                candidate.lname = textBox3.Text;
                candidate.polp = textBox4.Text;
                candidate.elecid = textBox6.Text;
                candidate.desc = textBox5.Text;
                candidate.region = comboBox1.GetItemText(comboBox1.SelectedItem);

                byte[] photo = null;
                FileStream fs = new FileStream(imgLoc,FileMode.Open,FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                photo = br.ReadBytes((int)fs.Length);
                conn.Open();
                string sql = "insert into candidate(gov_id,election_id,f_name,l_name,p_party,region,descr,photo)values('"+candidate.govid+"',"+candidate.elecid+",'"+candidate.fname+"','"+candidate.lname+"','"+candidate.polp+"','"+candidate.region+"','"+candidate.desc+"',@photo)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@photo",photo));
                int n = cmd.ExecuteNonQuery();
                conn.Close();
                if (n == 1)
                {
                    MessageBox.Show("Candidate Successfully Added!", "NEBE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (n == 0)
                {
                    MessageBox.Show("Faild to Register the Candidate, Please try again later!", "NEBE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "NEBE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All Files (*.*)|*";
                dlg.Title = "Select Candidate Photo";
                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    imgLoc = dlg.FileName.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
