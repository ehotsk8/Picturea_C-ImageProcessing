using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLL
{
    unsafe public class CurvesEdit
    {
        byte[] level = new byte[256];
        private double precision = 1;
        MPoint[] dataPoint;
        private MPoint[] controlPoint;
        private List<MPoint> splinePoint = new List<MPoint>();

        private static int PixelsCount;
        private static int PixelsCountWithChannels;
        private static int Channels;
        private static int i, j, someIntValue, width, height, stride;
        private static byte* Pixels;
        private static byte* PixelsBuffer;

        private Picture picture;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="picture"></param>
        public CurvesEdit(Picture picture)
        {
            this.picture = picture;
            width = picture.EditImage.Width;
            height = picture.EditImage.Height;
            stride = picture.Stride;

            Pixels = picture.Pixels;
            PixelsBuffer = picture.PixelsBuffer;

            Channels = picture.Channels;
            PixelsCountWithChannels = picture.PixelsCountWithChannels;
            PixelsCount = picture.PixelsCount;
        }

        public void setCorrect(Point[] Points)
        {
            for (int i = 0; i < Points[0].X; i++)
                level[i] = (byte)Points[0].Y;
            for (int i = Points[Points.Length - 1].X; i < 256; i++)
                level[i] = (byte)Points[Points.Length - 1].Y;


            dataPoint = new MPoint[Points.Length];
            for (int i = 0; i < Points.Length; i++)
                dataPoint[i] = new MPoint(Points[i]);

            Point[] spt = SplinePoint();
            for (int i = 0; i < spt.Length; i++)
            {
                int n = spt[i].Y;
                if (n < 0) n = 0;
                if (n > 255) n = 255;
                level[Points[0].X + i] = (byte)n;
            }

            for (i = 0; i < PixelsCount; i++)
            {
                Pixels[0] = level[PixelsBuffer[0]];
                Pixels[1] = level[PixelsBuffer[1]];
                Pixels[2] = level[PixelsBuffer[2]];
                Pixels += Channels;
                PixelsBuffer += Channels;
            }
            Pixels -= PixelsCountWithChannels;
            PixelsBuffer -= PixelsCountWithChannels;
        }
        private Point[] SplinePoint()
        {
            getSplinePoints();
            Point[] pts = new Point[splinePoint.Count];
            for (int i = 0; i < pts.Length; i++)
                pts[i] = splinePoint[i].ToPoint();
            return pts;
        }

        private void getSplinePoints()
        {
            splinePoint.Clear();
            if (dataPoint.Length == 1) splinePoint.Add(dataPoint[0]);

            if (dataPoint.Length == 2)
            {
                int n = 1;
                n = (int)((dataPoint[1].X - dataPoint[0].X) / precision);
                if (n == 0) n = 1;
                if (n < 0) n = -n;
                for (int j = 0; j < n; j++)
                {
                    double t = (double)j / (double)n;
                    double resX = (1 - t) * dataPoint[0].X + t * dataPoint[1].X;
                    double resY = (1 - t) * dataPoint[0].Y + t * dataPoint[1].Y;

                    splinePoint.Add(new MPoint(resX, resY));
                }
            }

            if (dataPoint.Length > 2)
            {
                getControlPoints();

                for (int i = 0; i < controlPoint.Length - 1; i++)
                {
                    MPoint b1 = new MPoint(controlPoint[i].X * 2.0 / 3.0 + controlPoint[i + 1].X / 3.0,
                        controlPoint[i].Y * 2.0 / 3.0 + controlPoint[i + 1].Y / 3.0);
                    MPoint b2 = new MPoint(controlPoint[i].X / 3.0 + controlPoint[i + 1].X * 2.0 / 3.0,
                        controlPoint[i].Y / 3.0 + controlPoint[i + 1].Y * 2.0 / 3.0);

                    int n = 1;
                    n = (int)((dataPoint[i + 1].X - dataPoint[i].X) / precision);
                    if (n == 0) n = 1;
                    if (n < 0) n = -n;
                    for (int j = 0; j < n; j++)
                    {
                        double t = (double)j / (double)n;
                        MPoint v = new MPoint(
                            (1 - t) * (1 - t) * (1 - t) * dataPoint[i].X + 3 * (1 - t) * (1 - t) * t * b1.X +
                            3 * (1 - t) * t * t * b2.X + t * t * t * dataPoint[i + 1].X,
                            (1 - t) * (1 - t) * (1 - t) * dataPoint[i].Y + 3 * (1 - t) * (1 - t) * t * b1.Y +
                            3 * (1 - t) * t * t * b2.Y + t * t * t * dataPoint[i + 1].Y);
                        splinePoint.Add(v);
                    }
                }
            }

        }

        private void getControlPoints()
        {
            if (dataPoint != null && dataPoint.Length == 3)
            {
                controlPoint = new MPoint[3];
                controlPoint[0] = dataPoint[0];
                controlPoint[1] = new MPoint((6 * dataPoint[1].X - dataPoint[0].X - dataPoint[2].X) / 4,
                    (6 * dataPoint[1].Y - dataPoint[0].Y - dataPoint[2].Y) / 4);
                controlPoint[2] = dataPoint[2];
            }

            if (dataPoint != null && dataPoint.Length > 3)
            {
                int n = dataPoint.Length;
                controlPoint = new MPoint[n];
                double[] diag = new double[n];
                double[] sub = new double[n];
                double[] sup = new double[n];

                for (int i = 0; i < n; i++)
                {
                    controlPoint[i] = dataPoint[i];
                    diag[i] = 4;
                    sub[i] = 1;
                    sup[i] = 1;
                }

                controlPoint[1] = new MPoint(6 * controlPoint[1].X - controlPoint[0].X,
                                            6 * controlPoint[1].Y - controlPoint[0].Y);
                controlPoint[n - 2] = new MPoint(6 * controlPoint[n - 2].X - controlPoint[n - 1].X,
                                                6 * controlPoint[n - 2].Y - controlPoint[n - 1].Y);

                for (int i = 2; i < n - 2; i++)
                {
                    controlPoint[i] = new MPoint(6 * controlPoint[i].X, 6 * controlPoint[i].Y);
                }

                for (int i = 2; i < n - 1; i++)
                {
                    sub[i] = sub[i] / diag[i - 1];
                    diag[i] = diag[i] - sub[i] * sup[i - 1];
                    controlPoint[i] = new MPoint(controlPoint[i].X - sub[i] * controlPoint[i - 1].X,
                        controlPoint[i].Y - sub[i] * controlPoint[i - 1].Y);
                }

                controlPoint[n - 2] = new MPoint(controlPoint[n - 2].X / diag[n - 2],
                    controlPoint[n - 2].Y / diag[n - 2]);

                for (int i = n - 3; i > 0; i--)
                {
                    controlPoint[i] = new MPoint((controlPoint[i].X - sup[i] * controlPoint[i + 1].X) / diag[i],
                        (controlPoint[i].Y - sup[i] * controlPoint[i + 1].Y) / diag[i]);
                }
            }
        }

    }
    public class MPoint
    {
        double _x, _y;

        public MPoint(double x, double y)
        {
            _x = x; _y = y;
        }
        public MPoint(Point pt)
        {
            _x = pt.X;
            _y = pt.Y;
        }
        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }
        public Point ToPoint()
        {
            return new Point((int)_x, (int)_y);
        }
    }
}

