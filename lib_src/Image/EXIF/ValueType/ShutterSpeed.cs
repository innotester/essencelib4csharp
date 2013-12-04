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
    public sealed class ShutterSpeed : ExifTagValue
    {
        public override string ToString()
        {
            return string.Format("1/{0}", (int)(double)value);
        }
    }
}
