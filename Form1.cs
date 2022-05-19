using System.Diagnostics;

namespace Election_MS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Admin admin = new Admin();
            admin.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login l1 = new Login();
            l1.ShowDialog();
        }
    }
}