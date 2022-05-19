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
    public partial class Exit : UserControl
    {
        public Exit()
        {
            InitializeComponent();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Admin.ActiveForm.Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
