using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRayTrace.tracer
{
    class Scene
    {
        private HashSet<ILightableObject> objects;
        private HashSet<PointLight> lights;

        public HashSet<ILightableObject> Objects
        {
            get { return objects; }
        }

        public HashSet<PointLight> Lights
        {
            get { return lights; }
        }

        public Scene()
        {
            ClearScene();
        }

        public void ClearScene()
        {
            objects = new HashSet<ILightableObject>();
            lights = new HashSet<PointLight>();
        }

        public void AddObject(ILightableObject o) 
        {
            objects.Add(o);
        }

        public void RemoveObject(ILightableObject o)
        {
            objects.Remove(o);
        }

        public void AddLight(PointLight l)
        {
            lights.Add(l);
        }

        public void RemoveLight(PointLight l)
        {
            lights.Remove(l);
        }
    }
}
