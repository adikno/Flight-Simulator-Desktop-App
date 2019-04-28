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
{   /*
     * This class responsible of communication with the server, by injecting the prefferd telnet client.
     */
    class ConnectTelnetClient : ITelnetClient


    {
        /// <summary>
        /// The stream
        /// </summary>
        private static NetworkStream stream;

        private bool connected = false;


        /// <summary>
        /// The writer
        /// </summary>
        private static BinaryWriter writer;

        TcpClient client;
        IPEndPoint ep;
        /**this function connct to tehlnet client
         */
        public void connect(string ip, int port)
        {

            ep = new IPEndPoint(IPAddress.Parse(ip), port);
            client = new TcpClient();
            client.Connect(ep);
            connected = true;
        }
        /**this function disconnect the clinet
         */
        public void disconnect()
        {
            client.Close();
        }

        public string read()
        {

            throw new NotImplementedException();
        }
        /**this function whrite commands to the simulator.
         */
        public void write(string command)
        {
            if (connected)
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
}
