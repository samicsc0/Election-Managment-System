using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using ZXing.Aztec;

namespace Election_MS
{
    public partial class Qrreader : Form
    {
        public Qrreader()
        {
            InitializeComponent();
        }
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;
        private void Qrreader_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach(FilterInfo filterInfo in filterInfoCollection)
            {
                cbodevice.Items.Add(filterInfo.Name);
            }
            cbodevice.SelectedIndex = 0;
            captureDevice = new VideoCaptureDevice(filterInfoCollection[cbodevice.SelectedIndex].MonikerString);
            captureDevice.NewFrame += CaptureDevice_NewFrame;
            captureDevice.Start();
            timer1.Start();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //captureDevice = new VideoCaptureDevice(filterInfoCollection[cbodevice.SelectedIndex].MonikerString);
            //captureDevice.NewFrame += CaptureDevice_NewFrame;
            //captureDevice.Start();
            //timer1.Start();
        }

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox.Image = (Bitmap)eventArgs.Frame.Clone();

        }

        private void Qrreader_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (captureDevice.IsRunning)
                    captureDevice.SignalToStop();
            }catch (Exception ex)
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(pictureBox.Image != null)
            {
                BarcodeReader barcodeReader = new BarcodeReader();
                Result result = barcodeReader.Decode((Bitmap)pictureBox.Image);
                if(result != null)
                {
                    String x = result.ToString();
                    timer1.Stop();
                    Confirmelect.Self.textBox3.Text = x;
                    this.Close();
                    try
                    {
                        if (captureDevice.IsRunning)
                            captureDevice.Stop();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
