/* Copyright (C) the essencelib4csharp contributors. All rights reserved.
 *
 * This file is part of essencelib4csharp, distributed under the GNU GPL v2 with
 * a Linking Exception.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace essencelib.Image.EXIF
{
    public sealed class Rational : ExifTagValue
    {
        private Int32 _num;
        private Int32 _denom;

        public Rational(byte[] bytes)
        {
            SetValue(bytes);
        }

        public Rational(ulong raw)
        {
            SetValue(BitConverter.GetBytes(raw));
        }

        public Rational(long raw)
        {
            SetValue(BitConverter.GetBytes(raw));
        }

        private void SetValue(byte[] bytes)
        {
            value_type = TagValueType.Rational;
            byte[] n = new byte[4];
            byte[] d = new byte[4];
            Array.Copy(bytes, 0, n, 0, 4);
            Array.Copy(bytes, 4, d, 0, 4);
            _num = BitConverter.ToInt32(n, 0);
            _denom = BitConverter.ToInt32(d, 0);
        }

        public double ToDouble()
        {
            return Convert.ToDouble(_num) / Convert.ToDouble(_denom); //Math.Round(, 2);
        }

        public string ToString(string separator)
        {
            return _num + separator + _denom;
        }

        public override string ToString()
        {
            string rtn = "";

            switch (tag_key)
            {
                case 0x6: // GPSAltitude
                case 0x11: // GPSImgDirection
                case 0x829D: // FNumber
                case 0x9203: // BrightnessValue
                case 0x920A: // FocalLength
                    rtn = string.Format("{0}", ToDouble());
                    break;
                case 0x11A: // XResolution
                case 0x11B: // YResolution
                    rtn = string.Format("{0}", (int)ToDouble());
                    break;
                default:
                    rtn = ToString("/"); ;
                    break;
            }

            return rtn;
        }
    }
}
