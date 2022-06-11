﻿using System;
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
    public partial class Adminreg : UserControl
    {
        public Adminreg()
        {
            InitializeComponent();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Adminclass admin = new Adminclass();
            admin.fname = textBox2.Text;
            admin.lname = textBox3.Text;
            admin.govid = textBox5.Text;
            admin.password = textBox4.Text;
            userClass u = new userClass();
            int check = u.addAdmin(admin);
            if (check == 1)
            {
                MessageBox.Show("Administrator Successfully Added!", "NEBE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (check == -1)
            {
                MessageBox.Show("Faild to Register the Administrator, Please try again latter!", "NEBE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
