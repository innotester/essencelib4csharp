/* Copyright (C) the essencelib4csharp contributors. All rights reserved.
 *
 * This file is part of essencelib4csharp, distributed under the GNU GPL v2 with
 * a Linking Exception.
 * 
 * references : PresentationCore.dll, System.Drawing.dll, WindowsBase.dll, System.Xaml.dll
 */

using System;
using System.Collections.Generic;
using System.Linq;

using System.IO;
using System.Windows.Media.Imaging;
using System.Drawing;

namespace essencelib.Image.EXIF
{
    public class ExifUtil4Jpeg
    {
        public static FileStream GetReadJpegFileStream(string file_name)
        {
            FileStream rtn = ExifUtil4Jpeg.GetReadFileStream(file_name);

            if (rtn != null)
            {
                if (!ExifUtil4Jpeg.IsJpegFile(rtn))
                    rtn = null;
            }

            return rtn;
        }

        public static bool IsJpegFile(Stream img_stream)
        {
            bool rtn;

            if (img_stream != null)
            {
                // check header
                if (img_stream.ReadByte() == 0xFF
                    && img_stream.ReadByte() == 0xD8)
                    rtn = true;
                else
                    rtn = false;
            }
            else
            {
                rtn = false;
            }

            // reset position
            img_stream.Position = 0;

            return rtn;
        }

        // 
        // JpegBitmapDecoder -> naspace : System.Windows.Media.Imaging
        //                      reference : PresentationCore.dll
        //
        public static JpegBitmapDecoder GetJpegDecoder(string file_name)
        {
            return GetJpegDecoder(GetReadJpegFileStream(file_name));
        }

        public static JpegBitmapDecoder GetJpegDecoder(Stream img_stream)
        {
            JpegBitmapDecoder rtn;

            if (img_stream != null)
                rtn = new JpegBitmapDecoder(
                            img_stream
                            , BitmapCreateOptions.PreservePixelFormat
                            , BitmapCacheOption.Default
                            );
            else
                rtn = null;

            return rtn;
        }

        // 
        // Bitmap -> naspace : System.Drawing
        //           reference : System.Drawing.dll
        //
        public static Bitmap GetThumbnail(JpegBitmapDecoder jpg_decoder)
        {
            Bitmap rtn = null;

            if (jpg_decoder != null)
            {
                BitmapSource thumb = jpg_decoder.Frames[0].Thumbnail;
                if (thumb != null)
                {
                    rtn = GetBitmapFromBitmapSource(thumb);
                }
            }

            return rtn;
        }

        public static ExifTagValue GetTagValue(JpegBitmapDecoder jpg_decoder, TagType tag_type)
        {
            return GetTagValue(jpg_decoder, (int)tag_type);
        }

        public static ExifTagValue GetTagValue(JpegBitmapDecoder jpg_decoder, int tag_key)
        {
            ExifTagValue rtn = null;

            if (jpg_decoder != null)
            {
                BitmapMetadata jpg_metadata = null;
                if (jpg_decoder.Frames.Count > 0)
                {
                    jpg_metadata = jpg_decoder.Frames[0].Metadata as BitmapMetadata;
                    rtn = GetTagValue(jpg_metadata, tag_key);
                }
            }

            return rtn;
        }

        public static ExifTagValue GetTagValue(BitmapMetadata jpg_metadata, TagType tag_type)
        {
            return GetTagValue(jpg_metadata, (int)tag_type);
        }

        public static ExifTagValue GetTagValue(BitmapMetadata jpg_metadata, int tag_key)
        {
            ExifTagValue rtn;

            if (jpg_metadata != null)
                rtn = ExifTags.GetTag(tag_key).GetValue(jpg_metadata);
            else
                rtn = null;

            return rtn;
        }

        public static ExifValues GetExifValues(BitmapMetadata jpg_metadata)
        {
            ExifValues rtn = new ExifValues();
            rtn._metadata = jpg_metadata;
            return rtn;
        }
        
        #region Sample tag values

        public static GPSRational GetLatitude(JpegBitmapDecoder jpg_decoder)
        {
            return GetTagValue(jpg_decoder, (int)TagType.GPSLatitude) as GPSRational;
        }

        public static GPSRational GetLatitude(BitmapMetadata jpg_metadata)
        {
            return GetTagValue(jpg_metadata, (int)TagType.GPSLatitude) as GPSRational;
        }

        public static GPSRational GetLongitude(JpegBitmapDecoder jpg_decoder)
        {
            return GetTagValue(jpg_decoder, (int)TagType.GPSLongitude) as GPSRational;
        }

        public static GPSRational GetLongitude(BitmapMetadata jpg_metadata)
        {
            return GetTagValue(jpg_metadata, (int)TagType.GPSLongitude) as GPSRational;
        }

        public static Rational GetAltitude(JpegBitmapDecoder jpg_decoder)
        {
            return GetTagValue(jpg_decoder, (int)TagType.GPSAltitude) as Rational;
        }

        public static Rational GetAltitude(BitmapMetadata jpg_metadata)
        {
            return GetTagValue(jpg_metadata, (int)TagType.GPSAltitude) as Rational;
        }

        #endregion

        #region Sub-functions

        public static FileStream GetReadFileStream(string file_name)
        {
            FileStream rtn = new FileStream(
                                    file_name
                                    , FileMode.Open
                                    , FileAccess.Read
                                    , FileShare.Read
                                    );

            return rtn;
        }

        public static Bitmap GetBitmapFromBitmapSource(BitmapSource bmp_src)
        {
            Bitmap rtn;

            using (MemoryStream stream = new MemoryStream())
            {
                BmpBitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bmp_src));
                enc.Save(stream);
                rtn = new Bitmap(stream);
            }

            return rtn;
        }

        #endregion

    }
}
