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
            userClass u = new userClass();
            vcon v = new vcon();
            v = u.canloadcon(govid);
            if (v != null)
            {
                textBox6.Text = v.full_name;
                textBox1.Text = v.po_pa;
                textBox2.Text = v.description;
                MemoryStream ms = new MemoryStream(v.img);
                try { 
                    pictureBox1.Image = Image.FromStream(ms);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            try
            {

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
