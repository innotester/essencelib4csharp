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
    public class ExifValues
    {
        internal BitmapMetadata _metadata;

        public ExifTagValue       GPSVersionID                { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.GPSVersionID               ); } }
        public string             GPSLatitudeRef              { get { return (string            )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.GPSLatitudeRef).value;        } }
        public GPSRational        GPSLatitude                 { get { return (GPSRational       )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.GPSLatitude                ); } }
        public string             GPSLongitudeRef             { get { return (string            )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.GPSLongitudeRef).value;       } }
        public GPSRational        GPSLongitude                { get { return (GPSRational       )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.GPSLongitude               ); } }
        public byte               GPSAltitudeRef              { get {var rtn = ExifUtil4Jpeg.GetTagValue(_metadata, TagType.GPSAltitudeRef).value;return (rtn == null) ? (byte)0 : (byte)rtn;}}
        public Rational           GPSAltitude                 { get { return (Rational          )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.GPSAltitude                ); } }
        public GPSRational        GPSTimeStamp                { get { return (GPSRational       )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.GPSTimeStamp               ); } }
        public ExifTagValue       GPSSatellites               { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.GPSSatellites              ); } }
        public ExifTagValue       GPSStatus                   { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.GPSStatus                  ); } }
        public ExifTagValue       GPSMeasureMode              { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.GPSMeasureMode             ); } }
        public ExifTagValue       GPSDOP                      { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.GPSDOP                     ); } }
        public ExifTagValue       GPSSpeedRef                 { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.GPSSpeedRef                ); } }
        public ExifTagValue       GPSSpeed                    { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.GPSSpeed                   ); } }
        public ExifTagValue       GPSTrackRef                 { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.GPSTrackRef                ); } }
        public ExifTagValue       GPSTrack                    { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.GPSTrack                   ); } }
        public string             GPSImgDirectionRef          { get { return (string            )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.GPSImgDirectionRef).value;    } }
        public Rational           GPSImgDirection             { get { return (Rational          )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.GPSImgDirection            ); } }
        public ExifTagValue       GPSMapDatum                 { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.GPSMapDatum                ); } }
        public ExifTagValue       GPSDestLatitudeRef          { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.GPSDestLatitudeRef         ); } }
        public ExifTagValue       GPSDestLatitude             { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.GPSDestLatitude            ); } }
        public ExifTagValue       GPSDestLongitudeRef         { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.GPSDestLongitudeRef        ); } }
        public ExifTagValue       GPSDestLongitude            { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.GPSDestLongitude           ); } }
        public ExifTagValue       GPSDestBearingRef           { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.GPSDestBearingRef          ); } }
        public ExifTagValue       GPSDestBearing              { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.GPSDestBearing             ); } }
        public ExifTagValue       GPSDestDistanceRef          { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.GPSDestDistanceRef         ); } }
        public ExifTagValue       GPSDestDistance             { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.GPSDestDistance            ); } }
        public ExifTagValue       GPSProcessingMethod         { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.GPSProcessingMethod        ); } }
        public ExifTagValue       GPSAreaInformation          { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.GPSAreaInformation         ); } }
        public ExifTagValue       GPSDateStamp                { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.GPSDateStamp               ); } }
        public ExifTagValue       GPSDifferential             { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.GPSDifferential            ); } }
        public ExifTagValue       ImageWidth                  { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.ImageWidth                 ); } }
        public ExifTagValue       ImageHeight                 { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.ImageHeight                ); } }
        public ExifTagValue       BitsPerSample               { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.BitsPerSample              ); } }
        public ExifTagValue       Compression                 { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.Compression                ); } }
        public ExifTagValue       PhotometricInterpretation   { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.PhotometricInterpretation  ); } }
        public ExifTagValue       ImageDescription            { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.ImageDescription           ); } }
        public string             Make                        { get { return (string            )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.Make).value;                  } }
        public string             Model                       { get { return (string            )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.Model).value;                 } }
        public ExifTagValue       StripOffsets                { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.StripOffsets               ); } }
        public ushort             Orientation                 { get {var rtn = ExifUtil4Jpeg.GetTagValue(_metadata, TagType.Orientation).value;return (rtn == null) ? (ushort)0 : (ushort)rtn;}}
        public ExifTagValue       SamplesPerPixel             { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.SamplesPerPixel            ); } }
        public ExifTagValue       RowsPerStrip                { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.RowsPerStrip               ); } }
        public ExifTagValue       StripByteCounts             { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.StripByteCounts            ); } }
        public Rational           XResolution                 { get { return (Rational          )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.XResolution                ); } }
        public Rational           YResolution                 { get { return (Rational          )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.YResolution                ); } }
        public ExifTagValue       PlanarConfiguration         { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.PlanarConfiguration        ); } }
        public ushort             ResolutionUnit              { get {var rtn = ExifUtil4Jpeg.GetTagValue(_metadata, TagType.ResolutionUnit).value;return (rtn == null) ? (ushort)0 : (ushort)rtn;}}
        public ExifTagValue       TransferFunction            { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.TransferFunction           ); } }
        public string             Software                    { get { return (string            )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.Software).value;              } }
        public string             DateTime                    { get { return (string            )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.DateTime).value;              } }
        public ExifTagValue       Artist                      { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.Artist                     ); } }
        public ExifTagValue       WhitePoint                  { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.WhitePoint                 ); } }
        public ExifTagValue       PrimaryChromaticities       { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.PrimaryChromaticities      ); } }
        public ExifTagValue       JPEGInterchangeFormat       { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.JPEGInterchangeFormat      ); } }
        public ExifTagValue       JPEGInterchangeFormatLength { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.JPEGInterchangeFormatLength); } }
        public ExifTagValue       YCbCrCoefficients           { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.YCbCrCoefficients          ); } }
        public ExifTagValue       YCbCrSubSampling            { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.YCbCrSubSampling           ); } }
        public ushort             YCbCrPositioning            { get {var rtn = ExifUtil4Jpeg.GetTagValue(_metadata, TagType.YCbCrPositioning).value;return (rtn == null) ? (ushort)0 : (ushort)rtn;}}
        public ExifTagValue       ReferenceBlackWhite         { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.ReferenceBlackWhite        ); } }
        public ExifTagValue       Copyright                   { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.Copyright                  ); } }
        public Rational           ExposureTime                { get { return (Rational          )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.ExposureTime               ); } }
        public Rational           FNumber                     { get { return (Rational          )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.FNumber                    ); } }
        public ushort             ExposureProgram             { get {var rtn = ExifUtil4Jpeg.GetTagValue(_metadata, TagType.ExposureProgram).value;return (rtn == null) ? (ushort)0 : (ushort)rtn;}}
        public ExifTagValue       SpectralSensitivity         { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.SpectralSensitivity        ); } }
        public ushort             ISOSpeedRatings             { get {var rtn = ExifUtil4Jpeg.GetTagValue(_metadata, TagType.ISOSpeedRatings).value;return (rtn == null) ? (ushort)0 : (ushort)rtn;}}
        public ExifTagValue       OECF                        { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.OECF                       ); } }
        public BitmapMetadataBlob ExifVersion                 { get { return (BitmapMetadataBlob)ExifUtil4Jpeg.GetTagValue(_metadata, TagType.ExifVersion).value;           } }
        public string             DateTimeOriginal            { get { return (string            )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.DateTimeOriginal).value;      } }
        public string             DateTimeDigitized           { get { return (string            )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.DateTimeDigitized).value;     } }
        public BitmapMetadataBlob ComponentsConfiguration     { get { return (BitmapMetadataBlob)ExifUtil4Jpeg.GetTagValue(_metadata, TagType.ComponentsConfiguration).value;} }
        public ExifTagValue       CompressedBitsPerPixel      { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.CompressedBitsPerPixel     ); } }
        public double             ShutterSpeedValue           { get {var rtn = ExifUtil4Jpeg.GetTagValue(_metadata, TagType.ShutterSpeedValue).value;return (rtn == null) ? (double)0 : (double)rtn;}}
        public double             ApertureValue               { get {var rtn = ExifUtil4Jpeg.GetTagValue(_metadata, TagType.ApertureValue).value;return (rtn == null) ? (double)0 : (double)rtn;}}
        public Rational           BrightnessValue             { get { return (Rational          )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.BrightnessValue            ); } }
        public ExifTagValue       ExposureBiasValue           { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.ExposureBiasValue          ); } }
        public ExifTagValue       MaxApertureValue            { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.MaxApertureValue           ); } }
        public ExifTagValue       SubjectDistance             { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.SubjectDistance            ); } }
        public ushort             MeteringMode                { get {var rtn = ExifUtil4Jpeg.GetTagValue(_metadata, TagType.MeteringMode).value;return (rtn == null) ? (ushort)0 : (ushort)rtn;}}
        public ExifTagValue       LightSource                 { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.LightSource                ); } }
        public ushort             Flash                       { get {var rtn = ExifUtil4Jpeg.GetTagValue(_metadata, TagType.Flash).value;return (rtn == null) ? (ushort)0 : (ushort)rtn;}}
        public Rational           FocalLength                 { get { return (Rational          )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.FocalLength                ); } }
        public ushort[]           SubjectArea                 { get { return (ushort[]          )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.SubjectArea).value;           } }
        public BitmapMetadataBlob MakerNote                   { get { return (BitmapMetadataBlob)ExifUtil4Jpeg.GetTagValue(_metadata, TagType.MakerNote).value;             } }
        public ExifTagValue       UserComment                 { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.UserComment                ); } }
        public ExifTagValue       SubSecTime                  { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.SubSecTime                 ); } }
        public string             SubSecTimeOriginal          { get { return (string            )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.SubSecTimeOriginal).value;    } }
        public string             SubSecTimeDigitized         { get { return (string            )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.SubSecTimeDigitized).value;   } }
        public BitmapMetadataBlob FlashpixVersion             { get { return (BitmapMetadataBlob)ExifUtil4Jpeg.GetTagValue(_metadata, TagType.FlashpixVersion).value;       } }
        public ushort             ColorSpace                  { get {var rtn = ExifUtil4Jpeg.GetTagValue(_metadata, TagType.ColorSpace).value;return (rtn == null) ? (ushort)0 : (ushort)rtn;}}
        public uint               PixelXDimension             { get {var rtn = ExifUtil4Jpeg.GetTagValue(_metadata, TagType.PixelXDimension).value;return (rtn == null) ? (uint)0 : (uint)rtn;}}
        public uint               PixelYDimension             { get {var rtn = ExifUtil4Jpeg.GetTagValue(_metadata, TagType.PixelYDimension).value;return (rtn == null) ? (uint)0 : (uint)rtn;}}
        public ExifTagValue       RelatedSoundFile            { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.RelatedSoundFile           ); } }
        public ExifTagValue       FlashEnergy                 { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.FlashEnergy                ); } }
        public ExifTagValue       SpatialFrequencyResponse    { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.SpatialFrequencyResponse   ); } }
        public ExifTagValue       FocalPlaneXResolution       { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.FocalPlaneXResolution      ); } }
        public ExifTagValue       FocalPlaneYResolution       { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.FocalPlaneYResolution      ); } }
        public ExifTagValue       FocalPlaneResolutionUnit    { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.FocalPlaneResolutionUnit   ); } }
        public ExifTagValue       SubjectLocation             { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.SubjectLocation            ); } }
        public ExifTagValue       ExposureIndex               { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.ExposureIndex              ); } }
        public ushort             SensingMethod               { get {var rtn = ExifUtil4Jpeg.GetTagValue(_metadata, TagType.SensingMethod).value;return (rtn == null) ? (ushort)0 : (ushort)rtn;}}
        public ExifTagValue       FileSource                  { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.FileSource                 ); } }
        public BitmapMetadataBlob SceneType                   { get { return (BitmapMetadataBlob)ExifUtil4Jpeg.GetTagValue(_metadata, TagType.SceneType).value;             } }
        public ExifTagValue       CFAPattern                  { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.CFAPattern                 ); } }
        public ExifTagValue       CustomRendered              { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.CustomRendered             ); } }
        public ushort             ExposureMode                { get {var rtn = ExifUtil4Jpeg.GetTagValue(_metadata, TagType.ExposureMode).value;return (rtn == null) ? (ushort)0 : (ushort)rtn;}}
        public ushort             WhiteBalance                { get {var rtn = ExifUtil4Jpeg.GetTagValue(_metadata, TagType.WhiteBalance).value;return (rtn == null) ? (ushort)0 : (ushort)rtn;}}
        public ExifTagValue       DigitalZoomRatio            { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.DigitalZoomRatio           ); } }
        public ushort             FocalLengthIn35mmFilm       { get {var rtn = ExifUtil4Jpeg.GetTagValue(_metadata, TagType.FocalLengthIn35mmFilm).value;return (rtn == null) ? (ushort)0 : (ushort)rtn;}}
        public ushort             SceneCaptureType            { get {var rtn = ExifUtil4Jpeg.GetTagValue(_metadata, TagType.SceneCaptureType).value;return (rtn == null) ? (ushort)0 : (ushort)rtn;}}
        public ExifTagValue       GainControl                 { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.GainControl                ); } }
        public ExifTagValue       Contrast                    { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.Contrast                   ); } }
        public ExifTagValue       Saturation                  { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.Saturation                 ); } }
        public ExifTagValue       Sharpness                   { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.Sharpness                  ); } }
        public ExifTagValue       DeviceSettingDescription    { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.DeviceSettingDescription   ); } }
        public ExifTagValue       SubjectDistanceRange        { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.SubjectDistanceRange       ); } }
        public ExifTagValue       ImageUniqueID               { get { return (ExifTagValue      )ExifUtil4Jpeg.GetTagValue(_metadata, TagType.ImageUniqueID              ); } }
    }
}
