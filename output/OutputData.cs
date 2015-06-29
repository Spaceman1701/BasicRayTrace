using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicRayTrace.Math;

namespace BasicRayTrace.output
{
    class OutputData
    {
        private int width;
        private int height;

        private Vector3[,] data;

        public int Width
        {
            get
            {
                return width;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
        }

        public Vector3[,] Data
        {
            get
            {
                return data;
            }
        }

        public OutputData(int width, int height)
        {
            this.width = width;
            this.height = height;

            data = new Vector3[width, height];
        }

        public Vector3 this[int x, int y]
        {
            get
            {
                return data[x, y];
            }
            set
            {
                data[x, y] = value;
            }
        }
    }
}
