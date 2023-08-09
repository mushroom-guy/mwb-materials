using System;
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
            k = Math.Min(Math.Max(k, 0.0f), 1.0f);
            var bk = (1.0f - k);
            var a = s.A * bk + t.A * k;
            var r = s.R * bk + t.R * k;
            var g = s.G * bk + t.G * k;
            var b = s.B * bk + t.B * k;
            return Color.FromArgb((int)a, (int)r, (int)g, (int)b);
        }

        public static float Lerp(this float a, float t, float k)
        {
            k = Math.Min(Math.Max(k, 0.0f), 1.0f);
            return (a * (1.0f - k)) + (t * k);
        }

        public static float GetLuminance(this Color c)
        {
            return (0.299f * (c.R / 255.0f) + 0.587f * (c.G / 255.0f) + 0.114f * (c.B / 255.0f));
        }

        public static Color GetNormalized(this Color c)
        {
            double distance = Math.Sqrt(c.R * c.R + c.G * c.G + c.B * c.B);
            return Color.FromArgb((int)(c.R / distance * 255.0), (int)(c.G / distance * 255.0), (int)(c.B / distance * 255.0));
        }
    }
}
