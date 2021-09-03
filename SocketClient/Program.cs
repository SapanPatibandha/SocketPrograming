using System;
using System.Net;
using System.Net.Sockets;

namespace SocketClient
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Press Enter to Connect");
            Console.ReadLine();


            var endpoint = new IPEndPoint(IPAddress.Loopback, 9000);
            var socket = new Socket(endpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(endpoint);
            var networkStream = new NetworkStream(socket, true);

            var msg = "This is message";

            var buffer = System.Text.Encoding.UTF8.GetBytes(msg);

            networkStream.Write(buffer, 0, buffer.Length);
            var response = new byte[1024];

            var bytesRead = networkStream.Read(response, 0, response.Length);

            var responseStr = System.Text.Encoding.UTF8.GetString(response);

            Console.WriteLine($"Received : {responseStr}");

            Console.ReadLine();
        }
    }
}
