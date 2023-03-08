using System;
using System.Threading.Tasks;
using Grpc.Net.Client;

namespace gRPCServiceClient
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            Console.Write("Enter your first name: ");
            var firstName = Console.ReadLine();
            
            Console.Write("Enter your last name: ");
            var lastName = Console.ReadLine();
            
            using var channel = GrpcChannel.ForAddress("http://localhost:5000");
            var client =  new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                new HelloRequest {  FirstName = firstName,  LastName = lastName});
            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}