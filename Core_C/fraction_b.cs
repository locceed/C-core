using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_C
{
    /// <summary>
    /// 作为基类。
    /// </summary>
    class fraction_b
    {
        public double upper = 0;
        public double lower = 0;
        public fraction_b(double num)
        {
            double a = 0;
            do
            {
                a++;
            }
            while (!((num * a) % 1 == 0));
            upper = num * a;
            lower = a;
            sim();
        }
        public fraction_b(int num)
        {
            double a = 0;
            do
            {
                a++;
            }
            while (!((num * a) % 1 == 0));
            upper = num * a;
            lower = a;
            sim();
        }

        public fraction_b(double upper_,double lower_)
        {
            upper = upper_;
            lower = lower_;
            sim();
        }
        public double value()
        {
            return (upper / lower);
        }
        public void sim()
        {
            double n = 1;
            do
            {
                if ((upper * n / lower) % 1 == 0)
                {
                    upper = upper * n / lower;
                    lower = n;
                }
                else
                {
                    n++;
                }
            }
            while (n < lower);
        }
        public fraction_b sim1()
        {
            double n = 1;
            double upper_ = upper;
            double lower_ = lower;
            do
            {
                if ((upper_ * n / lower_) % 1 == 0)
                {
                    upper_ = upper_ * n / lower_;
                    lower_ = n;
                }
                else
                {
                    n++;
                }
            }
            while (n < lower_);
            return new fraction_b(upper_, lower_);
        }
        static public fraction_b operator +(fraction_b a, fraction_b b)
        {
            return new fraction_b((a.upper * b.lower) + (a.lower * b.upper), a.lower * b.lower).sim1();

        }
        static public fraction_b operator -(fraction_b a, fraction_b b)
        {
            return new fraction_b((a.upper * b.lower) - (a.lower * b.upper), a.lower * b.lower).sim1();
        }
        static public fraction_b operator *(fraction_b a, fraction_b b)
        {
            return new fraction_b(a.upper * b.upper, a.lower * b.lower).sim1();
        }
        static public fraction_b operator /(fraction_b a, fraction_b b)
        {
            return new fraction_b(a.upper * b.lower, a.lower * b.upper).sim1();
        }
    }
}
