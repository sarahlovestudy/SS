using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCTest
{
    public class BaseResource : IDisposable
    {
        private IntPtr handle;//非托管
         
        private bool isDisposed = false;
        public BaseResource() { }

        public void Dispose()
        {
            Dispose();
            Console.WriteLine("Dispose");
        }
    }
}
