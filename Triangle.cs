using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle_vorm
{
    internal class Triangle
    {
        private double a;
        private double b;
        private double c;
        private double h;
        private double s;
        private double nurgA;
        private double nurgB;
        private double nurgC;

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
        public string outputS()
        {
            return Convert.ToString(s);
        }

        public string outputNurgA() 
        {
            return nurgA.ToString("F2"); ;
        }

        public string outputNurgB()
        {
            return nurgB.ToString("F2"); ;
        }

        public string outputNurgC()
        {
            return nurgC.ToString("F2"); ;
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

        public void CalculateNurgCos()
        {
            if (ExistTrtiangle)
            {
                nurgA = Math.Acos((b * b + c * c - a * a) / (2 * b * c)) * (180 / Math.PI);
                nurgB = Math.Acos((a * a + c * c - b * b) / (2 * a * c)) * (180 / Math.PI);
                nurgC = Math.Acos((a * a + b * b - c * c) / (2 * a * b)) * (180 / Math.PI);
            }
        }

        public void CalculateNurgSin()
        {
            if (ExistTrtiangle)
            {
                nurgA = Math.Asin((b * b + c * c - a * a) / (2 * b * c)) * (180 / Math.PI);
                nurgB = Math.Asin((a * a + c * c - b * b) / (2 * a * c)) * (180 / Math.PI);
                nurgC = Math.Asin((a * a + b * b - c * c) / (2 * a * b)) * (180 / Math.PI);
            }
        }

        public void CalculateNurgTan()
        {
            if (ExistTrtiangle)
            {
                nurgA = Math.Atan((b * b + c * c - a * a) / (2 * b * c)) * (180 / Math.PI);
                nurgB = Math.Atan((a * a + c * c - b * b) / (2 * a * c)) * (180 / Math.PI);
                nurgC = Math.Atan((a * a + b * b - c * c) / (2 * a * b)) * (180 / Math.PI);
            }
        }

        public double Perimeter()
        {
            if (ExistTrtiangle)
            {
                double p = 0;
                p = a + b + c;
                return p;
            }
            else
            {
                double p = 0;
                return p;
            }
        }

        public double Surface()
        {
            if (ExistTrtiangle)
            {
                double s = 0;
                double p = 0;
                p = (a + b + c) / 2;
                s = Math.Sqrt((p * (p - a) * (p - b) * (p - c)));
                return s;
            }
            else 
            { 
                double s = 0;
                return s;
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
        public double GetSetS
        {
            get { return s; }
            set { s = value; }
        }

        public double GetSetNurgA
        {
            get { return nurgA; }
            set { nurgA = value; }
        }

        public double GetSetNurgB
        {
            get { return nurgB; }
            set { nurgB = value; }
        }

        public double GetSetNurgC
        {
            get { return nurgC; }
            set { nurgC = value; }
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
                    if (nurgA < 90 && nurgB < 90 && nurgC < 90)
                    {
                        nurg = "Teravnurkne";
                    }
                    else if (nurgA == 90 || nurgB == 90 || nurgC == 90)
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
