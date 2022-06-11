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
            int dbr = user.login(user);
            if (dbr == 0)
            {
                Admin admin = new Admin(user.govid);
                admin.ShowDialog();
            }else if(dbr == 1)
            {
                Voterp voter = new Voterp();
                voter.ShowDialog();
            }else if(dbr == -1)
            {
                MessageBox.Show("Incorrect Gov't ID & Password","NEBE",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }else if(dbr == 0)
            {
                MessageBox.Show("Incorrect Go & Password", "NEBE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }
    }
}
