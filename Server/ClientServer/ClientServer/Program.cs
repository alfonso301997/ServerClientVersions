using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ClientServer
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = Dns.GetHostEntry("localhost").AddressList[0];
            TcpListener server = new TcpListener(ip, 8080);
            TcpClient client = default(TcpClient);

            try
            {
                server.Start();
                Console.WriteLine("Server Started!...");
                
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.ToString());
                Console.Read();

            }
            while(true)
                {
                client = server.AcceptTcpClient();
                byte[] receivedbuffer = new byte[100];
                NetworkStream stream = client.GetStream();
                stream.Read(receivedbuffer, 0  , receivedbuffer.Length);
                StringBuilder msg = new StringBuilder();

                foreach (byte b in receivedbuffer)
                {
                    if (b.Equals(00))
                    {
                        break;
                    }
                    else
                    {
                        msg.Append(Convert.ToChar(b).ToString());
                    }
                }
                Console.WriteLine(msg.ToString() + msg.Length);
                
            }
        }
    }
}
