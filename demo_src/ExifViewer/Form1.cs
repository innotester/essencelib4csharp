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
            using (OpenFileDialog dlg = new OpenFileDialog() { Filter = "Jpeg files (*.jpg;*.jpeg)|*.jpg;*.jpeg|All files (*.*)|*.*" })
            {

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    JpegBitmapDecoder decoder = ExifUtil4Jpeg.GetJpegDecoder(dlg.FileName);

                    if (pictureBoxMainImage.Image != null)
                        pictureBoxMainImage.Image.Dispose();

                    double SubfileType = -1;

                    ExifTags.InitJpegTags();
                    Rational v2 = (Rational)((ExifTag)ExifTags.tags[6]).GetValue((BitmapMetadata)decoder.Frames[0].Metadata);
                    double alt = v2.ToDouble();
                    GPSRational v = (GPSRational)((ExifTag)ExifTags.tags[2]).GetValue((BitmapMetadata)decoder.Frames[0].Metadata);
                    double lon = v.ToDegree();
                    ExifUtil4Jpeg.GetLongitude((BitmapMetadata)decoder.Frames[0].Metadata, ref lon);

                    ExifUtil4Jpeg.GetSubfileType((BitmapMetadata)decoder.Frames[0].Metadata, ref SubfileType);

                    Bitmap org_img = ExifUtil4Jpeg.GetBitmapFromBitmapSource(decoder.Frames[0]);
                    if (org_img != null)
                    {
                        pictureBoxMainImage.Image = org_img;

                        if (org_img.Width > org_img.Height)
                        {
                            pictureBoxMainImage.Width = 350;
                            pictureBoxMainImage.Height = 350 * org_img.Height / org_img.Width;
                        }
                        else
                        {
                            pictureBoxMainImage.Height = 350;
                            pictureBoxMainImage.Width = 350 * org_img.Width / org_img.Height;
                        }
                    }

                    if (pictureBoxThumbImage.Image != null)
                        pictureBoxThumbImage.Image.Dispose();
                    pictureBoxThumbImage.Image = ExifUtil4Jpeg.GetThumbnail(decoder);
                }
            }
        }
    }
}
