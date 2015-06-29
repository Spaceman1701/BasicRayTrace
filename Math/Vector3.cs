using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRayTrace.Math
{
    class Vector3
    {
        public float x;
        public float y;
        public float z;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        } 

        public Vector3() : this(0.0f, 0.0f, 0.0f) 
        {

        }

        public Vector3(Vector3 vec)
            : this(vec.x, vec.y, vec.z)
        {

        }

        public Vector3(float value)
            : this(value, value, value)
        {

        }

        public float Magnitude()
        {
            return (float)System.Math.Sqrt(x * x + y * y + z * z);
        }

        public Vector3 Normalize()
        {
            float mag = Magnitude();
            x /= mag;
            y /= mag;
            z /= mag;

            return this;
        }

        public static float Distance(Vector3 a, Vector3 b)
        {
            Vector3 dist = b - a;
            return dist.Magnitude();
        }

        public static float operator *(Vector3 a, Vector3 b)
        {
            return (a.x * b.x) + (a.y * b.y) + (a.z * b.z);
        }

        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static Vector3 operator *(float f, Vector3 b)
        {
            return new Vector3(f * b.x, f * b.y, f * b.z);
        }

    }
}
