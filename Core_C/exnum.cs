using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_C
{
    class exnum
    {
        public fraction_b fra_ = new fraction_b(0);
        public List<radical> rad_ = new List<radical>();
        public exnum (double n)
        {
            fra_ += new fraction_b(n);
        }
        public exnum (fraction_b n)
        {
            fra_ = n;
        }
        public exnum (radical n)
        {
            rad_.Add(n);
        }
        public double approx_value()
        {
            double n = 0;
            n += fra_.value();
            foreach (radical x in rad_)
            {
                n += x.getvalue();
            }
            return n;
        }
        static public exnum operator + (exnum a,exnum b)
        {
            exnum c = new exnum(a.fra_ + b.fra_);
            List<radical> rad_c = new List<radical>();
            foreach(radical x in a.rad_)
            {
                rad_c.Add(x);
            }
            foreach (radical x in b.rad_)
            {
                rad_c.Add(x);
            }
            c.rad_ = rad_c;
            return c;
        }
    }
}
