using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PLL
{
    public class PllFileFormat
    {
        public string PCName { get; set; }
        private static int Width { get; set; }
        private static int Height { get; set; }
        private static int Channels { get; set; }
        private static int PixelsCountWithChannels { get; set; }
        public Bitmap Image { get; set; }

        private static byte[] byfferArray;

        public PllFileFormat(string PCName, Bitmap Image)
        {
            this.PCName = PCName;
            this.Image = Image;
        }

        public static void Save(string path, PllFileFormat file)
        {
            if (file.Image != null)
            {
                var pict = new Picture(file.Image);
                byfferArray = pict.BytesBuffer;

                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))

                using (BinaryWriter binWriter = new BinaryWriter(fs))
                {
                    binWriter.Write(file.PCName);
                    binWriter.Write(file.Image.Width);
                    binWriter.Write(file.Image.Height);
                    binWriter.Write(pict.Channels);
                    binWriter.Write(pict.PixelsCountWithChannels);
                    binWriter.Write(pict.BytesBuffer);
                }
            }
        }

        public static PllFileFormat Load(string path)
        {
            PllFileFormat file = null;
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (BinaryReader binReader = new BinaryReader(fs))
            {
                string PCName = binReader.ReadString();
                Width = binReader.ReadInt32();
                Height = binReader.ReadInt32();
                Channels = binReader.ReadInt32();
                PixelsCountWithChannels = binReader.ReadInt32();
                byfferArray = binReader.ReadBytes(PixelsCountWithChannels);

                var bufferPixelsPtr = GCHandle.Alloc(byfferArray, GCHandleType.Pinned);
                var image = new Bitmap(Width, Height, Width * Channels,
                    System.Drawing.Imaging.PixelFormat.Format32bppArgb, bufferPixelsPtr.AddrOfPinnedObject());

                file = new PllFileFormat(PCName, image);
            }
            return file;
        }

    }
}
