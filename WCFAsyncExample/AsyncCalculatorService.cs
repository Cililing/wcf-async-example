using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace WCFAsyncExample
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class AsyncCalculatorService : IAsyncCalculatorService
    {
        IAsyncCalculatorServiceHandler _callback;

        public AsyncCalculatorService()
        {
            _callback = OperationContext.Current.GetCallbackChannel
                <IAsyncCalculatorServiceHandler>();
        }
        public void Factorial(int n)
        {
            Console.WriteLine("Factorial of {0} called", n);
            Thread.Sleep(1000);
            var result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            Console.WriteLine("Factorial of {0} is {1}", n, result);
            _callback.FactorialCallback(result);
        }

        public void WaitForSeconds(int sec)
        {
            Console.WriteLine("WaitForSeconds called");
            Thread.Sleep(1000);
            _callback.WaitForSecondsCallback("Finish with positive result");
        }
        
        public void Print(string s1)
        {
            Console.WriteLine("{0}: start [{1}]", s1, GetCurrentMethod());
            Thread.Sleep(1000);
            Console.WriteLine("{0}: stop [{1}]", s1, GetCurrentMethod());
        }

        public void Print2(string s2)
        {
            Console.WriteLine("{0}: start [{1}]", s2, GetCurrentMethod());
            Thread.Sleep(2000);
            Console.WriteLine("{0}: stop [{1}]", s2, GetCurrentMethod());
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private string GetCurrentMethod()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }
    }
}
