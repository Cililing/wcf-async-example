using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WCFAsyncExample;

namespace AsynCalcServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost basicHost = new ServiceHost(typeof(AsyncCalculatorService));
            
            try
            {
                ServiceEndpoint endpoint = basicHost.Description.Endpoints.Find(typeof(IAsyncCalculatorService));
                basicHost.Open();
                Console.WriteLine("Service is running. Press any button to finish.");
                Console.ReadKey();
                basicHost.Close();
            }
            catch (CommunicationException exception)
            {
                Console.WriteLine("Exception occured: {0}", exception);
                basicHost.Abort();
            }
        }
    }
}
