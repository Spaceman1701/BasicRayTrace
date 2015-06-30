using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicRayTrace.Math;
using BasicRayTrace.ray;
namespace BasicRayTrace.tracer
{
    class Sphere : ILightableObject
    {
        private Vector3 position;

        private float radius;

        private Vector3 color;

        private Vector3 baseColor;

        public Sphere(Vector3 position, float radius, Vector3 color)
        {
            Position = position;
            Radius = radius;
            Color = color;
            baseColor = color;


        }
        public Vector3 CalculateAngleOfReflection(Ray r, RayCollision rc)
        {
            return null;
        }

        public RayCollision RayCollision(Ray ray)
        {
            Vector3 dist = ray.Start - this.position;
            float a = ray.Direction * ray.Direction;
            float b = 2.0f * (dist * ray.Direction);
            float c = (dist * dist) - (radius * radius);

            float d = b * b - (4.0f * a * c); //Discrimant of quadraditic equation

            if (d < 0.0f)
            {
                return new RayCollision(false, null, this); //No collision
            }

            float t = (-b - d) / (2 * a);
            Vector3 position = (t * ray.Direction) + ray.Start;

            return new RayCollision(true, position, this); //Collision
        }

        public Vector3 CalculateNormal(Vector3 point)
        {
            return (position - point).Normalize();
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

        public float Radius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
            }
        }

        public Vector3 Position
        {
            get { return position; }
            set { position = value; }
        }

        public MaterialData MaterialData
        {
            get { return null; }
        }
    }
}
