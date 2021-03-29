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
            obj.Print(DisposableTest.objectcount);
            obj.Dispose();
            obj = null;
            Console.WriteLine("Assigned null... Object is destructing..");

            DisposableTest obj2 = new DisposableTest();
            obj2.Print(DisposableTest.objectcount);
            //obj2.Dispose();
            obj2 = null;
            Console.WriteLine("Assigned null... Object is destructing..");

            Console.ReadLine();
        }
    }
    public class DisposableTest : IDisposable
    {
        private bool disposed = false;
        public static int objectcount = 0;
        public DisposableTest()
        {
            objectcount += 1;
            Console.WriteLine("DisposableTest object is created..");
        }
        public void Print(int objno)
        {
            Console.WriteLine("Unmanaged Resource Count: " + objno.ToString());
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
        protected void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // to cleanup managed objects like: _context.Dispose();
                    Console.WriteLine("to cleanup managed objects");
                }
                // To cleanup unmanaged resources/objects 
                Console.WriteLine("To cleanup unmanaged resources/objects");
                objectcount -= 1;
                Console.WriteLine("Unmanaged Resource Count: " + objectcount.ToString());
                disposed = true;
            }
        }
    }
}
