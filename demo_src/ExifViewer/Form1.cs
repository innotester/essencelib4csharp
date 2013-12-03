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
using System.Collections;

namespace ExifViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ExifTags.InitJpegTags();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog() { Filter = "Jpeg files (*.jpg;*.jpeg)|*.jpg;*.jpeg|All files (*.*)|*.*" })
            {

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    JpegBitmapDecoder decoder = ExifUtil4Jpeg.GetJpegDecoder(dlg.FileName);

                    // Item Task
                    listView1.Items.Clear();

                    SortedList list = new SortedList(ExifTags.tags);

                    foreach (DictionaryEntry _o in list)
                    {
                        ExifTag tag = _o.Value as ExifTag;
                        ExifTagValue exif_value = tag.GetValue((BitmapMetadata)decoder.Frames[0].Metadata);

                        if (exif_value != null)
                        {
                            string out_val = exif_value.ToString();
                            string[] contents = new string[6];

                            contents[0] = tag.key.ToString();
                            contents[1] = string.Format("0x{0:X}", tag.key);
                            contents[2] = tag.name;
                            contents[3] = tag.desc;
                            contents[4] = out_val;
                            contents[5] = tag.query;

                            ListViewItem item = new ListViewItem(contents);

                            listView1.Items.Add(item);
                        }
                    }

                    // Thumbnail task 
                    Bitmap thumb_bmp = ExifUtil4Jpeg.GetThumbnail(decoder);

                    if (thumb_bmp != null)
                    {
                        if (pictureBoxThumbImage.Image != null)
                            pictureBoxThumbImage.Image.Dispose();

                        labelThumbnail.Text = "Thumbnail (O)";

                        pictureBoxThumbImage.Image = thumb_bmp;
                    }
                    else
                    {
                        Bitmap org_bmp = ExifUtil4Jpeg.GetBitmapFromBitmapSource(decoder.Frames[0]);

                        int thumb_width = 0;
                        int thumb_height = 0;

                        if (org_bmp.Width > org_bmp.Height)
                        {
                            thumb_width = 160;
                            thumb_height = 160 * org_bmp.Height / org_bmp.Width;
                        }
                        else
                        {
                            thumb_height = 160;
                            thumb_width = 160 * org_bmp.Width / org_bmp.Height;
                        }

                        thumb_bmp = (Bitmap)org_bmp.GetThumbnailImage(thumb_width, thumb_height, delegate { return false; }, IntPtr.Zero);

                        if (thumb_bmp != null)
                        {
                            if (pictureBoxThumbImage.Image != null)
                                pictureBoxThumbImage.Image.Dispose();

                            labelThumbnail.Text = "Thumbnail (X)";

                            pictureBoxThumbImage.Image = thumb_bmp;
                        }
                    }

                }
            }
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right && listView1.SelectedItems.Count == 1)
                contextMenuStrip1.Show(Cursor.Position);
        }

        private void copyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
