using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCTest
{
    class Program
    {
        static void Main(string[] args)
        {
            

            int N=0;
            for(int x=1;N<=8;x--, N++)
            {
                if (N % 2 == 1)
                {
                    x += N;
                    N += 2 * x;
                }

            }

              return;
        }
    }
}
