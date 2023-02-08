using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mwb_materials
{
    class FastBitmap : IDisposable
    {
        public FastBitmap(Bitmap src)
        {
            Source = src;
            bStarted = false;
        }

        public void Start(ImageLockMode Mode)
        {
            Debug.Assert(bStarted == false, "FastBitmap has already started!");

            LockMode = Mode;
            Data = Source.LockBits(new Rectangle(0, 0, Source.Width, Source.Height), LockMode, PixelFormat.Format32bppArgb);
            Ptr = Data.Scan0;
            Bytes = new byte[Math.Abs(Data.Stride) * Data.Height];
            System.Runtime.InteropServices.Marshal.Copy(Ptr, Bytes, 0, Bytes.Length);

            bStarted = true;
        }

        public void Stop()
        {
            Debug.Assert(bStarted == true, "FastBitmap hasn't started yet!");

            if (LockMode == ImageLockMode.WriteOnly || LockMode == ImageLockMode.ReadWrite)
            {
                System.Runtime.InteropServices.Marshal.Copy(Bytes, 0, Ptr, Bytes.Length);
            }

            Source.UnlockBits(Data);

            bStarted = false;
        }

        public Color ReadColor(int cursor)
        {
            Debug.Assert(bStarted == true, "Trying to read color from FastBitmap that hasn't started yet!");
            return Color.FromArgb(Bytes[cursor + 3], Bytes[cursor + 2], Bytes[cursor + 1], Bytes[cursor]);
        }

        public int ReadGrayscale(int cursor)
        {
            Debug.Assert(bStarted == true, "Trying to read grayscale from FastBitmap that hasn't started yet!");
            return (Bytes[cursor] + Bytes[cursor + 1] + Bytes[cursor + 2]) / 3;
        }

        public void WriteColor(int cursor, Color col)
        {
            Debug.Assert(bStarted == true, "Trying to write color in FastBitmap that hasn't started yet!");
            Bytes[cursor] = col.B;
            Bytes[cursor + 1] = col.G;
            Bytes[cursor + 2] = col.R;
            Bytes[cursor + 3] = col.A;
        }

        public void Dispose()
        {
            Source.Dispose();
        }

        public Bitmap Source { get; }
        public byte[] Bytes { get; private set; }
        private IntPtr Ptr;
        private BitmapData Data;
        private bool bStarted;
        private ImageLockMode LockMode;
    }
}
