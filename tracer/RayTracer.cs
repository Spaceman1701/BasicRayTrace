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
                    float outX = x * (0.1f / 1000.0f);
                    float outY = y * (0.1f / 1000.0f);

                    Ray ray = new Ray(new Vector3(x * 0.1f, y * 0.1f, 0.1f), new Vector3(x *0.1f, y*0.1f, 1000.0f));

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
                    output[x, y] = TestLighting(closestRay.Position, closestRay.Obj.CalculateNormal(closestRay.Position), new Vector3(320, 320, -400.0f), closestRay.Obj.Color);
                }
            }

            return output;
        }

        private Vector3 TestLighting(Vector3 position, Vector3 normal, Vector3 lightPos, Vector3 color)
        {
            Vector3 litColor = ((position - lightPos).Normalize() * normal) * color;

            Ray shadowRay = new Ray(position, lightPos);
            
            foreach (ILightableObject o in scene.Objects) 
            {
                RayCollision rc = o.RayCollision(shadowRay);
                if (rc.IsCollision)
                {
                    return new Vector3(1,0,0);
                }
            }

            return litColor;
        }
        
    }
}
