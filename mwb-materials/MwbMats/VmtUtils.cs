using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mwb_materials.MwbMats
{
    class VmtUtils
    {
        private static readonly EnvMapFile[] EnvMaps = new EnvMapFile[]
        {
            new EnvMapFile{ Name = "specularity_00", Content = Properties.Resources.specularity_00, Roughness = 0.5 },
            new EnvMapFile{ Name = "specularity_25", Content = Properties.Resources.specularity_25, Roughness = 0.7 },
            new EnvMapFile{ Name = "specularity_50", Content = Properties.Resources.specularity_50, Roughness = 0.8 },
            new EnvMapFile{ Name = "specularity_75", Content = Properties.Resources.specularity_75, Roughness = 0.85 },
            new EnvMapFile{ Name = "specularity_100", Content = Properties.Resources.specularity_100, Roughness = 0.9 },
        };

        public class EnvMapFile
        {
            public string Name { get; internal set; }
            public double Roughness { get; internal set; }
            public byte[] Content { get; internal set; }
        }

        public static string GetVMTVector(Color color)
        {
            string vec = "[" + Math.Round(color.R / 255.0, 3) + " " + Math.Round(color.G / 255.0, 3) + " " + Math.Round(color.B / 255.0, 3) + "]";
            vec = vec.Replace(",", ".");
            return vec;
        }

        public static EnvMapFile GetEnvMapTextureFromRoughness(double averageRoughness)
        {
            EnvMapFile file = EnvMaps[0];

            foreach (EnvMapFile envmap in EnvMaps)
            {
                if (averageRoughness >= envmap.Roughness)
                {
                    file = envmap;
                }
            }

            return file;
        }

        public static string GetVMTPath(string originalPath)
        {
            string vmtPath = string.Empty;

            if (originalPath.Contains("materials"))
            {
                vmtPath = originalPath;
                vmtPath = vmtPath.Substring(vmtPath.IndexOf("materials"));
                vmtPath = vmtPath.Replace("materials", string.Empty);
                vmtPath = vmtPath.Trim(new char[] { '\\' });
            }

            return vmtPath;
        }
    }
}
