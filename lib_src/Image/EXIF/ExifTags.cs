/* Copyright (C) the essencelib4csharp contributors. All rights reserved.
 *
 * This file is part of essencelib4csharp, distributed under the GNU GPL v2 with
 * a Linking Exception.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;

namespace essencelib.Image.EXIF
{
    public class ExifTags
    {
        private readonly static Hashtable tags = new Hashtable();

        public static SortedList SortedTags
        {
            get
            {
                return new SortedList(ExifTags.tags);
            }
        }

        public static ExifTag GetTag(int key)
        {
            System.Diagnostics.Debug.Assert(tags.Count > 0, "must call ExifTags.InitJpegTags() once before");

            ExifTag rtn;

            if (tags.ContainsKey(key))
                rtn = tags[key] as ExifTag;
            else
                rtn = null;

            return rtn;
        }

        public static void Add(int key, string name, string desc, string query, TagValueType value_type, string value_desc = null)
        {
            tags.Add(key, new ExifTag(key, name.Trim(), desc.Trim(), query.Trim(), value_type, value_desc));
        }

        public static void InitJpegTags()
        {
            if (tags.Count == 0)
            {
                var sb_vdesc = new StringBuilder();
                Add(0x0, "GPSVersionID               ", "GPS tag version                               ", "/app1/ifd/gps/subifd:{ulong=0}", TagValueType.Unknown);

                sb_vdesc.Clear();
                sb_vdesc.AppendLine("case N:North");
                sb_vdesc.AppendLine("case S:South");
                Add(0x1, "GPSLatitudeRef             ", "North or South Latitude                       ", "/app1/ifd/gps/subifd:{ulong=1}", TagValueType.Unknown, sb_vdesc.ToString());

                Add(0x2, "GPSLatitude                ", "Latitude                                      ", "/app1/ifd/gps/subifd:{ulong=2}", TagValueType.GPSRational);

                sb_vdesc.Clear();
                sb_vdesc.AppendLine("case E:East");
                sb_vdesc.AppendLine("case W:West");
                Add(0x3, "GPSLongitudeRef            ", "East or West Longitude                        ", "/app1/ifd/gps/subifd:{ulong=3}", TagValueType.Unknown, sb_vdesc.ToString());

                Add(0x4, "GPSLongitude               ", "Longitude                                     ", "/app1/ifd/gps/subifd:{ulong=4}", TagValueType.GPSRational);

                sb_vdesc.Clear();
                sb_vdesc.AppendLine("case 0:Above Sea Level");
                sb_vdesc.AppendLine("case 1:Below Sea Level");
                Add(0x5, "GPSAltitudeRef             ", "Altitude reference                            ", "/app1/ifd/gps/subifd:{ulong=5}", TagValueType.Unknown, sb_vdesc.ToString());

                Add(0x6, "GPSAltitude                ", "Altitude                                      ", "/app1/ifd/gps/subifd:{ulong=6}", TagValueType.Rational);
                Add(0x7, "GPSTimeStamp               ", "GPS time (atomic clock)                       ", "/app1/ifd/gps/subifd:{ulong=7}", TagValueType.GPSRational);
                Add(0x8, "GPSSatellites              ", "GPS satellites used for measurement           ", "/app1/ifd/gps/subifd:{ulong=8}", TagValueType.Unknown);
                Add(0x9, "GPSStatus                  ", "GPS receiver status                           ", "/app1/ifd/gps/subifd:{ulong=9}", TagValueType.Unknown);
                Add(0xA, "GPSMeasureMode             ", "GPS measurement mode                          ", "/app1/ifd/gps/subifd:{ulong=10}", TagValueType.Unknown);
                Add(0xB, "GPSDOP                     ", "Measurement precision                         ", "/app1/ifd/gps/subifd:{ulong=11}", TagValueType.Unknown);
                Add(0xC, "GPSSpeedRef                ", "Speed unit                                    ", "/app1/ifd/gps/subifd:{ulong=12}", TagValueType.Unknown);
                Add(0xD, "GPSSpeed                   ", "Speed of GPS receiver                         ", "/app1/ifd/gps/subifd:{ulong=13}", TagValueType.Unknown);
                Add(0xE, "GPSTrackRef                ", "Reference for direction of movement           ", "/app1/ifd/gps/subifd:{ulong=14}", TagValueType.Unknown);
                Add(0xF, "GPSTrack                   ", "Direction of movement                         ", "/app1/ifd/gps/subifd:{ulong=15}", TagValueType.Unknown);

                sb_vdesc.Clear();
                sb_vdesc.AppendLine("case M:Magnetic North");
                sb_vdesc.AppendLine("case T:True North");
                Add(0x10, "GPSImgDirectionRef         ", "Reference for direction of image              ", "/app1/ifd/gps/subifd:{ulong=16}", TagValueType.Unknown, sb_vdesc.ToString());

                Add(0x11, "GPSImgDirection            ", "Direction of image                            ", "/app1/ifd/gps/subifd:{ulong=17}", TagValueType.Rational);
                Add(0x12, "GPSMapDatum                ", "Geodetic survey data used                     ", "/app1/ifd/gps/subifd:{ulong=18}", TagValueType.Unknown);
                Add(0x13, "GPSDestLatitudeRef         ", "Reference for latitude of destination         ", "/app1/ifd/gps/subifd:{ulong=19}", TagValueType.Unknown);
                Add(0x14, "GPSDestLatitude            ", "Latitude of destination                       ", "/app1/ifd/gps/subifd:{ulong=20}", TagValueType.Unknown);
                Add(0x15, "GPSDestLongitudeRef        ", "Reference for longitude of destination        ", "/app1/ifd/gps/subifd:{ulong=21}", TagValueType.Unknown);
                Add(0x16, "GPSDestLongitude           ", "Longitude of destination                      ", "/app1/ifd/gps/subifd:{ulong=22}", TagValueType.Unknown);
                Add(0x17, "GPSDestBearingRef          ", "Reference for bearing of destination          ", "/app1/ifd/gps/subifd:{ulong=23}", TagValueType.Unknown);
                Add(0x18, "GPSDestBearing             ", "Bearing of destination                        ", "/app1/ifd/gps/subifd:{ulong=24}", TagValueType.Unknown);
                Add(0x19, "GPSDestDistanceRef         ", "Reference for distance to destination         ", "/app1/ifd/gps/subifd:{ulong=25}", TagValueType.Unknown);
                Add(0x1A, "GPSDestDistance            ", "Distance to destination                       ", "/app1/ifd/gps/subifd:{ulong=26}", TagValueType.Unknown);
                Add(0x1B, "GPSProcessingMethod        ", "Name of GPS processing method                 ", "/app1/ifd/gps/subifd:{ulong=27}", TagValueType.Unknown);
                Add(0x1C, "GPSAreaInformation         ", "Name of GPS area                              ", "/app1/ifd/gps/subifd:{ulong=28}", TagValueType.Unknown);
                Add(0x1D, "GPSDateStamp               ", "GPS date                                      ", "/app1/ifd/gps/subifd:{ulong=29}", TagValueType.Unknown);
                Add(0x1E, "GPSDifferential            ", "GPS differential correction                   ", "/app1/ifd/gps/subifd:{ulong=30}", TagValueType.Unknown);
                Add(0x100, "ImageWidth                 ", "Image width                                   ", "/app1/ifd/{ushort=256}", TagValueType.Unknown);
                Add(0x101, "ImageHeight                ", "Image height                                  ", "/app1/ifd/{ushort=257}", TagValueType.Unknown);
                Add(0x102, "BitsPerSample              ", "Number of bits per component                  ", "/app1/ifd/{ushort=258}", TagValueType.Unknown);
                Add(0x103, "Compression                ", "Compression scheme                            ", "/app1/ifd/{ushort=259}", TagValueType.Unknown);
                Add(0x106, "PhotometricInterpretation  ", "Pixel composition                             ", "/app1/ifd/{ushort=262}", TagValueType.Unknown);
                Add(0x10E, "ImageDescription           ", "Image title                                   ", "/app1/ifd/{ushort=270}", TagValueType.Unknown);
                Add(0x10F, "Make                       ", "Image input equipment manufacturer            ", "/app1/ifd/{ushort=271}", TagValueType.Unknown);
                Add(0x110, "Model                      ", "Image input equipment model                   ", "/app1/ifd/{ushort=272}", TagValueType.Unknown);
                Add(0x111, "StripOffsets               ", "Image data location                           ", "/app1/ifd/{ushort=273}", TagValueType.Unknown);

                sb_vdesc.Clear();
                sb_vdesc.AppendLine("case 1:Horizontal (normal)                ");
                sb_vdesc.AppendLine("case 2:Mirror horizontal                  ");
                sb_vdesc.AppendLine("case 3:Rotate 180                         ");
                sb_vdesc.AppendLine("case 4:Mirror vertical                    ");
                sb_vdesc.AppendLine("case 5:Mirror horizontal and rotate 270 CW");
                sb_vdesc.AppendLine("case 6:Rotate 90 CW                       ");
                sb_vdesc.AppendLine("case 7:Mirror horizontal and rotate 90 CW ");
                sb_vdesc.AppendLine("case 8:Rotate 270 CW                      ");
                Add(0x112, "Orientation                ", "Orientation of image                          ", "/app1/ifd/{ushort=274}", TagValueType.Unknown, sb_vdesc.ToString());

                Add(0x115, "SamplesPerPixel            ", "Number of components                          ", "/app1/ifd/{ushort=277}", TagValueType.Unknown);
                Add(0x116, "RowsPerStrip               ", "Number of rows per strip                      ", "/app1/ifd/{ushort=278}", TagValueType.Unknown);
                Add(0x117, "StripByteCounts            ", "Bytes per compressed strip                    ", "/app1/ifd/{ushort=279}", TagValueType.Unknown);
                Add(0x11A, "XResolution                ", "Image resolution in width direction           ", "/app1/ifd/{ushort=282}", TagValueType.Rational);
                Add(0x11B, "YResolution                ", "Image resolution in height direction          ", "/app1/ifd/{ushort=283}", TagValueType.Rational);
                Add(0x11C, "PlanarConfiguration        ", "Image data arrangement                        ", "/app1/ifd/{ushort=284}", TagValueType.Unknown);

                sb_vdesc.Clear();
                sb_vdesc.AppendLine("case 1:None");
                sb_vdesc.AppendLine("case 2:inches");
                sb_vdesc.AppendLine("case 3:cm");
                Add(0x128, "ResolutionUnit             ", "Unit of X and Y resolution                    ", "/app1/ifd/{ushort=296}", TagValueType.Unknown, sb_vdesc.ToString());

                Add(0x12D, "TransferFunction           ", "Transfer function                             ", "/app1/ifd/{ushort=301}", TagValueType.Unknown);
                Add(0x131, "Software                   ", "Software used                                 ", "/app1/ifd/{ushort=305}", TagValueType.Unknown);
                Add(0x132, "DateTime                   ", "File change date and time                     ", "/app1/ifd/{ushort=306}", TagValueType.Unknown);
                Add(0x13B, "Artist                     ", "Person who created the image                  ", "/app1/ifd/{ushort=315}", TagValueType.Unknown);
                Add(0x13E, "WhitePoint                 ", "White point chromaticity                      ", "/app1/ifd/{ushort=318}", TagValueType.Unknown);
                Add(0x13F, "PrimaryChromaticities      ", "Chromaticities of primaries                   ", "/app1/ifd/{ushort=319}", TagValueType.Unknown);
                Add(0x201, "JPEGInterchangeFormat      ", "Offset to JPEG SOI - ThumbnailOffset          ", "/app1/ifd/{ushort=513}", TagValueType.Unknown);
                Add(0x202, "JPEGInterchangeFormatLength", "Bytes of JPEG data - ThumbnailLength          ", "/app1/ifd/{ushort=514}", TagValueType.Unknown);
                Add(0x211, "YCbCrCoefficients          ", "Color space transformation matrix coefficients", "/app1/ifd/{ushort=529}", TagValueType.Unknown);
                Add(0x212, "YCbCrSubSampling           ", "Subsampling ratio of Y to C                   ", "/app1/ifd/{ushort=530}", TagValueType.Unknown);

                sb_vdesc.Clear();
                sb_vdesc.AppendLine("case 1:Centered");
                sb_vdesc.AppendLine("case 2:Co-sited");
                Add(0x213, "YCbCrPositioning           ", "Y and C positioning                           ", "/app1/ifd/{ushort=531}", TagValueType.Unknown, sb_vdesc.ToString());

                Add(0x214, "ReferenceBlackWhite        ", "Pair of black and white reference values      ", "/app1/ifd/{ushort=532}", TagValueType.Unknown);
                Add(0x8298, "Copyright                  ", "Copyright holder                              ", "/app1/ifd/exif/subifd:{ushort=33432}", TagValueType.Unknown);
                Add(0x829A, "ExposureTime               ", "Exposure time                                 ", "/app1/ifd/exif/subifd:{ushort=33434}", TagValueType.Rational);
                Add(0x829D, "FNumber                    ", "F number - LensAperture                       ", "/app1/ifd/exif/subifd:{ushort=33437}", TagValueType.Rational);

                sb_vdesc.Clear();
                sb_vdesc.AppendLine("case 0:Not Defined              ");
                sb_vdesc.AppendLine("case 1:Manual                   ");
                sb_vdesc.AppendLine("case 2:Program AE               ");
                sb_vdesc.AppendLine("case 3:Aperture-priority AE     ");
                sb_vdesc.AppendLine("case 4:Shutter speed priority AE");
                sb_vdesc.AppendLine("case 5:Creative (Slow speed)    ");
                sb_vdesc.AppendLine("case 6:Action (High speed)      ");
                sb_vdesc.AppendLine("case 7:Portrait                 ");
                sb_vdesc.AppendLine("case 8:Landscape                ");
                sb_vdesc.AppendLine("case 9:Bulb                     ");
                Add(0x8822, "ExposureProgram            ", "Exposure program                              ", "/app1/ifd/exif/subifd:{ushort=34850}", TagValueType.Unknown, sb_vdesc.ToString());

                Add(0x8824, "SpectralSensitivity        ", "Spectral sensitivity                          ", "/app1/ifd/exif/subifd:{ushort=34852}", TagValueType.Unknown);
                Add(0x8827, "ISOSpeedRatings            ", "ISO speed rating                              ", "/app1/ifd/exif/subifd:{ushort=34855}", TagValueType.Unknown);
                Add(0x8828, "OECF                       ", "Optoelectric conversion factor                ", "/app1/ifd/exif/subifd:{ushort=34856}", TagValueType.Unknown);
                Add(0x9000, "ExifVersion                ", "Exif version                                  ", "/app1/ifd/exif/subifd:{ushort=36864}", TagValueType.Unknown);
                Add(0x9003, "DateTimeOriginal           ", "Date and time of original data generation     ", "/app1/ifd/exif/subifd:{ushort=36867}", TagValueType.Unknown);
                Add(0x9004, "DateTimeDigitized          ", "Date and time of digital data generation      ", "/app1/ifd/exif/subifd:{ushort=36868}", TagValueType.Unknown);
                Add(0x9101, "ComponentsConfiguration    ", "Meaning of each component                     ", "/app1/ifd/exif/subifd:{ushort=37121}", TagValueType.Unknown);
                Add(0x9102, "CompressedBitsPerPixel     ", "Image compression mode                        ", "/app1/ifd/exif/subifd:{ushort=37122}", TagValueType.Unknown);
                Add(0x9201, "ShutterSpeedValue          ", "Shutter speed                                 ", "/app1/ifd/exif/subifd:{ushort=37377}", TagValueType.ShutterSpeed);
                Add(0x9202, "ApertureValue              ", "Aperture                                      ", "/app1/ifd/exif/subifd:{ushort=37378}", TagValueType.Aperture);
                Add(0x9203, "BrightnessValue            ", "Brightness                                    ", "/app1/ifd/exif/subifd:{ushort=37379}", TagValueType.Rational);
                Add(0x9204, "ExposureBiasValue          ", "Exposure bias                                 ", "/app1/ifd/exif/subifd:{ushort=37380}", TagValueType.Unknown);
                Add(0x9205, "MaxApertureValue           ", "Maximum lens aperture                         ", "/app1/ifd/exif/subifd:{ushort=37381}", TagValueType.Unknown);
                Add(0x9206, "SubjectDistance            ", "Subject distance                              ", "/app1/ifd/exif/subifd:{ushort=37382}", TagValueType.Unknown);

                sb_vdesc.Clear();
                sb_vdesc.AppendLine("case 0  :Unknown                ");
                sb_vdesc.AppendLine("case 1  :Average                ");
                sb_vdesc.AppendLine("case 2  :Center-weighted average");
                sb_vdesc.AppendLine("case 3  :Spot                   ");
                sb_vdesc.AppendLine("case 4  :Multi-spot             ");
                sb_vdesc.AppendLine("case 5  :Multi-segment          ");
                sb_vdesc.AppendLine("case 6  :Partial                ");
                sb_vdesc.AppendLine("case 255:Other                  ");
                Add(0x9207, "MeteringMode               ", "Metering mode                                 ", "/app1/ifd/exif/subifd:{ushort=37383}", TagValueType.Unknown, sb_vdesc.ToString());

                Add(0x9208, "LightSource                ", "Light source                                  ", "/app1/ifd/exif/subifd:{ushort=37384}", TagValueType.Unknown);

                sb_vdesc.Clear();
                sb_vdesc.AppendLine("case 0x0 :No Flash                                           ");
                sb_vdesc.AppendLine("case 0x1 :Fired                                              ");
                sb_vdesc.AppendLine("case 0x5 :Fired, Return not detected                         ");
                sb_vdesc.AppendLine("case 0x7 :Fired, Return detected                             ");
                sb_vdesc.AppendLine("case 0x8 :On, Did not fire                                   ");
                sb_vdesc.AppendLine("case 0x9 :On, Fired                                          ");
                sb_vdesc.AppendLine("case 0xd :On, Return not detected                            ");
                sb_vdesc.AppendLine("case 0xf :On, Return detected                                ");
                sb_vdesc.AppendLine("case 0x10:Off, Did not fire                                  ");
                sb_vdesc.AppendLine("case 0x14:Off, Did not fire, Return not detected             ");
                sb_vdesc.AppendLine("case 0x18:Auto, Did not fire                                 ");
                sb_vdesc.AppendLine("case 0x19:Auto, Fired                                        ");
                sb_vdesc.AppendLine("case 0x1d:Auto, Fired, Return not detected                   ");
                sb_vdesc.AppendLine("case 0x1f:Auto, Fired, Return detected                       ");
                sb_vdesc.AppendLine("case 0x20:No flash function                                  ");
                sb_vdesc.AppendLine("case 0x30:Off, No flash function                             ");
                sb_vdesc.AppendLine("case 0x41:Fired, Red-eye reduction                           ");
                sb_vdesc.AppendLine("case 0x45:Fired, Red-eye reduction, Return not detected      ");
                sb_vdesc.AppendLine("case 0x47:Fired, Red-eye reduction, Return detected          ");
                sb_vdesc.AppendLine("case 0x49:On, Red-eye reduction                              ");
                sb_vdesc.AppendLine("case 0x4d:On, Red-eye reduction, Return not detected         ");
                sb_vdesc.AppendLine("case 0x4f:On, Red-eye reduction, Return detected             ");
                sb_vdesc.AppendLine("case 0x50:Off, Red-eye reduction                             ");
                sb_vdesc.AppendLine("case 0x58:Auto, Did not fire, Red-eye reduction              ");
                sb_vdesc.AppendLine("case 0x59:Auto, Fired, Red-eye reduction                     ");
                sb_vdesc.AppendLine("case 0x5d:Auto, Fired, Red-eye reduction, Return not detected");
                sb_vdesc.AppendLine("case 0x5f:Auto, Fired, Red-eye reduction, Return detected    ");
                Add(0x9209, "Flash                      ", "Flash                                         ", "/app1/ifd/exif/subifd:{ushort=37385}", TagValueType.Unknown, sb_vdesc.ToString());

                Add(0x920A, "FocalLength                ", "Lens focal length                             ", "/app1/ifd/exif/subifd:{ushort=37386}", TagValueType.Rational);
                Add(0x9214, "SubjectArea                ", "Subject area                                  ", "/app1/ifd/exif/subifd:{ushort=37396}", TagValueType.Unknown);
                Add(0x927C, "MakerNote                  ", "Manufacturer notes                            ", "/app1/ifd/exif/subifd:{ushort=37500}", TagValueType.Unknown);
                Add(0x9286, "UserComment                ", "User comments                                 ", "/app1/ifd/exif/subifd:{ushort=37510}", TagValueType.Unknown);
                Add(0x9290, "SubSecTime                 ", "DateTime subseconds                           ", "/app1/ifd/exif/subifd:{ushort=37520}", TagValueType.Unknown);
                Add(0x9291, "SubSecTimeOriginal         ", "DateTimeOriginal subseconds                   ", "/app1/ifd/exif/subifd:{ushort=37521}", TagValueType.Unknown);
                Add(0x9292, "SubSecTimeDigitized        ", "DateTimeDigitized subseconds                  ", "/app1/ifd/exif/subifd:{ushort=37522}", TagValueType.Unknown);
                Add(0xA000, "FlashpixVersion            ", "Supported Flashpix version                    ", "/app1/ifd/exif/subifd:{ushort=40960}", TagValueType.Unknown);

                sb_vdesc.Clear();
                sb_vdesc.AppendLine("case 0x1   :sRGB          ");
                sb_vdesc.AppendLine("case 0x2   :Adobe RGB     ");
                sb_vdesc.AppendLine("case 0xfffd:Wide Gamut RGB");
                sb_vdesc.AppendLine("case 0xfffe:ICC Profile   ");
                sb_vdesc.AppendLine("case 0xffff:Uncalibrated  ");
                Add(0xA001, "ColorSpace                 ", "Color space information                       ", "/app1/ifd/exif/subifd:{ushort=40961}", TagValueType.Unknown, sb_vdesc.ToString());

                Add(0xA002, "PixelXDimension            ", "Valid image width                             ", "/app1/ifd/exif/subifd:{ushort=40962}", TagValueType.Unknown);
                Add(0xA003, "PixelYDimension            ", "Valid image height                            ", "/app1/ifd/exif/subifd:{ushort=40963}", TagValueType.Unknown);
                Add(0xA004, "RelatedSoundFile           ", "Related audio file                            ", "/app1/ifd/exif/subifd:{ushort=40964}", TagValueType.Unknown);
                Add(0xA20B, "FlashEnergy                ", "Flash energy                                  ", "/app1/ifd/exif/subifd:{ushort=41483}", TagValueType.Unknown);
                Add(0xA20C, "SpatialFrequencyResponse   ", "Spatial frequency response                    ", "/app1/ifd/exif/subifd:{ushort=41484}", TagValueType.Unknown);
                Add(0xA20E, "FocalPlaneXResolution      ", "Focal plane X resolution                      ", "/app1/ifd/exif/subifd:{ushort=41486}", TagValueType.Unknown);
                Add(0xA20F, "FocalPlaneYResolution      ", "Focal plane Y resolution                      ", "/app1/ifd/exif/subifd:{ushort=41487}", TagValueType.Unknown);
                Add(0xA210, "FocalPlaneResolutionUnit   ", "Focal plane resolution unit                   ", "/app1/ifd/exif/subifd:{ushort=41488}", TagValueType.Unknown);
                Add(0xA214, "SubjectLocation            ", "Subject location                              ", "/app1/ifd/exif/subifd:{ushort=41492}", TagValueType.Unknown);
                Add(0xA215, "ExposureIndex              ", "Exposure index                                ", "/app1/ifd/exif/subifd:{ushort=41493}", TagValueType.Unknown);

                sb_vdesc.Clear();
                sb_vdesc.AppendLine("case 1:Not defined            ");
                sb_vdesc.AppendLine("case 2:One-chip color area    ");
                sb_vdesc.AppendLine("case 3:Two-chip color area    ");
                sb_vdesc.AppendLine("case 4:Three-chip color area  ");
                sb_vdesc.AppendLine("case 5:Color sequential area  ");
                sb_vdesc.AppendLine("case 7:Trilinear              ");
                sb_vdesc.AppendLine("case 8:Color sequential linear");
                Add(0xA217, "SensingMethod              ", "Sensing method                                ", "/app1/ifd/exif/subifd:{ushort=41495}", TagValueType.Unknown, sb_vdesc.ToString());

                Add(0xA300, "FileSource                 ", "File source                                   ", "/app1/ifd/exif/subifd:{ushort=41728}", TagValueType.Unknown);

                sb_vdesc.Clear();
                sb_vdesc.AppendLine("case 1:Directly photographed");
                Add(0xA301, "SceneType                  ", "Scene type                                    ", "/app1/ifd/exif/subifd:{ushort=41729}", TagValueType.Unknown, sb_vdesc.ToString());

                Add(0xA302, "CFAPattern                 ", "CFA pattern                                   ", "/app1/ifd/exif/subifd:{ushort=41730}", TagValueType.Unknown);
                Add(0xA401, "CustomRendered             ", "Custom image processing                       ", "/app1/ifd/exif/subifd:{ushort=41985}", TagValueType.Unknown);

                sb_vdesc.Clear();
                sb_vdesc.AppendLine("case 0:Auto");
                sb_vdesc.AppendLine("case 1:Manual");
                sb_vdesc.AppendLine("case 2:Auto bracket");
                Add(0xA402, "ExposureMode               ", "Exposure mode                                 ", "/app1/ifd/exif/subifd:{ushort=41986}", TagValueType.Unknown, sb_vdesc.ToString());

                sb_vdesc.Clear();
                sb_vdesc.AppendLine("case 0:Auto");
                sb_vdesc.AppendLine("case 1:Manual");
                Add(0xA403, "WhiteBalance               ", "White balance                                 ", "/app1/ifd/exif/subifd:{ushort=41987}", TagValueType.Unknown, sb_vdesc.ToString());

                Add(0xA404, "DigitalZoomRatio           ", "Digital zoom ratio                            ", "/app1/ifd/exif/subifd:{ushort=41988}", TagValueType.Unknown);
                Add(0xA405, "FocalLengthIn35mmFilm      ", "Focal length in 35 mm film                    ", "/app1/ifd/exif/subifd:{ushort=41989}", TagValueType.Unknown);

                sb_vdesc.Clear();
                sb_vdesc.AppendLine("case 0:Standard");
                sb_vdesc.AppendLine("case 1:Landscape");
                sb_vdesc.AppendLine("case 2:Portrait");
                sb_vdesc.AppendLine("case 3:Night");
                Add(0xA406, "SceneCaptureType           ", "Scene capture type                            ", "/app1/ifd/exif/subifd:{ushort=41990}", TagValueType.Unknown, sb_vdesc.ToString());

                Add(0xA407, "GainControl                ", "Gain control                                  ", "/app1/ifd/exif/subifd:{ushort=41991}", TagValueType.Unknown);
                Add(0xA408, "Contrast                   ", "Contrast                                      ", "/app1/ifd/exif/subifd:{ushort=41992}", TagValueType.Unknown);
                Add(0xA409, "Saturation                 ", "Saturation                                    ", "/app1/ifd/exif/subifd:{ushort=41993}", TagValueType.Unknown);
                Add(0xA40A, "Sharpness                  ", "Sharpness                                     ", "/app1/ifd/exif/subifd:{ushort=41994}", TagValueType.Unknown);
                Add(0xA40B, "DeviceSettingDescription   ", "Device settings description                   ", "/app1/ifd/exif/subifd:{ushort=41995}", TagValueType.Unknown);
                Add(0xA40C, "SubjectDistanceRange       ", "Subject distance range                        ", "/app1/ifd/exif/subifd:{ushort=41996}", TagValueType.Unknown);
                Add(0xA420, "ImageUniqueID              ", "Unique image ID                               ", "/app1/ifd/exif/subifd:{ushort=42016}", TagValueType.Unknown);
            }
        }
    }
}