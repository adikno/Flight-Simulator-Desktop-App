using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class ConnectTelnetClient : ITelnetClient


    {
        /// <summary>
        /// The stream
        /// </summary>
        private static NetworkStream stream;

        /// <summary>
        /// The writer
        /// </summary>
        private static BinaryWriter writer;

        TcpClient client;
        IPEndPoint ep;
        public void connect(string ip, int port)
        {
        
            ep = new IPEndPoint(IPAddress.Parse(ip), port);
            client = new TcpClient();
            client.Connect(ep);            Globals.connected = true;
        }

        public void disconnect()
        {
            client.Close();
        }

        public string read()
        {

            throw new NotImplementedException();
        }

        public void write(string command)
        {

            command = command + "\r\n";
            if (client == null)
            {
                Console.WriteLine("Client not connected - can't write");
                return;
            }
            NetworkStream nwStream = client.GetStream();
            byte[] byteToSend = ASCIIEncoding.ASCII.GetBytes(command);
            nwStream.Write(byteToSend, 0, byteToSend.Length);

        }
    }
}
