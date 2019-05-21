using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanToInteger
{
    public static class Singleton<T> where T:class ,new()
    {
        private static T _Instance;
        private static Object _obj = new object();
        public static T GetInstance()
        {
            if (_Instance != null) return _Instance;
             lock(_obj)
            {
                if(_Instance == null)
                {
                    // var temp = Activator.CreateInstance<T>();
                    // System.Threading.Interlocked.Exchange(ref _Instance, temp);
                    var temp = Activator.CreateInstance<T>();
                    System.Threading.Interlocked.Exchange(ref _Instance, temp);
                }
            }
            return _Instance;
        }
    }


   
    class Program
    {
        public static object _obj = new object();
        public static void Test()
        {
            System.Threading.Thread.Sleep(1);
                 Console.WriteLine("task 0 completed "+DateTime.Now);
        }
        static void Main(string[] args)
        {
            string s = "zudfweormatjycujjirzjpyrmaxurectxrtqedmmgergwdvjmjtstdhcihacqnothgttgqfywcpgnuvwglvfiuxteopoyizgehkwuvvkqxbnufkcbodlhdmbqyghkojrgokpwdhtdrwmvdegwycecrgjvuexlguayzcammupgeskrvpthrmwqaqsdcgycdupykppiyhwzwcplivjnnvwhqkkxildtyjltklcokcrgqnnwzzeuqioyahqpuskkpbxhvzvqyhlegmoviogzwuiqahiouhnecjwysmtarjjdjqdrkljawzasriouuiqkcwwqsxifbndjmyprdozhwaoibpqrthpcjphgsfbeqrqqoqiqqdicvybzxhklehzzapbvcyleljawowluqgxxwlrymzojshlwkmzwpixgfjljkmwdtjeabgyrpbqyyykmoaqdambpkyyvukalbrzoyoufjqeftniddsfqnilxlplselqatdgjziphvrbokofvuerpsvqmzakbyzxtxvyanvjpfyvyiivqusfrsufjanmfibgrkwtiuoykiavpbqeyfsuteuxxjiyxvlvgmehycdvxdorpepmsinvmyzeqeiikajopqedyopirmhymozernxzaueljjrhcsofwyddkpnvcvzixdjknikyhzmstvbducjcoyoeoaqruuewclzqqqxzpgykrkygxnmlsrjudoaejxkipkgmcoqtxhelvsizgdwdyjwuumazxfstoaxeqqxoqezakdqjwpkrbldpcbbxexquqrznavcrprnydufsidakvrpuzgfisdxreldbqfizngtrilnbqboxwmwienlkmmiuifrvytukcqcpeqdwwucymgvyrektsnfijdcdoawbcwkkjkqwzffnuqituihjaklvthulmcjrhqcyzvekzqlxgddjoir";
        
            if (string.IsNullOrEmpty(s)) return ;
            if (s.Length == 1) return ;
            string result = s[0].ToString();
            int len = 0;
            int temp;
            while (len <= s.Length - 1)
            {
                temp = s.LastIndexOf(s[len]);
                string str = s.Substring(len, temp + 1 - len);
                while (temp != -1 && temp != len)
                {

                    string left = str.Substring(0, str.Length / 2);
                    string right;
                    if (str.Length % 2 == 1)
                        right = str.Substring(str.Length / 2 + 1, str.Length / 2);
                    else
                        right = str.Substring(str.Length / 2, str.Length / 2);

                    int length = left.Length;
                    int i = 0;
                    while(i<length)
                    {
                        if (i == (length))
                        {
                            if (result.Length <= str.Length)
                                result = str;
                        }
                        if (left[i] != right[length - 1 - i])
                            break;
                        i++;                         
                       
                    }

                    if (result.Length <= str.Length)
                        result = str;
                    str = str.Substring(0, str.Length - 1);
                    temp = str.LastIndexOf(s[len]);
                }
                len++;
            }
            Console.ReadKey();
        }
    }
}
