using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicRayTrace.Math;
using BasicRayTrace.ray;

namespace BasicRayTrace.tracer
{
    interface ILightableObject
    {
        Vector3 Color
        {
            get;
        }

        MaterialData MaterialData
        {
            get;
        }

        RayCollision RayCollision(Ray ray);

        Vector3 CalculateAngleOfReflection(Ray ray, RayCollision collision);
    }
}
