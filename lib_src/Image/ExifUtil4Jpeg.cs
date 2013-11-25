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

namespace essencelib.Image
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

        // 
        // Bitmap -> naspace : System.Drawing
        //           reference : System.Drawing.dll
        //
        public static bool GetLatitude(JpegBitmapDecoder jpg_decoder, ref double latitude)
        {
            bool rtn = false;

            if (jpg_decoder != null)
            {
                BitmapMetadata jpg_metadata = null;
                if (jpg_decoder.Frames.Count > 0)
                {
                    jpg_metadata = jpg_decoder.Frames[0].Metadata as BitmapMetadata;
                    rtn = GetLatitude(jpg_metadata, ref latitude);
                }
            }

            return rtn;
        }

        public static bool GetLatitude(BitmapMetadata jpg_metadata, ref double latitude)
        {
            bool rtn = false;

            if (jpg_metadata != null)
            {
                ulong[] raw_lat = jpg_metadata.GetQuery("/app1/ifd/gps/subifd:{ulong=2}") as ulong[];
                if (raw_lat != null)
                {
                    latitude = toDegree4GPS(raw_lat);
                    rtn = true;
                }
            }

            return rtn;
        }

        public static bool GetLongitude(JpegBitmapDecoder jpg_decoder, ref double longitude)
        {
            bool rtn = false;

            if (jpg_decoder != null)
            {
                BitmapMetadata jpg_metadata = null;
                if (jpg_decoder.Frames.Count > 0)
                {
                    jpg_metadata = jpg_decoder.Frames[0].Metadata as BitmapMetadata;
                    rtn = GetLongitude(jpg_metadata, ref longitude);
                }
            }

            return rtn;
        }

        public static bool GetLongitude(BitmapMetadata jpg_metadata, ref double longitude)
        {
            bool rtn = false;

            if (jpg_metadata != null)
            {
                ulong[] raw_lon = jpg_metadata.GetQuery("/app1/ifd/gps/subifd:{ulong=4}") as ulong[];
                if (raw_lon != null)
                {
                    longitude = toDegree4GPS(raw_lon);
                    rtn = true;
                }
            }

            return rtn;
        }

        public static bool GetAltitude(JpegBitmapDecoder jpg_decoder, ref double altitude)
        {
            bool rtn = false;

            if (jpg_decoder != null)
            {
                BitmapMetadata jpg_metadata = null;
                if (jpg_decoder.Frames.Count > 0)
                {
                    jpg_metadata = jpg_decoder.Frames[0].Metadata as BitmapMetadata;
                    rtn = GetAltitude(jpg_metadata, ref altitude);
                }
            }

            return rtn;
        }

        public static bool GetAltitude(BitmapMetadata jpg_metadata, ref double altitude)
        {
            bool rtn = false;

            if (jpg_metadata != null)
            {
                var raw_alt = jpg_metadata.GetQuery("/app1/ifd/gps/subifd:{ulong=6}");
                if (raw_alt != null)
                {
                    ulong l = (ulong)raw_alt;
                    byte[] bytes = BitConverter.GetBytes(l);
                    int num = BitConverter.ToInt32(bytes, 0);
                    int denom = BitConverter.ToInt32(bytes, 4);
                    altitude = (double)num / (double)denom;
                    rtn = true;
                }
            }

            return rtn;
        }


        #region sub-function

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
                PngBitmapEncoder enc = new PngBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bmp_src));
                enc.Save(stream);
                rtn = new Bitmap(stream);
            }

            return rtn;
        }

        private static double toDegree4GPS(ulong[] raw)
        {
            int dash = (int)(raw[0] - ((ulong)0x100000000));
            int _f = (int)(raw[1] - ((ulong)0x100000000));
            double _r = (double)(raw[2] - (ulong)0x6400000000) / 100.0;
            double res = (double)dash + (double)_f / 60.0 + _r / 3600.0;
            return Math.Floor(res * 1000000.0) / 1000000.0;
        }

        #endregion

    }
}
