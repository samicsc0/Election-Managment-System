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
            candidate.img = textBox7.Text;
            candidate.desc = textBox5.Text;
            candidate.region = comboBox1.GetItemText(comboBox1.SelectedItem);
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Select image(*.Jpg; *.png; *.Gif)|*.Jpg; *.png; *.Gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox7.Text = Image.FromFile(openFileDialog.FileName)+"";
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
