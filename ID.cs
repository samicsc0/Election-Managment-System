﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using QRCoder;

namespace Election_MS
{
    public partial class ID : Form
    {
        string fn,ln;
        string i;
        string gi;
        public ID(string fn,string ln, string govid,string i)
        {
            this.fn = fn;
            this.ln = ln;
            this.i = i;
            this.gi = govid;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }
        Bitmap bmp;
        private void iconButton2_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            bmp = new Bitmap(this.Size.Width,this.Size.Height,g);
            Graphics mg = Graphics.FromImage(bmp);
            mg.CopyFromScreen(this.Location.X,this.Location.Y,0,0,this.Size);
            printPreviewDialog1.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ID_Load(object sender, EventArgs e)
        {
            textBox1.Text = fn;
            textBox2.Text = ln;
            textBox3.Text = gi;
            string str = i;
            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(i, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);
            pictureBox2.Image = code.GetGraphic(5);

        }
    }
}
