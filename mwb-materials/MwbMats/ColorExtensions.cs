﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mwb_materials.MwbMats
{
    public static class ColorExtensions
    {
        public static Color Mul(this Color me, float mul)
        {
            return Color.FromArgb((byte)(me.A * mul), (byte)(me.R * mul), (byte)(me.G * mul), (byte)(me.B * mul));
        }

        public static Color LerpColor(this Color s, Color t, float k)
        {
            var bk = (1.0f - k);
            var a = s.A * bk + t.A * k;
            var r = s.R * bk + t.R * k;
            var g = s.G * bk + t.G * k;
            var b = s.B * bk + t.B * k;
            return Color.FromArgb((int)a, (int)r, (int)g, (int)b);
        }
    }
}
