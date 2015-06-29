using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicRayTrace.Math;

namespace BasicRayTrace.tracer
{
    class PointLight
    {
        private Vector3 position;
        private float power;
        private Vector3 color;


        public PointLight(Vector3 position, float power, Vector3 color)
        {
            Position = position;
            Power = power;
            Color = color;
        }
        
        public Vector3 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        public float Power
        {
            get
            {
                return power;
            }
            set
            {
                power = value;
            }
        }

        public Vector3 Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }
    }
}
