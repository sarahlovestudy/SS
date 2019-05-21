using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanToInteger
{
    class Class1
    {
        enum Roman
        {
            I=1,
            V=5,
            X=10,
            L=50,
            C=100,
            D=500,
            M=1000
        }
        static  public int RomanToInt(string s)
        { 
            int sum = (int)(Roman)Enum.Parse(typeof(Roman), s[0].ToString());
            int x,y;
            for(int i=1;i< s.Length; i++)
            {
                x = (int)(Roman)Enum.Parse(typeof(Roman), s[i-1].ToString());
                y = (int)(Roman)Enum.Parse(typeof(Roman), s[i].ToString());
                if (x >= y)
                    sum =sum + y;
                else
                    sum =sum - y;
            }
            return sum;
        }
      
    }
    
}
