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
    public sealed class GPSRational : ExifTagValue
    {

        public Rational Hours { get; set; }
        public Rational Minutes { get; set; }
        public Rational Seconds { get; set; }

        public GPSRational(byte[] bytes)
        {
            value_type = TagValueType.GPSRational;

            byte[] h = new byte[8]; byte[] m = new byte[8]; byte[] s = new byte[8];

            Array.Copy(bytes, 0, h, 0, 8); Array.Copy(bytes, 8, m, 0, 8); Array.Copy(bytes, 16, s, 0, 8);

            Hours = new Rational(h);
            Minutes = new Rational(m);
            Seconds = new Rational(s);
        }

        public GPSRational(ulong[] raw)
        {
            value_type = TagValueType.GPSRational;

            byte[] h = BitConverter.GetBytes(raw[0]);
            byte[] m = BitConverter.GetBytes(raw[1]);
            byte[] s = BitConverter.GetBytes(raw[2]);

            Hours = new Rational(h);
            Minutes = new Rational(m);
            Seconds = new Rational(s);
        }

        public double ToDegree()
        {
            return Hours.ToDouble() + Minutes.ToDouble() / 60.0 + Seconds.ToDouble() / 3600.0;
        }

        public override string ToString()
        {
            string rtn;
            switch (tag_key)
            {
                case 0x7: // GPSTimeStamp
                    rtn = String.Format("{0} : {1} : {2}", Hours.ToDouble(), Minutes.ToDouble(), Seconds.ToDouble());
                    break;
                case 0x2: // GPSLatitude
                case 0x4: // GPSLongitude
                default:
                    rtn = String.Format("{0}° {1}\' {2}\" ({3})", Hours.ToDouble(), Minutes.ToDouble(), Seconds.ToDouble(), ToDegree());
                    break;
            }

            return rtn;
        }

        public string ToString(string separator)
        {
            return Hours.ToDouble() + separator
                + Minutes.ToDouble() + separator +
                Seconds.ToDouble();
        }
    }
}
