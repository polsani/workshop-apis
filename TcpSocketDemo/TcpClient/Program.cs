using System;
using System.Text;

namespace TcpClient
{
    internal static class Program
    {
        private const int PORT = 3000;
        private const string IP_ADDRESS = "127.0.0.1";

        private static void Main(string[] args)
        {
            try    
            {    
                var client = new System.Net.Sockets.TcpClient();    
                Console.WriteLine($"Connecting to {IP_ADDRESS}:{PORT}...");
                
                client.Connect(IP_ADDRESS, PORT);    
                Console.WriteLine("Connected");
                Console.WriteLine("Enter the String you want to send ");    
                var input = Console.ReadLine();    
                var stream = client.GetStream();    
                var encoding = new UTF8Encoding();
                
                if (input != null)
                {
                    var sendingBuffer = encoding.GetBytes(input);    
                    Console.WriteLine("Sending message ...");    
                    stream.Write(sendingBuffer, 0, sendingBuffer.Length);
                }

                var receivedBuffer = new byte[100];    
                var lenght = stream.Read(receivedBuffer, 0, 100);    
                for (var i = 0; i < lenght; i++)    
                {    
                    Console.Write(Convert.ToChar(receivedBuffer[i]));    
                }    
    
                client.Close();    
                Console.ReadLine();    
            }    
            catch (Exception ex)    
            {    
                Console.WriteLine("Error: " + ex.StackTrace);    
            }    
        }
    }
}