/* Copyright (C) the essencelib4csharp contributors. All rights reserved.
 *
 * This file is part of essencelib4csharp, distributed under the GNU GPL v2 with
 * a Linking Exception.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;

namespace essencelib.Image.EXIF
{
    public class ExifTag
    {
        public int key;
        public string name;
        public string desc;
        public string query;
        public TagValueType value_type = TagValueType.Unknown;
        public string value_desc;
        public ExifTag(int key, string name, string desc, string query, TagValueType value_type, string value_desc)
        {
            this.key = key;
            this.name = name;
            this.desc = desc;
            this.query = query;
            this.value_type = value_type;
            this.value_desc = value_desc;
        }

        public ExifTagValue GetValue(BitmapMetadata bmg_metadata)
        {
            ExifTagValue rtn = null;

            var raw_value = bmg_metadata.GetQuery(query);
            if (raw_value != null)
            {
                switch (value_type)
                {
                    case TagValueType.Unknown:
                        rtn = new ExifTagValue();
                        rtn.value = raw_value;
                        rtn.tag_key = key;
                        break;
                    case TagValueType.Rational:
                        if (raw_value is ulong)
                            rtn = new Rational((ulong)raw_value);
                        else if (raw_value is long)
                            rtn = new Rational((long)raw_value);
                        rtn.tag_key = key;
                        break;
                    case TagValueType.GPSRational:
                        rtn = new GPSRational((ulong[])raw_value);
                        rtn.tag_key = key;
                        break;
                    case TagValueType.Aperture:
                        {
                            Rational r_val = null;
                            if (raw_value is ulong)
                                r_val = new Rational((ulong)raw_value);
                            else if (raw_value is long)
                                r_val = new Rational((long)raw_value);
                            rtn = new Aperture();
                            rtn.value = Math.Pow(Math.Sqrt(2), r_val.ToDouble());
                            rtn.tag_key = key;
                        }
                        break;
                    case TagValueType.ShutterSpeed:
                        {
                            Rational r_val = null;
                            if (raw_value is ulong)
                                r_val = new Rational((ulong)raw_value);
                            else if (raw_value is long)
                                r_val = new Rational((long)raw_value);
                            rtn = new ShutterSpeed();
                            rtn.value = Math.Pow(2, r_val.ToDouble());
                            rtn.tag_key = key;
                        }
                        break;
                }
            }

            if (rtn != null)
                rtn.tag = this;

            return rtn;

        }
    }
}
