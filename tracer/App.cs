using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicRayTrace.output;
using System.Drawing;
using System.Drawing.Imaging;

namespace BasicRayTrace.tracer
{
    class App
    {
        public const int width = 640;
        public const int height = 640;

        public const float aspect = (float)width/(float)height;

        public static void Main()
        {
            RayTracer rt = new RayTracer(width, height, aspect);

            rt.AddObject(new Sphere(new Math.Vector3(50, 50.0f, 3.0f), 2.0f, new Math.Vector3(1, 0, 1)));
            rt.AddObject(new Sphere(new Math.Vector3(45.0f, 45.0f, 40.0f), 8.0f, new Math.Vector3(0, 1, 1)));

            OutputData output = rt.RunBasic();

            using (Bitmap b = new Bitmap(width, height))
            {
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        float red = output[x, y].x;
                        float green = output[x, y].y;
                        float blue = output[x, y].z;

                        if (red < 0)
                        {
                            red = 0;
                        }
                        else if (red > 1)
                        {
                            red = 1;
                        }

                        if (blue < 0)
                        {
                            blue = 0;
                        }
                        else if (blue > 1)
                        {
                            blue = 1;
                        }

                        if (green < 0)
                        {
                            green = 0;
                        }
                        else if (green > 1)
                        {
                            green = 1;
                        }

                        Color c = Color.FromArgb((int)(red * 255), (int)(green * 255), (int)(blue * 255));

                        b.SetPixel(x, y, c);
                    }
                }
                    b.Save(@"C:\users\Ethan\Desktop\out.png", ImageFormat.Png);
            }
        }
    }
}
