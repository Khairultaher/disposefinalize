using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposeFinalizeDotNet
{
    class Program
    {
        static void Main(string[] args)
        {

            DisposableTest obj = new DisposableTest();
            obj.Print("Good Morning...");
            //obj.Dispose();
            obj = null;
            Console.WriteLine("Assigned null... Object is destructing..");

            Console.ReadLine();
        }
    }
    public class DisposableTest : IDisposable
    {
        private bool isdisposed = false;

        public DisposableTest()
        {
            Console.WriteLine("DisposableTest object is created..");
        }
        public void Print(string message)
        {
            Console.WriteLine("Hello " + message);
        }
        ~DisposableTest()
        {
            Console.WriteLine("Destructor/Finalize of DisposableTest");
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected void Dispose(bool dispose)
        {
            if (!isdisposed)
            {
                if (dispose)
                {
                    // to cleanup managed objects 
                    Console.WriteLine("to cleanup managed objects");
                }
                // To cleanup unmanaged resources/objects 
                Console.WriteLine("To cleanup unmanaged resources/objects");
                isdisposed = true;
            }
        }
    }
}
