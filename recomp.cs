using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

class Recomp
{
  static void Main()
  {
    Bitmap bmp;

    using (FileStream stream = new FileStream(@"Digest-Paperback-Barcode.png", FileMode.Open, FileAccess.Read, FileShare.Read))
      bmp = (Bitmap)Image.FromStream(stream);

    Bitmap ibmp = new Bitmap(bmp.Width, bmp.Height, PixelFormat.Format32bppRgb);

    Rectangle bounds = new Rectangle(0, 0, bmp.Width, bmp.Height);

    using (Graphics g = Graphics.FromImage(ibmp))
    {
      g.FillRectangle(Brushes.White, bounds);
      g.DrawImage(bmp, bounds, bounds, GraphicsUnit.Pixel);
    }

    ibmp.Save(@"Digest-Paperback-Barcode.png", ImageFormat.Png);
  }
}
