/* Copyright (C) the essencelib4csharp contributors. All rights reserved.
 *
 * This file is part of essencelib4csharp, distributed under the GNU GPL v2 with
 * a Linking Exception.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace essencelib.Image.EXIF
{
    public class ExifTagValue
    {
        public TagValueType value_type = TagValueType.Unknown;
        public int tag_key;
        public ExifTag tag;
        public object value;
        public override string ToString()
        {
            string rtn = "";

            if (value is ushort)
            {
                switch (tag_key)
                {
                    case 0x112: // Orientation
                        switch ((ushort)value)
                        {
                            case 1: rtn = "Horizontal (normal)"; break;
                            case 2: rtn = "Mirror horizontal"; break;
                            case 3: rtn = "Rotate 180"; break;
                            case 4: rtn = "Mirror vertical"; break;
                            case 5: rtn = "Mirror horizontal and rotate 270 CW"; break;
                            case 6: rtn = "Rotate 90 CW"; break;
                            case 7: rtn = "Mirror horizontal and rotate 90 CW"; break;
                            case 8: rtn = "Rotate 270 CW"; break;
                            default: rtn = "Unknown"; break;
                        }
                        break;
                    case 0x128: // ResolutionUnit
                        switch ((ushort)value)
                        {
                            case 1: rtn = "None"; break;
                            case 2: rtn = "inches"; break;
                            case 3: rtn = "cm"; break;
                            default: rtn = "Unknown"; break;
                        }
                        break;
                    case 0x213: // YCbCrPositioning
                        switch ((ushort)value)
                        {
                            case 1: rtn = "Centered "; break;
                            case 2: rtn = "Co-sited"; break;
                            default: rtn = "Unknown"; break;
                        }
                        break;
                    case 0x8822: // ExposureProgram
                        switch ((ushort)value)
                        {
                            case 0: rtn = "Not Defined"; break;
                            case 1: rtn = "Manual"; break;
                            case 2: rtn = "Program AE"; break;
                            case 3: rtn = "Aperture-priority AE"; break;
                            case 4: rtn = "Shutter speed priority AE"; break;
                            case 5: rtn = "Creative (Slow speed)"; break;
                            case 6: rtn = "Action (High speed)"; break;
                            case 7: rtn = "Portrait"; break;
                            case 8: rtn = "Landscape"; break;
                            case 9: rtn = "Bulb"; break;
                            default: rtn = "Unknown"; break;
                        }
                        break;
                    case 0x9207: // MeteringMode
                        switch ((ushort)value)
                        {
                            case 0: rtn = "Unknown"; break;
                            case 1: rtn = "Average"; break;
                            case 2: rtn = "Center-weighted average"; break;
                            case 3: rtn = "Spot"; break;
                            case 4: rtn = "Multi-spot"; break;
                            case 5: rtn = "Multi-segment"; break;
                            case 6: rtn = "Partial"; break;
                            case 255: rtn = "Other"; break;
                            default: rtn = "Unknown"; break;
                        }
                        break;
                    case 0x9209: // Flash
                        switch ((ushort)value)
                        {
                            case 0x0: rtn = "No Flash"; break;
                            case 0x1: rtn = "Fired"; break;
                            case 0x5: rtn = "Fired, Return not detected"; break;
                            case 0x7: rtn = "Fired, Return detected"; break;
                            case 0x8: rtn = "On, Did not fire"; break;
                            case 0x9: rtn = "On, Fired"; break;
                            case 0xd: rtn = "On, Return not detected"; break;
                            case 0xf: rtn = "On, Return detected"; break;
                            case 0x10: rtn = "Off, Did not fire"; break;
                            case 0x14: rtn = "Off, Did not fire, Return not detected"; break;
                            case 0x18: rtn = "Auto, Did not fire"; break;
                            case 0x19: rtn = "Auto, Fired"; break;
                            case 0x1d: rtn = "Auto, Fired, Return not detected"; break;
                            case 0x1f: rtn = "Auto, Fired, Return detected"; break;
                            case 0x20: rtn = "No flash function"; break;
                            case 0x30: rtn = "Off, No flash function"; break;
                            case 0x41: rtn = "Fired, Red-eye reduction"; break;
                            case 0x45: rtn = "Fired, Red-eye reduction, Return not detected"; break;
                            case 0x47: rtn = "Fired, Red-eye reduction, Return detected"; break;
                            case 0x49: rtn = "On, Red-eye reduction"; break;
                            case 0x4d: rtn = "On, Red-eye reduction, Return not detected"; break;
                            case 0x4f: rtn = "On, Red-eye reduction, Return detected"; break;
                            case 0x50: rtn = "Off, Red-eye reduction"; break;
                            case 0x58: rtn = "Auto, Did not fire, Red-eye reduction"; break;
                            case 0x59: rtn = "Auto, Fired, Red-eye reduction"; break;
                            case 0x5d: rtn = "Auto, Fired, Red-eye reduction, Return not detected"; break;
                            case 0x5f: rtn = "Auto, Fired, Red-eye reduction, Return detected"; break;
                            default: rtn = "Unknown"; break;
                        }
                        break;
                    case 0xA001: // ColorSpace
                        switch ((ushort)value)
                        {
                            case 0x1: rtn = "sRGB"; break;
                            case 0x2: rtn = "Adobe RGB"; break;
                            case 0xfffd: rtn = "Wide Gamut RGB"; break;
                            case 0xfffe: rtn = "ICC Profile"; break;
                            case 0xffff: rtn = "Uncalibrated"; break;
                            default: rtn = "Unknown"; break;
                        }
                        break;
                    case 0xA217: // SensingMethod
                        switch ((ushort)value)
                        {
                            case 1: rtn = "Not defined"; break;
                            case 2: rtn = "One-chip color area"; break;
                            case 3: rtn = "Two-chip color area"; break;
                            case 4: rtn = "Three-chip color area"; break;
                            case 5: rtn = "Color sequential area"; break;
                            case 7: rtn = "Trilinear"; break;
                            case 8: rtn = "Color sequential linear"; break;
                            default: rtn = "Unknown"; break;
                        }
                        break;
                    case 0xA402: // ExposureMode
                        switch ((ushort)value)
                        {
                            case 0: rtn = "Auto"; break;
                            case 1: rtn = "Manual"; break;
                            case 2: rtn = "Auto bracket"; break;
                            default: rtn = "Unknown"; break;
                        }
                        break;
                    case 0xA403: // WhiteBalance
                        switch ((ushort)value)
                        {
                            case 0: rtn = "Auto"; break;
                            case 1: rtn = "Manual"; break;
                            default: rtn = "Unknown"; break;
                        }
                        break;
                    case 0xA405: // FocalLengthIn35mmFilm
                        rtn = string.Format("{0}mm", (ushort)value);
                        break;
                    case 0xA406: // SceneCaptureType
                        switch ((ushort)value)
                        {
                            case 0: rtn = "Standard"; break;
                            case 1: rtn = "Landscape"; break;
                            case 2: rtn = "Portrait"; break;
                            case 3: rtn = "Night"; break;
                            default: rtn = "Unknown"; break;
                        }
                        break;
                    case 0x8827: // ISOSpeedRatings
                    default:
                        rtn = string.Format("{0}", (ushort)value);
                        break;
                }
            }
            else if (value is BitmapMetadataBlob)
            {
                BitmapMetadataBlob blob = value as BitmapMetadataBlob;

                switch (tag_key)
                {
                    case 0x9000: // ExifVersion
                        rtn = Encoding.ASCII.GetString(blob.GetBlobValue());
                        break;
                    case 0x9101: // ComponentsConfiguration
                        {
                            byte[] coms = blob.GetBlobValue();
                            string str_coms = "";
                            for (int i = 0; i < coms.Length; i++)
                            {
                                switch (coms[i])
                                {
                                    case 0: str_coms += "-, "; break;
                                    case 1: str_coms += "Y, "; break;
                                    case 2: str_coms += "Cb, "; break;
                                    case 3: str_coms += "Cr, "; break;
                                    default: str_coms += " , "; break;
                                }
                            }

                            if (str_coms.Length > 2)
                            {
                                rtn = str_coms.Substring(0, str_coms.Length - 2);
                            }
                        }
                        break;
                    case 0x927C: // MakerNote
                        string mnote = Encoding.ASCII.GetString(blob.GetBlobValue());
                        int idx = mnote.IndexOf('\0');
                        if (idx > 0)
                        {
                            rtn = mnote.Substring(0, idx);
                        }
                        else
                        {
                            rtn = mnote;
                        }
                        break;
                    case 0xA000: // FlashpixVersion
                        rtn = Encoding.ASCII.GetString(blob.GetBlobValue());
                        break;
                    case 0xA301: // SceneType
                        rtn = blob.GetBlobValue()[0] == 1 ? "Directly photographed" : "Unknown";
                        break;
                    default:
                        rtn = Encoding.ASCII.GetString(blob.GetBlobValue());
                        break;
                }
            }
            else if (value is string)
            {
                switch (tag_key)
                {
                    case 0x1: // GPSLatitudeRef
                        switch ((string)value)
                        {
                            case "N": rtn = "North"; break;
                            case "S": rtn = "South"; break;
                            default: rtn = "Unknown"; break;
                        }
                        break;
                    case 0x3: // GPSLongitudeRef
                        switch ((string)value)
                        {
                            case "E": rtn = "East"; break;
                            case "W": rtn = "West"; break;
                            default: rtn = "Unknown"; break;
                        }
                        break;
                    case 0x10: // GPSImgDirectionRef
                        switch ((string)value)
                        {
                            case "M": rtn = "Magnetic North"; break;
                            case "T": rtn = "True North"; break;
                            default: rtn = "Unknown"; break;
                        }
                        break;
                    case 0x131: // Software
                    case 0x132: // DateTime
                    case 0x9003: // DateTimeOriginal
                    case 0x9004: // DateTimeDigitized
                    case 0x9291: // SubSecTimeOriginal
                    case 0x9292: // SubSecTimeDigitized
                    default:
                        rtn = value as string;
                        break;
                }
            }
            else if (value is uint)
            {
                switch (tag_key)
                {
                    case 0xA002: // PixelXDimension
                    case 0xA003: // PixelYDimension
                    default:
                        rtn = string.Format("{0}", (uint)value);
                        break;
                }
            }
            else if (value is byte)
            {
                switch (tag_key)
                {
                    case 0x5: // GPSAltitudeRef
                        switch ((byte)value)
                        {
                            case 0: rtn = "Above Sea Level"; break;
                            case 1: rtn = "Below Sea Level"; break;
                            default: rtn = "Unknown"; break;
                        }
                        break;
                    default:
                        rtn = string.Format("{0}", (uint)value);
                        break;
                }
            }
            else if (value is ushort[])
            {
                ushort[] uv = value as ushort[];
                switch (tag_key)
                {
                    case 0x9214: // SubjectArea
                    default:
                        for (int i = 0; i < uv.Length; i++)
                        {
                            rtn += uv[i].ToString() + ' ';
                        }
                        break;
                }
            }
            else
            {
                object vv = value;
            }

            return rtn;
        }
    }
}
