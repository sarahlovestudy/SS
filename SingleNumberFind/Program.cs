using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleNumberFind
{
    class Program
    {
        static void Main(string[] args)
        {

            int x = 2, y = 1;
            int z = x ^ y;
            int[] nums = new int[5] { 4, 1, 2, 1, 2 };
            IEnumerable<int> j;
            int result;
            foreach (int value in nums)
            {
                j = nums.Where(p => p.Equals(value));
                int count = j.Count<int>();
                if (count == 1)
                    result = value;
            }
          


            int num =  FindSingleNumber(nums);
        }
        static int  FindSingleNumber(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
       
                if (!nums.Contains(nums[i]))
                    return nums[i];
            return 0;
        }
    }
}
