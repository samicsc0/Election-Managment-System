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
    
    public partial class AAdmin : UserControl
    {
        string up;
        public AAdmin()
        {
            InitializeComponent();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            userClass uc = new userClass();
            uc.fname = textBox2.Text;
            uc.lname = textBox3.Text;
            uc.govid = textBox5.Text;
            uc.region = comboBox1.GetItemText(comboBox1.SelectedItem);
            if (textBox4.Text == "")
                uc.psswd = up;
            else 
                uc.psswd = uc.ComputeSha256Hash(textBox4.Text);
            int i = uc.updatausr(uc);
            if(i == 1)
                MessageBox.Show("Info Update Successfully!", "NEBE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Faild, Please try again later!", "NEBE", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            userClass u = new userClass();
            String govid = textBox1.Text;
            u = u.infoup(govid);
            if (u != null)
            {
                if(u.acctype == 0)
                {
                    comboBox1.Visible=false;
                }
                else
                {
                    comboBox1.Visible=true;
                }
                textBox2.Text = u.fname;
                textBox3.Text = u.lname;
                textBox5.Text = u.govid;
                up = u.psswd;
                for(int i = 0; i < comboBox1.Items.Count; i++)
                {
                    if(comboBox1.Items[i].ToString() == u.region)
                        comboBox1.SelectedIndex=i;
                }
            }
            else if(u == null)
            {
                MessageBox.Show("Record Not found!", "NEBE", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
