using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_C
{
    /// <summary>
    /// 作为基类，格式  (multiplier) * x^exponent^-1  (x,exponent,multiplier为整数)
    /// </summary>
    class radical_b
    {
        public double multiplier = 1;
        public double x = 0;
        public double exponent = 1;
        public radical_b(double times, double n, double exp)
        {
            ///化简n(小数)//暂缓
            if (n % 1 != 0)
            {
                multiplier = times;
                x = n;
                exponent = exp;
                return;
            }
            ///化简exp
            double c = 2;
            double ex = 1;
            do
            {
                double var = Math.Log(n, c);
                if (var == 1)
                {
                    break;
                }
                if (var % 1 <= 0.00000000001 || var % 1 >= 0.99999999999) //容错
                {
                    n = c;
                    ex *= Math.Round(var);//修正
                }
                else
                {
                    c++;
                }
            }
            while (Math.Log(n, c) <= n);
            ///赋值
            fraction_b e = new fraction_b(ex, exp);
            exp = e.lower;
            n = Math.Pow(n, e.upper);
            ///化简n
            c = 2;//重用
            do
            {
                if (n % Math.Pow(c, exp) == 0)
                {
                    n /= Math.Pow(c, exp);
                    times *= c;
                }
                else
                {
                    c++;
                }
            }
            while (Math.Pow(c, exp) < n);
            multiplier = times;
            x = n;
            exponent = exp;
            //return times + "*" + "(" + exp + ")" + n + "=" + times * Math.Pow(n, ((double)1)/exp);
        }
        public void sim(double times, double n, double exp)
        {
            ///化简exp
            double c = 2;
            double ex = 1;
            do
            {
                double var = Math.Log(n, c);
                if (var == 1)
                {
                    break;
                }
                if (var % 1 <= 0.00000000001 || var % 1 >= 0.99999999999) //容错
                {
                    n = c;
                    ex *= Math.Round(var);//修正
                }
                else
                {
                    c++;
                }
            }
            while (Math.Log(n, c) <= n);
            ///赋值
            fraction_b e = new fraction_b(ex, exp);
            exp = e.lower;
            n = Math.Pow(n, e.upper);
            ///化简n
            c = 2;//重用
            do
            {
                if (n % Math.Pow(c, exp) == 0)
                {
                    n /= Math.Pow(c, exp);
                    times *= c;
                }
                else
                {
                    c++;
                }
            }
            while (Math.Pow(c, exp) < n);
            multiplier = times;
            x = n;
            exponent = exp;
            //return times + "*" + "(" + exp + ")" + n + "=" + times * Math.Pow(n, ((double)1)/exp);
        }
        public double value()
        {
            return multiplier * Math.Pow(x, ((double)1) / exponent);
        }
        static public radical_b operator *(radical_b a, radical_b b)
        {
            return new radical_b(a.multiplier * b.multiplier, Math.Pow(a.x, b.exponent) * Math.Pow(b.x, a.exponent), a.exponent * b.exponent);
        }
        static public radical_b operator /(radical_b a, radical_b b)
        {
            return new radical_b(a.multiplier / b.multiplier, Math.Pow(a.x, b.exponent) / Math.Pow(b.x, a.exponent), a.exponent * b.exponent);
        }
    }
}
