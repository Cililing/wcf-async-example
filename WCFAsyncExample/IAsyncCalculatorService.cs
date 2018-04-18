using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFAsyncExample
{
    [ServiceContract(CallbackContract = typeof(IAsyncCalculatorServiceHandler))]
    public interface IAsyncCalculatorService
    {
        [OperationContract]
        void Print(String s1);

        [OperationContract(IsOneWay = true)]
        void Print2(String s2);
        
        [OperationContract(IsOneWay = true)]
        void Factorial(int n);
        [OperationContract(IsOneWay = true)]
        void WaitForSeconds(int sec);
    }
    
}
