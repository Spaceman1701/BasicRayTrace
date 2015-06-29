using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicRayTrace.Math;

namespace BasicRayTrace.ray
{
    class Ray
    {
        private Vector3 start;
        private Vector3 end;

        private Vector3 direction;

        public Ray(Vector3 start, Vector3 end)
        {
            this.start = start;
            this.end = end;

            direction = end - start;
            direction.Normalize();
        }

        public Vector3 Start
        {
            get { return start; }
        }

        public Vector3 End
        {
            get { return End; }
        }

        public Vector3 Direction
        {
            get { return direction; }
        }
    }
}
