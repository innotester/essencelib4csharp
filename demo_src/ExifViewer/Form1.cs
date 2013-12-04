using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using essencelib.Image.EXIF;
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

                    foreach (DictionaryEntry _o in ExifTags.SortedTags)
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

                            ListViewItem item = new ListViewItem(contents) { Tag = exif_value };

                            listView1.Items.Add(item);
                        }
                    }

                    // ExifValues test task
                    ExifValues exif_values = ExifUtil4Jpeg.GetExifValues((BitmapMetadata)decoder.Frames[0].Metadata);
                    ExifTagValue       vGPSVersionID                 = exif_values.GPSVersionID                ;
                    string             vGPSLatitudeRef               = exif_values.GPSLatitudeRef              ;
                    GPSRational        vGPSLatitude                  = exif_values.GPSLatitude                 ;
                    string             vGPSLongitudeRef              = exif_values.GPSLongitudeRef             ;
                    GPSRational        vGPSLongitude                 = exif_values.GPSLongitude                ;
                    byte               vGPSAltitudeRef               = exif_values.GPSAltitudeRef              ;
                    Rational           vGPSAltitude                  = exif_values.GPSAltitude                 ;
                    GPSRational        vGPSTimeStamp                 = exif_values.GPSTimeStamp                ;
                    ExifTagValue       vGPSSatellites                = exif_values.GPSSatellites               ;
                    ExifTagValue       vGPSStatus                    = exif_values.GPSStatus                   ;
                    ExifTagValue       vGPSMeasureMode               = exif_values.GPSMeasureMode              ;
                    ExifTagValue       vGPSDOP                       = exif_values.GPSDOP                      ;
                    ExifTagValue       vGPSSpeedRef                  = exif_values.GPSSpeedRef                 ;
                    ExifTagValue       vGPSSpeed                     = exif_values.GPSSpeed                    ;
                    ExifTagValue       vGPSTrackRef                  = exif_values.GPSTrackRef                 ;
                    ExifTagValue       vGPSTrack                     = exif_values.GPSTrack                    ;
                    string             vGPSImgDirectionRef           = exif_values.GPSImgDirectionRef          ;
                    Rational           vGPSImgDirection              = exif_values.GPSImgDirection             ;
                    ExifTagValue       vGPSMapDatum                  = exif_values.GPSMapDatum                 ;
                    ExifTagValue       vGPSDestLatitudeRef           = exif_values.GPSDestLatitudeRef          ;
                    ExifTagValue       vGPSDestLatitude              = exif_values.GPSDestLatitude             ;
                    ExifTagValue       vGPSDestLongitudeRef          = exif_values.GPSDestLongitudeRef         ;
                    ExifTagValue       vGPSDestLongitude             = exif_values.GPSDestLongitude            ;
                    ExifTagValue       vGPSDestBearingRef            = exif_values.GPSDestBearingRef           ;
                    ExifTagValue       vGPSDestBearing               = exif_values.GPSDestBearing              ;
                    ExifTagValue       vGPSDestDistanceRef           = exif_values.GPSDestDistanceRef          ;
                    ExifTagValue       vGPSDestDistance              = exif_values.GPSDestDistance             ;
                    ExifTagValue       vGPSProcessingMethod          = exif_values.GPSProcessingMethod         ;
                    ExifTagValue       vGPSAreaInformation           = exif_values.GPSAreaInformation          ;
                    ExifTagValue       vGPSDateStamp                 = exif_values.GPSDateStamp                ;
                    ExifTagValue       vGPSDifferential              = exif_values.GPSDifferential             ;
                    ExifTagValue       vImageWidth                   = exif_values.ImageWidth                  ;
                    ExifTagValue       vImageHeight                  = exif_values.ImageHeight                 ;
                    ExifTagValue       vBitsPerSample                = exif_values.BitsPerSample               ;
                    ExifTagValue       vCompression                  = exif_values.Compression                 ;
                    ExifTagValue       vPhotometricInterpretation    = exif_values.PhotometricInterpretation   ;
                    ExifTagValue       vImageDescription             = exif_values.ImageDescription            ;
                    string             vMake                         = exif_values.Make                        ;
                    string             vModel                        = exif_values.Model                       ;
                    ExifTagValue       vStripOffsets                 = exif_values.StripOffsets                ;
                    ushort             vOrientation                  = exif_values.Orientation                 ;
                    ExifTagValue       vSamplesPerPixel              = exif_values.SamplesPerPixel             ;
                    ExifTagValue       vRowsPerStrip                 = exif_values.RowsPerStrip                ;
                    ExifTagValue       vStripByteCounts              = exif_values.StripByteCounts             ;
                    Rational           vXResolution                  = exif_values.XResolution                 ;
                    Rational           vYResolution                  = exif_values.YResolution                 ;
                    ExifTagValue       vPlanarConfiguration          = exif_values.PlanarConfiguration         ;
                    ushort             vResolutionUnit               = exif_values.ResolutionUnit              ;
                    ExifTagValue       vTransferFunction             = exif_values.TransferFunction            ;
                    string             vSoftware                     = exif_values.Software                    ;
                    string             vDateTime                     = exif_values.DateTime                    ;
                    ExifTagValue       vArtist                       = exif_values.Artist                      ;
                    ExifTagValue       vWhitePoint                   = exif_values.WhitePoint                  ;
                    ExifTagValue       vPrimaryChromaticities        = exif_values.PrimaryChromaticities       ;
                    ExifTagValue       vJPEGInterchangeFormat        = exif_values.JPEGInterchangeFormat       ;
                    ExifTagValue       vJPEGInterchangeFormatLength  = exif_values.JPEGInterchangeFormatLength ;
                    ExifTagValue       vYCbCrCoefficients            = exif_values.YCbCrCoefficients           ;
                    ExifTagValue       vYCbCrSubSampling             = exif_values.YCbCrSubSampling            ;
                    ushort             vYCbCrPositioning             = exif_values.YCbCrPositioning            ;
                    ExifTagValue       vReferenceBlackWhite          = exif_values.ReferenceBlackWhite         ;
                    ExifTagValue       vCopyright                    = exif_values.Copyright                   ;
                    Rational           vExposureTime                 = exif_values.ExposureTime                ;
                    Rational           vFNumber                      = exif_values.FNumber                     ;
                    ushort             vExposureProgram              = exif_values.ExposureProgram             ;
                    ExifTagValue       vSpectralSensitivity          = exif_values.SpectralSensitivity         ;
                    ushort             vISOSpeedRatings              = exif_values.ISOSpeedRatings             ;
                    ExifTagValue       vOECF                         = exif_values.OECF                        ;
                    BitmapMetadataBlob vExifVersion                  = exif_values.ExifVersion                 ;
                    string             vDateTimeOriginal             = exif_values.DateTimeOriginal            ;
                    string             vDateTimeDigitized            = exif_values.DateTimeDigitized           ;
                    BitmapMetadataBlob vComponentsConfiguration      = exif_values.ComponentsConfiguration     ;
                    ExifTagValue       vCompressedBitsPerPixel       = exif_values.CompressedBitsPerPixel      ;
                    double             vShutterSpeedValue            = exif_values.ShutterSpeedValue           ;
                    double             vApertureValue                = exif_values.ApertureValue               ;
                    Rational           vBrightnessValue              = exif_values.BrightnessValue             ;
                    ExifTagValue       vExposureBiasValue            = exif_values.ExposureBiasValue           ;
                    ExifTagValue       vMaxApertureValue             = exif_values.MaxApertureValue            ;
                    ExifTagValue       vSubjectDistance              = exif_values.SubjectDistance             ;
                    ushort             vMeteringMode                 = exif_values.MeteringMode                ;
                    ExifTagValue       vLightSource                  = exif_values.LightSource                 ;
                    ushort             vFlash                        = exif_values.Flash                       ;
                    Rational           vFocalLength                  = exif_values.FocalLength                 ;
                    ushort[]           vSubjectArea                  = exif_values.SubjectArea                 ;
                    BitmapMetadataBlob vMakerNote                    = exif_values.MakerNote                   ;
                    ExifTagValue       vUserComment                  = exif_values.UserComment                 ;
                    ExifTagValue       vSubSecTime                   = exif_values.SubSecTime                  ;
                    string             vSubSecTimeOriginal           = exif_values.SubSecTimeOriginal          ;
                    string             vSubSecTimeDigitized          = exif_values.SubSecTimeDigitized         ;
                    BitmapMetadataBlob vFlashpixVersion              = exif_values.FlashpixVersion             ;
                    ushort             vColorSpace                   = exif_values.ColorSpace                  ;
                    uint               vPixelXDimension              = exif_values.PixelXDimension             ;
                    uint               vPixelYDimension              = exif_values.PixelYDimension             ;
                    ExifTagValue       vRelatedSoundFile             = exif_values.RelatedSoundFile            ;
                    ExifTagValue       vFlashEnergy                  = exif_values.FlashEnergy                 ;
                    ExifTagValue       vSpatialFrequencyResponse     = exif_values.SpatialFrequencyResponse    ;
                    ExifTagValue       vFocalPlaneXResolution        = exif_values.FocalPlaneXResolution       ;
                    ExifTagValue       vFocalPlaneYResolution        = exif_values.FocalPlaneYResolution       ;
                    ExifTagValue       vFocalPlaneResolutionUnit     = exif_values.FocalPlaneResolutionUnit    ;
                    ExifTagValue       vSubjectLocation              = exif_values.SubjectLocation             ;
                    ExifTagValue       vExposureIndex                = exif_values.ExposureIndex               ;
                    ushort             vSensingMethod                = exif_values.SensingMethod               ;
                    ExifTagValue       vFileSource                   = exif_values.FileSource                  ;
                    BitmapMetadataBlob vSceneType                    = exif_values.SceneType                   ;
                    ExifTagValue       vCFAPattern                   = exif_values.CFAPattern                  ;
                    ExifTagValue       vCustomRendered               = exif_values.CustomRendered              ;
                    ushort             vExposureMode                 = exif_values.ExposureMode                ;
                    ushort             vWhiteBalance                 = exif_values.WhiteBalance                ;
                    ExifTagValue       vDigitalZoomRatio             = exif_values.DigitalZoomRatio            ;
                    ushort             vFocalLengthIn35mmFilm        = exif_values.FocalLengthIn35mmFilm       ;
                    ushort             vSceneCaptureType             = exif_values.SceneCaptureType            ;
                    ExifTagValue       vGainControl                  = exif_values.GainControl                 ;
                    ExifTagValue       vContrast                     = exif_values.Contrast                    ;
                    ExifTagValue       vSaturation                   = exif_values.Saturation                  ;
                    ExifTagValue       vSharpness                    = exif_values.Sharpness                   ;
                    ExifTagValue       vDeviceSettingDescription     = exif_values.DeviceSettingDescription    ;
                    ExifTagValue       vSubjectDistanceRange         = exif_values.SubjectDistanceRange        ;
                    ExifTagValue       vImageUniqueID                = exif_values.ImageUniqueID               ;

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

                        thumb_bmp = (Bitmap)org_bmp.GetThumbnailImage(thumb_width, thumb_height, () => false, IntPtr.Zero);

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

        private void copyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (copyToClipboardToolStripMenuItem.Tag != null)
            {
                ListViewItem lv_item = copyToClipboardToolStripMenuItem.Tag as ListViewItem;
                ExifTagValue tag_val = lv_item.Tag as ExifTagValue;
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("TagKey:{0}\r\n", lv_item.SubItems[0].Text);
                sb.AppendFormat("TagKey(Hex):{0}\r\n", lv_item.SubItems[1].Text);
                sb.AppendFormat("Name:{0}\r\n", lv_item.SubItems[2].Text);
                sb.AppendFormat("Desc.:{0}\r\n", lv_item.SubItems[3].Text);
                sb.AppendFormat("Query:{0}\r\n", lv_item.SubItems[5].Text);
                sb.AppendFormat("Value:{0}\r\n", lv_item.SubItems[4].Text);
                if (tag_val.value_type == TagValueType.Unknown)
                    sb.AppendFormat("ValueType:{0}({1})\r\n", tag_val.GetType(), tag_val.value.GetType());
                else
                    sb.AppendFormat("ValueType:{0}\r\n", tag_val.GetType());

                if (tag_val.tag.value_desc != null)
                    sb.AppendFormat("Value meanings====================\r\n{0}End of value meanings=============", tag_val.tag.value_desc);

                Clipboard.SetText(sb.ToString());
            }
        }

        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right && listView1.SelectedItems.Count == 1)
            {
                copyToClipboardToolStripMenuItem.Tag = listView1.SelectedItems[0];
                contextMenuStrip1.Show(Cursor.Position);
            }
        }
    }
}
