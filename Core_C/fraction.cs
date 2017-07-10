using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_C1.core
{
    /// <summary>
    /// 所有运算类的基础，构成根式类的基础
    /// </summary>
    class fraction
    {
        /// <summary>
        /// 分子
        /// </summary>
        private double numerator = 0;
        /// <summary>
        /// 分母
        /// </summary>
        private double denominator = 1;
        public fraction(double Numerator, double Denominator)
        {
            if (Denominator == 0)
            {
                throw new DivideByZeroException();
            }
            List<double> n = intify(Numerator, Denominator);
            List<double> c = simplify(n[0], n[1]);
            numerator = c[0];
            denominator = c[1];
        }
        public fraction(fraction Numerator, fraction Denominator)
        {
            fraction c = Numerator / Denominator;
            numerator = c.numerator;
            denominator = c.denominator;
        }
        public fraction(double value)
        {
            if (value.ToString().IndexOf(".") != -1)
            {
                int multiplier = value.ToString().Length - value.ToString().IndexOf(".");
                List<double> c = simplify(value * Math.Pow(10, multiplier), Math.Pow(10, multiplier));
                numerator = c[0];
                denominator = c[1];
            }
            else
            {
                numerator = value;
                denominator = 1;
            }
        }
        /// <summary>
        /// 分子
        /// </summary>
        public double Numerator
        {
            get
            {
                return numerator;
            }
            set
            {
                numerator = value;
            }
        }
        /// <summary>
        /// 分母
        /// </summary>
        public double Denominator
        {
            get
            {
                return denominator;
            }
            set
            {
                denominator = value;
            }
        }
        /// <summary>
        /// 近似值
        /// </summary>
        public double Value
        {
            get
            {
                return numerator / denominator;
            }
        }
        /// <summary>
        /// 倒数
        /// </summary>
        public fraction Reciprocal
        {
            get
            {
                return new fraction(denominator, numerator);
            }
        }
        /// <summary>
        /// 相反数
        /// </summary>
        public fraction oppnum
        {
            get
            {
                return new fraction(-numerator, denominator);
            }
        }
        private List<double> intify(double a, double b)
        {
            List<double> r = new List<double>();
            if (a == 0)//patch for NaN
            {
                r.Add(0);
                r.Add(1);
                return r;
            }
            double A = Convert.ToDouble(a.ToString().Replace(".", ""));
            double B = Convert.ToDouble(b.ToString().Replace(".", ""));
            double am = A / a;
            double bm = B / b;
            double m = Math.Max(am, bm);
            r.Add(a * m);
            r.Add(b * m);
            return r;
        }
        private List<double> simplify(double a, double b)//辗转相除法
        {
            bool isneg = false;
            if (a < 0)
            {
                isneg = !(isneg);
                a = -a;
            }
            if (b < 0)
            {
                isneg = !(isneg);
                b = -b;
            }
            List<double> r = new List<double>();
            if (a == b)
            {
                if (isneg == true)
                {
                    r.Add(-1);
                }
                else
                {
                    r.Add(1);
                }
                r.Add(1);
                return r;
            }
            double A = a;
            double B = b;
            while (A != 0 && B != 0)
            {
                if (A > B)
                {
                    A = A % B;
                }
                else
                {
                    B = B % A;
                }
            }
            double c = Math.Max(A, B);
            if (isneg == true)
            {
                r.Add(-(a / c));
            }
            else
            {
                r.Add(a / c);
            }
            r.Add(b / c);
            return r;
        }
        static public fraction operator +(fraction a, fraction b)
        {//
            if (a.denominator == b.denominator)
            {
                return new fraction(a.numerator + b.numerator, a.denominator);
            }
            else
            {
                return new fraction((a.numerator * b.denominator) + (a.denominator * b.numerator), a.denominator * b.denominator);
            }
        }
        static public fraction operator +(fraction a, double b)
        {//
            return new fraction((a.numerator + b * a.denominator), a.denominator);
        }
        static public fraction operator +(double a, fraction b)
        {//
            return new fraction((b.numerator + a * b.denominator), b.denominator);
        }
        static public fraction operator -(fraction a, fraction b)
        {//
            if (a.denominator == b.denominator)
            {
                return new fraction(a.numerator - b.numerator, a.denominator);
            }
            else
            {
                return new fraction((a.numerator * b.denominator) - (a.denominator * b.numerator), a.denominator * b.denominator);
            }
        }
        static public fraction operator -(fraction a, double b)
        {//
            return new fraction((a.numerator - b * a.denominator), a.denominator);
        }
        static public fraction operator -(double a, fraction b)
        {//
            return new fraction((a * b.denominator - b.numerator), b.denominator);
        }
        static public fraction operator *(fraction a, fraction b)
        {//
            return new fraction(a.numerator * b.numerator, a.denominator * b.denominator);
        }
        static public fraction operator *(fraction a, double b)
        {//
            return new fraction((b * a.numerator), a.denominator);
        }
        static public fraction operator *(double a, fraction b)
        {//
            return new fraction((a * b.numerator), b.denominator);
        }
        static public fraction operator /(fraction a, fraction b)
        {//
            return new fraction(a.numerator * b.denominator, a.denominator * b.numerator);
        }
        static public fraction operator /(fraction a, double b)
        {//
            return new fraction(a.numerator, a.denominator * b);
        }
        static public fraction operator /(double a, fraction b)
        {//
            return new fraction(a * b.denominator, b.numerator);
        }
        static public fraction operator ^(fraction a, double b)
        {
            return new fraction(Math.Pow(a.numerator, b), Math.Pow(a.denominator, b));
        }
        /// <summary>
        /// 过时方法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private List<double> simplify_1(double a, double b)//质因数分解法
        {
            bool isneg = false;
            if (a < 0)
            {
                isneg = !(isneg);
                a = -a;
            }
            if (b < 0)
            {
                isneg = !(isneg);
                b = -b;
            }
            List<double> r = new List<double>();
            if (a == b)
            {
                if (isneg == true)
                {
                    r.Add(-1);
                }
                else
                {
                    r.Add(1);
                }
                r.Add(1);
                return r;
            }
            double c = Math.Min(a, b);
            List<double> c_ = new List<double>();
            for (double p = 2; p <= Math.Sqrt(c); p++)
            {
                if ((c % p) == 0)
                {
                    c /= p;
                    c_.Add(p);
                    p--;
                }
            }
            double d = Math.Max(a, b);
            double e = Math.Min(a, b);
            foreach (double q in c_)
            {
                if ((d % q) == 0)
                {
                    d /= q;
                    e /= q;
                }
            }
            if (Math.Max(a, b) == a)
            {
                if (isneg == true)
                {
                    r.Add(-d);
                }
                else
                {
                    r.Add(d);
                }
                r.Add(e);
            }
            else
            {
                if (isneg == true)
                {
                    r.Add(-e);
                }
                else
                {
                    r.Add(e);
                }
                r.Add(d);
            }
            return r;
        }
    }
}
