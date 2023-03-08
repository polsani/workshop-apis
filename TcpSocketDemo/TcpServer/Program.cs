using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TcpServer
{
    internal static class Program
    {
        private const int PORT = 3000;
        private const string IP_ADDRESS = "127.0.0.1";

        private static void Main(string[] args)
        {
            try    
            {    
                var ipAddress = IPAddress.Parse(IP_ADDRESS);    
                var listener = new TcpListener(ipAddress, PORT);
                
                listener.Start();    
                
                Console.WriteLine($"Server is Running on Port: {PORT}");    
                Console.WriteLine("Local endpoint:" + listener.LocalEndpoint);    
                Console.WriteLine("Waiting for Connections...");    
                
                var socket = listener.AcceptSocket();    
                
                Console.WriteLine("Connection Accepted From:" + socket.RemoteEndPoint);    
                
                var buffer = new byte[100];    
                var receivedLenght = socket.Receive(buffer);
                Console.WriteLine($"Received message from {socket.RemoteEndPoint}");

                for (var i = 0; i < receivedLenght; i++)    
                {    
                    Console.Write(Convert.ToChar(buffer[i]));    
                }
                
                var encoding = new UTF8Encoding();    
                socket.Send(encoding.GetBytes("Automatic Message: String Received byte server !"));    
                Console.WriteLine("\nAutomatic Message is Sent");    
                socket.Close();    
                listener.Stop();    
                
                Console.ReadLine();    
            }    
            catch (Exception ex)    
            {    
                Console.WriteLine("Error: " + ex.StackTrace);    
            } 
        }
    }
}