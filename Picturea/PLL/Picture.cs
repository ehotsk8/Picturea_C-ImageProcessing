using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PLL
{
    unsafe public class Picture
    {
        public Bitmap OriginalImage { get; set; }
        public Bitmap EditImage { get; set; }
        public int Channels { get; set; }
        public int Stride { get; set; }
        public int PixelsCountWithChannels { get; set; }
        public int PixelsCount { get; set; }

        public byte[] BytesBuffer { get; set; }

        public byte* Pixels { get; set; }
        public byte* PixelsBuffer { get; set; }
        public byte* PixelsSourceBuffer { get; set; }

        public byte[] TransformBuffer { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Picture(Bitmap picture)
        {
            OriginalImage = picture;
            ImageBuffer(picture);
            ImageSource(picture);
        }

        private void ImageSource(Bitmap picture)
        {
            Bitmap bitmap = new Bitmap(picture, new Size(picture.Width, picture.Height));
            var bitmapData =
                   bitmap.LockBits(new Rectangle(0, 0, picture.Width, picture.Height),
                   ImageLockMode.ReadWrite, bitmap.PixelFormat);
            var BytesBuffer = new byte[PixelsCountWithChannels];
            Marshal.Copy(bitmapData.Scan0, BytesBuffer, 0, PixelsCountWithChannels);
            GCHandle bufferSourcePixelsPtr = GCHandle.Alloc(BytesBuffer, GCHandleType.Pinned);
            PixelsSourceBuffer = (byte*)bufferSourcePixelsPtr.AddrOfPinnedObject();
            bufferSourcePixelsPtr.Free();
        }

        private void ImageBuffer(Bitmap picture)
        {
            Bitmap bitmap = new Bitmap(picture, new Size(picture.Width, picture.Height));
            var bitmapData =
                   bitmap.LockBits(new Rectangle(0, 0, picture.Width, picture.Height),
                   ImageLockMode.ReadWrite, bitmap.PixelFormat);

            Channels = Image.GetPixelFormatSize(bitmap.PixelFormat) / 8;
            Stride = bitmapData.Stride;
            PixelsCountWithChannels = Stride * bitmap.Height;

            bitmap.UnlockBits(bitmapData);

            BytesBuffer = new byte[PixelsCountWithChannels];
            Marshal.Copy(bitmapData.Scan0, BytesBuffer, 0, PixelsCountWithChannels);
            GCHandle bufferPixelsPtr = GCHandle.Alloc(BytesBuffer, GCHandleType.Pinned);

            Pixels = (byte*)bitmapData.Scan0;
            PixelsBuffer = (byte*)bufferPixelsPtr.AddrOfPinnedObject();
            PixelsCount = PixelsCountWithChannels / Channels;

            EditImage = bitmap;
            Width = bitmap.Width;
            Height = bitmap.Height;

            bufferPixelsPtr.Free();
            GC.Collect();
        }

        public void ApplyChanges()
        {
            Marshal.Copy((IntPtr)Pixels, BytesBuffer, 0, PixelsCountWithChannels);
            var bufferPixelsPtr = GCHandle.Alloc(BytesBuffer, GCHandleType.Pinned).AddrOfPinnedObject();
            var image = new Bitmap(EditImage.Width, EditImage.Height, Stride, EditImage.PixelFormat, bufferPixelsPtr);
            ImageBuffer(image);
        }

        public void ApplyChangesTransform()
        {
            var bufferPixelsPtr = GCHandle.Alloc(TransformBuffer, GCHandleType.Pinned);
            EditImage = new Bitmap(Width, Height, Width * Channels, EditImage.PixelFormat, bufferPixelsPtr.AddrOfPinnedObject());
            bufferPixelsPtr.Free();
            GC.Collect();
        }
    }
}
