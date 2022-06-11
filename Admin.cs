using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Election_MS
{
    public partial class Admin : Form
    {
        public Admin(String govid)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.iconButton1.BackColor = Color.FromArgb(84,255,245);
            this.iconButton1.ForeColor = Color.FromArgb(34, 34, 34);
            this.iconButton1.IconColor = Color.FromArgb(34, 34, 34);

            this.iconButton2.BackColor = Color.FromArgb(34,34,34);
            this.iconButton2.ForeColor = Color.FromArgb(255,255,255);
            this.iconButton2.IconColor = Color.FromArgb(255, 255, 255);
            this.iconButton3.BackColor = Color.FromArgb(34, 34, 34);
            this.iconButton3.ForeColor = Color.FromArgb(255, 255, 255);
            this.iconButton3.IconColor = Color.FromArgb(255, 255, 255);
            this.iconButton4.BackColor = Color.FromArgb(34, 34, 34);
            this.iconButton4.ForeColor = Color.FromArgb(255, 255, 255);
            this.iconButton4.IconColor = Color.FromArgb(255, 255, 255);
            this.iconButton5.BackColor = Color.FromArgb(34, 34, 34);
            this.iconButton5.ForeColor = Color.FromArgb(255, 255, 255);
            this.iconButton5.IconColor = Color.FromArgb(255, 255, 255);

            regCan1.Show();
            regVo1.Hide();
            electionsched1.Hide();
            iconButton7.Hide();
            iconButton8.Hide();
            iconButton6.Hide();
            adminreg1.Hide();
            deactivate1.Hide();
            aAdmin1.Hide();
            exit1.Hide();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.iconButton2.BackColor = Color.FromArgb(84, 255, 245);
            this.iconButton2.ForeColor = Color.FromArgb(34, 34, 34);
            this.iconButton2.IconColor = Color.FromArgb(34, 34, 34);

            this.iconButton1.BackColor = Color.FromArgb(34, 34, 34);
            this.iconButton1.ForeColor = Color.FromArgb(255, 255, 255);
            this.iconButton1.IconColor = Color.FromArgb(255, 255, 255);
            this.iconButton3.BackColor = Color.FromArgb(34, 34, 34);
            this.iconButton3.ForeColor = Color.FromArgb(255, 255, 255);
            this.iconButton3.IconColor = Color.FromArgb(255, 255, 255);
            this.iconButton4.BackColor = Color.FromArgb(34, 34, 34);
            this.iconButton4.ForeColor = Color.FromArgb(255, 255, 255);
            this.iconButton4.IconColor = Color.FromArgb(255, 255, 255);
            this.iconButton5.BackColor = Color.FromArgb(34, 34, 34);
            this.iconButton5.ForeColor = Color.FromArgb(255, 255, 255);
            this.iconButton5.IconColor = Color.FromArgb(255, 255, 255);
            
            regVo1.Show();
            regCan1.Hide();
            electionsched1.Hide();
            iconButton7.Hide();
            iconButton8.Hide();
            iconButton6.Hide();
            exit1.Hide();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            this.iconButton3.BackColor = Color.FromArgb(84, 255, 245);
            this.iconButton3.ForeColor = Color.FromArgb(34, 34, 34);
            this.iconButton3.IconColor = Color.FromArgb(34, 34, 34);

            this.iconButton1.BackColor = Color.FromArgb(34, 34, 34);
            this.iconButton1.ForeColor = Color.FromArgb(255, 255, 255);
            this.iconButton1.IconColor = Color.FromArgb(255, 255, 255);
            this.iconButton2.BackColor = Color.FromArgb(34, 34, 34);
            this.iconButton2.ForeColor = Color.FromArgb(255, 255, 255);
            this.iconButton2.IconColor = Color.FromArgb(255, 255, 255);
            this.iconButton4.BackColor = Color.FromArgb(34, 34, 34);
            this.iconButton4.ForeColor = Color.FromArgb(255, 255, 255);
            this.iconButton4.IconColor = Color.FromArgb(255, 255, 255);
            this.iconButton5.BackColor = Color.FromArgb(34, 34, 34);
            this.iconButton5.ForeColor = Color.FromArgb(255, 255, 255);
            this.iconButton5.IconColor = Color.FromArgb(255, 255, 255);

            regVo1.Hide();
            regCan1.Hide();
            electionsched1.Hide();
            iconButton7.Show();
            iconButton8.Show();
            iconButton6.Show();
            exit1.Hide();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            this.iconButton4.BackColor = Color.FromArgb(84, 255, 245);
            this.iconButton4.ForeColor = Color.FromArgb(34, 34, 34);
            this.iconButton4.IconColor = Color.FromArgb(34, 34, 34);

            this.iconButton1.BackColor = Color.FromArgb(34, 34, 34);
            this.iconButton1.ForeColor = Color.FromArgb(255, 255, 255);
            this.iconButton1.IconColor = Color.FromArgb(255, 255, 255);
            this.iconButton2.BackColor = Color.FromArgb(34, 34, 34);
            this.iconButton2.ForeColor = Color.FromArgb(255, 255, 255);
            this.iconButton2.IconColor = Color.FromArgb(255, 255, 255);
            this.iconButton3.BackColor = Color.FromArgb(34, 34, 34);
            this.iconButton3.ForeColor = Color.FromArgb(255, 255, 255);
            this.iconButton3.IconColor = Color.FromArgb(255, 255, 255);
            this.iconButton5.BackColor = Color.FromArgb(34, 34, 34);
            this.iconButton5.ForeColor = Color.FromArgb(255, 255, 255);
            this.iconButton5.IconColor = Color.FromArgb(255, 255, 255);

            electionsched1.Show();
            regVo1.Hide();
            regCan1.Hide();
            iconButton7.Hide();
            iconButton8.Hide();
            iconButton6.Hide();
            exit1.Hide();
            deactivate1.Hide();
            adminreg1.Hide();
            aAdmin1.Hide();
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            this.iconButton5.BackColor = Color.FromArgb(84, 255, 245);
            this.iconButton5.ForeColor = Color.FromArgb(34, 34, 34);
            this.iconButton5.IconColor = Color.FromArgb(34, 34, 34);

            this.iconButton1.BackColor = Color.FromArgb(34, 34, 34);
            this.iconButton1.ForeColor = Color.FromArgb(255, 255, 255);
            this.iconButton1.IconColor = Color.FromArgb(255, 255, 255);
            this.iconButton2.BackColor = Color.FromArgb(34, 34, 34);
            this.iconButton2.ForeColor = Color.FromArgb(255, 255, 255);
            this.iconButton2.IconColor = Color.FromArgb(255, 255, 255);
            this.iconButton3.BackColor = Color.FromArgb(34, 34, 34);
            this.iconButton3.ForeColor = Color.FromArgb(255, 255, 255);
            this.iconButton3.IconColor = Color.FromArgb(255, 255, 255);
            this.iconButton4.BackColor = Color.FromArgb(34, 34, 34);
            this.iconButton4.ForeColor = Color.FromArgb(255, 255, 255);
            this.iconButton4.IconColor = Color.FromArgb(255, 255, 255);
            electionsched1.Hide();
            regVo1.Hide();
            regCan1.Hide();
            adminreg1.Hide();
            deactivate1.Hide();
            aAdmin1.Hide();
            iconButton7.Hide();
            iconButton8.Hide();
            iconButton6.Hide();
            exit1.Show();
        }

        private void regCan1_Load(object sender, EventArgs e)
        {
            regCan1.Hide();
            regVo1.Hide();
            electionsched1.Hide();
            
        }

        private void electionsched1_Load(object sender, EventArgs e)
        {

        }

        private void manfoot1_Load(object sender, EventArgs e)
        {
            electionsched1.Hide();
            regVo1.Hide();
            regCan1.Hide();
            adminreg1.Hide();
            deactivate1.Hide();
            aAdmin1.Hide();
            iconButton7.Hide();
            iconButton8.Hide();
            iconButton6.Hide();
            
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            electionsched1.Hide();
            regVo1.Hide();
            regCan1.Hide();
            adminreg1.Hide();
            deactivate1.Hide();
            aAdmin1.Hide();
            iconButton7.Hide();
            iconButton8.Hide();
            iconButton6.Hide();
            exit1.Hide();
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            electionsched1.Hide();
            regVo1.Hide();
            regCan1.Hide();
            adminreg1.Hide();
            deactivate1.Show();
            aAdmin1.Hide();
            iconButton7.Show();
            iconButton8.Show();
            iconButton6.Show();
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            electionsched1.Hide();
            regVo1.Hide();
            regCan1.Hide();
            adminreg1.Hide();
            deactivate1.Hide();
            aAdmin1.Show();
            iconButton7.Show();
            iconButton8.Show();
            iconButton6.Show();
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            electionsched1.Hide();
            regVo1.Hide();
            regCan1.Hide();
            adminreg1.Show();
            deactivate1.Hide();
            aAdmin1.Hide();
            iconButton7.Show();
            iconButton8.Show();
            iconButton6.Show();
        }

        private void exit1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
