using AsyncCalculatorClient.AsyncCalculatorService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncCalculatorService
{
    class Program
    {
        static void Main(string[] args)
        {
            var callback = new CallbackHandler();
            var instanceContext = new InstanceContext(callback);
            var asyncCalculatorService = new AsyncCalculatorServiceClient(instanceContext);

            // Test sync and async methods
            
            Console.WriteLine("Invoking f1");
            asyncCalculatorService.Print("Client1");
            Thread.Sleep(10);
            Console.WriteLine("f1 done");
            Console.WriteLine("Invoking f2");
            asyncCalculatorService.Print2("Client2");
            Thread.Sleep(10);
            Console.WriteLine("f2 done");
            Console.WriteLine("Invoking f1");
            asyncCalculatorService.Print("Client1");
            Thread.Sleep(10);
            Console.WriteLine("f1 done");

            Console.WriteLine("Press any button to clear console and continue");
            Console.ReadKey();
            Console.Clear();


            List<int> factorialValues = new List<int> { 10, 3, 15, 4, 16 };
            factorialValues.ForEach(value =>
            {
                Console.WriteLine("Factorial({0}) invoking...", value);
                asyncCalculatorService.Factorial(value);
            });

            Console.WriteLine("Press any to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }

    class CallbackHandler : IAsyncCalculatorServiceCallback
    {
        public void FactorialCallback(int result)
        {
            Console.WriteLine("Result of factorial is: {0}", result);
        }

        public void WaitForSecondsCallback(string result)
        {
            Console.WriteLine("Result of method is: {0}", result);
        }
    }
}
