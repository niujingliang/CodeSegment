using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeSegment
{
    public class SingleEntryGate
    {
        private const int NotEntered = 0;
        private const int Entered = 1;

        private int _status;

        // 如果是第一次执行，则返回true；否则返回false
        public bool TryEnter()
        {
            int oldStatus = Interlocked.Exchange(ref _status, Entered);
            return (oldStatus == NotEntered);
        }
    }
}
