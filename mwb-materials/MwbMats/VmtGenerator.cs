﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mwb_materials.MwbMats
{
    class VmtGenerator
    {
        private static readonly byte[] VmtBytes = Properties.Resources.default_vmt;

        private static void SanitizeName(ref string name)
        {
            name = name.Trim().Replace(".vmt", string.Empty);
        }

        private static string GetVmtContent()
        {
            return Encoding.UTF8.GetString(VmtBytes);
        }

        public static void Generate(string path, string name, Dictionary<string, object> values, string movePath)
        {
            SanitizeName(ref name);
            string content = GetVmtContent();

            foreach (KeyValuePair<string, object> pair in values)
            {
                content = content.Replace("${" + pair.Key + "}", pair.Value.ToString());
            }

            byte[] newBytes = Encoding.UTF8.GetBytes(content);

            using (StreamWriter sw = File.CreateText(path + "\\" + name + ".vmt"))
            {
                sw.BaseStream.Write(newBytes, 0, newBytes.Length);
            }

            if (movePath != string.Empty)
            {
                string fileSrc = path + "\\" + Path.GetFileNameWithoutExtension(name) + ".vmt";
                string fileDest = movePath + "\\" + Path.GetFileNameWithoutExtension(name) + ".vmt";

                Directory.CreateDirectory(movePath);

                if (File.Exists(fileDest))
                {
                    File.Delete(fileDest);
                }

                File.Move(fileSrc, fileDest);
            }
        }

        public static void Generate(string path, string name)
        {
            SanitizeName(ref name);

            using (StreamWriter sw = File.CreateText(path + "\\" + name + ".vmt"))
            {
                sw.BaseStream.Write(VmtBytes, 0, VmtBytes.Length);
            }
        }
    }
}
