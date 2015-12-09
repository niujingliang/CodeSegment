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
            //读写锁
            using (ReaderWriterLock.GetReadLock())
            {
                /*
                */
            }

            //依赖解析
            var userType = typeof(User);
            var drCurrent = DependencyResolver.Current;
            var drCache = DependencyResolver.CurrentCache;
            var user = drCache.GetService(userType);
            var user1 = drCache.GetService(userType);
            Console.WriteLine(user == user1);//true;

            Console.ReadKey();
        }
    }
}
