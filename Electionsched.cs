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
    public partial class Electionsched : UserControl
    {
        public Electionsched()
        {
            InitializeComponent();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Election election = new Election();
            election.title = textBox2.Text;
            election.sdate = dateTimePicker2.Text;
            election.stime = dateTimePicker3.Text; 
            election.edate = dateTimePicker1.Text;
            election.etime = dateTimePicker4.Text;
            userClass u = new userClass();
            int check = u.scheduleElection(election);
            if (check == 1)
            {
                MessageBox.Show("Election Successfully Scheduled!", "NEBE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else if(check == -1)
            {
                MessageBox.Show("Faild to Schedule the Election, Please try again latter!!", "NEBE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
