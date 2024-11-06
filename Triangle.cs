using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle_vorm
{
    internal class Triangle
    {
        private double a, b, c, h;
        private double nurkA, nurkB, nurkC;

        public Triangle() { }

        public Triangle(double A) 
        {
            a = A;
            b = A;
            c = A;
        }

        public Triangle(double A, double B, double C)
        {
            a = A;
            b = B;
            c = C;
        }

        public Triangle(double side, double height)
        {
            this.h = height;
            a = side;         
        }

        public double CalculateSurfaceHeight()
        {
            return 0.5 * a * h;
        }   

        public string outputA()
        {
            return Convert.ToString(c);
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

        public string outputNurgA() 
        {
            return nurkA.ToString("F2"); ;
        }

        public string outputNurgB()
        {
            return nurkB.ToString("F2"); ;
        }

        public string outputNurgC()
        {
            return nurkC.ToString("F2"); ;
        }

        // https://stackoverflow.com/questions/45791505/find-angle-from-given-side-of-right-andgle-triangle-and-vise-versa-in-c-sharp

        public void CalculateNurgCos()
        {
            if (ExistTrtiangle)
            {
                nurkA = Math.Acos((b * b + c * c - a * a) / (2 * b * c)) * (180 / Math.PI);
                nurkB = Math.Acos((a * a + c * c - b * b) / (2 * a * c)) * (180 / Math.PI);
                nurkC = Math.Acos((a * a + b * b - c * c) / (2 * a * b)) * (180 / Math.PI);
            }
            else
            {
                nurkA = 0;
                nurkB = 0;
                nurkC = 0;
            }
        }

        public double Perimeter()
        {
            if (ExistTrtiangle)
            {
                return a + b + c;
            }
            else
            {
                return 0;
            }
        }

        public double Surface()
        {
            if (ExistTrtiangle)
            {
                double p = (a + b + c) / 2;  
                double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                return s;
            }
            else 
            { 
                return 0;
            }
            
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

        public double GetSetNurgA
        {
            get { return nurkA; }
            set { nurkA = value; }
        }

        public double GetSetNurgB
        {
            get { return nurkB; }
            set { nurkB = value; }
        }

        public double GetSetNurgC
        {
            get { return nurkC; }
            set { nurkC = value; }
        }

        public bool ExistTrtiangle
        {
            get
            {
                if ((a > b + c) && (b > a + c) && (c > a + b))
                    return false;
                else
                    return true;
            }
        }

        public string TriangleType
        {
            get
            {
                if (ExistTrtiangle)
                {
                    string külg = "";
                    if (a == b && b == c && a == c)
                    {
                        külg = "Võrdkülgne";
                    }
                    else if (a == b || a == c || b == c)
                    {
                        külg = "Võrdhaarane";
                    }
                    else
                    {
                        külg = "Erikülgne";
                    }

                    string nurg = "";
                    if (nurkA < 90 && nurkB < 90 && nurkC < 90)
                    {
                        nurg = "Teravnurkne";
                    }
                    else if (nurkA == 90 || nurkB == 90 || nurkC == 90)
                    {
                        nurg = "Täisnurkne";
                    }
                    else
                    {
                        nurg = "Nürinurkne";
                    }

                    return $"{külg} ja {nurg} kolmnurk";
                }
                else
                {
                    return "Ei ole kolmnurk ";
                }
            }
        }
    }
}
