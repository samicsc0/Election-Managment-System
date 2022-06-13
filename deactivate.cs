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
    public partial class deactivate : UserControl
    {
        public deactivate()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            String id = textBox1.Text;
            String uty = comboBox1.GetItemText(comboBox1.SelectedItem);
            userClass u = new userClass();
            int ans = u.deactivate(id,uty);
            if (ans == 1)
            {
                MessageBox.Show("Deactivated Successfully!", "NEBE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Faild!", "NEBE", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            userClass u = new userClass();
            String govid = textBox1.Text;
            String uty = comboBox1.GetItemText(comboBox1.SelectedItem);
                u = u.infoRetus(govid,uty);
                if (u != null)
                {
                    textBox2.Text = u.govid;
                    textBox3.Text = u.username.ToUpper();
                }
                else
                {
                    MessageBox.Show("Record Not found!", "NEBE", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            String id = textBox1.Text;
            String uty = comboBox1.GetItemText(comboBox1.SelectedItem);
            userClass u = new userClass();
            int ans = u.activate(id, uty);
            if (ans == 1)
            {
                MessageBox.Show("Activated Successfully!", "NEBE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Faild!", "NEBE", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void deactivate_Load(object sender, EventArgs e)
        {

        }
    }
}
