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
    public partial class RegVo : UserControl
    {
        public RegVo()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            bool x = textBox1.Text != ""  && textBox6.Text !="" && textBox2.Text != "" && textBox5.Text != "" && textBox3.Text != "" && comboBox1.GetItemText(comboBox1.SelectedItem) != "";
            voterclass v = new voterclass();
            if(x == true) { 
                v.fn = textBox1.Text;
                v.ln = textBox6.Text;
                v.govid = textBox2.Text;
                v.psswd = textBox5.Text;
                v.elid = textBox3.Text;
                v.region = comboBox1.GetItemText(comboBox1.SelectedItem);
                userClass u = new userClass();
                int check = u.regvoter(v);
                if (check == 1)
                {
                    MessageBox.Show("Voter Successfully Added!", "NEBE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (check == -1)
                {
                    MessageBox.Show("Faild to Register the Voter, Please try again later!", "NEBE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }if (x == false)
            {
                MessageBox.Show("Please fill all the fields!", "NEBE", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegVo_Load(object sender, EventArgs e)
        {
            
        }
    }
}
