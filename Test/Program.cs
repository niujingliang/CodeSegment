using CodeSegment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        public class User { }
        static void Main(string[] args)
        {
            //ReaderWriterLock  读写锁
            using (ReaderWriterLock.GetReadLock())
            {
                /*
                */
            }

            //DependencyResolver  依赖解析
            var userType = typeof(User);
            var drCurrent = DependencyResolver.Current;
            var userA = drCurrent.GetService(userType);
            var userB = drCurrent.GetService(userType);
            Console.WriteLine(userA == userB);
            Console.WriteLine("================");
            var drCache = DependencyResolver.CurrentCache;
            var user = drCache.GetService(userType);
            var user1 = drCache.GetService(userType);
            Console.WriteLine(user == user1);//true;

            //SingleEntryGate
            SingleEntryGate seg = new SingleEntryGate();
            if (seg.TryEnter())
            {
                //第一次进入
            }

            Console.ReadKey();
        }
    }
}
