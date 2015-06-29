using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicRayTrace.Math;

namespace BasicRayTrace.tracer
{
    interface ILightModel
    {
        Vector3 ComputeColor(ILightableObject obj, ICollection<PointLight> lights);
    }
}
