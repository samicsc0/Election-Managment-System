using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Election_MS
{
    public partial class RegCan : UserControl
    {
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
            Candidate candidate = new Candidate();
            candidate.govid = textBox1.Text;
            candidate.fname = textBox2.Text;
            candidate.lname = textBox3.Text;
            candidate.polp = textBox4.Text;
            candidate.elecid = textBox6.Text;
            candidate.desc = textBox5.Text;
            candidate.region = comboBox1.GetItemText(comboBox1.SelectedItem);

            byte[] img = null;
            FileStream fs = new FileStream(textBox7.Text, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            img = br.ReadBytes((int)fs.Length);
            candidate.img = img;


            userClass u = new userClass();
            int check = u.regcan(candidate);
            if (check == 1)
            {
                MessageBox.Show("Candidate Successfully Added!", "NEBE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (check == -1)
            {
                MessageBox.Show("Faild to Register the Candidate, Please try again latter!", "NEBE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Select image(*.Jpg; *.png; *.Gif)|*.Jpg; *.png; *.Gif";
                openFileDialog.Title = "Select Candidates Picture";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox7.Text = openFileDialog.FileName.ToString();
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
