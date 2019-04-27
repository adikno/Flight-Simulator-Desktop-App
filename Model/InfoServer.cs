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
        private bool isConnected = false;
        private double lonModel = 0;
        private double latModel = 0;
        public event PropertyChangedEventHandler PropertyChanged;
        double EPSILON = 0.000025;
        bool isFirstTime = true;




        public InfoServer()
        {
           
        }
        public bool IsConnected
        {
            get { return isConnected; }
            set
            {
                isConnected = value;
            }
        }
        public double LonModel {
            get { return lonModel; }

            set
            {
                lonModel = value;
                NotifyPropertyChanged("lon");
            }
        }
        public double LatModel
        {
            get { return latModel; }

            set
            {
                latModel = value;
                NotifyPropertyChanged("lat");
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
            IsConnected = true;
            int i = 0;
            new Task(delegate() {
                while (IsConnected)
                {
                    i++;
       
                    reader = new BinaryReader(client.GetStream());
                

                    string input = ""; // input will be stored here
                    char s;

                    while ((s = reader.ReadChar()) != '\n' && IsConnected) {
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
            if (isFirstTime)
            {
                lonModel = Double.Parse(args[0], format);
                latModel = Double.Parse(args[1], format);
                isFirstTime = false;
            }
           
            else if ((Convert.ToDouble(args[0]) < Convert.ToDouble(LonModel) - EPSILON || Convert.ToDouble(args[0]) > Convert.ToDouble(LonModel) + EPSILON) &&
                           (Convert.ToDouble(args[1]) < Convert.ToDouble(LatModel) - EPSILON || Convert.ToDouble(args[1]) > Convert.ToDouble(LatModel) + EPSILON))
            {
                LonModel = Double.Parse(args[0], format);
                LatModel = Double.Parse(args[1], format);
            }
            Thread.Sleep(100);

        }
        public void Stop()
        {
            IsConnected = false;
            client.Close();
            listener.Stop();
        }
    }
}

