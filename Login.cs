using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Election_MS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userClass user = new userClass();
            user.govid = this.textBox1.Text;
            user.psswd = this.textBox2.Text;
            textBox1.Clear();
            textBox2.Clear();
            userClass dbr = user.login(user);
            if (dbr != null)
            {
                if (dbr.acctype == 0)
                {
                    Admin admin = new Admin(dbr.govid);
                    admin.ShowDialog();
                }
                else if (dbr.acctype == 1)
                {
                    Voterp voter = new Voterp(dbr.govid);
                    voter.ShowDialog();
                }
            }
            if(dbr == null)
            {
                MessageBox.Show("Incorrect Gov't ID & Password","NEBE",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }
    }
}
