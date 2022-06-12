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
    public partial class Voterp : Form
    {
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
            
            userClass u = new userClass();
            u = u.votinfo(g);
            iconButton3.Text = "Welcome, " + char.ToUpper(u.fname[0]) + u.fname.Substring(1)+"!";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
