using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicRayTrace.Math;
using BasicRayTrace.tracer;

namespace BasicRayTrace.ray
{
    class RayCollision
    {
        private Vector3 position;
        private bool isCollision;
        private ILightableObject obj;

        public RayCollision(bool isCollision, Vector3 position, ILightableObject obj)
        {
            this.position = position;
            this.isCollision = isCollision;
            this.obj = obj;
        }

        public bool IsCollision
        {
            get { return isCollision; }
        }

        public Vector3 Position
        {
            get { return position; }
        }

        public ILightableObject Obj
        {
            get { return obj; }
        }
    }
}
