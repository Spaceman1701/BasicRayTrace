using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicRayTrace.output;
using BasicRayTrace.ray;
using BasicRayTrace.Math;

namespace BasicRayTrace.tracer
{
    class RayTracer
    {
        private int width;
        private int height;
        private float aspect;

        private OutputData output;

        Scene scene;

        public RayTracer(int width, int height, float aspect)
        {
            this.width = width;
            this.height = height;
            this.aspect = aspect;

            scene = new Scene();

            output = new OutputData(width, height);
        }

        public void AddLight(PointLight l)
        {
            scene.AddLight(l);
        }

        public void AddObject(ILightableObject obj)
        {
            scene.AddObject(obj);
        }

        public OutputData RunBasic()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Ray ray = new Ray(new Vector3(x*0.1f, y*0.1f, 0.1f), new Vector3(x, y, 1000.0f));

                    HashSet<RayCollision> rcs = new HashSet<RayCollision>();

                    foreach (ILightableObject o in scene.Objects)
                    {
                        RayCollision rc = o.RayCollision(ray);
                        if (rc.IsCollision)
                        {
                            rcs.Add(rc);
                        }
                    }
                    if (rcs.Count == 0)
                    {
                        output[x, y] = new Vector3(0, 0, 0);
                        continue;
                    }
                    RayCollision closestRay = (from RayCollision r in rcs
                                     orderby Vector3.Distance(r.Position, ray.Start) ascending
                                     select r).First();
                    output[x, y] = closestRay.Obj.Color;
                }
            }

            return output;
        }
        
    }
}
