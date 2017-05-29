using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_C
{
    class fraction//分数
    {
        ArrayList numerator = new ArrayList();
        ArrayList denominator = new ArrayList();
        public fraction(double num)
        {
            long a = 0;
            do
            {
                a++;
            }
            while (!((num * a) % 1 == 0));
            numerator.Add(num * a);
            denominator.Add(a);
        }
        public double getvalue()
        {
            double numerator_ = 0;
            double denominator_ = 0;
            foreach(object x in numerator)
            {
                numerator_ += Convert.ToDouble(x);
            }
            foreach (object x in denominator)
            {
                denominator_ += Convert.ToDouble(x);
            }
            return (numerator_ / denominator_);
        } 

        static public fraction operator + (fraction a,fraction b)
        {
            return new fraction(a.getvalue() + b.getvalue());
        }
        static public fraction operator - (fraction a, fraction b)
        {
            return new fraction(a.getvalue() - b.getvalue());
        }
        static public fraction operator * (fraction a, fraction b)
        {
            return new fraction(a.getvalue() * b.getvalue());
        }
        static public fraction operator / (fraction a, fraction b)
        {
            return new fraction(a.getvalue() / b.getvalue());
        }
    }
}
