using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using essencelib.Image;
using System.Windows.Media.Imaging;

namespace ExifViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    JpegBitmapDecoder decoder = ExifUtil4Jpeg.GetJpegDecoder(dlg.FileName);

                    pictureBoxThumbImage.Image = ExifUtil4Jpeg.GetThumbnail(decoder);
                }
            }
        }
    }
}
