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
        public static Confirmelect Self;
        public string govid;
        public string vid;
        public int elid;
        public string rgn;
        public Confirmelect(string govid,string vid,int elid,string rgn)
        {
            this.govid = govid;
            this.vid = vid;
            this.elid = elid;
            this.rgn = rgn;
            Self = this;
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

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            bool chk;
            int res;
            userClass a = new userClass();
            bool b = a.vt(vid);
            try
            {
                if (b)
                {
                    if (textBox3.Text != "")
                    {
                        Guid code = new Guid(textBox3.Text);
                        chk = a.chkcode(code);
                        if (chk)
                        {
                            res = a.voted(code, govid, elid, vid);
                            if (res == 1)
                            {
                                if(a.cir(govid) == 0)
                                {
                                    a.insr(govid,elid,rgn);
                                }
                                else
                                {
                                    int x = a.numvt(govid);
                                    a.uprep(govid, x + 1);
                                }
                                MessageBox.Show("Voted Successfully!", "NEBE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Your secret code doesn't exist, Please try again!", "NEBE", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please insert our confirmation code in the field!", "NEBE", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    }
                }
                else
                {
                    MessageBox.Show("You can't vote more than one time!", "NEBE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Input Error! Please check your input & try again.", "NEBE", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            Qrreader qr = new Qrreader();
            qr.ShowDialog();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
