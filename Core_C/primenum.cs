using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_C
{
    class primenum
    {
        public static bool isprime(long n)//判断一个数n是否为质数
　       {
            long m = (long)Math.Sqrt(n);
            for (long i = 2; i <= m; i++)
            {
                if (n % i == 0 && i != n) { return false; }
            }
            return true;
        }
        public static List<long> get(long max)//输出比指定的数小的质数
        {
            List<long> temp = new List<long>();
            for (long i = 2; i <= max; i++)
　           {
                if (isprime(i))
                {
                    temp.Add(i);
                }
            }
            return temp;
        }
        public static List<long> factorize(long n)//分解质因数,在大于int32时可能有bug
        {
            List<long> temp = new List<long>();
            for (long x = 2; x <= n; x++) //注意: n是变化的.
            {
                if (n % x == 0)
                {
                    n /= x;
                    temp.Add(x);
                    x--;//防止该整数有多个相同质因数最终只能输出一个的情况
                }
            }
            return temp;
        }
        
    }
}
