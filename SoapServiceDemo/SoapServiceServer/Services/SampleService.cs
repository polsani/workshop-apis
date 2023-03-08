using SoapServiceServer.Models;
using SoapServiceServer.ServiceContracts;

namespace SoapServiceServer.Services
{
    public class SampleService: ISampleService
    {
        public string Greeting(RequestModel model)
        {
            return $"Hello {model.Name}. A greeting e-mail has been sent to {model.Email}";
        }
    }
}