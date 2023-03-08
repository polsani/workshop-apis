using System.ServiceModel;
using SoapServiceServer.Models;

namespace SoapServiceServer.ServiceContracts
{
    [ServiceContract]
    public interface ISampleService
    {
        [OperationContract]
        string Greeting(RequestModel model);
    }
}