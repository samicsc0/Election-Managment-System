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
    public partial class Confirmelect : Form
    {
        public string govid;
        public Confirmelect(string govid)
        {
            this.govid = govid;
            InitializeComponent();
        }

        private void Confirmelect_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            textBox6.Text = govid;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
