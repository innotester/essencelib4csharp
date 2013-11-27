using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

using System.Windows.Media.Imaging;

namespace essencelib.Image
{
    public class ExifTags
    {
        public static Hashtable tags = new Hashtable();

        public static void Add(int key, string name, string desc, string query, TagValueType value_type)
        {
            tags.Add(key, new ExifTag(key, name, desc, query, value_type));
        }

        public static void InitJpegTags()
        {
            if (tags.Count == 0)
            {
                Add(0x0, "GPSVersionID               ", "GPS tag version                               ", "/app1/ifd/gps/subifd:{ulong=0}", TagValueType.Unknown);
                Add(0x1, "GPSLatitudeRef             ", "North or South Latitude                       ", "/app1/ifd/gps/subifd:{ulong=1}", TagValueType.Unknown);
                Add(0x2, "GPSLatitude                ", "Latitude                                      ", "/app1/ifd/gps/subifd:{ulong=2}", TagValueType.GPSRational);
                Add(0x3, "GPSLongitudeRef            ", "East or West Longitude                        ", "/app1/ifd/gps/subifd:{ulong=3}", TagValueType.Unknown);
                Add(0x4, "GPSLongitude               ", "Longitude                                     ", "/app1/ifd/gps/subifd:{ulong=4}", TagValueType.GPSRational);
                Add(0x5, "GPSAltitudeRef             ", "Altitude reference                            ", "/app1/ifd/gps/subifd:{ulong=5}", TagValueType.Unknown);
                Add(0x6, "GPSAltitude                ", "Altitude                                      ", "/app1/ifd/gps/subifd:{ulong=6}", TagValueType.Rational);
                Add(0x7, "GPSTimeStamp               ", "GPS time (atomic clock)                       ", "/app1/ifd/gps/subifd:{ulong=7}", TagValueType.Unknown);
                Add(0x8, "GPSSatellites              ", "GPS satellites used for measurement           ", "/app1/ifd/gps/subifd:{ulong=8}", TagValueType.Unknown);
                Add(0x9, "GPSStatus                  ", "GPS receiver status                           ", "/app1/ifd/gps/subifd:{ulong=9}", TagValueType.Unknown);
                Add(0xA, "GPSMeasureMode             ", "GPS measurement mode                          ", "/app1/ifd/gps/subifd:{ulong=10}", TagValueType.Unknown);
                Add(0xB, "GPSDOP                     ", "Measurement precision                         ", "/app1/ifd/gps/subifd:{ulong=11}", TagValueType.Unknown);
                Add(0xC, "GPSSpeedRef                ", "Speed unit                                    ", "/app1/ifd/gps/subifd:{ulong=12}", TagValueType.Unknown);
                Add(0xD, "GPSSpeed                   ", "Speed of GPS receiver                         ", "/app1/ifd/gps/subifd:{ulong=13}", TagValueType.Unknown);
                Add(0xE, "GPSTrackRef                ", "Reference for direction of movement           ", "/app1/ifd/gps/subifd:{ulong=14}", TagValueType.Unknown);
                Add(0xF, "GPSTrack                   ", "Direction of movement                         ", "/app1/ifd/gps/subifd:{ulong=15}", TagValueType.Unknown);
                Add(0x10, "GPSImgDirectionRef         ", "Reference for direction of image              ", "/app1/ifd/gps/subifd:{ulong=16}", TagValueType.Unknown);
                Add(0x11, "GPSImgDirection            ", "Direction of image                            ", "/app1/ifd/gps/subifd:{ulong=17}", TagValueType.Unknown);
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
                Add(0x112, "Orientation                ", "Orientation of image                          ", "/app1/ifd/{ushort=274}", TagValueType.Unknown);
                Add(0x115, "SamplesPerPixel            ", "Number of components                          ", "/app1/ifd/{ushort=277}", TagValueType.Unknown);
                Add(0x116, "RowsPerStrip               ", "Number of rows per strip                      ", "/app1/ifd/{ushort=278}", TagValueType.Unknown);
                Add(0x117, "StripByteCounts            ", "Bytes per compressed strip                    ", "/app1/ifd/{ushort=279}", TagValueType.Unknown);
                Add(0x11A, "XResolution                ", "Image resolution in width direction           ", "/app1/ifd/{ushort=282}", TagValueType.Unknown);
                Add(0x11B, "YResolution                ", "Image resolution in height direction          ", "/app1/ifd/{ushort=283}", TagValueType.Unknown);
                Add(0x11C, "PlanarConfiguration        ", "Image data arrangement                        ", "/app1/ifd/{ushort=284}", TagValueType.Unknown);
                Add(0x128, "ResolutionUnit             ", "Unit of X and Y resolution                    ", "/app1/ifd/{ushort=296}", TagValueType.Unknown);
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
                Add(0x213, "YCbCrPositioning           ", "Y and C positioning                           ", "/app1/ifd/{ushort=531}", TagValueType.Unknown);
                Add(0x214, "ReferenceBlackWhite        ", "Pair of black and white reference values      ", "/app1/ifd/{ushort=532}", TagValueType.Unknown);
                Add(0x8298, "Copyright                  ", "Copyright holder                              ", "/app1/ifd/exif/subifd:{ushort=33432}", TagValueType.Unknown);
                Add(0x829A, "ExposureTime               ", "Exposure time                                 ", "/app1/ifd/exif/subifd:{ushort=33434}", TagValueType.Unknown);
                Add(0x829D, "FNumber                    ", "F number - LensAperture                       ", "/app1/ifd/exif/subifd:{ushort=33437}", TagValueType.Unknown);
                Add(0x8822, "ExposureProgram            ", "Exposure program                              ", "/app1/ifd/exif/subifd:{ushort=34850}", TagValueType.Unknown);
                Add(0x8824, "SpectralSensitivity        ", "Spectral sensitivity                          ", "/app1/ifd/exif/subifd:{ushort=34852}", TagValueType.Unknown);
                Add(0x8827, "ISOSpeedRatings            ", "ISO speed rating                              ", "/app1/ifd/exif/subifd:{ushort=34855}", TagValueType.Unknown);
                Add(0x8828, "OECF                       ", "Optoelectric conversion factor                ", "/app1/ifd/exif/subifd:{ushort=34856}", TagValueType.Unknown);
                Add(0x9000, "ExifVersion                ", "Exif version                                  ", "/app1/ifd/exif/subifd:{ushort=36864}", TagValueType.Unknown);
                Add(0x9003, "DateTimeOriginal           ", "Date and time of original data generation     ", "/app1/ifd/exif/subifd:{ushort=36867}", TagValueType.Unknown);
                Add(0x9004, "DateTimeDigitized          ", "Date and time of digital data generation      ", "/app1/ifd/exif/subifd:{ushort=36868}", TagValueType.Unknown);
                Add(0x9101, "ComponentsConfiguration    ", "Meaning of each component                     ", "/app1/ifd/exif/subifd:{ushort=37121}", TagValueType.Unknown);
                Add(0x9102, "CompressedBitsPerPixel     ", "Image compression mode                        ", "/app1/ifd/exif/subifd:{ushort=37122}", TagValueType.Unknown);
                Add(0x9201, "ShutterSpeedValue          ", "Shutter speed                                 ", "/app1/ifd/exif/subifd:{ushort=37377}", TagValueType.Unknown);
                Add(0x9202, "ApertureValue              ", "Aperture                                      ", "/app1/ifd/exif/subifd:{ushort=37378}", TagValueType.Unknown);
                Add(0x9203, "BrightnessValue            ", "Brightness                                    ", "/app1/ifd/exif/subifd:{ushort=37379}", TagValueType.Unknown);
                Add(0x9204, "ExposureBiasValue          ", "Exposure bias                                 ", "/app1/ifd/exif/subifd:{ushort=37380}", TagValueType.Unknown);
                Add(0x9205, "MaxApertureValue           ", "Maximum lens aperture                         ", "/app1/ifd/exif/subifd:{ushort=37381}", TagValueType.Unknown);
                Add(0x9206, "SubjectDistance            ", "Subject distance                              ", "/app1/ifd/exif/subifd:{ushort=37382}", TagValueType.Unknown);
                Add(0x9207, "MeteringMode               ", "Metering mode                                 ", "/app1/ifd/exif/subifd:{ushort=37383}", TagValueType.Unknown);
                Add(0x9208, "LightSource                ", "Light source                                  ", "/app1/ifd/exif/subifd:{ushort=37384}", TagValueType.Unknown);
                Add(0x9209, "Flash                      ", "Flash                                         ", "/app1/ifd/exif/subifd:{ushort=37385}", TagValueType.Unknown);
                Add(0x920A, "FocalLength                ", "Lens focal length                             ", "/app1/ifd/exif/subifd:{ushort=37386}", TagValueType.Unknown);
                Add(0x9214, "SubjectArea                ", "Subject area                                  ", "/app1/ifd/exif/subifd:{ushort=37396}", TagValueType.Unknown);
                Add(0x927C, "MakerNote                  ", "Manufacturer notes                            ", "/app1/ifd/exif/subifd:{ushort=37500}", TagValueType.Unknown);
                Add(0x9286, "UserComment                ", "User comments                                 ", "/app1/ifd/exif/subifd:{ushort=37510}", TagValueType.Unknown);
                Add(0x9290, "SubSecTime                 ", "DateTime subseconds                           ", "/app1/ifd/exif/subifd:{ushort=37520}", TagValueType.Unknown);
                Add(0x9291, "SubSecTimeOriginal         ", "DateTimeOriginal subseconds                   ", "/app1/ifd/exif/subifd:{ushort=37521}", TagValueType.Unknown);
                Add(0x9292, "SubSecTimeDigitized        ", "DateTimeDigitized subseconds                  ", "/app1/ifd/exif/subifd:{ushort=37522}", TagValueType.Unknown);
                Add(0xA000, "FlashpixVersion            ", "Supported Flashpix version                    ", "/app1/ifd/exif/subifd:{ushort=40960}", TagValueType.Unknown);
                Add(0xA001, "ColorSpace                 ", "Color space information                       ", "/app1/ifd/exif/subifd:{ushort=40961}", TagValueType.Unknown);
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
                Add(0xA217, "SensingMethod              ", "Sensing method                                ", "/app1/ifd/exif/subifd:{ushort=41495}", TagValueType.Unknown);
                Add(0xA300, "FileSource                 ", "File source                                   ", "/app1/ifd/exif/subifd:{ushort=41728}", TagValueType.Unknown);
                Add(0xA301, "SceneType                  ", "Scene type                                    ", "/app1/ifd/exif/subifd:{ushort=41729}", TagValueType.Unknown);
                Add(0xA302, "CFAPattern                 ", "CFA pattern                                   ", "/app1/ifd/exif/subifd:{ushort=41730}", TagValueType.Unknown);
                Add(0xA401, "CustomRendered             ", "Custom image processing                       ", "/app1/ifd/exif/subifd:{ushort=41985}", TagValueType.Unknown);
                Add(0xA402, "ExposureMode               ", "Exposure mode                                 ", "/app1/ifd/exif/subifd:{ushort=41986}", TagValueType.Unknown);
                Add(0xA403, "WhiteBalance               ", "White balance                                 ", "/app1/ifd/exif/subifd:{ushort=41987}", TagValueType.Unknown);
                Add(0xA404, "DigitalZoomRatio           ", "Digital zoom ratio                            ", "/app1/ifd/exif/subifd:{ushort=41988}", TagValueType.Unknown);
                Add(0xA405, "FocalLengthIn35mmFilm      ", "Focal length in 35 mm film                    ", "/app1/ifd/exif/subifd:{ushort=41989}", TagValueType.Unknown);
                Add(0xA406, "SceneCaptureType           ", "Scene capture type                            ", "/app1/ifd/exif/subifd:{ushort=41990}", TagValueType.Unknown);
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

    public class ExifTag
    {
        public int key;
        public string name;
        public string desc;
        public string query;
        public TagValueType value_type = TagValueType.Unknown;
        public ExifTag(int key, string name, string desc, string query, TagValueType value_type)
        {
            this.name = name;
            this.desc = desc;
            this.query = query;
            this.value_type = value_type;
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
                        
                        break;
                    case TagValueType.Rational:
                        rtn = new Rational((ulong)raw_value);
                        break;
                    case TagValueType.URational:
                        
                        break;
                    case TagValueType.GPSRational:
                        rtn = new GPSRational((ulong[])raw_value);
                        break;
                }
            }

            return rtn;

        }
    }

    public class ExifTagValue
    {
        public TagValueType value_type = TagValueType.Unknown;
        public override string ToString()
        {
            return "";
        }
    }

    public enum TagValueType
    {
        Unknown = 0,
        Rational,
        URational,
        GPSRational,
    }

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
            return Math.Round(Convert.ToDouble(_num) / Convert.ToDouble(_denom), 2);
        }

        public string ToString(string separator)
        {
            return _num.ToString() + separator + _denom.ToString();
        }

        public override string ToString()
        {
            return this.ToString("/");
        }
    }

    public sealed class URational : ExifTagValue
    {
        private UInt32 _num;
        private UInt32 _denom;

        public URational(byte[] bytes)
        {
            value_type = TagValueType.URational;
            byte[] n = new byte[4];
            byte[] d = new byte[4];
            Array.Copy(bytes, 0, n, 0, 4);
            Array.Copy(bytes, 4, d, 0, 4);
            _num = BitConverter.ToUInt32(n, 0);
            _denom = BitConverter.ToUInt32(d, 0);
        }

        public double ToDouble()
        {
            return Math.Round(Convert.ToDouble(_num) / Convert.ToDouble(_denom), 2);
        }

        public override string ToString()
        {
            return this.ToString("/");
        }

        public string ToString(string separator)
        {
            return _num.ToString() + separator + _denom.ToString();
        }
    }

    public sealed class GPSRational : ExifTagValue
    {
        private Rational _hours;
        private Rational _minutes;
        private Rational _seconds;

        public Rational Hours
        {
            get
            {
                return _hours;
            }
            set
            {
                _hours = value;
            }
        }
        public Rational Minutes
        {
            get
            {
                return _minutes;
            }
            set
            {
                _minutes = value;
            }
        }
        public Rational Seconds
        {
            get
            {
                return _seconds;
            }
            set
            {
                _seconds = value;
            }
        }

        public GPSRational(byte[] bytes)
        {
            value_type = TagValueType.GPSRational;

            byte[] h = new byte[8]; byte[] m = new byte[8]; byte[] s = new byte[8];

            Array.Copy(bytes, 0, h, 0, 8); Array.Copy(bytes, 8, m, 0, 8); Array.Copy(bytes, 16, s, 0, 8);

            _hours = new Rational(h);
            _minutes = new Rational(m);
            _seconds = new Rational(s);
        }

        public GPSRational(ulong[] raw)
        {
            value_type = TagValueType.GPSRational;

            byte[] h = BitConverter.GetBytes(raw[0]);
            byte[] m = BitConverter.GetBytes(raw[1]);
            byte[] s = BitConverter.GetBytes(raw[2]);

            _hours = new Rational(h);
            _minutes = new Rational(m);
            _seconds = new Rational(s);
        }

        public double ToDegree()
        {
            return _hours.ToDouble() + _minutes.ToDouble() / 60.0 + _seconds.ToDouble() / 3600.0;
        }

        public override string ToString()
        {
            return _hours.ToDouble() + "° "
                + _minutes.ToDouble() + "\' "
                + _seconds.ToDouble() + "\"";
        }

        public string ToString(string separator)
        {
            return _hours.ToDouble() + separator
                + _minutes.ToDouble() + separator +
                _seconds.ToDouble();
        }
    }
}
