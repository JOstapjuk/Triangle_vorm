using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle_vorm
{
    enum TriangleSide
    {
        A,
        B,
        C
    }

    internal class Triangle
    {
        private double a;
        private double b;
        private double c;
        private double h;

        public Triangle(TriangleSide A, TriangleSide B, TriangleSide C)
        {
            a = (double)A;
            b = (double)B;
            c = (double)C;
        }

        public Triangle(TriangleSide A, TriangleSide B, TriangleSide C, double height)
        {
            a = (double)A;
            b = (double)B;
            c = (double)C;
            h = height;
        }

        public Triangle(TriangleSide side, double height)
        {
            switch (side)
            {
                case TriangleSide.A:
                    a = height;
                    b = 0;
                    c = 0;
                    break;
                case TriangleSide.B:
                    b = height;
                    a = 0;
                    c = 0;
                    break;
                case TriangleSide.C:
                    c = height;
                    a = 0;
                    b = 0;
                    break;
            }
            h = height;
        }


        public string outputA()
        {
            return Convert.ToString(a);
        }

        public string outputB()
        {
            return Convert.ToString(b);
        }

        public string outputC()
        {
            return Convert.ToString(c);
        }

        public string outputH()
        {
            return Convert.ToString(h);
        }

        public double HeightFromA()
        {
            double s = Surface();
            return (2 * s) / a; 
        }

        public double HeightFromB()
        {
            double s = Surface();
            return (2 * s) / b; 
        }

        public double HeightFromC()
        {
            double s = Surface();
            return (2 * s) / c;
        }

        public double Perimeter()
        {
            double p = 0;
            p = a + b + c;
            return p;
        }

        public double Surface()
        {
            double s = 0;
            double p = 0;
            p = (a + b + c) / 2;
            s = Math.Sqrt((p * (p - a) * (p - b) * (p - c)));
            return s;
        }

        public double GetSetA
        {
            get { return a; }
            set { a = value; }
        }

        public double GetSetB
        {
            get { return b; }
            set { b = value; }
        }

        public double GetSetC
        {
            get { return c; }
            set { c = value; }
        }
        public double GetSetH
        {
            get { return h; }
            set { h = value; }
        }

        public bool ExistTrtiangle
        {
            get 
            {
                if ((a > b + c) && (b > a + c) && (c > a + b))
                    return false;
                else return true;
            }
        }
    }
}
