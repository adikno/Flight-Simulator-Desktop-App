using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using FlightSimulator.Views.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        private string _ButtonText;
        public string ButtonText
        {
            get { return _ButtonText ?? (_ButtonText = "Connect"); }
            set
            {
                _ButtonText = value;
                NotifyPropertyChanged("ButtonText");
            }
        }
        public double Lon
        {
            get { return server.LonModel; }
            
        }

        public double Lat
        {
            get { return server.LatModel; }
            
        }
        private InfoServer server;
        public FlightBoardViewModel(InfoServer server1)
        {
            server = server1;
            Globals.telnetClient = new ConnectTelnetClient();
            server.PropertyChanged += m_PropertyChanged;

        }
        private void m_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.Equals("lat"))
            {
                NotifyPropertyChanged("Lat");
            }
            else
            {
                NotifyPropertyChanged("Lon");
            }
        }

        #region Commands
        #region ClickCommand
        private ICommand _settingCommand;
        public ICommand SettingCommand
        {
            get
            {
                return _settingCommand?? (_settingCommand = new CommandHandler(() => OnClick()));
            }
        }
        private void OnClick()
        {
            Window win2 = new Setting();
            win2.Show();
        }
        #endregion

        #region ConnectCommand
        private ICommand _connectCommand;
        public ICommand ConnectCommand
        {
            get
            {
                return _connectCommand ?? (_connectCommand = new CommandHandler(() => OnConnect()));
            }
        }
        private void OnConnect()
        {
            if (!server.IsConnected)
            {
                int infoPort = Properties.Settings.Default.FlightInfoPort;
               
                server.Start(infoPort);

                string IP = Properties.Settings.Default.FlightServerIP;
                int port = Properties.Settings.Default.FlightCommandPort;
                while (!server.IsConnected)
                {
       
                } 
               
                Globals.telnetClient.connect(IP, port);
                ButtonText = "Disconennect";
                
            }
            else
            {
           
                server.Stop();
                Globals.telnetClient.disconnect();
            }

        }
        #endregion
        #endregion
    }
}
