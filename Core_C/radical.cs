using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_C1.core
{
    /// <summary>
    /// 构成实数类的基础
    /// </summary>
    class radical
    {
        private fraction multiplier = new fraction(1);
        private double x = 0;
        private double exponent = 1;
        /// <summary>
        /// 请输入整数，否则自动四舍五入。
        /// </summary>
        /// <param name="Multiplier"></param>
        /// <param name="X"></param>
        /// <param name="Exponent"></param>
        public radical(double Multiplier, double X, double Exponent)
        {
            Multiplier = Math.Round(Multiplier);
            X = Math.Round(X);
            Exponent = Math.Round(Exponent);
            fraction Multiplier_ = new fraction(Multiplier);
            if (Exponent == 0)
            {
                throw new Exception("Undefined");
            }
            if (Exponent % 2 == 0 && X < 0)
            {
                throw new Exception("Undefined");
            }
            ArrayList n = simplify(Multiplier_, X, Exponent);
            multiplier = (fraction)(n[0]);
            x = (double)n[1];
            exponent = (double)n[2];
        }
        /// <summary>
        /// double请输入整数，否则自动四舍五入。
        /// </summary>
        /// <param name="Multiplier"></param>
        /// <param name="X"></param>
        /// <param name="Exponent"></param>
        public radical(fraction Multiplier, double X, double Exponent)
        {
            X = Math.Round(X);
            Exponent = Math.Round(Exponent);
            if (Exponent == 0)
            {
                throw new Exception("Undefined");
            }
            if (Exponent % 2 == 0 && X < 0)
            {
                throw new Exception("Undefined");
            }
            ArrayList n = simplify(Multiplier, X, Exponent);
            multiplier = (fraction)(n[0]);
            x = (double)n[1];
            exponent = (double)n[2];
        }
        public radical(fraction Multiplier, fraction X, fraction Exponent)
        {
            ArrayList p = intify(Multiplier, X, Exponent);
            ArrayList n = simplify((fraction)p[0], (double)p[1], (double)p[2]);
            multiplier = (fraction)(n[0]);
            x = (double)n[1];
            exponent = (double)n[2];
        }
        public ArrayList intify(fraction a, fraction b, fraction c)
        {
            ArrayList r = new ArrayList();
            double B, C = 1;
            if (c.Value < 0)
            {
                c = c.oppnum;//相反数
                b = b.Reciprocal;
            }
            if (c.Denominator != 1)//非整数
            {
                b = b ^ c.Denominator;
                c.Denominator = 1;
            }
            C = c.Numerator;
            if (b.Denominator != 1)//非整数
            {
                a.Denominator *= b.Denominator;
                b.Numerator *= Math.Pow(b.Denominator, C - 1);
                b.Denominator = 1;
            }
            B = b.Numerator;
            r.Add(a);
            r.Add(B);
            r.Add(C);
            return r;
        }
        public fraction Multiplier
        {
            get
            {
                return multiplier;
            }
            set
            {
                multiplier = value;
            }
        }
        public double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public double Exponent
        {
            get
            {
                return exponent;
            }
            set
            {
                exponent = value;
            }
        }
        public double Value
        {
            get
            {
                return value(multiplier, x, exponent);
            }
        }
        /// <summary>
        /// 简化
        /// </summary>
        /// <param name="a">multiplier</param>
        /// <param name="b">x</param>
        /// <param name="c">exponent</param>
        private ArrayList simplify(fraction a, double b, double c)
        {
            ArrayList r = new ArrayList();
            bool isneg = false;
            if (b < 0)
            {
                b = -b;
                isneg = true;
            }
            if (c == 1)//这个IF是为了防止c=1时计算量过大，本质上可省去只留下ELSE部分
            {
                a *= b;
                b = 1;
            }
            else
            {
                double v = Math.Pow(b, (1 / c));
                for (double f = 2; f <= v; f++)
                {
                    double F = Math.Pow(f, c);
                    if ((b / F) % 1 == 0)
                    {
                        b /= F;
                        a *= f;
                        f--;//
                    }
                }
            }
            if (isneg)
            {
                r.Add(a.oppnum);
            }
            else
            {
                r.Add(a);
            }
            r.Add(b);
            r.Add(c);
            return r;
        }
        private double value(fraction a, double b, double c)
        {
            return a.Value * Math.Pow(b, (1 / c));
        }
        static public radical operator *(radical a, radical b)
        {
            if (a.exponent == b.exponent)
            {
                return new radical(a.multiplier * b.multiplier, a.x * b.x, a.exponent);
            }
            else
            {
                return new radical(a.multiplier * b.multiplier, Math.Pow(a.x, b.exponent) * Math.Pow(b.x, a.exponent), a.exponent * b.exponent);
            }
        }
        static public radical operator *(double a, radical b)
        {
            return new radical(a * b.multiplier, b.x, b.exponent);
        }
        static public radical operator *(radical a, double b)
        {
            return new radical(b * a.multiplier, a.x, a.exponent);
        }
        static public radical operator /(radical a, radical b)
        {
            if (a.exponent == b.exponent)
            {
                return new radical(new fraction(a.multiplier, b.multiplier), new fraction(a.x, b.x), new fraction(a.exponent));
            }
            else
            {
                fraction c = new fraction(a.multiplier, b.multiplier);
                fraction d = new fraction(Math.Pow(a.x, b.exponent), Math.Pow(b.x, a.exponent));
                return new radical(new fraction(a.multiplier, b.multiplier), new fraction(Math.Pow(a.x, b.exponent), Math.Pow(b.x, a.exponent)), new fraction(a.exponent * b.exponent));
            }
        }
        static public radical operator /(double a, radical b)
        {
            return new radical(new fraction(1), new fraction(Math.Pow(a, b.exponent), b.x), new fraction(b.exponent));
        }
        static public radical operator /(radical a, double b)
        {
            return new radical(a.multiplier / b, a.x, a.exponent);
        }
    }
}
