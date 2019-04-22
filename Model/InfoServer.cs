using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    public class InfoServer : INotifyPropertyChanged
    {


        private TcpListener listener;
        TcpClient client;
        private BinaryReader reader;
        private bool isConnected;
        private double lonModel;
        private double latModel;
        public event PropertyChangedEventHandler PropertyChanged;

       
        

        public InfoServer()
        {
            
        }
        public double LonModel {
            get { return lonModel; }

            set
            {
                lonModel = value;
                NotifyPropertyChanged("LonModel");
            }
        }
        public double LatModel
        {
            get { return latModel; }

            set
            {
                latModel = value;
                NotifyPropertyChanged("LatModel");
            }
        }
        private void NotifyPropertyChanged(string v)
        {
           if (PropertyChanged != null){
                this.PropertyChanged(this,new PropertyChangedEventArgs(v));
            }
        }

        public void Start(int port)
        {
            IPEndPoint ep = new
            IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            listener = new TcpListener(ep);
            listener.Start();
            client = listener.AcceptTcpClient();
            int i = 0;
            new Task(delegate() {
                while (true)
                {
                    i++;
                    Console.WriteLine(i);
                    /*try
                    {
                        using (NetworkStream stream = client.GetStream())
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            string commandLine = reader.ReadLine();
                            ExecuteCommand(commandLine);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        break;
                    }*/
                    reader = new BinaryReader(client.GetStream());
                

                    string input = ""; // input will be stored here
                    char s;
                    while ((s = reader.ReadChar()) != '\n') {
                        input += s;
                    } // read untill \n
                    ExecuteCommand(input);
            }
            }).Start();
        }

        private void ExecuteCommand(string commandLine)
        {
            string[] args = commandLine.Split(',');
            var format = new NumberFormatInfo();
            format.NegativeSign = "-";
            format.NumberDecimalSeparator = ".";

            LonModel = Double.Parse(args[0], format);
            LatModel = Double.Parse(args[1], format);
        }

        public void Stop()
        {
            client.Close();
            listener.Stop();
        }
    }
}

