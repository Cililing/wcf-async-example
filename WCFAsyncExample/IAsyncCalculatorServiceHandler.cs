using System.ServiceModel;

namespace WCFAsyncExample
{
    public interface IAsyncCalculatorServiceHandler
    {
        [OperationContract(IsOneWay = true)]
        void FactorialCallback(int result);
        [OperationContract(IsOneWay = true)]
        void WaitForSecondsCallback(string result);
    }
}