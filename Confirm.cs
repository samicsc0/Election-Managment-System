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

    public partial class Confirm : UserControl
    {
        public object govid { get; set; }
        public Confirm()
        {
            InitializeComponent();
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Confirm_Load(object sender, EventArgs e)
        {
            String name = (string)this.govid;
            textBox6.Text =name;
        }
    }
}
