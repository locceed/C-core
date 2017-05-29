using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_C
{
    class fraction_b
    {
        public long upper = 0;
        public long lower = 0;
        public fraction_b(double num)
        {
            long a = 0;
            do
            {
                a++;
            }
            while (!((num * a) % 1 == 0));
            upper = (long)(num * a);
            lower = a;
        }
        public fraction_b(long upper_,long lower_)
        {
            upper = upper_;
            lower = lower_;
        }
        public double value()
        {
            return (upper / lower);
        }
        public void sim()
        {
            long n = 1;
            do
            {
                if ((Convert.ToDouble(upper) * Convert.ToDouble(n) / Convert.ToDouble(lower)) % 1 == 0)
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
        static public fraction_b operator +(fraction_b a, fraction_b b)
        {
            return new fraction_b((a.upper * b.lower) + (a.lower * b.upper), a.lower * b.lower);
        }
        static public fraction_b operator -(fraction_b a, fraction_b b)
        {
            return new fraction_b((a.upper * b.lower) - (a.lower * b.upper), a.lower * b.lower);
        }
        static public fraction_b operator *(fraction_b a, fraction_b b)
        {
            return new fraction_b(a.upper * b.upper, a.lower * b.lower);
        }
        static public fraction_b operator /(fraction_b a, fraction_b b)
        {
            return new fraction_b(a.upper * b.lower, a.lower * b.upper);
        }
    }
}
